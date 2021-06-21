using System;
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common
{
    public static partial class DoubleHelper
    {
        [Obsolete("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.", true)]
        public static bool TryParse(string s, IFormatProvider provider, out double result) 
            => throw new NotSupportedException("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.");

        [Obsolete("Use JJ.Framework.Conversion.DoubleParser.ParseNullable instead.", true)]
        public static double? ParseNullable(string input) 
            => throw new NotSupportedException("Use JJ.Framework.Conversion.DoubleParser.ParseNullable instead.");

        [Obsolete("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.", true)]
        public static bool TryParse(string input, out double? output) 
            => throw new NotSupportedException("Use JJ.Framework.Conversion.DoubleParser.TryParse instead.");
    }
}
