namespace JJ.Framework.Common.Legacy.Tests;

// ncrunch: no coverage start

internal static class DebuggerDisplayFormatter
{
    public static string GetDebuggerDisplay(CollectionExtensionsTestsEx.Item item)
    {
        return $"({item.Number},{item.Nully})";
    }
}

// ncrunch: no coverage end
