
#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#include "WinWasm.h"

// helpers

BinaryenExpressionRef makeUnary(BinaryenModuleRef module, BinaryenOp op, BinaryenType inputType) {
	if (inputType == BinaryenInt32()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralInt32(-10)));
	if (inputType == BinaryenInt64()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralInt64(-22)));
	if (inputType == BinaryenFloat32()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralFloat32(-33.612f)));
	if (inputType == BinaryenFloat64()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralFloat64(-9005.841)));
	abort();
}

BinaryenExpressionRef makeBinary(BinaryenModuleRef module, BinaryenOp op, BinaryenType type) {
	if (type == BinaryenInt32()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralInt32(-10)), BinaryenConst(module, BinaryenLiteralInt32(-11)));
	if (type == BinaryenInt64()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralInt64(-22)), BinaryenConst(module, BinaryenLiteralInt64(-23)));
	if (type == BinaryenFloat32()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralFloat32(-33.612f)), BinaryenConst(module, BinaryenLiteralFloat32(-62.5)));
	if (type == BinaryenFloat64()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralFloat64(-9005.841)), BinaryenConst(module, BinaryenLiteralFloat64(-9007.333)));
	abort();
}

BinaryenExpressionRef makeInt32(BinaryenModuleRef module, int x) {
	return BinaryenConst(module, BinaryenLiteralInt32(x));
}

BinaryenExpressionRef makeFloat32(BinaryenModuleRef module, float x) {
	return BinaryenConst(module, BinaryenLiteralFloat32(x));
}

BinaryenExpressionRef makeInt64(BinaryenModuleRef module, int64_t x) {
	return BinaryenConst(module, BinaryenLiteralInt64(x));
}

BinaryenExpressionRef makeFloat64(BinaryenModuleRef module, double x) {
	return BinaryenConst(module, BinaryenLiteralFloat64(x));
}

int main() {

	BinaryenModuleRef module = BinaryenModuleCreate();

#if 1
#if 0
	BinaryenType params[4] = { BinaryenInt32(), BinaryenInt64(), BinaryenFloat32(), BinaryenFloat64() };
	BinaryenFunctionTypeRef iiIfF = BinaryenAddFunctionType(module, "iiIfF", BinaryenInt32(), params, 4);
	BinaryenExpressionRef callOperands4[] = { makeInt32(module, 13), makeInt64(module, 37), makeFloat32(module, 1.3f), makeFloat64(module, 3.7) };
	BinaryenExpressionRef  c = BinaryenCallImport(module, "importname", callOperands4, 4, BinaryenInt32());
#else
	BinaryenFunctionTypeRef i = BinaryenAddFunctionType(module, "i", BinaryenInt32(), 0, 0);
	BinaryenAddImport(module, "importname", "WScript.Shell", "CurrentDirectory", i);
	BinaryenExpressionRef  c = BinaryenCallImport(module, "importname", 0, 0, BinaryenInt32());
#endif
#else
	BinaryenExpressionRef b = BinaryenReturn(module, makeInt32(module, 123));
	BinaryenFunctionRef fiiIfF = BinaryenAddFunction(module, "fiiIfF", iiIfF, NULL, 0, b);
	BinaryenExpressionRef callOperands4[] = { makeInt32(module, 13), makeInt64(module, 37), makeFloat32(module, 1.3f), makeFloat64(module, 3.7) };
#if 0
	BinaryenExpressionRef  c = BinaryenCall(module, "fiiIfF", callOperands4, 4, BinaryenNop(module));
#else
	BinaryenExpressionRef  c = BinaryenCallIndirect(module, makeInt32(module, 123), callOperands4, 4, iiIfF);
#endif
#endif
	BinaryenFunctionTypeRef v = BinaryenAddFunctionType(module, "v", BinaryenNone(), NULL, 0);
	BinaryenFunctionRef f = BinaryenAddFunction(module, "f", v, NULL, 0, c);
	BinaryenExpressionRef  s = BinaryenCall(module, "f", NULL, 0, BinaryenNone());
	BinaryenFunctionRef starter = BinaryenAddFunction(module, "starter", v, NULL, 0, s);

	//	BinaryenSetStart(module, starter);
	BinaryenAddExport(module, "starter", "starter");

	printf("validate module\n");
	assert(BinaryenModuleValidate(module));

	char buffer[1024];
	size_t size;
	printf("write module\n");
	size = BinaryenModuleWrite(module, buffer, 1024);
	assert(size > 0); // must have non-zero size
	assert(size < 512); // must be very small

#if 1
	// must Dispose, BinaryenModuleRead to populate unimplemented param properties, maybe others
	printf("dispose module\n");
	BinaryenModuleDispose(module);

	printf("read module\n");
	module = BinaryenModuleRead(buffer, size);

	printf("validate module\n");
	assert(BinaryenModuleValidate(module));
#endif

	printf("print module\n");
	BinaryenModulePrint(module);

	struct BinaryenLiteral retVal;
	BinaryenRun(module, "starter", &retVal);

	char printbuf[64];
	printf("retVal: %s\n", BinaryenLiteralPrint(printbuf, sizeof(printbuf), retVal));

	printf("dispose module\n");
	BinaryenModuleDispose(module);
}
