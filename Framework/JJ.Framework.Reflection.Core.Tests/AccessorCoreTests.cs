namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests
{
    [TestMethod]
    public void AccessorCore_Constructor_WithTypeName_TypeNotFound_Exception()
    {
        var wrongTypeName = "NonExistentNamespace.NonExistentType";
        ThrowsException(
            () => new AccessorCore(wrongTypeName),
            $"Type '{wrongTypeName}' not found.");
    }
}
