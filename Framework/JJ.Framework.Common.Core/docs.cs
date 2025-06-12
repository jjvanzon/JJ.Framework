// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedType.Global
#pragma warning disable IDE1006
#pragma warning disable CS1572 // Surplus param tag

namespace JJ.Framework.Common.Core
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive.

        /// <summary>
        /// Compensates for missing null-tolerant version in ConfigurationHelper.
        /// </summary>
        public struct _configurationhelpercore { }

        /// <summary>
        /// Shorthand to check if an environment variable is defined with a specific key and value.
        /// </summary>
        public struct _environmentvariableisdefined { }

        /// <summary>
        /// Sets or gets flags from bit fields (ints) and flag enums.
        /// These otherwise require (hard to remember) bit operations.
        /// These helpers help you out in this moment of confusion.
        /// </summary>
        public struct _flagging { }

        // TODO: Alternative doc to consider:

        /// <summary>
        /// Simple helpers and extensions for flag operations on ints and [Flags] enums:
        /// – <c>HasFlag</c> to ask “is this bit or flag set?”  
        /// – <c>SetFlag</c> / <c>ClearFlag</c> for toggling a single flag  
        /// – <c>SetFlags</c> / <c>ClearFlags</c> when you’ve got a collection of flags  
        /// Works seamlessly on both raw integer masks and enum-typed flags, so you never typo your bit math again.
        /// </summary>
        public struct _flaggingalt { }

        /// <summary> 
        /// Returns the current method name or current property name.
        /// </summary> 
        public struct _name { }

        /// <summary> 
        /// Helper for conversion from code elements to text (a supplement to the <langword>nameof</langword> keyword).
        /// </summary> 
        public struct _namehelper { }
        
        /// <summary>
        /// Gets the string representation of an expression.
        /// </summary>
        /// <param name="expression">What you pass here, gets converted to text, that is returned.</param>
        /// <param name="expressionString">Do not set this parameter. It is for internal use.</param>
        /// <returns>What you pass as expression will be returned as text for further processing.</returns>
        public struct _textof { }
    }
}
