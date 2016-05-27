#pragma once

#include <binaryen-c.h>

#ifdef __cplusplus
extern "C" {
#endif

	void BinaryenRun(BinaryenModuleRef *wasm, char *name, struct BinaryenLiteral *retVal);
	char *BinaryenLiteralPrint(char *buf, size_t lbuf, struct BinaryenLiteral literal);

#ifdef __cplusplus
}
#endif



