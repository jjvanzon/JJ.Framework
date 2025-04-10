namespace JJ.Framework.Common.Core.Tests.Helpers;

internal class DebuggerDisplayFormatter
{
    public static string GetDebuggerDisplay(CollectionExtensionsCoreTests.Item item)
    {
        return $"({item.Number},{item.Nully})";
    }
}