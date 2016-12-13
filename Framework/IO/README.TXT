JJ.Framework.IO is a place to put code for working with different basic file formats and streams.

Currently it contains:
- CsvReader: a class for reading out CSV files
- StreamHelper: converts between string, Stream and byte[]. Surprisingly different code is required for converting between those three, and this helper class makes it a bit more consistent.
- BinaryWriterExtensions contains some methods for reading and writing structs to a stream.