﻿using System;
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common
{
    [Obsolete(OBSOLETE_MESSAGE, true)]
    public static class Int32Helper
    {
        private const string OBSOLETE_MESSAGE = "Use JJ.Framework.Conversion.Int32Parser instead.";

        [Obsolete(OBSOLETE_MESSAGE, true)]
        public static bool TryParse(string s, IFormatProvider provider, out int result)
            => throw new NotSupportedException(OBSOLETE_MESSAGE);

        [Obsolete(OBSOLETE_MESSAGE, true)]
        public static int? ParseNullable(string input)
            => throw new NotSupportedException(OBSOLETE_MESSAGE);

        [Obsolete(OBSOLETE_MESSAGE, true)]
        public static bool TryParse(string input, out int? output)
            => throw new NotSupportedException(OBSOLETE_MESSAGE);
    }
}