namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCore_Throws_Tests
{
    // Throws

    [TestMethod]
    public void AssertCore_Throws()
    {
        Throws         (ThrowingAction        );
        Throws         (ThrowingFunc          );
        ThrowsException(ThrowingFunc          );
        Throws         (ThrowingAction, "boom");
        Throws         (ThrowingFunc,   "boom");
        ThrowsException(ThrowingFunc,   "boom");
        Throws         <InvalidOperationException>(ThrowingAction        );
        Throws         <InvalidOperationException>(ThrowingFunc          );
        ThrowsException<InvalidOperationException>(ThrowingFunc          );
        Throws         <InvalidOperationException>(ThrowingAction, "boom");
        Throws         <InvalidOperationException>(ThrowingFunc,   "boom");
        ThrowsException<InvalidOperationException>(ThrowingFunc,   "boom");
        Throws         (ThrowingAction, typeof(InvalidOperationException)        );
        Throws         (ThrowingFunc,   typeof(InvalidOperationException)        );
        ThrowsException(ThrowingFunc,   typeof(InvalidOperationException)        );
        Throws         (ThrowingAction, typeof(InvalidOperationException), "boom");
        Throws         (ThrowingFunc,   typeof(InvalidOperationException), "boom");
        ThrowsException(ThrowingFunc,   typeof(InvalidOperationException), "boom");
    }

    [TestMethod]
    public void AssertCore_Throws_DidNotThrow()
    {
        const string expectedMsgPart = "An exception should have"; // been throws/occurred.
        Throws(() => Throws         (() => { }        ), expectedMsgPart);
        Throws(() => Throws         (() => ""         ), expectedMsgPart);
        Throws(() => ThrowsException(() => ""         ), expectedMsgPart);
        Throws(() => Throws         (() => { }, "murp"), expectedMsgPart);
        Throws(() => Throws         (() => "",  "murp"), expectedMsgPart);
        Throws(() => ThrowsException(() => "",  "murp"), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => { }        ), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => ""         ), expectedMsgPart);
        Throws(() => ThrowsException<InvalidOperationException>(() => ""         ), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => { }, "murp"), expectedMsgPart);
        Throws(() => Throws         <InvalidOperationException>(() => "",  "murp"), expectedMsgPart);
        Throws(() => ThrowsException<InvalidOperationException>(() => "",  "murp"), expectedMsgPart);
        Throws(() => Throws         (() => { }, typeof(InvalidOperationException)        ), expectedMsgPart);
        Throws(() => Throws         (() => "",  typeof(InvalidOperationException)        ), expectedMsgPart);
        Throws(() => ThrowsException(() => "",  typeof(InvalidOperationException)        ), expectedMsgPart);
        Throws(() => Throws         (() => { }, typeof(InvalidOperationException), "murp"), expectedMsgPart);
        Throws(() => Throws         (() => "",  typeof(InvalidOperationException), "murp"), expectedMsgPart);
        Throws(() => ThrowsException(() => "",  typeof(InvalidOperationException), "murp"), expectedMsgPart);
    }

    [TestMethod]
    public void AssertCore_Throws_WrongExceptionType()
    {
        const string expectedMsgPart = "AreEqual failed";

        Throws(() => Throws         <NullReferenceException>(ThrowingAction), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc  ), expectedMsgPart);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc  ), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingAction, "boom"), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc  , "boom"), expectedMsgPart);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc  , "boom"), expectedMsgPart);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException)), expectedMsgPart);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException)), expectedMsgPart);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException)), expectedMsgPart);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException), "boom"), expectedMsgPart);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException), "boom"), expectedMsgPart);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException), "boom"), expectedMsgPart);
    }

    [TestMethod]
    public void AssertCore_Throws_WrongMessage()
    {
        string[] msgParts = [ "boom", "murp" ];

        Throws(() => Throws         (ThrowingAction, "murp"), msgParts);
        Throws(() => Throws         (ThrowingFunc,   "murp"), msgParts);
        Throws(() => ThrowsException(ThrowingFunc,   "murp"), msgParts);
        Throws(() => Throws         <InvalidOperationException>(ThrowingAction, "murp"), msgParts);
        Throws(() => Throws         <InvalidOperationException>(ThrowingFunc,   "murp"), msgParts);
        Throws(() => ThrowsException<InvalidOperationException>(ThrowingFunc,   "murp"), msgParts);
        Throws(() => Throws         (ThrowingAction, typeof(InvalidOperationException), "murp"), msgParts);
        Throws(() => Throws         (ThrowingFunc,   typeof(InvalidOperationException), "murp"), msgParts);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(InvalidOperationException), "murp"), msgParts);
    }

    [TestMethod]
    public void AssertCore_Throws_WrongExceptionType_And_WrongMessage()
    {
        const string expectedMsgPart = "AreEqual failed";

        Throws(() => Throws         <NullReferenceException>(ThrowingAction, "murp"), expectedMsgPart);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc,   "murp"), expectedMsgPart);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc,   "murp"), expectedMsgPart);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException), "murp"), expectedMsgPart);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException), "murp"), expectedMsgPart);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException), "murp"), expectedMsgPart);
    }

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread()
    {
        ThrowsOnOtherThread         (ThrowingAction);
        ThrowsOnOtherThread         (ThrowingFunc);
        ThrowsExceptionOnOtherThread(ThrowingFunc);
    }

    [TestMethod]
    public void AssertCore_ThrowsOnOtherThread_DidNotThrow()
    {
        const string expectedMsgPart = "An exception should have";

        Throws(() => ThrowsOnOtherThread         (() => { }), expectedMsgPart);
        Throws(() => ThrowsOnOtherThread         (() => ""), expectedMsgPart);
        Throws(() => ThrowsExceptionOnOtherThread(() => ""), expectedMsgPart);
    }

    private void ThrowingAction() => throw new InvalidOperationException("boom");
    private object ThrowingFunc() => throw new InvalidOperationException("boom");
}