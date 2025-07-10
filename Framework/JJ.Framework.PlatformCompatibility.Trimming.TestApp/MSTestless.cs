// ReSharper disable once CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    internal class TestClassAttribute : Attribute;
    internal class TestMethodAttribute : Attribute;

    internal static class Assert
    {
        public static void AreEqual<T>(T expected, T actual)
            => AssertCore.AreEqual(expected, actual);
    }
}
