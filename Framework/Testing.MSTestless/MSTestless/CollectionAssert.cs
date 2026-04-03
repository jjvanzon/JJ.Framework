// ReSharper disable DuplicatedSequentialIfBodies
// ReSharper disable ConvertIfStatementToSwitchStatement
using System;
using System.Linq;

namespace Microsoft.VisualStudio.TestTools.UnitTesting;

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
        return $"Expected: {Format(expected)}, Actual: {Format(actual)}";
    }

    private static string Format<T>(T[]? arr)
    {
        if (arr == null) return "<null>";
        if (arr.Length == 0) return "<empty>";
        if (arr.Length <= MaxItemsToShow) return "[" + string.Join(", ", arr) + "]";
        return "[" + string.Join(", ", arr.Take(MaxItemsToShow)) + ", ...]";
    }
}