namespace JJ.Framework.Reflection.Core.Tests.Helpers;

internal static class ParseHelperCore
{
    public static Guid ToGuid(int number) => new ($"{number}".PadLeft(32, '0'));
    public static DateTime FromYear(int year) => new (year, 1, 1);
    //public static DateTime From2000(int year) => new (year + 2000, 1, 1);
}
