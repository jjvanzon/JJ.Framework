#pragma warning disable CS1574 // Parameter name not found
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Text.Core.docs;

/// <summary>
/// Misc text processing methods to:
/// <list type="bullet">
///   <item>Prettify logs and console output.</item>
///   <item>Deal with blank lines, punctuation and accents.</item>
///   <item>
///     Overloads of basic methods like <c>Trim</c> and <c>Replace</c> <br/>
///     that vary by parameters of types <c>char</c> and <c>string</c>.
///   </item>
/// </list>
/// </summary>
public struct _textcore;

/// <inheritdoc cref="_textcore" />
public struct _stringhelpercore;

/// <inheritdoc cref="_textcore" />
public struct _stringextensionscore;
 
/// <inheritdoc cref="_prettytimespan" />
public struct _prettyduration;

/// <summary>
/// Formats an amount of seconds into a pretty format for pretty loggings.
/// Prettiness is disputable. Examples:
/// <c>2.63 d</c> | <c>2.35 h</c> | <c>1.50 min</c> | 
/// <c>1.23 s</c> | <c>3.54 ms</c> | <c>573.23 μs</c>
/// </summary>
/// <param name="sec">Amount of seconds to format as a "pretty" text. </param>
public struct _prettytimespan;

/// <summary>
/// <para>
/// Returns the time in an arguably pretty format,
/// for loggings and console text output, e.g.,
/// <c>14:30:45.123</c>.
/// </para>
/// 
/// <para>
/// The input is a <c>DateTime</c> or if omitted, 
/// <c>DateTime.Now</c>.
/// Will only display the time part.
/// </para>
/// </summary>
public struct _prettytime;

/// <summary>
/// <para>
/// Returns byte count for logging, with readability in mind.
/// Displays units like <c>bytes</c>, <c>kB</c>, <c>MB</c> or <c>GB</c>.
/// It aims to pick the unit most readable, with a certain mid-way point
/// upon which is flips between units. E.g.,
/// </para>
/// 
/// <para>
/// <c>100 bytes</c> |
/// <c>5119 bytes</c> |
/// <c>5 kB</c> |
/// <c>5120 kB</c> |   
/// <c>5 MB</c> |      
/// <c>5120 MB</c> |   
/// <c>5 GB</c> |      
/// <c>10 GB</c> |     
/// <c>10000 GB</c>
/// </para>
/// 
/// <para>
/// Displays <c>0 bytes</c> for null byte arrays.
/// </para>
/// </summary>
public struct _prettybytecount;

/// <summary>
/// <para>
/// Shortens the GUIDs displayed in a text. GUIDs like:
/// </para>
/// 
/// <code>
/// "{07c75275-0150-4414-bbca-0081b021a0ea}"
/// </code>
/// 
/// <para>
/// can really clutter up text.
/// That's why they are often shortened when user-facing, like:
/// </para>
/// 
/// <code>
/// 07c752
/// </code>
/// 
/// <para>
/// Then we can eyeball it more easily.
/// You can call <c>WithShortGuids</c>, pass it a text and a desired length, and it'll
/// shorten the GUIDs to a text like:
/// </para>
/// 
/// <code>
/// "New record 07c752"
/// </code>
/// 
/// <para>
/// It simply keeps all your text, but shortens only the GUIDs.
/// </para>
/// 
/// <para>
/// Matches GUID-like sequences with or without dashes, with or without braces or quotes.<br/>
/// Preserves casing <c>cf9ecb39</c> or <c>B5F8F33</c>.<br/>
/// Shorten already shortened GUIDs.<br/>
/// Avoids shortening strings that look like words e.g. <c>defaced</c> or <c>facade</c>.
/// </para>
/// </summary>
public struct _withshortguids;

/// <summary>
/// <para>
/// Counts the numbers of lines in a text. Returns the amount of enters in the text,
/// minus any last enter (considered part of the last line).
/// </para>
/// 
/// <para>
/// Empty text returns 0 lines.
/// Works platform-safe by counting on <c>\n</c> newline characters,
/// which match both carriange-return-line-feed style on Windows,
/// and line-feed-only style on other systems.
/// </para>
/// </summary>
public struct _countlines;


/// <summary>
/// <para>
/// Checks if the given text starts with a blank line.
/// This can be useful for avoiding appending too many blank lines
/// to a console or logging.
/// </para>
/// 
/// <para>
/// Consider using the <see cref="StringHelperCore.EndsWithBlankLine"></see>
/// as well, which serves a similar purpose, and may help you better.
/// </para>
/// </summary>
/// <inheritdoc cref="_withblankline" />
public struct _startswithblankline;

/// <summary>
/// <para>
/// Checks if the text has a leading blank line.
/// This is useful for when you want to append text (console) output
/// or logging with a new line, but wish to omit any duplicate empty lines
/// in case multiple logic wants to do so.
/// </para>
/// 
/// <para>
/// The code tries to avoid excess processing as much as possible,
/// looking at the end of a text and backwards to find white space, 
/// non-white space or an end of line character.
/// </para>
/// </summary>
/// <inheritdoc cref="_withblankline" />
public struct _endswithblankline;

/// <remarks>
/// <b>Empty text</b> is considered a blank line. This seems assumptive,
/// but the blank text is considered a line, likely to be appended
/// to text (console) output or logging.
/// </remarks>
public struct _withblankline;


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
/// Replaces accented characters in the string (é, ñ, ü) with their unaccented equivalents (e, n, u).
/// Intended for normalization before search, sorting or comparison.
/// </summary>
public struct _removeaccents;

/// <summary>
/// <para>
/// Overload of <c>String.Trim</c> that takes a string to trim off,
/// instead of just a char.
/// Will remove multiple repentitions of the same string from the beginning and end of a text.
/// </para>
/// 
/// <para>
/// Note that if you use this overload, this may accidentally clash
/// with <c>Span&lt;char&gt;</c> overloads. So if you see that clash,
/// you may want to import the <c>JJ.Framework.Text.Core</c> namespace,
/// so it's lead to the <c>String</c> overload.
/// </para>
/// </summary>
public struct _trim;

/// <summary>
/// Syntax sugar for original string.Replace method,
/// where char and string can be mixed as arguments.
/// </summary>
public struct _replace;
