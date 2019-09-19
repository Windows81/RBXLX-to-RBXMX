# rbxlx2rbxmx
Automatically creates an `.rbxmx` file from a specific object, given a `.rbxlx` file, using a command-line interface.

**You can download the executable [here](https://github.com/Windows81/rbxlx2rbxmx/raw/master/RBXLX-to-RBXMX/bin/Debug/RBXLX-to-RBXMX.exe).**
## Usage
*Note: familiarity with command-line arguments is highly recommended.*  This program takes in a variable number of arguments (minimum 3).

The first argument is a path to the `.rbxlx` file from which you wish to extract information.  The second argument is a path to the `.rbxmx` file you wish to create/overwrite.  All subsequent arguments guide the reference item using the original file's heirarchy, starting from name of the service.
### Example syntax (as given in demo)
```console
RBXLX-to-RBXMX "demo.rbxlx" "demo.rbxmx" Workspace VisualPlugin
```
