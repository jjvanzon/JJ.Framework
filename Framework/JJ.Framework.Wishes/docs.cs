using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Wishes.Testing;

#pragma warning disable CS0649
#pragma warning disable CS0169 // Field is never used
#pragma warning disable IDE0044

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace JJ.Framework.Wishes
{
    public struct docs
    {
        /// <summary>
        /// Handles a collection of this class and its base classes recursively.
        /// </summary>
        public struct _classesrecursive { }

        /// <summary>
        /// <strong>AssertWishes.AreEqual</strong> overloads that accept an optional
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
        /// Handles a collection of this interface or its deeper interfaces recursively.
        /// </summary>
        public struct _interfacesrecursive { }

        /// <summary>
        /// Handles a collection of this type and its base classes and interfaces recursively.
        /// </summary>
        public struct _typesrecursive { }
    }
}
