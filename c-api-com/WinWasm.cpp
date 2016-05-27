/*
* Copyright 2016 WebAssembly Community Group participants
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

//===============================
// Binaryen C API implementation
//===============================

#include "WinWasm.h"
#include "pass.h"
#include "shell-interface.h"

using namespace wasm;

extern "C" {long ComCall(const char *lib, const char *func, ModuleInstance::LiteralList& arguments, std::vector<WasmType> params, WasmType retType, Literal *retVal); }

struct ShellExternalInterfaceC : ShellExternalInterface
{
	ShellExternalInterfaceC() : ShellExternalInterface()
	{
		//CoInitialize(NULL);
	}

	~ShellExternalInterfaceC()
	{
		//CoUninitialize();
	}

	Literal callImport(Import *import, ModuleInstance::LiteralList& arguments) override {
		if (import->module == SPECTEST && import->base == PRINT) {
			for (auto argument : arguments) {
				std::cout << argument << '\n';
			}
			return Literal();
		}
		else if (import->module == ENV && import->base == EXIT) {
			// XXX hack for torture tests
			std::cout << "exit()\n";
			throw ExitException();
		}
#if 1
		else
		{
			Literal retVal;
			long hr = ComCall(import->module.str, import->base.str, arguments, import->type->params, import->type->result, &retVal);
			return hr ? Literal(hr) : retVal;
		}
#else
		std::cout << "callImport " << import->name.str << "\n";
		abort();
#endif
	}
};

static Literal BinaryenCallExport(Module* wasm, Name entry) {
	std::unique_ptr<ShellExternalInterfaceC> interface;
	std::unique_ptr<ModuleInstance> instance;
	Literal retVal;
	if (wasm) {
		interface = make_unique<ShellExternalInterfaceC>();
		instance = make_unique<ModuleInstance>(*wasm, interface.get());
		if (entry.is()) {
			Function* function = wasm->getFunction(entry);
			if (!function) {
				std::cerr << "Unknown entry " << entry << std::endl;
			}
			else if (function->params.size() != 0) {
				std::cerr << "Parameter count not zero: " << function->params.size() << std::endl;
			}
			else {
				ModuleInstance::LiteralList arguments;
				for (WasmType param : function->params) {
					arguments.push_back(Literal(param));
				}
				try {
					retVal = instance->callExport(entry, arguments);
				}
				catch (ExitException&) {
				}
			}
		}
	}
	return retVal;
}

extern "C" {
#include <Windows.h>
	char *BinaryenLiteralPrint(char *buf, size_t lbuf, struct BinaryenLiteral literal)
	{
		std::ostringstream obuf;
		switch (literal.type)
		{
		case wasm::none:
			obuf << "none";
			break;
		case wasm::i32:
			obuf << "i32:" << literal.i32;
			break;
		case wasm::i64:
			obuf << "i64:" << literal.i64;
			break;
		case wasm::f32:
			obuf << "f32:" << literal.f32;
			break;
		case wasm::f64:
			obuf << "f64:" << literal.f64;
			break;
		default: abort();
		}
		return strncpy(buf, obuf.str().c_str(), lbuf);
	}

	// retVal only seems to return uninitialized
	void BinaryenRun(BinaryenModuleRef *wasm, char *name, struct BinaryenLiteral *retVal) {
		CoInitialize(NULL);
		Literal literal = BinaryenCallExport((Module *)wasm, name);
		CoUninitialize();
		retVal->type = literal.type;
		// haven't found a way to cast instead of switch
		switch (literal.type)
		{
		case wasm::none:
			break;
		case wasm::i32:
			retVal->i32 = literal.geti32();
			break;
		case wasm::i64:
			retVal->i64 = literal.geti64();
			break;
		case wasm::f32:
			retVal->f32 = literal.getf32();
			break;
		case wasm::f64:
			retVal->f64 = literal.getf64();
			break;
		default: abort();
		}
	}

	HRESULT WasmInvokeFunc(IDispatch *pdisp, const char *methodname, unsigned dispatch_type, DISPPARAMS *dispparams, VARIANT *v);
	void *WinCreateObjectA(const char *classname);

	HRESULT ComCall(const char *classname, const char *methodname, ModuleInstance::LiteralList& arguments, std::vector<WasmType> params, WasmType retType, Literal *retVal)
	{
		IDispatch *pdisp = (IDispatch *)WinCreateObjectA(classname);
		if (pdisp == NULL)
			return DISP_E_UNKNOWNINTERFACE; // cannot create object

		DISPPARAMS dispparams;
		VARIANT v;
		if (arguments.size() > params.size())
			abort();
		dispparams.cArgs = params.size();
		dispparams.cNamedArgs = 0;
		dispparams.rgvarg = new VARIANTARG[dispparams.cArgs];
		dispparams.rgdispidNamedArgs = new DISPID[dispparams.cNamedArgs];
		VARIANTARG *prgvarg = dispparams.rgvarg;
		for (auto argument : arguments) {
			switch (argument.type)
			{
			case wasm::i32:
				VariantClear(prgvarg);
				prgvarg->vt = VT_I4;
				prgvarg->intVal = argument.geti32();
				break;
			case wasm::i64:
				VariantClear(prgvarg);
				prgvarg->vt = VT_I8;
				prgvarg->llVal = argument.geti64();
				break;
			case wasm::f32:
				VariantClear(prgvarg);
				prgvarg->vt = VT_R4;
				prgvarg->fltVal = argument.getf32();
				break;
			case wasm::f64:
				VariantClear(prgvarg);
				prgvarg->vt = VT_R8;
				prgvarg->dblVal = argument.getf64();
				break;
			default: abort();
			}
		}
		while (prgvarg++ != dispparams.rgvarg + dispparams.cArgs)
			prgvarg->vt = VT_EMPTY;
		HRESULT hr = WasmInvokeFunc(pdisp, methodname, DISPATCH_METHOD | DISPATCH_PROPERTYGET, &dispparams, &v);
		if (hr == S_OK)
		{
			switch (retType)
			{
			case wasm::i32:
				if ((hr = VariantChangeType(&v, &v, 0, VT_I4)) == S_OK)
					*retVal = Literal(v.intVal);
				break;
			case wasm::i64:
				if ((hr = VariantChangeType(&v, &v, 0, VT_I8)) == S_OK)
					*retVal = Literal(v.llVal);
				break;
			case wasm::f32:
				if ((hr = VariantChangeType(&v, &v, 0, VT_R4)) == S_OK)
					*retVal = Literal(v.fltVal);
				break;
			case wasm::f64:
				if ((hr = VariantChangeType(&v, &v, 0, VT_R8)) == S_OK)
					*retVal = Literal(v.dblVal);
				break;
			default: abort();
			}
		}
		return hr;
	}

	HRESULT WinCoCreateInstance(CLSID clsid, CLSID refiid, void **ppIface)
	{
		HRESULT hr;
		if (FAILED(hr = CoCreateInstance(clsid, NULL, CLSCTX_INPROC_SERVER, refiid, ppIface)))
			hr = CoCreateInstance(clsid, NULL, CLSCTX_LOCAL_SERVER, refiid, ppIface);
		return(hr);
	}

	HRESULT WinCoCreateInstanceEx(CLSID clsid, LPWSTR servername, IID refiid, void **ppIUn)
	{
		HRESULT hr;
		COSERVERINFO ServerInfo;
		MULTI_QI mqi[1];

		memset(&ServerInfo, 0, sizeof(ServerInfo));
		ServerInfo.pwszName = servername;
		mqi[0].pIID = /*&IID_IDispatch*/&refiid;
		mqi[0].pItf = NULL;
		mqi[0].hr = S_OK;
		hr = CoCreateInstanceEx(
			clsid,
			NULL,
			CLSCTX_REMOTE_SERVER | CLSCTX_LOCAL_SERVER,
			&ServerInfo, 1, mqi
		);
		/* 80004002 means interface (IID_IDispatch) doesn't exist */
		*ppIUn = mqi[0].pItf;
		return(hr);
	}

	void *WinCreateObjectEx(LPWSTR wclassname, LPWSTR wservername)
	{
		CLSID clsid;
		HRESULT hr;
		IDispatch *pdisp;
		WCHAR *w;

		if (FAILED(CLSIDFromString(wclassname, &clsid)))
		{
			hr = CLSIDFromProgID(wclassname, &clsid);
			if (hr)
				return(NULL); /* cannot obtain classid */
		}
		StringFromCLSID(clsid, &w);
		ProgIDFromCLSID(clsid, &w);
		if (wservername == NULL || !*wservername ||
			wcscmp(wservername, L"localhost") == 0)
			hr = WinCoCreateInstance(clsid, IID_IDispatch, (VOID **)&pdisp);
		else
			hr = WinCoCreateInstanceEx(clsid, wservername, IID_IDispatch, (VOID **)&pdisp);
		if (hr || pdisp == NULL)
			return(NULL); /* cannot create instance */
		ITypeInfo *pTinfo;
		pdisp->GetTypeInfo(0, 0, &pTinfo);
		return(pdisp);
	}

	void *WinCreateObjectA(const char *classname)
	{
		size_t len = strlen(classname) + 1;
		WCHAR *wclassname = new WCHAR[len];
		wclassname[MultiByteToWideChar(
			CP_ACP,
			MB_PRECOMPOSED,
			classname,
			(int)strlen(classname),
			wclassname,
			len - 1)
		] = 0;
		return(WinCreateObjectEx(wclassname, NULL));
	}

	HRESULT WasmInvokeFunc(IDispatch *pdisp, const char *membername, unsigned dispatch_type, DISPPARAMS *dispparams, VARIANT *v)
	{
		HRESULT hr;
		WCHAR buf[1][512], *pbuf[1];
		unsigned err;
		DISPID dispid[1];
		EXCEPINFO excp;

		if (*membername)
		{
			buf[0][MultiByteToWideChar(
				CP_ACP,
				MB_PRECOMPOSED,
				membername,
				-1,
				buf[0],
				sizeof(buf[0]))
			] = 0;
			pbuf[0] = buf[0];
			hr = pdisp->GetIDsOfNames(IID_NULL, pbuf, 1, LOCALE_SYSTEM_DEFAULT, dispid);
			if (hr)
				return DISP_E_MEMBERNOTFOUND;
			;
		}
		else
			dispid[0] = 0; /* default property */ /* is this needed for methods? */

												  /* invoke the method */
		switch (dispatch_type)
		{
		case DISPATCH_PROPERTYPUT:
		{
			DISPID temp_dispid = DISPID_PROPERTYPUT;
			dispparams->rgdispidNamedArgs = &temp_dispid;
		}
		dispparams->cNamedArgs = 0;
		case DISPATCH_METHOD:
		case DISPATCH_PROPERTYGET:
		case DISPATCH_METHOD | DISPATCH_PROPERTYGET:
			VariantInit(v);
			HRESULT hr;
			hr = pdisp->Invoke(dispid[0], IID_NULL, 0, (WORD)dispatch_type, dispparams, v, &excp, &err);
			_fpreset(); /* reinit fpu in case it was changed */
			break;
		default:
			return DISP_E_UNKNOWNINTERFACE;
		}
		return hr;
	}
}
