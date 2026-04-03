namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertHelperCore_Basics_Tests
{
    [TestMethod]
    public void AssertHelperCore_IsTrue_Value_Succeeds() => IsTrue(true);
    
    [TestMethod]
    public void AssertHelperCore_IsTrue_Value_Fails() 
        => ThrowsExceptionContaining(() => IsTrue(false), "Assert.IsTrue failed.");
    
    [TestMethod]
    public void AssertHelperCore_IsFalse_Value_Succeeds() => IsFalse(false);
    
    [TestMethod]
    public void AssertHelperCore_IsFalse_Value_Fails()
        => ThrowsExceptionContaining(() => IsFalse(true), "Assert.IsFalse failed.");
    
    [TestMethod]
    public void AssertHelperCore_IsTrue_WithMessage_Succeeds() => IsTrue(true, "It went wrong.");
    
    [TestMethod]
    public void AssertHelperCore_IsTrue_WithMessage_Fails() 
        => ThrowsExceptionContaining(() => IsTrue(false, "It went wrong."), "Assert.IsTrue failed.", "It went wrong.");
    
    [TestMethod]
    public void AssertHelperCore_IsFalse_WithMessage_Succeeds() => IsFalse(false, "It went wrong.");
    
    [TestMethod]
    public void AssertHelperCore_IsFalse_WithMessage_Fails() 
        => ThrowsExceptionContaining(() => IsFalse(true, "It went wrong."), "Assert.IsFalse failed.", "It went wrong.");
}
