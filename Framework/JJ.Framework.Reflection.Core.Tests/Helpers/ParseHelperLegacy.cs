using System;
using System.Globalization;

namespace JJ.Framework.Reflection.Core.Tests.Helpers
{
    internal static class ParseHelperLegacy
    {
        private static readonly IFormatProvider _formattingCulture = new CultureInfo("en-US");

        public static TimeSpan ParseTimeSpan(string s) => TimeSpan.Parse(s, _formattingCulture);
        public static DateTime ParseDateTime(string s) => DateTime.Parse(s, _formattingCulture);
    }
}
