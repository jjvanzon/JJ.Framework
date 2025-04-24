// ReSharper disable UnusedType.Global
// ReSharper disable IdentifierTypo
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
    }
}
