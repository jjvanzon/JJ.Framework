#pragma warning disable CS1574 // Parameter name not found
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Text.Core.docs;
 
/// <summary>
/// Formats an amount of seconds into a pretty format fore pretty loggings.
/// Prettiness is disputable. Examples:
/// <list>
///   <item>1.00 h</item>
///   <item>1.50 min</item>
///   <item>1.00 min</item>
///   <item>30.00 s</item>
///   <item>1.00 s</item>
///   <item>500 ms</item>
/// </list>
/// </summary>
/// <param name="sec">Amount of seconds to format as a "pretty" text. </param>
public struct _prettyduration;

/// <summary>
/// Returns the time span as text with units like 
/// <c>d</c>, <c>h</c>, <c>min</c>, <c>s</c>, <c>ms</c> and <c>μs</c>,
/// as a single number with 2-decimal precision, like:
/// <c>2.63 d</c> | <c>2.35 h</c> | <c>1.50 min</c> | 
/// <c>1.23 s</c> | <c>3.54 ms</c> | <c>573.23 μs</c>
/// <br/>
/// Can be used to prettify logging and console output.
/// </summary>
public struct _prettytimespan;

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

/// <summary>
/// Syntax sugar for original string.Replace method,
/// where char and string can be mixed as arguments.
/// </summary>
public struct _replace;

/// <summary>
/// Replaces accented characters in the string (é, ñ, ü) with their unaccented equivalents (e, n, u).
/// Intended for normalization before search, sorting or comparison.
/// </summary>
public struct _removeaccents;
       