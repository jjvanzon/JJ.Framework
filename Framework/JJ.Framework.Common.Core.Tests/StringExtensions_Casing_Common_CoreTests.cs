namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class StringExtensions_Casing_Common_CoreTests
{
    private static readonly string _null = null;
    
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
}