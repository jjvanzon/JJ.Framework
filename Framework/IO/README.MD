# JJ.Framework.IO

Contains various file functions, functions for working with streams and working with CSV's.

* `CsvReader`: A class for reading out CSV files.
* `StreamHelper`: Converts between `string`, `Stream` and `byte[]`. Surprisingly different code is required for converting between those three, and this helper class makes it a bit more consistent.
* `BinaryWriterExtensions`: Contains some methods for reading and writing `structs` to a `Stream`.
* `GetNumberedFilePath`: A method for inserting numbers in file paths in case the file name already exists.
* `ClearFolder` / `ClearFolderRecursive`: Recursively clearing a directory, whereas `Directory.Delete(path, bool recursive)` would delete the directory itself.
* `ApplicationFolderPath`: Gets that path without command line parameters, or executable file name, etc.
* `GetFolderSize` / `GetFolderSizeRecursive`: Methods for counting the total number of bytes in a folder, including a recursive variation.
* `CountFilesRecursive`
* `IsFolder` / `IsFile`: Checks if a path is regarded to be a folder or a file, which is not always obvious.
* `FolderIsEmpty` method.
* Easily working with file attributes.
* Converting between relative path and absolute path.
* A method for comparing two paths, regardess of them being absolute or relative.
* `PathParser`: Neatly splits up a file path into its smaller parts.
* `SafeFileOverwriter`: First writes to a temporary file and only when all went well, the original file is overwritten. The security settings and file attributes and file properties are retained as the temp file replaces the original.