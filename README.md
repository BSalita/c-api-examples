# c-api-examples in C and CS
Visual Studio 2015 solution for building WebAssembly/binaryen/test/examples/binaryen-c files. Examples are built using test source code in bot C and C#.

1. Builds binaryen-c.cpp into a static library.
2. Builds binaryen-c-dll.c into a dynamic library by DllExporting from the static library.
3. Builds c-api-hello-world.c (uses static library)
4. Builds c-api-kitchen-sink.c (uses static library)
5. Builds cs-api-hello-world.cs (uses dll)
6. Builds c-api-kitchen-sink.cs (uses dll)

To use, clone WebAssembly/binaryen. Be sure to edit all this repos project files (.vcxproj) to path source files at the binaryen cloned directory.
