// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace

// These are structs, so their syntax colorings are unobtrusive.

namespace JJ.Framework.Existence.Core.docs;

/// <summary>
/// Pick the first non-nully (non-empty) value from a list of fallbacks.
/// Works like <c>??</c> but treats empty strings, zero, and empty collections as "null".
/// </summary>
public struct _coalesce;

/// <summary>
/// Test whether a collection contains a given element.
/// </summary>
public struct _contains;

/// <summary>
/// <para>
/// One-stop shop for "nully" checks, fallback picks, existence tests and loose comparisons,
/// so you never have to never have to wrestle with boilerplate null/empty guards again:
/// </para>
/// 
/// <para>
///   <c>FilledIn</c> / <c>Has</c> / <c>IsNully</c> <br/>
///   One step beyond <c>null</c>, treating empty strings, zero, or empty lists as "nully".
/// </para>
/// <para>
///   <c>Coalesce</c> <br/>
///   First non-nully value picker (think <c>??</c> on steroids).
/// </para>
/// <para>
///   <c>Contains</c> / <c>In</c> <br/>
///   "Is this in that?" tests for collections and sets
/// </para>
/// <para>
///   <c>Is</c>  <br/>
///   Loose equality (case/trim-insensitive, etc.) when you don't care about exact matches.
/// </para>
/// 
/// <para>
/// Grab these methods instead of wrestling with <c>if</c> statements and repeated checks.
/// Your code (and your brain) will thank you.
/// </para>
/// </summary>
public struct _existencecore;

/// <summary>
/// Perform a null-or-empty check one step beyond a plain null check.
/// Zeroes, empty collections, defaults and white space are considered empty too.
/// </summary>
/// <inheritdoc cref="_flagargs" />
public struct _has;

/// <inheritdoc cref="_has" />
public struct _filledin;

/// <summary>
/// Obsolete.
/// Use caseMatters instead.
/// FLIP YOUR BOOLEANS IF NEEDED:
/// Where ignoreCase: false, caseMatters should now be true.
/// Default behavior is to ignore case.
/// </summary>
/// <param name="ignoreCase">
/// Obsolete.
/// Use caseMatters instead.
/// FLIP YOUR BOOLEANS IF NEEDED:
/// Where ignoreCase: false, caseMatters should now be true.
/// Default behavior is to ignore case.
/// </param>
public struct _ignorecaseobsolete;

/// <summary>
/// A looser way to check if a value belongs to a set or collection.
/// 
/// <para>
/// <b>BREAKING CHANGES:</b>
/// </para>
///
/// <para>
/// <b>Obsolete: In(x, a, b, c)</b><br/>
/// <b>Alternative: x.In(a, b, c)</b>
/// </para>
/// 
/// <para>
/// <b>ignoreCase replaced by caseMatters!</b><br/>
/// <b>Where ignoreCase: false,</b><br/>
/// <b>caseMatters should now be true!</b>
/// </para>
/// </summary>
/// <inheritdoc cref="_flagargs" />
public struct _in;

/// <summary>
/// Loose equality tests (e.g., case- and trim-insensitive string comparisons).
/// <para>
/// <b>BREAKING CHANGE:</b><br/>
/// <b>ignoreCase replaced by caseMatters!</b><br/>
/// <b>Where ignoreCase: false,</b><br/>
/// <b>caseMatters should now be true!</b>
/// </para>
/// </summary>
/// <inheritdoc cref="_flagargs" />
public struct _is;

/// <summary>
/// The inverse of <c>Has</c>, i.e. true when a value is null, empty, or (optionally) zero/whitespace.
/// </summary>
/// <inheritdoc cref="_flagargs" />
public struct _isnully;

/// <summary>
/// <para> Use <c>caseMatters</c> to make checks case-sensitive. </para>
/// <para> Example: <c>a.Is(b, caseMatters)</c> </para>
/// <para> Only exact case matches will return true. You can also use: </para>
/// <para> <c>caseMatters: true</c> </para>
/// <para> if you prefer the explicit boolean.</para>
/// <para>
/// <b>BREAKING CHANGE:</b><br/>
/// <b>ignoreCase replaced by caseMatters!</b><br/>
/// <b>Where ignoreCase: false,</b><br/>
/// <b>caseMatters should now be true!</b>
/// </para>
/// </summary>
/// <inheritdoc cref="_flagargs" />
public struct _casematters;

/// <summary>
/// <para> Use <c>spaceMatters</c> to treat white space as meaningful content. </para>
/// <para> Example: <c>Has(text, spaceMatters)</c> </para>
/// <para> It counts <c>"   "</c> as filled in. You can also use: </para>
/// <para> <c>spaceMatters: true</c> </para>
/// <para> if you prefer the explicit boolean. </para>
/// </summary>
/// <inheritdoc cref="_flagargs" />
public struct _spacematters;

/// <param name="caseMatters">
/// If true (or if you pass <c>caseMatters</c>), comparisons will require exact casing.
/// For example, <c>"abc"</c> will not match <c>"ABC"</c>.
/// 
/// <para>
/// <b>BREAKING CHANGE:</b><br/>
/// <b>ignoreCase replaced by caseMatters!</b><br/>
/// <b>Where ignoreCase: false,</b><br/>
/// <b>caseMatters should now be true!</b>
/// </para>
/// 
/// <para>See also: <see cref="CaseMatters" />.</para>
/// </param>
/// 
/// <param name="spaceMatters">
/// <para>
/// If true (or if you pass <c>spaceMatters</c>), white space counts as real content.
/// <c>"   "</c> will be considered filled in, not empty.
/// </para>
/// 
/// <para>See also: <see cref="SpaceMatters" />.</para>
/// </param>
///
/// <para name="zeroMatters">
/// See: <see cref="ZeroMatters" />.
/// </para>
public struct _flagargs;

/// <summary>
/// <para>
/// By default, value types are checked for <c>null</c> and <c>0</c>,
/// to determine if it's considered empty:
/// </para>
///
/// <para>
/// <c>Has(0)</c> returns <c>false</c>.
/// </para>
///
/// On the other hand:
///
/// <para>
/// <c>Has(0, zeroMatters)</c> returns <c>true</c>
/// </para>
/// 
/// Sometimes this means that <c>Has</c> doesn't do much more than a <c>null</c> check,
/// but the benefit is that you can use the <c>Has</c> syntax
/// and other methods for a wider range of options, e.g.:
///
/// <code>
/// Has(Volume)
/// Has(SamplingRate)
/// Has(AudioLength, zeroMatters)
/// </code>
///
/// <b>Zero</b> is wider in meaning than just <c>0</c>: it means any zeroed out data,
/// or just the <c>default</c> value. That way <c>zeroMatters</c> can also
/// apply to non-initialized <c>structs</c> or <c>DateTimes</c> or <c>Booleans</c>.
/// </summary>
public struct _zeroMatters;