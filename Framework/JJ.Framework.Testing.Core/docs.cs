// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InvalidXmlDocComment
#pragma warning disable CS0649
#pragma warning disable IDE1006 // Naming Styles

namespace JJ.Framework.Testing.Core
{
    namespace docs
    {
        /// <summary>
        /// <strong>AssertHelperCore.AreEqual</strong> overloads that accept an optional
        /// <see cref="DeltaDirectionEnum"> DeltaDirectionEnum </see> parameter. <br/><br/>
        /// 
        /// Specify the acceptable delta (tolerance) for comparisons, based on the direction: <br/><br/>
        /// - <see cref="DeltaDirectionEnum.Down"> Down </see> or a <strong>negative</strong> delta:
        ///   Allows only downward tolerance. <br/>
        /// - <see cref="DeltaDirectionEnum.Up"> Up </see>:
        ///   Allows only upward tolerance. <br/>
        /// - <see cref="DeltaDirectionEnum.None"> None </see> / <see langword="default" />:
        ///   Allows tolerance in both directions. <br/><br/>
        /// 
        /// Designed for scenarios like double-to-int conversions, ensuring accurate comparisons
        /// despite rounding (e.g., flooring).
        /// </summary>
        public struct _deltadirection { }
       
        /// <summary>
        /// <c>From</c>, <c>Init</c> and <c>Source</c> are synonyms.
        /// </summary>
        public struct _from { }
        
                
        /// <summary>
        /// Asserts not only that the value isn't null,
        /// also that the return type is not nullable.
        /// </summary>
        /// <typeparam name="TRet">Do not specify explicitly! <c>ret</c> determines this type!</typeparam>
        /// <param name="expected">The value ret is expected to have.</param>
        /// <param name="ret">Expression whose return type should not be nullable.</param>
        public struct _nonullret { }

        /// <summary>
        /// <c>To</c>, <c>Value</c>, <c>Val</c> and <c>Dest</c> are synonyms.
        /// </summary>
        public struct _to { }
    }
}
