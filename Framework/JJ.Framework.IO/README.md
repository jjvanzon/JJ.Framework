JJ.Framework.IO.Legacy
======================

Contains various file functions, functions for working with streams and working with CSV's.

* `CsvReader`: A class for reading out CSV files.
* `StreamHelper`: Converts between `string`, `Stream` and `byte[]`. Surprisingly different code is required for converting between those three, and this helper class makes it a bit more consistent.
* `BinaryWriterExtensions`: Contains some methods for reading and writing `structs` to a `Stream`.

Historic release for compatibility with older projects, now upgraded to the newest .NET, doc comments everywhere and compatible with code trimming and native compilation.

Release Notes
--------------

|         |               |     |
|---------|---------------|-----|
| `0.250` | __IO.Legacy__ | Full test coverage, and member docs.
|         |               | Release of historic version.
|         |               | Features:
|         |               | `CsvReader`: lightweight streaming CSV reader
|         |               | `StreamHelper`: converts between `Stream`, `byte[]` and `string`
|         |               | `ReadStruct`/`WriteStruct`: simply read and write structs to streams
|         |               | Bug fix: `CsvReader` preserves a trailing escaped quotes
|         |               | Bug fix: `CsvReader` solved crash over trailing new line


💬 Feedback
============

Got feedback or questions? You can reach me [here.](https://jjvanzon.github.io/#-how-to-reach-me)