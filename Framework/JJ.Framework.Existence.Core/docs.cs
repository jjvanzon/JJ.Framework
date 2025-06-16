// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
#pragma warning disable IDE1006
#pragma warning disable CS1572 // Surplus param tag

namespace JJ.Framework.Existence.Core
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive.

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
        /// Use matchCase instead.
        /// FLIP YOUR BOOLEANS IF NEEDED:
        /// Where ignoreCase: false, matchCase should now be true.
        /// Default behavior is to ignore case.
        /// </summary>
        /// <param name="ignoreCase">
        /// Obsolete.
        /// Use matchCase instead.
        /// FLIP YOUR BOOLEANS IF NEEDED:
        /// Where ignoreCase: false, matchCase should now be true.
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
        /// <b>ignoreCase replaced by matchCase!</b><br/>
        /// <b>Where ignoreCase: false,</b><br/>
        /// <b>matchCase should now be true!</b>
        /// </para>
        /// </summary>
        /// <inheritdoc cref="_flagargs" />
        public struct _in;

        /// <summary>
        /// Loose equality tests (e.g., case- and trim-insensitive string comparisons).
        /// <para>
        /// <b>BREAKING CHANGE:</b><br/>
        /// <b>ignoreCase replaced by matchCase!</b><br/>
        /// <b>Where ignoreCase: false,</b><br/>
        /// <b>matchCase should now be true!</b>
        /// </para>
        /// </summary>
        public struct _is;

        /// <summary>
        /// The inverse of <c>Has</c>, i.e. true when a value is null, empty, or (optionally) zero/whitespace.
        /// </summary>
        /// <inheritdoc cref="_flagargs" />
        public struct _isnully;

        /// <summary>
        /// <para> Use <c>matchCase</c> to make checks case-sensitive. </para>
        /// <para> Example: <c>a.Is(b, matchCase)</c> </para>
        /// <para> Only exact case matches will return true. You can also use: </para>
        /// <para> <c>matchCase: true</c> </para>
        /// <para> if you prefer the explicit boolean.</para>
        /// <para>
        /// <b>BREAKING CHANGE:</b><br/>
        /// <b>ignoreCase replaced by matchCase!</b><br/>
        /// <b>Where ignoreCase: false,</b><br/>
        /// <b>matchCase should now be true!</b>
        /// </para>
        /// </summary>
        /// <inheritdoc cref="_flagargs" />
        public struct _matchcase;
        
        /// <summary>
        /// <para> Use <c>spaceMatters</c> to treat white space as meaningful content. </para>
        /// <para> Example: <c>Has(text, spaceMatters)</c> </para>
        /// <para> It counts <c>"   "</c> as filled in. You can also use: </para>
        /// <para> <c>spaceMatters: true</c> </para>
        /// <para> if you prefer the explicit boolean. </para>
        /// </summary>
        /// <inheritdoc cref="_flagargs" />
        public struct _spacematters;

        /// <param name="matchCase">
        /// If true (or if you pass <c>matchCase</c>), comparisons will require exact casing.
        /// For example, <c>"abc"</c> will not match <c>"ABC"</c>.
        /// <para>
        /// <b>BREAKING CHANGE:</b><br/>
        /// <b>ignoreCase replaced by matchCase!</b><br/>
        /// <b>Where ignoreCase: false,</b><br/>
        /// <b>matchCase should now be true!</b>
        /// </para>
        /// </param>
        /// <param name="spaceMatters">
        /// If true (or if you pass <c>spaceMatters</c>), white space counts as real content.
        /// <c>"   "</c> will be considered filled in, not empty.
        /// </param>
        public struct _flagargs;
    }
}
