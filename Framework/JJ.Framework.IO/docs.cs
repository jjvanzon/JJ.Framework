// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

namespace JJ.Framework.IO.Legacy.docs;

/// <summary>
/// Reads CSV data from a stream. Supports quoted fields and escaped quotes.
/// Separator is a hard-coded comma in this version.
/// </summary>
public struct _csvreader;

/// <summary>
/// Dispose managed resources held by the object (such as the underlying <c>StreamReader</c>).
/// </summary>
public struct _dispose;

/// <summary>
/// Read the next CSV line. Returns <c>true</c> when a line was available and parsed; <c>false</c> at end of stream.
/// </summary>
public struct _csvread;

/// <summary>
/// Indexer to obtain the parsed field value by zero-based column index for the most recently read line.
/// </summary>
public struct _csvindexer;

/// <summary>
/// Helper methods for converting between <see cref="string"/>, <see cref="byte"/>[] and <see cref="Stream"/>.
/// Surprisingly different code is required for converting between those three,
/// and this helper class makes it a bit more consistent.
/// </summary>
public struct _streamhelper;

/// <summary>
/// Convert the entire stream to a byte array. The stream position is read from its current position.
/// </summary>
public struct _streamtobytes;

/// <summary>
/// Turns a <see cref="byte"/> array into a <see cref="Stream"/> so it can be used with common IO methods.
/// </summary>
public struct _bytestostream;

/// <summary>
/// Read a <see cref="Stream"/> into a <see cref="string"/> using the provided <see cref="Encoding"/>.
/// </summary>
public struct _streamtostring;

/// <summary>
/// Create a <see cref="Stream"/> from a <see cref="string"/> using the provided <see cref="Encoding"/> (usually set to <see cref="Encoding.UTF8"/>).
/// </summary>
public struct _stringtostream;

/// <summary>
/// Convert a <see cref="string"/> to a <see cref="byte"/>[] using the provided <see cref="Encoding"/> (usually set to <see cref="Encoding.UTF8"/>).
/// </summary>
public struct _stringtobytes;

/// <summary>
/// Convert a <see cref="byte"/>[] to a <see cref="string"/> using the provided <see cref="Encoding"/> (usually set to <see cref="Encoding.UTF8"/>).
/// </summary>
public struct _bytestostring;
