// ReSharper disable DuplicatedSequentialIfBodies
// ReSharper disable ConvertIfStatementToSwitchStatement
namespace JJ.Framework.Testing.Core.MSTestless;

public class CollectionAssert
{
    private const int MaxItemsToShow = 10;

    public static void AreEqual<T>(T[]? expected, T[]? actual)
    {
        if (expected == null && actual == null)
        {
            return;
        }
       
        if (expected == null)
        {
            throw new Exception(Format(expected, actual));
        }

        if (actual == null)
        {
            throw new Exception(Format(expected, actual));
        }

        if (!expected.SequenceEqual(actual))
        {
            throw new Exception(Format(expected, actual));
        }
    }

    private static string Format<T>(T[]? expected, T[]? actual)
    {
        return $"Expected: {Format(expected)}, Actual: {Join(", ", actual ?? [ ])}";
    }

    private static string Format<T>(T[]? arr)
    {
        if (arr == null) return "<null>";
        if (arr.Length == 0) return "<empty>";
        if (arr.Length <= MaxItemsToShow) return "[" + Join(", ", arr) + "]";
        return "[" + Join(", ", arr.Take(MaxItemsToShow)) + ", ...]";
    }
}