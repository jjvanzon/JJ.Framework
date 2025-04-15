// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace JJ.Framework.Text
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive when used in inheritdoc tags.
    
        /// <summary>
        /// On top of the usual Split, this version allows you to use the separator character
        /// inside values if you surround the value by quotes.
        /// To embed quotes again, you repeat the quote character 2x.
        /// Multi-line values are not supported.
        /// </summary>
        /// <param name="input">The full string to be split into substrings.</param>
        /// <param name="separator">The substring delimiter used to divide the input.</param>
        /// <param name="options">Controls whether empty entries are included in the result.</param>
        /// <param name="quote">
        /// Quote character. If set, text enclosed in quotes will be treated as a single value,
        /// even if it contains the separator. To embed quotes in the value again, repeat the quote character twice.
        /// </param>
        public struct _splitwithquotation { }
    }
}
