// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Common.Core.docs;

/// <summary>
/// Compensates for missing null-tolerant version in ConfigurationHelper.
/// </summary>
public struct _configurationhelpercore;

/// <summary>
/// Shorthand to check if an environment variable is defined with a specific key and value.
/// </summary>
public struct _environmentvariableisdefined;

/// <summary>
/// <para>
/// Sets or gets flags from bit fields (ints) and flag enums.
/// These otherwise require (hard to remember) bit operations.
/// These helpers can help you out in a moment of confusion.
/// </para>
/// <c>HasFlag</c> to ask: "Is this bit or flag set?" <br/>
/// <c>SetFlag</c> / <c>ClearFlag</c> toggles a single flag <br/>
/// <c>SetFlags</c> / <c>ClearFlags</c> when you’ve got a collection of flags <br/>
/// </summary>
public struct _flagging;

/// <summary> 
/// Returns the current method name or current property name.
/// </summary> 
public struct _name;

/// <summary> 
/// Helper for conversion from code elements to text (a supplement to the <see langword="nameof" /> keyword).
/// </summary> 
public struct _namehelper;

/// <summary>
/// Gets the string representation of an expression.
/// </summary>
/// <param name="expression">What you pass here, gets converted to text, that is returned.</param>
/// <param name="expressionString">Do not set this parameter. It is for internal use.</param>
/// <returns>What you pass as expression will be returned as text for further processing.</returns>
public struct _textof;
