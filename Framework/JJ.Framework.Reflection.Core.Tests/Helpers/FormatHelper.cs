using System.Globalization;
using static System.Globalization.CultureInfo;

namespace JJ.Framework.Reflection.Core.Tests.Helpers;

internal static class FormatHelper
{
    private static readonly CultureInfo _cultureInfo = GetCultureInfo("en-US");

    public static Guid ToGuid(int number) => new ($"{number}".PadLeft(32, '0'));
    public static DateTime FromYear(int year) => new (year, 1, 1);
    public static string FormatDateTime(DateTime dateTime) => dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff", _cultureInfo);
}
