namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests;

[TestClass]
public class AccessorLegacyTests_Exception
{
    [TestMethod]
    public void AccessorLegacy_Constructor_WithTypeName_TypeNotFound_Exception()
    {
        var wrongTypeName = "NonExistentNamespace.NonExistentType";
        ThrowsException(
            () => new AccessorLegacy(wrongTypeName),
            $"Type '{wrongTypeName}' not found.");
    }
}
