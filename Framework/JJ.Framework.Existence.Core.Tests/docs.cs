#pragma warning disable CS0649
#pragma warning disable CS0169 // Field is never used
#pragma warning disable IDE0044
#pragma warning disable IDE1006 // Naming Styles

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace JJ.Framework.Existence.Core.Tests
{
    namespace docs
    {
        // NOTE: These are structs, so their syntax colorings are unobtrusive.
        
        /// <summary>
        /// Asserts that even when a value is filled in,
        /// the return type is still nullable.
        /// </summary>
        /// <typeparam name="TRet">Do not specify explicitly! <c>ret</c> determines this type!</typeparam>
        /// <param name="expected">The value ret is expected to have.</param>
        /// <param name="ret">Expression whose return type should be nullable.</param>
        public struct _nullret { }
        
        /// <summary>
        /// Asserts not only that the value isn't null,
        /// also that the return type is not nullable.
        /// </summary>
        /// <typeparam name="TRet">Do not specify explicitly! <c>ret</c> determines this type!</typeparam>
        /// <param name="expected">The value ret is expected to have.</param>
        /// <param name="ret">Expression whose return type should not be nullable.</param>
        public struct _nonullret { }
        
    }
}