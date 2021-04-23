win64:
	clang++ main.cc -g -O3 `llvm-config --cxxflags --ldflags --system-libs --libs core` -target x86_64-pc-win32 -o roc.exe

win32:
	clang++ main.cc -target i686-pc-win32 -o roc.exe

linux64:
	clang++ main.cc -g -O3 `llvm-config --cxxflags --ldflags --system-libs --libs core` -target x86_64-pc-linux-elf -o roc

linux32:
	clang++ main.cc -target i686-pc-linux-elf -o roc

cleanwin:
	rm roc.exe

cleanlinux:
	rm roc