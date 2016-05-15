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
// Binaryen C API dll implementation
//===============================

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#include <binaryen-c.h>

#ifdef _MSC_VER
#ifdef _M_X64
#define DllExport(result) __declspec(dllexport) result
#define DllImport(result) __declspec(dllimport) result
#else
#define DllExport(result) __declspec(dllexport) result __stdcall
#define DllImport(result) __declspec(dllimport) result __stdcall
#endif
#else
#define APIENTRY
#define DllExport(result) result
#define DllImport(result) result
#endif

	DllExport(BinaryenType) BinaryenNoneDll(void) {
#pragma comment(linker, "/export:BinaryenNone=BinaryenNoneDll")
		return BinaryenNone();
	}

	DllExport(BinaryenType) BinaryenInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenInt32=BinaryenInt32Dll")
		return BinaryenInt32();
	}

	DllExport(BinaryenType) BinaryenInt64Dll(void) {
#pragma comment(linker, "/export:BinaryenInt64=BinaryenInt64Dll")
		return BinaryenInt64();
	}

	DllExport(BinaryenType) BinaryenFloat32Dll(void) {
#pragma comment(linker, "/export:BinaryenFloat32=BinaryenFloat32Dll")
		return BinaryenFloat32();
	}

	DllExport(BinaryenType) BinaryenFloat64Dll(void) {
#pragma comment(linker, "/export:BinaryenFloat64=BinaryenFloat64Dll")
		return BinaryenFloat64();
	}

	DllExport(BinaryenModuleRef) BinaryenModuleCreateDll(void) {
#pragma comment(linker, "/export:BinaryenModuleCreate=BinaryenModuleCreateDll")
		return BinaryenModuleCreate();
	}

	DllExport(void) BinaryenModuleDisposeDll(BinaryenModuleRef module) {
#pragma comment(linker, "/export:BinaryenModuleDispose=BinaryenModuleDisposeDll")
		BinaryenModuleDispose(module);
	}

	DllExport(BinaryenFunctionTypeRef) BinaryenAddFunctionTypeDll(BinaryenModuleRef module, const char* name, BinaryenType result, BinaryenType* paramTypes, BinaryenIndex numParams) {
#pragma comment(linker, "/export:BinaryenAddFunctionType=BinaryenAddFunctionTypeDll")
		return BinaryenAddFunctionType(module, name, result, paramTypes, numParams);
	}

	// following binary BinaryenLiteral
	// warning: must change if counterpart in binaryen-c.cpp changes
	enum WasmType {
		none,
		i32,
		i64,
		f32,
		f64,
		unreachable // none means no type, e.g. a block can have no return type. but
					// unreachable is different, as it can be "ignored" when doing
					// type checking across branches
	};

	DllExport(struct BinaryenLiteral) BinaryenLiteralInt32Dll(int32_t x) {
#pragma comment(linker, "/export:BinaryenLiteralInt32=BinaryenLiteralInt32Dll")
		struct BinaryenLiteral ret;
		ret.type = i32;
		ret.i32 = x;
		return ret;
	}

	DllExport(struct BinaryenLiteral) BinaryenLiteralInt64Dll(int64_t x) {
#pragma comment(linker, "/export:BinaryenLiteralInt64=BinaryenLiteralInt64Dll")
		struct BinaryenLiteral ret;
		ret.type = i64;
		ret.i64 = x;
		return ret;
	}

	DllExport(struct BinaryenLiteral) BinaryenLiteralFloat32Dll(float x) {
#pragma comment(linker, "/export:BinaryenLiteralFloat32=BinaryenLiteralFloat32Dll")
		struct BinaryenLiteral ret;
		ret.type = f32;
		ret.f32 = x;
		return ret;
	}

	DllExport(struct BinaryenLiteral) BinaryenLiteralFloat64Dll(double x) {
#pragma comment(linker, "/export:BinaryenLiteralFloat64=BinaryenLiteralFloat64Dll")
		struct BinaryenLiteral ret;
		ret.type = f64;
		ret.f64 = x;
		return ret;
	}

	DllExport(struct BinaryenLiteral) BinaryenLiteralFloat32BitsDll(int32_t x) {
#pragma comment(linker, "/export:BinaryenLiteralFloat32Bits=BinaryenLiteralFloat32BitsDll")
		struct BinaryenLiteral ret;
		ret.type = f32;
		ret.f32 = (float)x;
		return ret;
	}

	DllExport(struct BinaryenLiteral) BinaryenLiteralFloat64BitsDll(int64_t x) {
#pragma comment(linker, "/export:BinaryenLiteralFloat64Bits=BinaryenLiteralFloat64BitsDll")
		struct BinaryenLiteral ret;
		ret.type = f64;
		ret.f64 = (double)x;
		return ret;
	}

	DllExport(BinaryenOp) BinaryenClzDll(void) {
#pragma comment(linker, "/export:BinaryenClz=BinaryenClzDll")
		return BinaryenClz();
	}

	DllExport(BinaryenOp) BinaryenCtzDll(void) {
#pragma comment(linker, "/export:BinaryenCtz=BinaryenCtzDll")
		return BinaryenCtz();
	}

	DllExport(BinaryenOp) BinaryenPopcntDll(void) {
#pragma comment(linker, "/export:BinaryenPopcnt=BinaryenPopcntDll")
		return BinaryenPopcnt();
	}

	DllExport(BinaryenOp) BinaryenNegDll(void) {
#pragma comment(linker, "/export:BinaryenNeg=BinaryenNegDll")
		return BinaryenNeg();
	}

	DllExport(BinaryenOp) BinaryenAbsDll(void) {
#pragma comment(linker, "/export:BinaryenAbs=BinaryenAbsDll")
		return BinaryenAbs();
	}

	DllExport(BinaryenOp) BinaryenCeilDll(void) {
#pragma comment(linker, "/export:BinaryenCeil=BinaryenCeilDll")
		return BinaryenCeil();
	}

	DllExport(BinaryenOp) BinaryenFloorDll(void) {
#pragma comment(linker, "/export:BinaryenFloor=BinaryenFloorDll")
		return BinaryenFloor();
	}

	DllExport(BinaryenOp) BinaryenTruncDll(void) {
#pragma comment(linker, "/export:BinaryenTrunc=BinaryenTruncDll")
		return BinaryenTrunc();
	}

	DllExport(BinaryenOp) BinaryenNearestDll(void) {
#pragma comment(linker, "/export:BinaryenNearest=BinaryenNearestDll")
		return BinaryenNearest();
	}

	DllExport(BinaryenOp) BinaryenSqrtDll(void) {
#pragma comment(linker, "/export:BinaryenSqrt=BinaryenSqrtDll")
		return BinaryenSqrt();
	}

	DllExport(BinaryenOp) BinaryenEqZDll(void) {
#pragma comment(linker, "/export:BinaryenEqZ=BinaryenEqZDll")
		return BinaryenEqZ();
	}

	DllExport(BinaryenOp) BinaryenExtendSInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenExtendSInt32=BinaryenExtendSInt32Dll")
		return BinaryenExtendSInt32();
	}

	DllExport(BinaryenOp) BinaryenExtentUInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenExtentUInt32=BinaryenExtentUInt32Dll")
		return BinaryenExtentUInt32();
	}

	DllExport(BinaryenOp) BinaryenWrapInt64Dll(void) {
#pragma comment(linker, "/export:BinaryenWrapInt64=BinaryenWrapInt64Dll")
		return BinaryenWrapInt64();
	}

	DllExport(BinaryenOp) BinaryenTruncSFloat32ToInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncSFloat32ToInt32=BinaryenTruncSFloat32ToInt32Dll")
		return BinaryenTruncSFloat32ToInt32();
	}

	DllExport(BinaryenOp) BinaryenTruncSFloat32ToInt64Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncSFloat32ToInt64=BinaryenTruncSFloat32ToInt64Dll")
		return BinaryenTruncSFloat32ToInt64();
	}

	DllExport(BinaryenOp) BinaryenTruncUFloat32ToInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncUFloat32ToInt32=BinaryenTruncUFloat32ToInt32Dll")
		return BinaryenTruncUFloat32ToInt32();
	}

	DllExport(BinaryenOp) BinaryenTruncUFloat32ToInt64Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncUFloat32ToInt64=BinaryenTruncUFloat32ToInt64Dll")
		return BinaryenTruncUFloat32ToInt64();
	}

	DllExport(BinaryenOp) BinaryenTruncSFloat64ToInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncSFloat64ToInt32=BinaryenTruncSFloat64ToInt32Dll")
		return BinaryenTruncSFloat64ToInt32();
	}

	DllExport(BinaryenOp) BinaryenTruncSFloat64ToInt64Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncSFloat64ToInt64=BinaryenTruncSFloat64ToInt64Dll")
		return BinaryenTruncSFloat64ToInt64();
	}

	DllExport(BinaryenOp) BinaryenTruncUFloat64ToInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncUFloat64ToInt32=BinaryenTruncUFloat64ToInt32Dll")
		return BinaryenTruncUFloat64ToInt32();
	}

	DllExport(BinaryenOp) BinaryenTruncUFloat64ToInt64Dll(void) {
#pragma comment(linker, "/export:BinaryenTruncUFloat64ToInt64=BinaryenTruncUFloat64ToInt64Dll")
		return BinaryenTruncUFloat64ToInt64();
	}

	DllExport(BinaryenOp) BinaryenReinterpretFloat32Dll(void) {
#pragma comment(linker, "/export:BinaryenReinterpretFloat32=BinaryenReinterpretFloat32Dll")
		return BinaryenReinterpretFloat32();
	}

	DllExport(BinaryenOp) BinaryenReinterpretFloat64Dll(void) {
#pragma comment(linker, "/export:BinaryenReinterpretFloat64=BinaryenReinterpretFloat64Dll")
		return BinaryenReinterpretFloat64();
	}

	DllExport(BinaryenOp) BinaryenConvertSInt32ToFloat32Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertSInt32ToFloat32=BinaryenConvertSInt32ToFloat32Dll")
		return BinaryenConvertSInt32ToFloat32();
	}

	DllExport(BinaryenOp) BinaryenConvertSInt32ToFloat64Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertSInt32ToFloat64=BinaryenConvertSInt32ToFloat64Dll")
		return BinaryenConvertSInt32ToFloat64();
	}

	DllExport(BinaryenOp) BinaryenConvertUInt32ToFloat32Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertUInt32ToFloat32=BinaryenConvertUInt32ToFloat32Dll")
		return BinaryenConvertUInt32ToFloat32();
	}

	DllExport(BinaryenOp) BinaryenConvertUInt32ToFloat64Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertUInt32ToFloat64=BinaryenConvertUInt32ToFloat64Dll")
		return BinaryenConvertUInt32ToFloat64();
	}

	DllExport(BinaryenOp) BinaryenConvertSInt64ToFloat32Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertSInt64ToFloat32=BinaryenConvertSInt64ToFloat32Dll")
		return BinaryenConvertSInt64ToFloat32();
	}

	DllExport(BinaryenOp) BinaryenConvertSInt64ToFloat64Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertSInt64ToFloat64=BinaryenConvertSInt64ToFloat64Dll")
		return BinaryenConvertSInt64ToFloat64();
	}

	DllExport(BinaryenOp) BinaryenConvertUInt64ToFloat32Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertUInt64ToFloat32=BinaryenConvertUInt64ToFloat32Dll")
		return BinaryenConvertUInt64ToFloat32();
	}

	DllExport(BinaryenOp) BinaryenConvertUInt64ToFloat64Dll(void) {
#pragma comment(linker, "/export:BinaryenConvertUInt64ToFloat64=BinaryenConvertUInt64ToFloat64Dll")
		return BinaryenConvertUInt64ToFloat64();
	}

	DllExport(BinaryenOp) BinaryenPromoteFloat32Dll(void) {
#pragma comment(linker, "/export:BinaryenPromoteFloat32=BinaryenPromoteFloat32Dll")
		return BinaryenPromoteFloat32();
	}

	DllExport(BinaryenOp) BinaryenDemoteFloat64Dll(void) {
#pragma comment(linker, "/export:BinaryenDemoteFloat64=BinaryenDemoteFloat64Dll")
		return BinaryenDemoteFloat64();
	}

	DllExport(BinaryenOp) BinaryenReinterpretInt32Dll(void) {
#pragma comment(linker, "/export:BinaryenReinterpretInt32=BinaryenReinterpretInt32Dll")
		return BinaryenReinterpretInt32();
	}

	DllExport(BinaryenOp) BinaryenReinterpretInt64Dll(void) {
#pragma comment(linker, "/export:BinaryenReinterpretInt64=BinaryenReinterpretInt64Dll")
		return BinaryenReinterpretInt64();
	}

	DllExport(BinaryenOp) BinaryenAddDll(void) {
#pragma comment(linker, "/export:BinaryenAdd=BinaryenAddDll")
		return BinaryenAdd();
	}

	DllExport(BinaryenOp) BinaryenSubDll(void) {
#pragma comment(linker, "/export:BinaryenSub=BinaryenSubDll")
		return BinaryenSub();
	}

	DllExport(BinaryenOp) BinaryenMulDll(void) {
#pragma comment(linker, "/export:BinaryenMul=BinaryenMulDll")
		return BinaryenMul();
	}

	DllExport(BinaryenOp) BinaryenDivSDll(void) {
#pragma comment(linker, "/export:BinaryenDivS=BinaryenDivSDll")
		return BinaryenDivS();
	}

	DllExport(BinaryenOp) BinaryenDivUDll(void) {
#pragma comment(linker, "/export:BinaryenDivU=BinaryenDivUDll")
		return BinaryenDivU();
	}

	DllExport(BinaryenOp) BinaryenRemSDll(void) {
#pragma comment(linker, "/export:BinaryenRemS=BinaryenRemSDll")
		return BinaryenRemS();
	}

	DllExport(BinaryenOp) BinaryenRemUDll(void) {
#pragma comment(linker, "/export:BinaryenRemU=BinaryenRemUDll")
		return BinaryenRemU();
	}

	DllExport(BinaryenOp) BinaryenAndDll(void) {
#pragma comment(linker, "/export:BinaryenAnd=BinaryenAndDll")
		return BinaryenAnd();
	}

	DllExport(BinaryenOp) BinaryenOrDll(void) {
#pragma comment(linker, "/export:BinaryenOr=BinaryenOrDll")
		return BinaryenOr();
	}

	DllExport(BinaryenOp) BinaryenXorDll(void) {
#pragma comment(linker, "/export:BinaryenXor=BinaryenXorDll")
		return BinaryenXor();
	}

	DllExport(BinaryenOp) BinaryenShlDll(void) {
#pragma comment(linker, "/export:BinaryenShl=BinaryenShlDll")
		return BinaryenShl();
	}

	DllExport(BinaryenOp) BinaryenShrUDll(void) {
#pragma comment(linker, "/export:BinaryenShrU=BinaryenShrUDll")
		return BinaryenShrU();
	}

	DllExport(BinaryenOp) BinaryenShrSDll(void) {
#pragma comment(linker, "/export:BinaryenShrS=BinaryenShrSDll")
		return BinaryenShrS();
	}

	DllExport(BinaryenOp) BinaryenRotLDll(void) {
#pragma comment(linker, "/export:BinaryenRotL=BinaryenRotLDll")
		return BinaryenRotL();
	}

	DllExport(BinaryenOp) BinaryenRotRDll(void) {
#pragma comment(linker, "/export:BinaryenRotR=BinaryenRotRDll")
		return BinaryenRotR();
	}

	DllExport(BinaryenOp) BinaryenDivDll(void) {
#pragma comment(linker, "/export:BinaryenDiv=BinaryenDivDll")
		return BinaryenDiv();
	}

	DllExport(BinaryenOp) BinaryenCopySignDll(void) {
#pragma comment(linker, "/export:BinaryenCopySign=BinaryenCopySignDll")
		return BinaryenCopySign();
	}

	DllExport(BinaryenOp) BinaryenMinDll(void) {
#pragma comment(linker, "/export:BinaryenMin=BinaryenMinDll")
		return BinaryenMin();
	}

	DllExport(BinaryenOp) BinaryenMaxDll(void) {
#pragma comment(linker, "/export:BinaryenMax=BinaryenMaxDll")
		return BinaryenMax();
	}

	DllExport(BinaryenOp) BinaryenEqDll(void) {
#pragma comment(linker, "/export:BinaryenEq=BinaryenEqDll")
		return BinaryenEq();
	}

	DllExport(BinaryenOp) BinaryenNeDll(void) {
#pragma comment(linker, "/export:BinaryenNe=BinaryenNeDll")
		return BinaryenNe();
	}

	DllExport(BinaryenOp) BinaryenLtSDll(void) {
#pragma comment(linker, "/export:BinaryenLtS=BinaryenLtSDll")
		return BinaryenLtS();
	}

	DllExport(BinaryenOp) BinaryenLtUDll(void) {
#pragma comment(linker, "/export:BinaryenLtU=BinaryenLtUDll")
		return BinaryenLtU();
	}

	DllExport(BinaryenOp) BinaryenLeSDll(void) {
#pragma comment(linker, "/export:BinaryenLeS=BinaryenLeSDll")
		return BinaryenLeS();
	}

	DllExport(BinaryenOp) BinaryenLeUDll(void) {
#pragma comment(linker, "/export:BinaryenLeU=BinaryenLeUDll")
		return BinaryenLeU();
	}

	DllExport(BinaryenOp) BinaryenGtSDll(void) {
#pragma comment(linker, "/export:BinaryenGtS=BinaryenGtSDll")
		return BinaryenGtS();
	}

	DllExport(BinaryenOp) BinaryenGtUDll(void) {
#pragma comment(linker, "/export:BinaryenGtU=BinaryenGtUDll")
		return BinaryenGtU();
	}

	DllExport(BinaryenOp) BinaryenGeSDll(void) {
#pragma comment(linker, "/export:BinaryenGeS=BinaryenGeSDll")
		return BinaryenGeS();
	}

	DllExport(BinaryenOp) BinaryenGeUDll(void) {
#pragma comment(linker, "/export:BinaryenGeU=BinaryenGeUDll")
		return BinaryenGeU();
	}

	DllExport(BinaryenOp) BinaryenLtDll(void) {
#pragma comment(linker, "/export:BinaryenLt=BinaryenLtDll")
		return BinaryenLt();
	}

	DllExport(BinaryenOp) BinaryenLeDll(void) {
#pragma comment(linker, "/export:BinaryenLe=BinaryenLeDll")
		return BinaryenLe();
	}

	DllExport(BinaryenOp) BinaryenGtDll(void) {
#pragma comment(linker, "/export:BinaryenGt=BinaryenGtDll")
		return BinaryenGt();
	}

	DllExport(BinaryenOp) BinaryenGeDll(void) {
#pragma comment(linker, "/export:BinaryenGe=BinaryenGeDll")
		return BinaryenGe();
	}

	DllExport(BinaryenOp) BinaryenPageSizeDll(void) {
#pragma comment(linker, "/export:BinaryenPageSize=BinaryenPageSizeDll")
		return BinaryenPageSize();
	}

	DllExport(BinaryenOp) BinaryenCurrentMemoryDll(void) {
#pragma comment(linker, "/export:BinaryenCurrentMemory=BinaryenCurrentMemoryDll")
		return BinaryenCurrentMemory();
	}

	DllExport(BinaryenOp) BinaryenGrowMemoryDll(void) {
#pragma comment(linker, "/export:BinaryenGrowMemory=BinaryenGrowMemoryDll")
		return BinaryenGrowMemory();
	}

	DllExport(BinaryenOp) BinaryenHasFeatureDll(void) {
#pragma comment(linker, "/export:BinaryenHasFeature=BinaryenHasFeatureDll")
		return BinaryenHasFeature();
	}

	DllExport(BinaryenExpressionRef) BinaryenBlockDll(BinaryenModuleRef module, const char* name, BinaryenExpressionRef* children, BinaryenIndex numChildren) {
#pragma comment(linker, "/export:BinaryenBlock=BinaryenBlockDll")
		return BinaryenBlock(module, name, children, numChildren);
	}

	DllExport(BinaryenExpressionRef) BinaryenIfDll(BinaryenModuleRef module, BinaryenExpressionRef condition, BinaryenExpressionRef ifTrue, BinaryenExpressionRef ifFalse) {
#pragma comment(linker, "/export:BinaryenIf=BinaryenIfDll")
		return BinaryenIf(module, condition, ifTrue, ifFalse);
	}

	DllExport(BinaryenExpressionRef) BinaryenLoopDll(BinaryenModuleRef module, const char* out, const char* in, BinaryenExpressionRef body) {
#pragma comment(linker, "/export:BinaryenLoop=BinaryenLoopDll")
		return BinaryenLoop(module, out, in, body);
	}

	DllExport(BinaryenExpressionRef) BinaryenBreakDll(BinaryenModuleRef module, const char* name, BinaryenExpressionRef condition, BinaryenExpressionRef value) {
#pragma comment(linker, "/export:BinaryenBreak=BinaryenBreakDll")
		return BinaryenBreak(module, name, condition, value);
	}

	DllExport(BinaryenExpressionRef) BinaryenSwitchDll(BinaryenModuleRef module, const char **names, BinaryenIndex numNames, const char* defaultName, BinaryenExpressionRef condition, BinaryenExpressionRef value) {
#pragma comment(linker, "/export:BinaryenSwitch=BinaryenSwitchDll")
		return BinaryenSwitch(module, names, numNames, defaultName, condition, value);
	}

	DllExport(BinaryenExpressionRef) BinaryenCallDll(BinaryenModuleRef module, const char *target, BinaryenExpressionRef* operands, BinaryenIndex numOperands, BinaryenType returnType) {
#pragma comment(linker, "/export:BinaryenCall=BinaryenCallDll")
		return BinaryenCall(module, target, operands, numOperands, returnType);
	}

	DllExport(BinaryenExpressionRef) BinaryenCallImportDll(BinaryenModuleRef module, const char *target, BinaryenExpressionRef* operands, BinaryenIndex numOperands, BinaryenType returnType) {
#pragma comment(linker, "/export:BinaryenCallImport=BinaryenCallImportDll")
		return BinaryenCallImport(module, target, operands, numOperands, returnType);
	}

	DllExport(BinaryenExpressionRef) BinaryenCallIndirectDll(BinaryenModuleRef module, BinaryenExpressionRef target, BinaryenExpressionRef* operands, BinaryenIndex numOperands, BinaryenFunctionTypeRef type) {
#pragma comment(linker, "/export:BinaryenCallIndirect=BinaryenCallIndirectDll")
		return BinaryenCallIndirect(module, target, operands, numOperands, type);
	}

	DllExport(BinaryenExpressionRef) BinaryenGetLocalDll(BinaryenModuleRef module, BinaryenIndex index, BinaryenType type) {
#pragma comment(linker, "/export:BinaryenGetLocal=BinaryenGetLocalDll")
		return BinaryenGetLocal(module, index, type);
	}

	DllExport(BinaryenExpressionRef) BinaryenSetLocalDll(BinaryenModuleRef module, BinaryenIndex index, BinaryenExpressionRef value) {
#pragma comment(linker, "/export:BinaryenSetLocal=BinaryenSetLocalDll")
		return BinaryenSetLocal(module, index, value);
	}

	DllExport(BinaryenExpressionRef) BinaryenLoadDll(BinaryenModuleRef module, uint32_t bytes, int8_t signed_, uint32_t offset, uint32_t align, BinaryenType type, BinaryenExpressionRef ptr) {
#pragma comment(linker, "/export:BinaryenLoad=BinaryenLoadDll")
		return BinaryenLoad(module, bytes, signed_, offset, align, type, ptr);
	}

	DllExport(BinaryenExpressionRef) BinaryenStoreDll(BinaryenModuleRef module, uint32_t bytes, uint32_t offset, uint32_t align, BinaryenExpressionRef ptr, BinaryenExpressionRef value) {
#pragma comment(linker, "/export:BinaryenStore=BinaryenStoreDll")
		return BinaryenStore(module, bytes, offset, align, ptr, value);
	}

	DllExport(BinaryenExpressionRef) BinaryenConstDll(BinaryenModuleRef module, struct BinaryenLiteral value) {
#pragma comment(linker, "/export:BinaryenConst=BinaryenConstDll")
		return BinaryenConst(module, value);
	}

	DllExport(BinaryenExpressionRef) BinaryenUnaryDll(BinaryenModuleRef module, BinaryenOp op, BinaryenExpressionRef value) {
#pragma comment(linker, "/export:BinaryenUnary=BinaryenUnaryDll")
		return BinaryenUnary(module, op, value);
	}

	DllExport(BinaryenExpressionRef) BinaryenBinaryDll(BinaryenModuleRef module, BinaryenOp op, BinaryenExpressionRef left, BinaryenExpressionRef right) {
#pragma comment(linker, "/export:BinaryenBinary=BinaryenBinaryDll")
		return BinaryenBinary(module, op, left, right);
	}

	DllExport(BinaryenExpressionRef) BinaryenSelectDll(BinaryenModuleRef module, BinaryenExpressionRef condition, BinaryenExpressionRef ifTrue, BinaryenExpressionRef ifFalse) {
#pragma comment(linker, "/export:BinaryenSelect=BinaryenSelectDll")
		return BinaryenSelect(module, condition, ifTrue, ifFalse);
	}

	DllExport(BinaryenExpressionRef) BinaryenReturnDll(BinaryenModuleRef module, BinaryenExpressionRef value) {
#pragma comment(linker, "/export:BinaryenReturn=BinaryenReturnDll")
		return BinaryenReturn(module, value);
	}

	DllExport(BinaryenExpressionRef) BinaryenHostDll(BinaryenModuleRef module, BinaryenOp op, const char* name, BinaryenExpressionRef* operands, BinaryenIndex numOperands) {
#pragma comment(linker, "/export:BinaryenHost=BinaryenHostDll")
		return BinaryenHost(module, op, name, operands, numOperands);
	}

	DllExport(BinaryenExpressionRef) BinaryenNopDll(BinaryenModuleRef module) {
#pragma comment(linker, "/export:BinaryenNop=BinaryenNopDll")
		return BinaryenNop(module);
	}

	DllExport(BinaryenExpressionRef) BinaryenUnreachableDll(BinaryenModuleRef module) {
#pragma comment(linker, "/export:BinaryenUnreachable=BinaryenUnreachableDll")
		return BinaryenUnreachable(module);
	}

	DllExport(BinaryenFunctionRef) BinaryenAddFunctionDll(BinaryenModuleRef module, const char* name, BinaryenFunctionTypeRef type, BinaryenType* localTypes, BinaryenIndex numLocalTypes, BinaryenExpressionRef body) {
#pragma comment(linker, "/export:BinaryenAddFunction=BinaryenAddFunctionDll")
		return BinaryenAddFunction(module, name, type, localTypes, numLocalTypes, body);
	}

	DllExport(BinaryenImportRef) BinaryenAddImportDll(BinaryenModuleRef module, const char* internalName, const char* externalModuleName, const char *externalBaseName, BinaryenFunctionTypeRef type) {
#pragma comment(linker, "/export:BinaryenAddImport=BinaryenAddImportDll")
		return BinaryenAddImport(module, internalName, externalModuleName, externalBaseName, type);
	}

	DllExport(BinaryenExportRef) BinaryenAddExportDll(BinaryenModuleRef module, const char* internalName, const char* externalName) {
#pragma comment(linker, "/export:BinaryenAddExport=BinaryenAddExportDll")
		return BinaryenAddExport(module, internalName, externalName);
	}

	DllExport(void) BinaryenSetFunctionTableDll(BinaryenModuleRef module, BinaryenFunctionRef* functions, BinaryenIndex numFunctions) {
#pragma comment(linker, "/export:BinaryenSetFunctionTable=BinaryenSetFunctionTableDll")
		BinaryenSetFunctionTable(module, functions, numFunctions);
	}

	DllExport(void) BinaryenSetMemoryDll(BinaryenModuleRef module, BinaryenIndex initial, BinaryenIndex maximum, const char* exportName, const char **segments, BinaryenIndex* segmentOffsets, BinaryenIndex* segmentSizes, BinaryenIndex numSegments) {
#pragma comment(linker, "/export:BinaryenSetMemory=BinaryenSetMemoryDll")
		BinaryenSetMemory(module, initial, maximum, exportName, segments, segmentOffsets, segmentSizes, numSegments);
	}

	DllExport(void) BinaryenSetStartDll(BinaryenModuleRef module, BinaryenFunctionRef start) {
#pragma comment(linker, "/export:BinaryenSetStart=BinaryenSetStartDll")
		BinaryenSetStart(module, start);
	}

	DllExport(void) BinaryenModulePrintDll(BinaryenModuleRef module) {
#pragma comment(linker, "/export:BinaryenModulePrint=BinaryenModulePrintDll")
		BinaryenModulePrint(module);
	}

	DllExport(int) BinaryenModuleValidateDll(BinaryenModuleRef module) {
#pragma comment(linker, "/export:BinaryenModuleValidate=BinaryenModuleValidateDll")
		return BinaryenModuleValidate(module);
	}

	DllExport(void) BinaryenModuleOptimizeDll(BinaryenModuleRef module) {
#pragma comment(linker, "/export:BinaryenModuleOptimize=BinaryenModuleOptimizeDll")
		BinaryenModuleOptimize(module);
	}

	DllExport(size_t) BinaryenModuleWriteDll(BinaryenModuleRef module, char* output, size_t outputSize) {
#pragma comment(linker, "/export:BinaryenModuleWrite=BinaryenModuleWriteDll")
		return BinaryenModuleWrite(module, output, outputSize);
	}

	DllExport(BinaryenModuleRef) BinaryenModuleReadDll(char* input, size_t inputSize) {
#pragma comment(linker, "/export:BinaryenModuleRead=BinaryenModuleReadDll")
		return BinaryenModuleRead(input, inputSize);
	}

	DllExport(RelooperRef) RelooperCreateDll(void) {
#pragma comment(linker, "/export:RelooperCreate=RelooperCreateDll")
		return RelooperCreate();
	}

	DllExport(RelooperBlockRef) RelooperAddBlockDll(RelooperRef relooper, BinaryenExpressionRef code) {
#pragma comment(linker, "/export:RelooperAddBlock=RelooperAddBlockDll")
		return RelooperAddBlock(relooper, code);
	}

	DllExport(void) RelooperAddBranchDll(RelooperBlockRef from, RelooperBlockRef to, BinaryenExpressionRef condition, BinaryenExpressionRef code) {
#pragma comment(linker, "/export:RelooperAddBranch=RelooperAddBranchDll")
		RelooperAddBranch(from, to, condition, code);
	}

	DllExport(BinaryenExpressionRef) RelooperRenderAndDisposeDll(RelooperRef relooper, RelooperBlockRef entry, BinaryenIndex labelHelper, BinaryenModuleRef module) {
#pragma comment(linker, "/export:RelooperRenderAndDispose=RelooperRenderAndDisposeDll")
		return RelooperRenderAndDispose(relooper, entry, labelHelper, module);
	}