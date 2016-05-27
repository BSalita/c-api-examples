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

#ifdef _MSC_VER
#ifdef _M_X64
#define Alias(func) comment(linker, "/export:" func "=" func)
#else
#define Alias(func) comment(linker, "/export:" func "=_" func)
#endif

// Core types (call to get the value of each; you can cache them, they
// never change)

#pragma Alias("BinaryenNone")
#pragma Alias("BinaryenInt32")
#pragma Alias("BinaryenInt64")
#pragma Alias("BinaryenFloat32")
#pragma Alias("BinaryenFloat64")

// Modules
//
// Modules contain lists of functions, imports, exports, function types. The
// Add* methods create them on a module. The module owns them and will free their
// memory when the module is disposed of.
//
// Expressions are also allocated inside modules, and freed with the module. They
// are not created by Add* methods, since they are not added directly on the
// module, instead, they are arguments to other expressions (and then they are
// the children of that AST node), or to a function (and then they are the body
// of that function).
//
// A module can also contain a function table for indirect calls, a memory,
// and a start method.

#pragma Alias("BinaryenModuleCreate")
#pragma Alias("BinaryenModuleDispose")

// Function types

typedef void* BinaryenFunctionTypeRef;

// Note: name can be NULL, in which case we auto-generate a name
#pragma Alias("BinaryenAddFunctionType")

// Literals. These are passed by value.

#pragma Alias("BinaryenLiteralInt32")
#pragma Alias("BinaryenLiteralInt64")
#pragma Alias("BinaryenLiteralFloat32")
#pragma Alias("BinaryenLiteralFloat64")
#pragma Alias("BinaryenLiteralFloat32Bits")
#pragma Alias("BinaryenLiteralFloat64Bits")

// Expressions
//
// Some expressions have a BinaryenOp, which is the more
// specific operation/opcode.
//
// Some expressions have optional parameters, like Return may not
// return a value. You can supply a NULL pointer in those cases.
//
// For more information, see wasm.h

#pragma Alias("BinaryenClzInt32")
#pragma Alias("BinaryenCtzInt32")
#pragma Alias("BinaryenPopcntInt32")
#pragma Alias("BinaryenNegFloat32")
#pragma Alias("BinaryenAbsFloat32")
#pragma Alias("BinaryenCeilFloat32")
#pragma Alias("BinaryenFloorFloat32")
#pragma Alias("BinaryenTruncFloat32")
#pragma Alias("BinaryenNearestFloat32")
#pragma Alias("BinaryenSqrtFloat32")
#pragma Alias("BinaryenEqZInt32")
#pragma Alias("BinaryenClzInt64")
#pragma Alias("BinaryenCtzInt64")
#pragma Alias("BinaryenPopcntInt64")
#pragma Alias("BinaryenNegFloat64")
#pragma Alias("BinaryenAbsFloat64")
#pragma Alias("BinaryenCeilFloat64")
#pragma Alias("BinaryenFloorFloat64")
#pragma Alias("BinaryenTruncFloat64")
#pragma Alias("BinaryenNearestFloat64")
#pragma Alias("BinaryenSqrtFloat64")
#pragma Alias("BinaryenEqZInt64")
#pragma Alias("BinaryenExtendSInt32")
#pragma Alias("BinaryenExtentUInt32")
#pragma Alias("BinaryenWrapInt64")
#pragma Alias("BinaryenTruncSFloat32ToInt32")
#pragma Alias("BinaryenTruncSFloat32ToInt64")
#pragma Alias("BinaryenTruncUFloat32ToInt32")
#pragma Alias("BinaryenTruncUFloat32ToInt64")
#pragma Alias("BinaryenTruncSFloat64ToInt32")
#pragma Alias("BinaryenTruncSFloat64ToInt64")
#pragma Alias("BinaryenTruncUFloat64ToInt32")
#pragma Alias("BinaryenTruncUFloat64ToInt64")
#pragma Alias("BinaryenReinterpretFloat32")
#pragma Alias("BinaryenReinterpretFloat64")
#pragma Alias("BinaryenConvertSInt32ToFloat32")
#pragma Alias("BinaryenConvertSInt32ToFloat64")
#pragma Alias("BinaryenConvertUInt32ToFloat32")
#pragma Alias("BinaryenConvertUInt32ToFloat64")
#pragma Alias("BinaryenConvertSInt64ToFloat32")
#pragma Alias("BinaryenConvertSInt64ToFloat64")
#pragma Alias("BinaryenConvertUInt64ToFloat32")
#pragma Alias("BinaryenConvertUInt64ToFloat64")
#pragma Alias("BinaryenPromoteFloat32")
#pragma Alias("BinaryenDemoteFloat64")
#pragma Alias("BinaryenReinterpretInt32")
#pragma Alias("BinaryenReinterpretInt64")
#pragma Alias("BinaryenAddInt32")
#pragma Alias("BinaryenSubInt32")
#pragma Alias("BinaryenMulInt32")
#pragma Alias("BinaryenDivSInt32")
#pragma Alias("BinaryenDivUInt32")
#pragma Alias("BinaryenRemSInt32")
#pragma Alias("BinaryenRemUInt32")
#pragma Alias("BinaryenAndInt32")
#pragma Alias("BinaryenOrInt32")
#pragma Alias("BinaryenXorInt32")
#pragma Alias("BinaryenShlInt32")
#pragma Alias("BinaryenShrUInt32")
#pragma Alias("BinaryenShrSInt32")
#pragma Alias("BinaryenRotLInt32")
#pragma Alias("BinaryenRotRInt32")
#pragma Alias("BinaryenEqInt32")
#pragma Alias("BinaryenNeInt32")
#pragma Alias("BinaryenLtSInt32")
#pragma Alias("BinaryenLtUInt32")
#pragma Alias("BinaryenLeSInt32")
#pragma Alias("BinaryenLeUInt32")
#pragma Alias("BinaryenGtSInt32")
#pragma Alias("BinaryenGtUInt32")
#pragma Alias("BinaryenGeSInt32")
#pragma Alias("BinaryenGeUInt32")
#pragma Alias("BinaryenAddInt64")
#pragma Alias("BinaryenSubInt64")
#pragma Alias("BinaryenMulInt64")
#pragma Alias("BinaryenDivSInt64")
#pragma Alias("BinaryenDivUInt64")
#pragma Alias("BinaryenRemSInt64")
#pragma Alias("BinaryenRemUInt64")
#pragma Alias("BinaryenAndInt64")
#pragma Alias("BinaryenOrInt64")
#pragma Alias("BinaryenXorInt64")
#pragma Alias("BinaryenShlInt64")
#pragma Alias("BinaryenShrUInt64")
#pragma Alias("BinaryenShrSInt64")
#pragma Alias("BinaryenRotLInt64")
#pragma Alias("BinaryenRotRInt64")
#pragma Alias("BinaryenEqInt64")
#pragma Alias("BinaryenNeInt64")
#pragma Alias("BinaryenLtSInt64")
#pragma Alias("BinaryenLtUInt64")
#pragma Alias("BinaryenLeSInt64")
#pragma Alias("BinaryenLeUInt64")
#pragma Alias("BinaryenGtSInt64")
#pragma Alias("BinaryenGtUInt64")
#pragma Alias("BinaryenGeSInt64")
#pragma Alias("BinaryenGeUInt64")
#pragma Alias("BinaryenAddFloat32")
#pragma Alias("BinaryenSubFloat32")
#pragma Alias("BinaryenMulFloat32")
#pragma Alias("BinaryenDivFloat32")
#pragma Alias("BinaryenCopySignFloat32")
#pragma Alias("BinaryenMinFloat32")
#pragma Alias("BinaryenMaxFloat32")
#pragma Alias("BinaryenEqFloat32")
#pragma Alias("BinaryenNeFloat32")
#pragma Alias("BinaryenLtFloat32")
#pragma Alias("BinaryenLeFloat32")
#pragma Alias("BinaryenGtFloat32")
#pragma Alias("BinaryenGeFloat32")
#pragma Alias("BinaryenAddFloat64")
#pragma Alias("BinaryenSubFloat64")
#pragma Alias("BinaryenMulFloat64")
#pragma Alias("BinaryenDivFloat64")
#pragma Alias("BinaryenCopySignFloat64")
#pragma Alias("BinaryenMinFloat64")
#pragma Alias("BinaryenMaxFloat64")
#pragma Alias("BinaryenEqFloat64")
#pragma Alias("BinaryenNeFloat64")
#pragma Alias("BinaryenLtFloat64")
#pragma Alias("BinaryenLeFloat64")
#pragma Alias("BinaryenGtFloat64")
#pragma Alias("BinaryenGeFloat64")
#pragma Alias("BinaryenPageSize")
#pragma Alias("BinaryenCurrentMemory")
#pragma Alias("BinaryenGrowMemory")
#pragma Alias("BinaryenHasFeature")

// Block: name can be NULL
#pragma Alias("BinaryenBlock")
// If: ifFalse can be NULL
#pragma Alias("BinaryenIf")
// Loop: both out and in can be NULL, or just out can be NULL
#pragma Alias("BinaryenLoop")
// Break: value and condition can be NULL
#pragma Alias("BinaryenBreak")
// Switch: value can be NULL
#pragma Alias("BinaryenSwitch")
// Call, CallImport: Note the 'returnType' parameter. You must declare the
//                   type returned by the function being called, as that
//                   function might not have been created yet, so we don't
//                   know what it is.
#pragma Alias("BinaryenCall")
#pragma Alias("BinaryenCallImport")
#pragma Alias("BinaryenCallIndirect")
// GetLocal: Note the 'type' parameter. It might seem redundant, since the
//           local at that index must have a type. However, this API lets you
//           build code "top-down": create a node, then its parents, and so
//           on, and finally create the function at the end. (Note that in fact
//           you do not mention a function when creating ExpressionRefs, only
//           a module.) And since GetLocal is a leaf node, we need to be told
//           its type. (Other nodes detect their type either from their
//           type or their opcode, or failing that, their children. But
//           GetLocal has no children, it is where a "stream" of type info
//           begins.)
#pragma Alias("BinaryenGetLocal")
#pragma Alias("BinaryenSetLocal")
// Load: align can be 0, in which case it will be the natural alignment (equal to bytes)
#pragma Alias("BinaryenLoad")
// Store: align can be 0, in which case it will be the natural alignment (equal to bytes)
#pragma Alias("BinaryenStore")
#pragma Alias("BinaryenConst")
#pragma Alias("BinaryenUnary")
#pragma Alias("BinaryenBinary")
#pragma Alias("BinaryenSelect")
// Return: value can be NULL
#pragma Alias("BinaryenReturn")
// Host: name may be NULL
#pragma Alias("BinaryenHost")
#pragma Alias("BinaryenNop")
#pragma Alias("BinaryenUnreachable")

// Functions

#pragma Alias("BinaryenAddFunction")

// Imports

#pragma Alias("BinaryenAddImport")

// Exports

#pragma Alias("BinaryenAddExport")

// Function table. One per module

#pragma Alias("BinaryenSetFunctionTable")

// Memory. One per module

// Each segment has data in segments, a start offset in segmentOffsets, and a size in segmentSizes.
// exportName can be NULL
#pragma Alias("BinaryenSetMemory")

// Start function. One per module

#pragma Alias("BinaryenSetStart")

//
// ========== Module Operations ==========
//

// Print a module to stdout.
#pragma Alias("BinaryenModulePrint")

// Validate a module, showing errors on problems.
//  @return 0 if an error occurred, 1 if validated succesfully
#pragma Alias("BinaryenModuleValidate")

// Run the standard optimization passes on the module.
#pragma Alias("BinaryenModuleOptimize")

// Serialize a module into binary form.
// @return how many bytes were written. This will be less than or equal to bufferSize
#pragma Alias("BinaryenModuleWrite")

// Deserialize a module from binary form.
#pragma Alias("BinaryenModuleRead")

//
// ========== CFG / Relooper ==========
//
// General usage is (1) create a relooper, (2) create blocks, (3) add
// branches between them, (4) render the output.
//
// See Relooper.h for more details

// Create a relooper instance
#pragma Alias("RelooperCreate")

// Create a basic block that ends with nothing, or with some simple branching
#pragma Alias("RelooperAddBlock")

// Create a branch to another basic block
// The branch can have code on it, that is executed as the branch happens. this is useful for phis. otherwise, code can be NULL
#pragma Alias("RelooperAddBranch")

// Create a basic block that ends a switch on a condition
// TODO RelooperBlockRef RelooperAddBlockWithSwitch(RelooperRef relooper, BinaryenExpressionRef code, BinaryenExpressionRef condition);

// Create a switch-style branch to another basic block. The block's switch table will have an index for this branch
// TODO void RelooperAddBranchForSwitch(RelooperBlockRef from, RelooperBlockRef to, BinaryenIndex index, BinaryenExpressionRef code);

// Generate structed wasm control flow from the CFG of blocks and branches that were created
// on this relooper instance. This returns the rendered output, and also disposes of the
// relooper and its blocks and branches, as they are no longer needed.
//   @param labelHelper To render irreducible control flow, we may need a helper variable to
//                      guide us to the right target label. This value should be an index of
//                      an i32 local variable that is free for us to use.
#pragma Alias("RelooperRenderAndDispose")

#endif