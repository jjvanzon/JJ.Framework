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
