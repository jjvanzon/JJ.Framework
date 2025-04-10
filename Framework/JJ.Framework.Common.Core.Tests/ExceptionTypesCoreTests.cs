namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class ExceptionTypesCoreTests
{
    [TestMethod]
    public void Test_InvalidValueException_Message()
    {
        object value = "Hi";
        var exception = new InvalidValueException(value);
        AreEqual("Invalid System.String value: 'Hi'.", () => exception.Message);
    }
    
    [TestMethod]
    public void Test_ValueNotSupportedException_Message()
    {
        object value = "Hi";
        var exception = new ValueNotSupportedException(value);
        AreEqual("System.String value: 'Hi' is not supported.", () => exception.Message);
    }
    
    // Null tolerance does not resolve pretty, but it does the job:
    
    [TestMethod]
    public void Test_InvalidValueException_NullTolerance()
    {
        var exception = new InvalidValueException(null);
        AreEqual("Invalid  value: ''.", () => exception.Message);
    }
    
    [TestMethod]
    public void Test_ValueNotSupportedException_NullTolerance()
    {
        var exception = new ValueNotSupportedException(null);
        AreEqual(" value: '' is not supported.", () => exception.Message);
    }
}