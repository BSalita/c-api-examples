# c-api-examples
Visual Studio 2015 solution for building WebAssembly/binaryen/test/examples/binaryen-c files.

1. Builds binaryen-c.cpp into a static library.
2. Builds binaryen-c-dll.c into a dynamic library by DllExporting from the static library.
3. Builds c-api-hello-world.c
4. Builds c-api-kitchen-sink.c
5. Builds cs-api-hello-world.c
6. Builds c-api-kitchen-sink.c

To use, clone WebAssembly/binaryen. Be sure to edit all this repos project files (.vcxproj) to path source files at the binaryen cloned directory.
