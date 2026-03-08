namespace JJ.Framework.Reflection.Legacy.Tests.CoreTestHelpers;

internal static class ReflectionCacheTestHelper
{
    /// <summary>
    /// NOTE: Tested methods are run twice to hit cache retrieval.
    /// </summary>
    public const int Repeats = 2;
    public static readonly string NonExistentName = Guid.NewGuid().ToString();
}