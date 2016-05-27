// Be sure to explicitly set Properties->Build->Platform target property to match DllImport (x64 to x64, x86 to x86). Any other Platform target won't work.  
// If debugging required, best to enable native debugging; Properties->Debug->Enable native code debugging.

using System;
using System.Runtime.InteropServices; // DllImport

namespace cs_api_hello_world_staticlib
{
    // using is closest match to a C++ typedef.
    using BinaryenModuleRef = UIntPtr;
    using BinaryenExpressionRef = UIntPtr;
    using BinaryenFunctionTypeRef = UIntPtr;
    using BinaryenType = UInt32;
    using BinaryenIndex = UInt32;
    using BinaryenOp = Int32;
    using BinaryenFunctionRef = UIntPtr;

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
        extern static BinaryenModuleRef BinaryenModuleCreate();

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenType BinaryenInt32();

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenFunctionTypeRef BinaryenAddFunctionType(BinaryenModuleRef module, string name, BinaryenType result, BinaryenType[] paramTypes, BinaryenIndex numParams);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenGetLocal(BinaryenModuleRef module, BinaryenIndex Index, BinaryenType type);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenExpressionRef BinaryenBinary(BinaryenModuleRef module, BinaryenOp op, BinaryenExpressionRef left, BinaryenExpressionRef right);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenOp BinaryenAddInt32();

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static BinaryenFunctionRef BinaryenAddFunction(BinaryenModuleRef module, string name, BinaryenFunctionTypeRef type, BinaryenType[] localTypes, BinaryenIndex numLocalTypes, BinaryenExpressionRef body);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModulePrint(BinaryenModuleRef module);

        [DllImport(@"binaryen-c-dll.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void BinaryenModuleDispose(BinaryenModuleRef module);

        static void Main(string[] args)
        {
            BinaryenModuleRef module = BinaryenModuleCreate();

            // Creation a function type for  i32 (i32, i32)
            BinaryenType[] Params = new BinaryenType[2] { BinaryenInt32(), BinaryenInt32() };
            BinaryenFunctionTypeRef iii = BinaryenAddFunctionType(module, "iii", BinaryenInt32(), Params, 2);

            // Get the 0 and 1 arguments, and add them
            BinaryenExpressionRef x = BinaryenGetLocal(module, 0, BinaryenInt32()),
                                  y = BinaryenGetLocal(module, 1, BinaryenInt32());
            BinaryenExpressionRef add = BinaryenBinary(module, BinaryenAddInt32(), x, y);

            // Create the add function
            // Note: no additional local variables
            // Note: no basic blocks here, we are an AST. The function body is just an expression node.
            BinaryenFunctionRef adder = BinaryenAddFunction(module, "adder", iii, new uint[1], 0, add);

            // Print it out
            BinaryenModulePrint(module);

            // Clean up the module, which owns all the objects we created above
            BinaryenModuleDispose(module);
        }
    }
}
