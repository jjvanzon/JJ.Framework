using System;
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Text
{
    public static partial class StringExtensions
    {
        [Obsolete("Use TakeStart instead.", true)]
        public static string TakeLeft(this string input, int length) => throw new NotSupportedException("Use TakeStart instead.");

        [Obsolete("Use TakeEnd instead.", true)]
        public static string TakeRight(this string input, int length) => throw new NotSupportedException("Use TakeEnd instead.");
    }
}
