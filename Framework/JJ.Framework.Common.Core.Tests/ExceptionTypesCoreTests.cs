namespace JJ.Framework.Common.Core.Tests;

//file enum CustomerType
//{
//    Undefined,
//    Subscriber,
//    Customer
//}

[TestClass]
public class ExceptionTypesCoreTests
{
    [TestMethod]
    public void Test_InvalidValueException_Message()
    {
        object value = "Hi";
        var exception = new InvalidValueException(value);
        AreEqual("Invalid String value: 'Hi'.", () => exception.Message);
    }
    
    [TestMethod]
    public void Test_ValueNotSupportedException_Message()
    {
        object value = "Hi";
        var exception = new ValueNotSupportedException(value);
        AreEqual("String value: 'Hi' is not supported.", () => exception.Message);
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
        
    [TestMethod]
    public void Test_ValueNotSupportedException_WithEnum() 
        => AssertHelper.ThrowsException<ValueNotSupportedException>(
            () => throw new ValueNotSupportedException(CustomerType.Subscriber),
            "CustomerType value: 'Subscriber' is not supported.");

    [TestMethod]
    public void Test_InvalidValueException_WithEnum() 
        => AssertHelper.ThrowsException<InvalidValueException>(
            () => throw new InvalidValueException(CustomerType.Undefined),
            "Invalid CustomerType value: 'Undefined'.");
}