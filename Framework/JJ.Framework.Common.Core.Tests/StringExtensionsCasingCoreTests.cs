namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class StringExtensionsCasingCoreTests
{
    private static readonly string? _null = null;

    // StartWithCap
    
    [TestMethod]
    public void StartWithCap_Core_Test() 
        => AreEqual("Test", () => "test".StartWithCap());

    [TestMethod]
    public void StartWithCap_NullException() 
        => ThrowsException(() => _null.StartWithCap());
    
    [TestMethod]
    public void StartWithCap_EmptyString() 
        => AreEqual("", () => "".StartWithCap());
    
    [TestMethod]
    public void StartWithCap_AlreadyStartsWithCap() 
        => AreEqual("Test", () => "Test".StartWithCap());

    // StartWithLowerCase
    
    [TestMethod]
    public void StartWithLowerCase_Example() 
        => AreEqual("test", () => "Test".StartWithLowerCase());
    
    [TestMethod]
    public void StartWithLowerCase_Core_Test() 
        => AreEqual("tEST", () => "TEST".StartWithLowerCase());
    
    [TestMethod]
    public void StartWithLowerCase_NullException() 
        => ThrowsException(() => _null.StartWithLowerCase());
    
    [TestMethod]
    public void StartWithLowerCase_EmptyString()
        => AreEqual("", () => "".StartWithLowerCase());
    
    [TestMethod]
    public void StartWithLowerCase_AlreadyStartsWithLowerCase() 
        => AreEqual("tEsT", () => "tEsT".StartWithLowerCase());
}