namespace JJ.Framework.Reflection.Core.Tests.Helpers;

internal static class ParseHelperCore
{
    public static Guid ToGuid(int number) => new ($"{number}".PadLeft(32, '0'));
}
