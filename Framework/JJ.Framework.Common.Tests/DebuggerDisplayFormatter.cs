namespace JJ.Framework.Common.Legacy.Tests;

// ncrunch: no coverage start

internal class DebuggerDisplayFormatter
{
    public static string GetDebuggerDisplay(CollectionExtensionsCoreTests.Item item)
    {
        return $"({item.Number},{item.Nully})";
    }
}

// ncrunch: no coverage end
