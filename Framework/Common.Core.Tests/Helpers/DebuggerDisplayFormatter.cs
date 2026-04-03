namespace JJ.Framework.Common.Core.Tests.Helpers;

// ncrunch: no coverage start

internal class DebuggerDisplayFormatter
{
    public static string GetDebuggerDisplay(CollectionExtensionsCoreTests.Item item)
    {
        return $"({item.Number},{item.Nully})";
    }
}

// ncrunch: no coverage end
