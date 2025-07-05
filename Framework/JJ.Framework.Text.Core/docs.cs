#pragma warning disable CS1574
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Text.Core.docs;

/// <summary>
/// Determines whether the given string ends with a punctuation character,
/// optionally ignoring trailing whitespace.
/// This method is helpful when building strings with multiple optional elements,
/// ensuring proper punctuation is applied only when necessary.
/// 
/// If the string is <c>null</c> or empty, it is treated as the beginning of a line,
/// where no punctuation is required. In this case, the method returns <c>true</c>,
/// indicating no additional punctuation is needed.
/// </summary>
/// <param name="text">
/// The string to evaluate. This parameter can be <c>null</c> or empty.
/// </param>
/// <param name="ignoreWhiteSpace">
/// If set to <c>true</c>, trailing whitespace in the string is ignored before evaluating for punctuation.
/// Defaults to <c>true</c>.
/// </param>
/// <returns>
/// <c>true</c> if the string ends with a punctuation character,
/// or if the string is <c>null</c> or empty (considered as starting a new line).<br/>
/// <c>false</c> if the string does not end with a punctuation character
/// after accounting for <paramref name="ignoreWhiteSpace"/>.
/// </returns>
public struct _endswithpunctuation;
