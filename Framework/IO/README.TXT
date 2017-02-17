JJ.Framework.IO is a place to put code for working with different basic file formats and streams and other basic file functions.

Currently it contains:
- CsvReader: a class for reading out CSV files
- StreamHelper: converts between string, Stream and byte[]. Surprisingly different code is required for converting between those three, and this helper class makes it a bit more consistent.
- BinaryWriterExtensions contains some methods for reading and writing structs to a stream.
- FileHelper / FileInfoExtensions / DirectoryInfoExtensions among other things contain:
	- GetNumberedFilePath: A method for inserting numbers in file paths in case the file name already exists.
	- ClearFolder / ClearFolderRecursive: Recursively clearing a directory, whereas Directory.Delete(path, bool recursive) also deletes the directory itself.
	- ApplicationFolderPath: Gets that path without command line parameters, or executable file name, etc.
	- GetFolderSize / GetFolderSizeRecursive: Methods for counting the total number of bytes in a folder, including a recursive variation.
	- CountFileRecursive
	- IsFolder/ IsFile: Checks if a path is regarded to be a folder or a file.
	- FolderIsEmpty method.
	- Easily working with file attributes.
	- Converting between relative path and absolute path.
	- A method for comparing two paths.
- PathParser: Neatly splits up a string file path into its smaller parts.