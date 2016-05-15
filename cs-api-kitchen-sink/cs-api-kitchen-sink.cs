// Be sure to explicitly set Properties->Build->Platform target property to match DllImport (x64 to x64, x86 to x86). Any other Platform target won't work.  
// If debugging required, best to enable native debugging; Properties->Debug->Enable native code debugging.

using System;
using System.Runtime.InteropServices; // DllImport

namespace cs_api_hello_world_staticlib
{
    // using is closest match to a C++ typedef.
    using BinaryenModuleRef = UIntPtr;
    using BinaryenExpressionRef = UIntPtr;
    using BinaryenExpressionRefRef = UIntPtr; // binaryenHost()
    using BinaryenFunctionTypeRef = UIntPtr;
    using BinaryenType = UInt32;
    using BinaryenIndex = UInt32;
    using BinaryenOp = Int32;
    using BinaryenFunctionRef = UIntPtr;
    using BinaryenImportRef = UIntPtr;
    using BinaryenExportRef = UIntPtr;
    using RelooperRef = UIntPtr;
    using RelooperBlockRef = UIntPtr;
    using size_t = UInt32; // Currently limiting to UInt32

    [StructLayout(LayoutKind.Explicit)]
    struct BinaryenLiteral
    {
        [FieldOffset(0)]
        Int32 type;
        [FieldOffset(4)]
        Int32 i32;
        [FieldOffset(4)]
        Int64 i64;
        [FieldOffset(4)]
        float f32;
        [FieldOffset(4)]
        double f64;
    };

    class Program
    {
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenModuleRef BinaryenModuleCreate();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModuleDispose(BinaryenModuleRef module);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenNone();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenInt64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenFloat32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenFloat64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenFunctionTypeRef BinaryenAddFunctionType(BinaryenModuleRef module, string name, BinaryenType result, BinaryenType[] paramTypes, BinaryenIndex numParams);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralInt32(Int32 x);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralInt64(Int64 x);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat32(float x);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat64(double x);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat32Bits(Int32 x);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat64Bits(Int64 x);


        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenClz();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCtz();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenPopcnt();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNeg();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAbs();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCeil();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenFloor();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTrunc();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNearest();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSqrt();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEqZ();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenExtendSInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenExtentUInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenWrapInt64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat32ToInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat32ToInt64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat32ToInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat32ToInt64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat64ToInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat64ToInt64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat64ToInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat64ToInt64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretFloat32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretFloat64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt32ToFloat32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt32ToFloat64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt32ToFloat32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt32ToFloat64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt64ToFloat32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt64ToFloat64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt64ToFloat32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt64ToFloat64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenPromoteFloat32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDemoteFloat64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretInt32();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretInt64();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAdd();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSub();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMul();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivS();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivU();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRemS();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRemU();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAnd();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenOr();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenXor();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShl();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShrU();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShrS();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRotL();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRotR();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDiv();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCopySign();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMin();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMax();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEq();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNe();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtS();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtU();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeS();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeU();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtS();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtU();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeS();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeU();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLt();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLe();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGt();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGe();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenPageSize();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCurrentMemory();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGrowMemory();

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenHasFeature();

        // Block: name can be NULL

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenBlock(BinaryenModuleRef module, string name, BinaryenExpressionRef[] children, BinaryenIndex numChildren);

        // If: ifFalse can be NULL
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenIf(BinaryenModuleRef module, BinaryenExpressionRef condition, BinaryenExpressionRef ifTrue, BinaryenExpressionRef ifFalse);
        // Loop: both out and in can be NULL, or just out can be NULL

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenLoop(BinaryenModuleRef module, string Out, string In, BinaryenExpressionRef body);
        // Break: value and condition can be NULL

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenBreak(BinaryenModuleRef module, string name, BinaryenExpressionRef condition, BinaryenExpressionRef value);
        // Switch: value can be NULL

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenSwitch(BinaryenModuleRef module, ref string names, BinaryenIndex numNames, string defaultName, BinaryenExpressionRef condition, BinaryenExpressionRef value);
        // Call, CallImport: Note the 'returnType' parameter. You must declare the
        //                   type returned by the function being called, as that
        //                   function might not have been created yet, so we don't
        //                   know what it is.

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenCall(BinaryenModuleRef module, string target, BinaryenExpressionRef[] operands, BinaryenIndex numOperands, BinaryenType returnType);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenCallImport(BinaryenModuleRef module, string target, BinaryenExpressionRef[] operands, BinaryenIndex numOperands, BinaryenType returnType);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenCallIndirect(BinaryenModuleRef module, BinaryenExpressionRef target, BinaryenExpressionRef[] operands, BinaryenIndex numOperands, BinaryenFunctionTypeRef type);

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

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenGetLocal(BinaryenModuleRef module, BinaryenIndex Index, BinaryenType type);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenSetLocal(BinaryenModuleRef module, BinaryenIndex index, BinaryenExpressionRef value);
        // Load: align can be 0, in which case it will be the natural alignment (equal to bytes)

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenLoad(BinaryenModuleRef module, UInt32 bytes, SByte signed_, UInt32 offset, UInt32 align, BinaryenType type, BinaryenExpressionRef ptr);
        // Store: align can be 0, in which case it will be the natural alignment (equal to bytes)

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenStore(BinaryenModuleRef module, UInt32 bytes, UInt32 offset, UInt32 align, BinaryenExpressionRef ptr, BinaryenExpressionRef value);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenConst(BinaryenModuleRef module, BinaryenLiteral value);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenUnary(BinaryenModuleRef module, BinaryenOp op, BinaryenExpressionRef value);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenBinary(BinaryenModuleRef module, BinaryenOp op, BinaryenExpressionRef left, BinaryenExpressionRef right);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenSelect(BinaryenModuleRef module, BinaryenExpressionRef condition, BinaryenExpressionRef ifTrue, BinaryenExpressionRef ifFalse);

        // Return: value can be NULL
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenReturn(BinaryenModuleRef module, BinaryenExpressionRef value);

        // Host: name may be NULL
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenHost(BinaryenModuleRef module, BinaryenOp op, string name, BinaryenExpressionRefRef operands, BinaryenIndex numOperands);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenNop(BinaryenModuleRef module);

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenUnreachable(BinaryenModuleRef module);

        // kitchen sink, tests the full API


        // helpers

        static BinaryenExpressionRef makeUnary(BinaryenModuleRef module, BinaryenOp op, BinaryenType inputType)
        {
            if (inputType == BinaryenInt32()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralInt32(-10)));
            if (inputType == BinaryenInt64()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralInt64(-22)));
            if (inputType == BinaryenFloat32()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralFloat32(-33.612f)));
            if (inputType == BinaryenFloat64()) return BinaryenUnary(module, op, BinaryenConst(module, BinaryenLiteralFloat64(-9005.841)));
            throw new NotImplementedException();
        }

        static BinaryenExpressionRef makeBinary(BinaryenModuleRef module, BinaryenOp op, BinaryenType type)
        {
            if (type == BinaryenInt32()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralInt32(-10)), BinaryenConst(module, BinaryenLiteralInt32(-11)));
            if (type == BinaryenInt64()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralInt64(-22)), BinaryenConst(module, BinaryenLiteralInt64(-23)));
            if (type == BinaryenFloat32()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralFloat32(-33.612f)), BinaryenConst(module, BinaryenLiteralFloat32(-62.5f)));
            if (type == BinaryenFloat64()) return BinaryenBinary(module, op, BinaryenConst(module, BinaryenLiteralFloat64(-9005.841)), BinaryenConst(module, BinaryenLiteralFloat64(-9007.333)));
            throw new NotImplementedException();
        }

        static BinaryenExpressionRef makeInt32(BinaryenModuleRef module, int x)
        {
            return BinaryenConst(module, BinaryenLiteralInt32(x));
        }

        static BinaryenExpressionRef makeFloat32(BinaryenModuleRef module, float x)
        {
            return BinaryenConst(module, BinaryenLiteralFloat32(x));
        }

        static BinaryenExpressionRef makeInt64(BinaryenModuleRef module, Int64 x)
        {
            return BinaryenConst(module, BinaryenLiteralInt64(x));
        }

        static BinaryenExpressionRef makeFloat64(BinaryenModuleRef module, double x)
        {
            return BinaryenConst(module, BinaryenLiteralFloat64(x));
        }

        static BinaryenExpressionRef makeSomething(BinaryenModuleRef module)
        {
            return makeInt32(module, 1337);
        }

        // tests

        static void test_core()
        {

            // Core types

            Console.WriteLine("BinaryenNone: " + BinaryenNone());
            Console.WriteLine("BinaryenInt32: " + BinaryenInt32());
            Console.WriteLine("BinaryenInt64: " + BinaryenInt64());
            Console.WriteLine("BinaryenFloat32: " + BinaryenFloat32());
            Console.WriteLine("BinaryenFloat64: " + BinaryenFloat64());

            // Module creation

            BinaryenModuleRef module = BinaryenModuleCreate();

            // Literals and consts

            BinaryenExpressionRef constI32 = BinaryenConst(module, BinaryenLiteralInt32(1)),
                                  constI64 = BinaryenConst(module, BinaryenLiteralInt64(2)),
                                  constF32 = BinaryenConst(module, BinaryenLiteralFloat32(3.14f)),
                                  constF64 = BinaryenConst(module, BinaryenLiteralFloat64(2.1828)),
                                  constF32Bits = BinaryenConst(module, BinaryenLiteralFloat32Bits(-60876)), // ffff1234 is -60876 (signed)
                                  constF64Bits = BinaryenConst(module, BinaryenLiteralFloat64Bits(-261458978362419)); // 0xffff12345678abcd is -261458978362419 (signed)

            string switchValueNames = "the-value";
            string switchBodyNames = "the-body";

            BinaryenExpressionRef[] callOperands2 = { makeInt32(module, 13), makeFloat64(module, 3.7) };
            BinaryenExpressionRef[] callOperands4 = { makeInt32(module, 13), makeInt64(module, 37), makeFloat32(module, 1.3f), makeFloat64(module, 3.7) };

            BinaryenType[] Params = { BinaryenInt32(), BinaryenInt64(), BinaryenFloat32(), BinaryenFloat64() };
            BinaryenFunctionTypeRef iiIfF = BinaryenAddFunctionType(module, "iiIfF", BinaryenInt32(), Params, 4);

            BinaryenExpressionRef[] bodyList = {
                // Unary
                makeUnary(module, BinaryenClz(), 1),
                makeUnary(module, BinaryenCtz(), 2),
                makeUnary(module, BinaryenPopcnt(), 1),
                makeUnary(module, BinaryenNeg(), 3),
                makeUnary(module, BinaryenAbs(), 4),
                makeUnary(module, BinaryenCeil(), 3),
                makeUnary(module, BinaryenFloor(), 4),
                makeUnary(module, BinaryenTrunc(), 3),
                makeUnary(module, BinaryenNearest(), 3),
                makeUnary(module, BinaryenSqrt(), 4),
                makeUnary(module, BinaryenEqZ(), 1),
                makeUnary(module, BinaryenExtendSInt32(), 1),
                makeUnary(module, BinaryenExtentUInt32(), 1),
                makeUnary(module, BinaryenWrapInt64(), 2),
                makeUnary(module, BinaryenTruncSFloat32ToInt32(), 3),
                makeUnary(module, BinaryenTruncSFloat32ToInt64(), 3),
                makeUnary(module, BinaryenTruncUFloat32ToInt32(), 3),
                makeUnary(module, BinaryenTruncUFloat32ToInt64(), 3),
                makeUnary(module, BinaryenTruncSFloat64ToInt32(), 4),
                makeUnary(module, BinaryenTruncSFloat64ToInt64(), 4),
                makeUnary(module, BinaryenTruncUFloat64ToInt32(), 4),
                makeUnary(module, BinaryenTruncUFloat64ToInt64(), 4),
                makeUnary(module, BinaryenReinterpretFloat32(), 3),
                makeUnary(module, BinaryenReinterpretFloat64(), 4),
                makeUnary(module, BinaryenConvertSInt32ToFloat32(), 1),
                makeUnary(module, BinaryenConvertSInt32ToFloat64(), 1),
                makeUnary(module, BinaryenConvertUInt32ToFloat32(), 1),
                makeUnary(module, BinaryenConvertUInt32ToFloat64(), 1),
                makeUnary(module, BinaryenConvertSInt64ToFloat32(), 2),
                makeUnary(module, BinaryenConvertSInt64ToFloat64(), 2),
                makeUnary(module, BinaryenConvertUInt64ToFloat32(), 2),
                makeUnary(module, BinaryenConvertUInt64ToFloat64(), 2),
                makeUnary(module, BinaryenPromoteFloat32(), 3),
                makeUnary(module, BinaryenDemoteFloat64(), 4),
                makeUnary(module, BinaryenReinterpretInt32(), 1),
                makeUnary(module, BinaryenReinterpretInt64(), 1),
                // Binary
                makeBinary(module, BinaryenAdd(), 1),
                makeBinary(module, BinaryenSub(), 4),
                makeBinary(module, BinaryenDivS(), 1),
                makeBinary(module, BinaryenDivU(), 2),
                makeBinary(module, BinaryenRemS(), 2),
                makeBinary(module, BinaryenRemU(), 1),
                makeBinary(module, BinaryenAnd(), 1),
                makeBinary(module, BinaryenOr(), 2),
                makeBinary(module, BinaryenXor(), 1),
                makeBinary(module, BinaryenShl(), 2),
                makeBinary(module, BinaryenShrU(), 2),
                makeBinary(module, BinaryenShrS(), 1),
                makeBinary(module, BinaryenRotL(), 1),
                makeBinary(module, BinaryenRotR(), 2),
                makeBinary(module, BinaryenDiv(), 3),
                makeBinary(module, BinaryenCopySign(), 4),
                makeBinary(module, BinaryenMin(), 3),
                makeBinary(module, BinaryenMax(), 4),
                makeBinary(module, BinaryenEq(), 1),
                makeBinary(module, BinaryenNe(), 3),
                makeBinary(module, BinaryenLtS(), 1),
                makeBinary(module, BinaryenLtU(), 2),
                makeBinary(module, BinaryenLeS(), 2),
                makeBinary(module, BinaryenLeU(), 1),
                makeBinary(module, BinaryenGtS(), 2),
                makeBinary(module, BinaryenGtU(), 1),
                makeBinary(module, BinaryenGeS(), 1),
                makeBinary(module, BinaryenGeU(), 2),
                makeBinary(module, BinaryenLt(), 3),
                makeBinary(module, BinaryenLe(), 4),
                makeBinary(module, BinaryenGt(), 4),
                makeBinary(module, BinaryenGe(), 3),
                // All the rest
                BinaryenBlock(module, "", new BinaryenModuleRef[0], 0), // block with no name
                BinaryenIf(module, makeInt32(module, 1), makeInt32(module, 2), makeInt32(module, 3)),
                BinaryenIf(module, makeInt32(module, 4), makeInt32(module, 5), NULL),
                BinaryenLoop(module, "out", "in", makeInt32(module, 0)),
                BinaryenLoop(module, "", "in2", makeInt32(module, 0)),
                BinaryenLoop(module, "", "", makeInt32(module, 0)),
                BinaryenBreak(module, "the-value", makeInt32(module, 0), makeInt32(module, 1)),
                BinaryenBreak(module, "the-body", makeInt32(module, 2), NULL),
                BinaryenBreak(module, "the-value", NULL, makeInt32(module, 3)),
                BinaryenBreak(module, "the-body", NULL, NULL),
                BinaryenSwitch(module, ref switchValueNames, 1, "the-value", makeInt32(module, 0), makeInt32(module, 1)),
                BinaryenSwitch(module, ref switchBodyNames, 1, "the-body", makeInt32(module, 2), NULL),
                BinaryenUnary(module, BinaryenEqZ(), // check the output type of the call node
                  BinaryenCall(module, "kitchen-sinker", callOperands4, 4, BinaryenInt32())
                ),
                BinaryenUnary(module, BinaryenEqZ(), // check the output type of the call node
                  BinaryenCallImport(module, "an-imported", callOperands2, 2, BinaryenFloat32())
                ),
                BinaryenUnary(module, BinaryenEqZ(), // check the output type of the call node
                  BinaryenCallIndirect(module, makeInt32(module, 2449), callOperands4, 4, iiIfF)
                ),
                BinaryenGetLocal(module, 0, BinaryenInt32()),
                BinaryenSetLocal(module, 0, makeInt32(module, 101)),
                BinaryenLoad(module, 4, 0, 0, 0, BinaryenInt32(), makeInt32(module, 1)),
                BinaryenLoad(module, 1, 1, 2, 4, BinaryenInt64(), makeInt32(module, 8)),
                BinaryenLoad(module, 4, 0, 0, 0, BinaryenFloat32(), makeInt32(module, 2)),
                BinaryenLoad(module, 8, 0, 2, 8, BinaryenFloat64(), makeInt32(module, 9)),
                BinaryenStore(module, 4, 0, 0, makeInt32(module, 10), makeInt32(module, 11)),
                BinaryenStore(module, 8, 2, 4, makeInt32(module, 110), makeInt64(module, 111)),
                BinaryenSelect(module, makeInt32(module, 1), makeInt32(module, 3), makeInt32(module, 5)),
                BinaryenReturn(module, NULL),
                BinaryenReturn(module, makeFloat32(module, 1)),
                // TODO: Host
                BinaryenNop(module),
                BinaryenUnreachable(module),
              };

            // Make the main body of the function. one block with a return value, one without
            BinaryenExpressionRef value = BinaryenBlock(module, "the-value", bodyList, (UInt32)bodyList.Length);
            BinaryenExpressionRef body = BinaryenBlock(module, "the-body", new BinaryenExpressionRef[] { value }, 1);

            // Create the function
            BinaryenType[] localTypes = { BinaryenInt32() };
            BinaryenFunctionRef sinker = BinaryenAddFunction(module, "kitchen-sinker", iiIfF, localTypes, 1, body);

            // Imports

            BinaryenType[] iparams = { BinaryenInt32(), BinaryenFloat64() };
            BinaryenFunctionTypeRef fiF = BinaryenAddFunctionType(module, "fiF", BinaryenFloat32(), iparams, 2);
            BinaryenAddImport(module, "an-imported", "module", "base", fiF);

            // Exports

            BinaryenAddExport(module, "kitchen-sinker", "kitchen_sinker");

            // Function table. One per module
            BinaryenFunctionRef[] functions = { sinker };
            BinaryenSetFunctionTable(module, functions, 1);

            // Memory. One per module

            string[] segments = { "hello, world" };
            BinaryenIndex[] segmentOffsets = { 10 };
            BinaryenIndex[] segmentSizes = { 12 };
            BinaryenSetMemory(module, 1, 256, "mem", segments, segmentOffsets, segmentSizes, 1);

            // Start function. One per module

            BinaryenFunctionTypeRef v = BinaryenAddFunctionType(module, "v", BinaryenNone(), new BinaryenType[0], 0);
            BinaryenFunctionRef starter = BinaryenAddFunction(module, "starter", v, new BinaryenType[0], 0, BinaryenNop(module));
            BinaryenSetStart(module, starter);

            // Verify it validates
            System.Diagnostics.Debug.Assert(BinaryenModuleValidate(module) != 0);

            // Print it out
            BinaryenModulePrint(module);

            // Clean up the module, which owns all the objects we created above
            BinaryenModuleDispose(module);
        }
        // Functions


        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenFunctionRef BinaryenAddFunction(BinaryenModuleRef module, string name, BinaryenFunctionTypeRef type, BinaryenType[] localTypes, BinaryenIndex numLocalTypes, BinaryenExpressionRef body);

        // Imports


        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenImportRef BinaryenAddImport(BinaryenModuleRef module, string internalName, string externalModuleName, string externalBaseName, BinaryenFunctionTypeRef type);

        // Exports


        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExportRef BinaryenAddExport(BinaryenModuleRef module, string internalName, string externalName);

        // Function table. One per module

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenSetFunctionTable(BinaryenModuleRef module, BinaryenFunctionRef[] functions, BinaryenIndex numFunctions);

        // Memory. One per module

        // Each segment has data in segments, a start offset in segmentOffsets, and a size in segmentSizes.
        // exportName can be NULL
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenSetMemory(BinaryenModuleRef module, BinaryenIndex initial, BinaryenIndex maximum, string exportName, string[] segments, BinaryenIndex[] segmentOffsets, BinaryenIndex[] segmentSizes, BinaryenIndex numSegments);

        // Start function. One per module

        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenSetStart(BinaryenModuleRef module, BinaryenFunctionRef start);

        //
        // ========== Module Operations ==========
        //

        // Print a module to stdout.
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModulePrint(BinaryenModuleRef module);

        // Validate a module, showing errors on problems.
        //  @return 0 if an error occurred, 1 if validated succesfully
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int BinaryenModuleValidate(BinaryenModuleRef module);

        // Run the standard optimization passes on the module.
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModuleOptimize(BinaryenModuleRef module);

        // Serialize a module into binary form.
        // @return how many bytes were written. This will be less than or equal to bufferSize
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static size_t BinaryenModuleWrite(BinaryenModuleRef module, byte[] output, size_t outputSize);

        // Deserialize a module from binary form.
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenModuleRef BinaryenModuleRead(byte[] input, size_t inputSize);

        //
        // ========== CFG / Relooper ==========
        //
        // General usage is (1) create a relooper, (2) create blocks, (3) add
        // branches between them, (4) render the output.
        //
        // See Relooper.h for more details

        //typedef void* RelooperRef;
        //typedef void* RelooperBlockRef;

        // Create a relooper instance
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static RelooperRef RelooperCreate();

        // Create a basic block that ends with nothing, or with some simple branching
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static RelooperBlockRef RelooperAddBlock(RelooperRef relooper, BinaryenExpressionRef code);

        // Create a branch to another basic block
        // The branch can have code on it, that is executed as the branch happens. this is useful for phis. otherwise, code can be NULL
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void RelooperAddBranch(RelooperBlockRef from, RelooperBlockRef to, BinaryenExpressionRef condition, BinaryenExpressionRef code);

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
        [DllImport(@"..\..\..\x64\Debug\binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef RelooperRenderAndDispose(RelooperRef relooper, RelooperBlockRef entry, BinaryenIndex labelHelper, BinaryenModuleRef module);

        static UIntPtr NULL = UIntPtr.Zero;

        static void test_relooper()
        {
            BinaryenModuleRef module = BinaryenModuleCreate();
            BinaryenFunctionTypeRef v = BinaryenAddFunctionType(module, "v", BinaryenNone(), new UInt32[0], 0); // NULL translated to new UInt32[0]
            BinaryenType[] localTypes = { BinaryenInt32() };

            { // trivial: just one block
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block = RelooperAddBlock(relooper, makeSomething(module));
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "just-one-block", v, localTypes, 1, body);
            }
            { // two blocks
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperAddBranch(block0, block1, NULL, NULL); // no condition, no code on branch
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "two-blocks", v, localTypes, 1, body);
            }
            { // two blocks with code between them
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperAddBranch(block0, block1, NULL, makeInt32(module, 77)); // code on branch
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "two-blocks-plus-code", v, localTypes, 1, body);
            }
            { // two blocks in a loop
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperAddBranch(block0, block1, NULL, NULL);
                RelooperAddBranch(block1, block0, NULL, NULL);
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "loop", v, localTypes, 1, body);
            }
            { // two blocks in a loop with codes
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperAddBranch(block0, block1, NULL, makeInt32(module, 33));
                RelooperAddBranch(block1, block0, NULL, makeInt32(module, -66));
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "loop-plus-code", v, localTypes, 1, body);
            }
            { // split
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperBlockRef block2 = RelooperAddBlock(relooper, makeInt32(module, 2));
                RelooperAddBranch(block0, block1, makeInt32(module, 55), NULL);
                RelooperAddBranch(block0, block2, NULL, NULL);
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "split", v, localTypes, 1, body);
            }
            { // split + code
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperBlockRef block2 = RelooperAddBlock(relooper, makeInt32(module, 2));
                RelooperAddBranch(block0, block1, makeInt32(module, 55), makeInt32(module, 10));
                RelooperAddBranch(block0, block2, NULL, makeInt32(module, 20));
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "split-plus-code", v, localTypes, 1, body);
            }
            { // if
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperBlockRef block2 = RelooperAddBlock(relooper, makeInt32(module, 2));
                RelooperAddBranch(block0, block1, makeInt32(module, 55), NULL);
                RelooperAddBranch(block0, block2, NULL, NULL);
                RelooperAddBranch(block1, block2, NULL, NULL);
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "if", v, localTypes, 1, body);
            }
            { // if + code
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperBlockRef block2 = RelooperAddBlock(relooper, makeInt32(module, 2));
                RelooperAddBranch(block0, block1, makeInt32(module, 55), makeInt32(module, -1));
                RelooperAddBranch(block0, block2, NULL, makeInt32(module, -2));
                RelooperAddBranch(block1, block2, NULL, makeInt32(module, -3));
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "if-plus-code", v, localTypes, 1, body);
            }
            { // if-else
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperBlockRef block2 = RelooperAddBlock(relooper, makeInt32(module, 2));
                RelooperBlockRef block3 = RelooperAddBlock(relooper, makeInt32(module, 3));
                RelooperAddBranch(block0, block1, makeInt32(module, 55), NULL);
                RelooperAddBranch(block0, block2, NULL, NULL);
                RelooperAddBranch(block1, block3, NULL, NULL);
                RelooperAddBranch(block2, block3, NULL, NULL);
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "if-else", v, localTypes, 1, body);
            }
            { // loop+tail
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperBlockRef block2 = RelooperAddBlock(relooper, makeInt32(module, 2));
                RelooperAddBranch(block0, block1, NULL, NULL);
                RelooperAddBranch(block1, block0, makeInt32(module, 10), NULL);
                RelooperAddBranch(block1, block2, NULL, NULL);
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "loop-tail", v, localTypes, 1, body);
            }
            { // nontrivial loop + phi to head
                RelooperRef relooper = RelooperCreate();
                RelooperBlockRef block0 = RelooperAddBlock(relooper, makeInt32(module, 0));
                RelooperBlockRef block1 = RelooperAddBlock(relooper, makeInt32(module, 1));
                RelooperBlockRef block2 = RelooperAddBlock(relooper, makeInt32(module, 2));
                RelooperBlockRef block3 = RelooperAddBlock(relooper, makeInt32(module, 3));
                RelooperBlockRef block4 = RelooperAddBlock(relooper, makeInt32(module, 4));
                RelooperBlockRef block5 = RelooperAddBlock(relooper, makeInt32(module, 5));
                RelooperBlockRef block6 = RelooperAddBlock(relooper, makeInt32(module, 6));
                RelooperAddBranch(block0, block1, NULL, makeInt32(module, 10));
                RelooperAddBranch(block1, block2, makeInt32(module, -2), NULL);
                RelooperAddBranch(block1, block6, NULL, makeInt32(module, 20));
                RelooperAddBranch(block2, block3, makeInt32(module, -6), NULL);
                RelooperAddBranch(block2, block1, NULL, makeInt32(module, 30));
                RelooperAddBranch(block3, block4, makeInt32(module, -10), NULL);
                RelooperAddBranch(block3, block5, NULL, NULL);
                RelooperAddBranch(block4, block5, NULL, NULL);
                RelooperAddBranch(block5, block6, NULL, makeInt32(module, 40));
                BinaryenExpressionRef body = RelooperRenderAndDispose(relooper, block0, 0, module);
                BinaryenFunctionRef sinker = BinaryenAddFunction(module, "nontrivial-loop-plus-phi-to-head", v, localTypes, 1, body);
            }

            System.Diagnostics.Debug.Assert(BinaryenModuleValidate(module) != 0);

            Console.WriteLine("raw:");
            BinaryenModulePrint(module);

            BinaryenModuleOptimize(module);

            System.Diagnostics.Debug.Assert(BinaryenModuleValidate(module) != 0);

            Console.WriteLine("optimized:");
            BinaryenModulePrint(module);

            BinaryenModuleDispose(module);
        }

        static void test_binaries()
        {
            byte[] buffer = new byte[1024];
            size_t size;
            BinaryenModuleRef module;

            { // create a module and write it to binary
                module = BinaryenModuleCreate();
                BinaryenType[] Params = { BinaryenInt32(), BinaryenInt32() };
                BinaryenFunctionTypeRef iii = BinaryenAddFunctionType(module, "iii", BinaryenInt32(), Params, 2);
                BinaryenExpressionRef x = BinaryenGetLocal(module, 0, BinaryenInt32()),
                                      y = BinaryenGetLocal(module, 1, BinaryenInt32());
                BinaryenExpressionRef add = BinaryenBinary(module, BinaryenAdd(), x, y);
                BinaryenFunctionRef adder = BinaryenAddFunction(module, "adder", iii, new UInt32[0], 0, add); // NULL converted to new UInt32[0]
                size = BinaryenModuleWrite(module, buffer, (UInt32)buffer.Length); // write out the module
                BinaryenModuleDispose(module);
            }

            System.Diagnostics.Debug.Assert(size != 0);
            System.Diagnostics.Debug.Assert(size < 512); // this is a tiny module

            // read the module from the binary
            module = BinaryenModuleRead(buffer, size);

            // validate, print, and free
            System.Diagnostics.Debug.Assert(BinaryenModuleValidate(module) == 0);
            Console.WriteLine("module loaded from binary form:");
            BinaryenModulePrint(module);
            BinaryenModuleDispose(module);
        }

        static void Main(string[] args)
        {
            test_core();
            test_relooper();
            test_binaries();
        }
    }
}
