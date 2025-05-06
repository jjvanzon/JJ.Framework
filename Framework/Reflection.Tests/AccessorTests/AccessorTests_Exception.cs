namespace JJ.Framework.Reflection.Tests.AccessorTests;

[TestClass]
public class AccessorTests_Exception
{
    [TestMethod]
    public void AccessorLegacy_Constructor_WithTypeName_TypeNotFound_Exception()
    {
        var wrongTypeName = "NonExistentNamespace.NonExistentType";
        ThrowsException(
            () => new Accessor(wrongTypeName),
            $"Type '{wrongTypeName}' not found.");
    }
}
