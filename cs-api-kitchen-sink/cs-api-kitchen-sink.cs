// Be sure to explicitly set Properties->Build->Platform target property to match DllImport (x64 to x64, x86 to x86). Any other Platform target won't work.  
// If debugging required, best to enable native debugging; Properties->Debug->Enable native code debugging.

using System;
using System.Runtime.InteropServices; // DllImport

namespace cs_api_hello_world_staticlib
{
    // using is closest match to a C++ typedef.
    using RelooperBlockRef = UIntPtr;
    using BinaryenExportRef = UIntPtr;
    using BinaryenExpressionRef = UIntPtr;
    using BinaryenFunctionRef = UIntPtr;
    using BinaryenFunctionTypeRef = UIntPtr;
    using BinaryenImportRef = UIntPtr;
    using BinaryenIndex = UInt32;
    using BinaryenModuleRef = UIntPtr;
    using BinaryenOp = Int32;
    using RelooperRef = UIntPtr;
    using BinaryenType = UInt32;
    using int32_t = Int32;
    using int64_t = Int64;
    using int8_t = SByte;
    using size_t = UIntPtr;
    using uint32_t = UInt32;

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
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenNone();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenFloat64();

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenModuleRef BinaryenModuleCreate();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModuleDispose(BinaryenModuleRef module);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenFunctionTypeRef BinaryenAddFunctionType(BinaryenModuleRef module, string name, BinaryenType result, BinaryenType[] paramTypes, BinaryenIndex numParams);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralInt32(int32_t x);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralInt64(int64_t x);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat32(float x);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat64(double x);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat32Bits(int32_t x);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenLiteral BinaryenLiteralFloat64Bits(int64_t x);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenClzInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCtzInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenPopcntInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNegFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAbsFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCeilFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenFloorFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNearestFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSqrtFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEqZInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenClzInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCtzInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenPopcntInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNegFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAbsFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCeilFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenFloorFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNearestFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSqrtFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEqZInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenExtendSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenExtentUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenWrapInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat32ToInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat32ToInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat32ToInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat32ToInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat64ToInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncSFloat64ToInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat64ToInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenTruncUFloat64ToInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt32ToFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt32ToFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt32ToFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt32ToFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt64ToFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertSInt64ToFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt64ToFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenConvertUInt64ToFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenPromoteFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDemoteFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenReinterpretInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAddInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSubInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMulInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRemSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRemUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAndInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenOrInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenXorInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShlInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShrUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShrSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRotLInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRotRInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEqInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNeInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeSInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeUInt32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAddInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSubInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMulInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivSInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivUInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRemSInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRemUInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAndInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenOrInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenXorInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShlInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShrUInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenShrSInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRotLInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenRotRInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEqInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNeInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtSInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtUInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeSInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeUInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtSInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtUInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeSInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeUInt64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAddFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSubFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMulFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCopySignFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMinFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMaxFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEqFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNeFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeFloat32();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAddFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenSubFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMulFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenDivFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCopySignFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMinFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenMaxFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenEqFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenNeFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLtFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenLeFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGtFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGeFloat64();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenPageSize();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenCurrentMemory();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenGrowMemory();
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenHasFeature();

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenBlock(BinaryenModuleRef module, string name, BinaryenExpressionRef[] children, BinaryenIndex numChildren);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenIf(BinaryenModuleRef module, BinaryenExpressionRef condition, BinaryenExpressionRef ifTrue, BinaryenExpressionRef ifFalse);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenLoop(BinaryenModuleRef module, string Out, string In, BinaryenExpressionRef body);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenBreak(BinaryenModuleRef module, string name, BinaryenExpressionRef condition, BinaryenExpressionRef value);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenSwitch(BinaryenModuleRef module, string[] names, BinaryenIndex numNames, string defaultName, BinaryenExpressionRef condition, BinaryenExpressionRef value);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenCall(BinaryenModuleRef module, string target, BinaryenExpressionRef[] operands, BinaryenIndex numOperands, BinaryenType returnType);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenCallImport(BinaryenModuleRef module, string target, BinaryenExpressionRef[] operands, BinaryenIndex numOperands, BinaryenType returnType);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenCallIndirect(BinaryenModuleRef module, BinaryenExpressionRef target, BinaryenExpressionRef[] operands, BinaryenIndex numOperands, BinaryenFunctionTypeRef type);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenGetLocal(BinaryenModuleRef module, BinaryenIndex index, BinaryenType type);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenSetLocal(BinaryenModuleRef module, BinaryenIndex index, BinaryenExpressionRef value);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenLoad(BinaryenModuleRef module, uint32_t bytes, int8_t signed_, uint32_t offset, uint32_t align, BinaryenType type, BinaryenExpressionRef ptr);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenStore(BinaryenModuleRef module, uint32_t bytes, uint32_t offset, uint32_t align, BinaryenExpressionRef ptr, BinaryenExpressionRef value);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenConst(BinaryenModuleRef module, BinaryenLiteral value); // was struct BinaryenLiteral
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenUnary(BinaryenModuleRef module, BinaryenOp op, BinaryenExpressionRef value);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenBinary(BinaryenModuleRef module, BinaryenOp op, BinaryenExpressionRef left, BinaryenExpressionRef right);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenSelect(BinaryenModuleRef module, BinaryenExpressionRef condition, BinaryenExpressionRef ifTrue, BinaryenExpressionRef ifFalse);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenReturn(BinaryenModuleRef module, BinaryenExpressionRef value);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenHost(BinaryenModuleRef module, BinaryenOp op, string name, BinaryenExpressionRef[] operands, BinaryenIndex numOperands);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenNop(BinaryenModuleRef module);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenUnreachable(BinaryenModuleRef module);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenFunctionRef BinaryenAddFunction(BinaryenModuleRef module, string name, BinaryenFunctionTypeRef type, BinaryenType[] localTypes, BinaryenIndex numLocalTypes, BinaryenExpressionRef body);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenImportRef BinaryenAddImport(BinaryenModuleRef module, string internalName, string externalModuleName, string externalBaseName, BinaryenFunctionTypeRef type);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExportRef BinaryenAddExport(BinaryenModuleRef module, string internalName, string externalName);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenSetFunctionTable(BinaryenModuleRef module, BinaryenFunctionRef[] functions, BinaryenIndex numFunctions);
        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenSetMemory(BinaryenModuleRef module, BinaryenIndex initial, BinaryenIndex maximum, string exportName, string[] segments, BinaryenIndex[] segmentOffsets, BinaryenIndex[] segmentSizes, BinaryenIndex numSegments);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenSetStart(BinaryenModuleRef module, BinaryenFunctionRef start);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModulePrint(BinaryenModuleRef module);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int BinaryenModuleValidate(BinaryenModuleRef module);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModuleOptimize(BinaryenModuleRef module);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static size_t BinaryenModuleWrite(BinaryenModuleRef module, byte[] output, size_t outputSize); // string converted to byte[]

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenModuleRef BinaryenModuleRead(byte[] input, size_t inputSize);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static RelooperRef RelooperCreate();

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static RelooperBlockRef RelooperAddBlock(RelooperRef relooper, BinaryenExpressionRef code);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void RelooperAddBranch(RelooperBlockRef from, RelooperBlockRef to, BinaryenExpressionRef condition, BinaryenExpressionRef code);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef RelooperRenderAndDispose(RelooperRef relooper, RelooperBlockRef entry, BinaryenIndex labelHelper, BinaryenModuleRef module);

        static UIntPtr NULL = UIntPtr.Zero;

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

            string[] switchValueNames = { "the-value" };
            string[] switchBodyNames = { "the-body" };

            BinaryenExpressionRef[] callOperands2 = { makeInt32(module, 13), makeFloat64(module, 3.7) };
            BinaryenExpressionRef[] callOperands4 = { makeInt32(module, 13), makeInt64(module, 37), makeFloat32(module, 1.3f), makeFloat64(module, 3.7) };

            BinaryenType[] Params = { BinaryenInt32(), BinaryenInt64(), BinaryenFloat32(), BinaryenFloat64() };
            BinaryenFunctionTypeRef iiIfF = BinaryenAddFunctionType(module, "iiIfF", BinaryenInt32(), Params, 4);

            BinaryenExpressionRef[] bodyList = {
                // Unary
		        makeUnary(module, BinaryenClzInt32(), 1),
                makeUnary(module, BinaryenCtzInt64(), 2),
                makeUnary(module, BinaryenPopcntInt32(), 1),
                makeUnary(module, BinaryenNegFloat32(), 3),
                makeUnary(module, BinaryenAbsFloat64(), 4),
                makeUnary(module, BinaryenCeilFloat32(), 3),
                makeUnary(module, BinaryenFloorFloat64(), 4),
                makeUnary(module, BinaryenTruncFloat32(), 3),
                makeUnary(module, BinaryenNearestFloat32(), 3),
                makeUnary(module, BinaryenSqrtFloat64(), 4),
                makeUnary(module, BinaryenEqZInt32(), 1),
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
                makeUnary(module, BinaryenReinterpretInt64(), 2),
		        // Binary
		        makeBinary(module, BinaryenAddInt32(), 1),
                makeBinary(module, BinaryenSubFloat64(), 4),
                makeBinary(module, BinaryenDivSInt32(), 1),
                makeBinary(module, BinaryenDivUInt64(), 2),
                makeBinary(module, BinaryenRemSInt64(), 2),
                makeBinary(module, BinaryenRemUInt32(), 1),
                makeBinary(module, BinaryenAndInt32(), 1),
                makeBinary(module, BinaryenOrInt64(), 2),
                makeBinary(module, BinaryenXorInt32(), 1),
                makeBinary(module, BinaryenShlInt64(), 2),
                makeBinary(module, BinaryenShrUInt64(), 2),
                makeBinary(module, BinaryenShrSInt32(), 1),
                makeBinary(module, BinaryenRotLInt32(), 1),
                makeBinary(module, BinaryenRotRInt64(), 2),
                makeBinary(module, BinaryenDivFloat32(), 3),
                makeBinary(module, BinaryenCopySignFloat64(), 4),
                makeBinary(module, BinaryenMinFloat32(), 3),
                makeBinary(module, BinaryenMaxFloat64(), 4),
                makeBinary(module, BinaryenEqInt32(), 1),
                makeBinary(module, BinaryenNeFloat32(), 3),
                makeBinary(module, BinaryenLtSInt32(), 1),
                makeBinary(module, BinaryenLtUInt64(), 2),
                makeBinary(module, BinaryenLeSInt64(), 2),
                makeBinary(module, BinaryenLeUInt32(), 1),
                makeBinary(module, BinaryenGtSInt64(), 2),
                makeBinary(module, BinaryenGtUInt32(), 1),
                makeBinary(module, BinaryenGeSInt32(), 1),
                makeBinary(module, BinaryenGeUInt64(), 2),
                makeBinary(module, BinaryenLtFloat32(), 3),
                makeBinary(module, BinaryenLeFloat64(), 4),
                makeBinary(module, BinaryenGtFloat64(), 4),
                makeBinary(module, BinaryenGeFloat32(), 3),
		        // All the rest
		        BinaryenBlock(module, null, null, 0), // block with no name
		        BinaryenIf(module, makeInt32(module, 1), makeInt32(module, 2), makeInt32(module, 3)),
                BinaryenIf(module, makeInt32(module, 4), makeInt32(module, 5), NULL),
                BinaryenLoop(module, "out", "in", makeInt32(module, 0)),
                BinaryenLoop(module, null, "in2", makeInt32(module, 0)),
                BinaryenLoop(module, null, null, makeInt32(module, 0)),
                BinaryenBreak(module, "the-value", makeInt32(module, 0), makeInt32(module, 1)),
                BinaryenBreak(module, "the-nothing", makeInt32(module, 2), NULL),
                BinaryenBreak(module, "the-value", NULL, makeInt32(module, 3)),
                BinaryenBreak(module, "the-nothing", NULL, NULL),
                BinaryenSwitch(module, switchValueNames, 1, "the-value", makeInt32(module, 0), makeInt32(module, 1)),
                BinaryenSwitch(module, switchBodyNames, 1, "the-nothing", makeInt32(module, 2), NULL),
                BinaryenUnary(module, BinaryenEqZInt32(), // check the output type of the call node
		        BinaryenCall(module, "kitchen-sinker", callOperands4, 4, BinaryenInt32())
                ),
                BinaryenUnary(module, BinaryenEqZInt32(), // check the output type of the call node
			        BinaryenUnary(module,
                        BinaryenTruncSFloat32ToInt32(),
                        BinaryenCallImport(module, "an-imported", callOperands2, 2, BinaryenFloat32())
                    )
                ),
                BinaryenUnary(module, BinaryenEqZInt32(), // check the output type of the call node
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
                BinaryenReturn(module, makeInt32(module, 1337)),
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

        static void test_relooper()
        {
            BinaryenModuleRef module = BinaryenModuleCreate();
            BinaryenFunctionTypeRef v = BinaryenAddFunctionType(module, "v", BinaryenNone(), null, 0); // NULL translated to null or new UInt32[0]?
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
                BinaryenExpressionRef add = BinaryenBinary(module, BinaryenAddInt32(), x, y);
                BinaryenFunctionRef adder = BinaryenAddFunction(module, "adder", iii, new UInt32[0], 0, add); // NULL converted to new UInt32[0]
                size = BinaryenModuleWrite(module, buffer, (UIntPtr)buffer.Length); // write out the module
                BinaryenModuleDispose(module);
            }

            System.Diagnostics.Debug.Assert(size.ToUInt64() != 0);
            System.Diagnostics.Debug.Assert(size.ToUInt64() < 512); // this is a tiny module

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
