win64:
	rm roc.exe
	clang++ main.cc -target x86_64-pc-win32 -o roc.exe

win32:
	rm roc.exe
	clang++ main.cc -target i686-pc-win32 -o roc.exe

linux64:
	rm roc
	clang++ main.cc -target x86_64-pc-linux-elf -o roc

linux32:
	rm roc
	clang++ main.cc -target i686-pc-linux-elf -o roc

clean:
	rm roc
	rm roc.exe