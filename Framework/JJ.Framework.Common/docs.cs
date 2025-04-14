// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace JJ.Framework.Common
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive when used in inheritdoc tags.
    
        /// <summary>
        /// On top of the usual Split, this version allows you to use the separator character
        /// inside values if you surround the value by quotes.
        /// The implementation is quite limited.
        /// Repeated quotes don't escape to a single characters
        /// and multi-line values aren't supported either.
        /// </summary>
        /// <param name="input">The full string to be split into substrings.</param>
        /// <param name="separator">The substring delimiter used to divide the input.</param>
        /// <param name="options">Controls whether empty entries are included in the result.</param>
        /// <param name="quote">
        /// Quote character. If set, text enclosed in quotes will be treated as a single value,
        /// even if it contains the separator. Limitation: can only be used to escape separators, not to embed quotes or line breaks.
        /// </param>
        public struct _splitwithquotation { }
    }
}
