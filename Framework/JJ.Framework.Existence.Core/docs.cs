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
        public struct _coalesce { }

        /// <summary>
        /// Test whether a collection contains a given element.
        /// </summary>
        public struct _contains { }

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
        public struct _existencecore { }

        /// <summary>
        /// Perform a null-or-empty check one step beyond a plain null check.
        /// Zeroes, empty collections, defaults and white space are considered empty too.
        /// </summary>
        public struct _has { }
        
        /// <inheritdoc cref="_has" />
        public struct _filledin { }
        
        /// <summary>
        /// A looser way to check if a value belongs to a set or collection.
        /// </summary>
        public struct _in { }

        /// <summary>
        /// Loose equality tests (e.g., case- and trim-insensitive string comparisons).
        /// </summary>
        public struct _is { }

        /// <summary>
        /// The inverse of <c>Has</c>, i.e. true when a value is null, empty, or (optionally) zero/whitespace.
        /// </summary>
        public struct _isnully { }
    }
}
