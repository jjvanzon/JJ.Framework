JJ.Framework.IO.Legacy
======================

Contains various file functions, functions for working with streams and working with CSV's.

* `CsvReader`: A class for reading out CSV files.
* `StreamHelper`: Converts between `string`, `Stream` and `byte[]`. Surprisingly different code is required for converting between those three, and this helper class makes it a bit more consistent.
* `BinaryWriterExtensions`: Contains some methods for reading and writing `structs` to a `Stream`.

Historic release for compatibility with older projects, now upgraded to the newest .NET, doc comments everywhere and compatible with code trimming and native compilation.


💬 Feedback
============

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)