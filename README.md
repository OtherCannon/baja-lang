# Oc-Lang

Oc is a simple data-oriented language designed for fast runtimes and fast programming, without drawbacks such as a garbage collector or complex syntax.

## Building
### Requirements:
- LLVM (Compiled yourself, not the prebuilt binaries)
- MinGW & MSYS2 (If on Windows)

### Building Steps:
1. Clone the repository:
`git clone https://www.github.com/OtherCannon/oc-lang.git oc-lang`
2. Enter the repository folder:
`cd oc-lang`
`cd compiler`
3. Build for your platform:
#### Windows:
`make win64` - 64-bit
`make win32` - 32-bit
#### Linux:
`make linux64` - 64-bit
`make linux32` - 32-bit