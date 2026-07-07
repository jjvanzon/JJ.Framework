JJ.Framework.IO.Core
====================

A set of helpers for IO related tasks.  
An extension to [`JJ.Framework.IO.Legacy`](https://www.nuget.org/packages/JJ.Framework.IO.Legacy).

-----

`SanitizeFilePath`

- Removes invalid path chars optionally replacing them with a specific replacement char

-----

Add a `maxExtensionLength` option to:

- `GetFileNameWithoutExtension`
- `GetExtension`
- `HasExtension`
- `IsFile`

For better heuristic differentiation between files and directories.

-----

`GetNumberedFilePath`

Numbers a file path if the original path already exists to prevent clashes e.g.:

- `MyFileToCopy.txt`
- `MyFileToCopy (2).txt`
- `MyFileToCopy (3).txt`

-----

`CreateSafeFileStream`

- A thread-safe variant of numbering file names (e.g. `MyFileToCopy (2).txt`) 
  for highly concurrent scenarios, solving quite some tricky problems, 
  that surface when you pressure the system, 
  having a lot of activity all in one folder.