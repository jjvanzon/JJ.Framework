#pragma warning disable IDE1006 // Naming Styles
// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Logging.Core.docs;

/// <summary>
/// Does not include the ".wishes" part for future compatibility.
/// </summary>
public struct _defaultconfigsectionname; 

/// <summary>
/// A separate excluded categories collection allows filtering out categories 
/// even when the initial category list is empty, where direct removal wouldn't be possible.
/// </summary>
public struct _loggerexcludedcategories;
    
/// <summary>
/// Allows specifying the format of the output log messages,
/// namely the occurrence or leaving out of the elements: timestamp, category and message,
/// {0}, {1} and {2} respectively (for now).
/// </summary>
public struct _loggerformat;

/// <summary>
/// Specifies the logger type. Options include:
/// <list type="bullet">
/// <item>LoggerEnum values (e.g., Console, DebugOutput).</item>
/// <item>Assembly name containing an ILogger implementation.</item>
/// <item>Full .NET Type string indicating an implementation of ILogger.</item>
/// </list>
/// </summary>
public struct _loggertype;

/// <inheritdoc cref="_loggertype" />
/// <remarks>Multiple values allowed separated by semi-colons.</remarks>
public struct _loggertypes;
