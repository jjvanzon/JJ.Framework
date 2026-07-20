namespace JJ.Framework.Testing.Core.Tests;

[TestClass]
public class AssertCore_Throws_Tests
{
    // Throws

    [TestMethod]
    public void Test_AssertCore_Throws()
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
    public void Test_AssertCore_Throws_DidNotThrow()
    {
        string[] expectedMsgParts = [ "should have", "been thrown" ] ;
        Throws(() => Throws         (() => { }        ), expectedMsgParts);
        Throws(() => Throws         (() => ""         ), expectedMsgParts);
        Throws(() => ThrowsException(() => ""         ), expectedMsgParts);
        Throws(() => Throws         (() => { }, "murp"), expectedMsgParts);
        Throws(() => Throws         (() => "",  "murp"), expectedMsgParts);
        Throws(() => ThrowsException(() => "",  "murp"), expectedMsgParts);
        Throws(() => Throws         <InvalidOperationException>(() => { }        ), expectedMsgParts);
        Throws(() => Throws         <InvalidOperationException>(() => ""         ), expectedMsgParts);
        Throws(() => ThrowsException<InvalidOperationException>(() => ""         ), expectedMsgParts);
        Throws(() => Throws         <InvalidOperationException>(() => { }, "murp"), expectedMsgParts);
        Throws(() => Throws         <InvalidOperationException>(() => "",  "murp"), expectedMsgParts);
        Throws(() => ThrowsException<InvalidOperationException>(() => "",  "murp"), expectedMsgParts);
        Throws(() => Throws         (() => { }, typeof(InvalidOperationException)        ), expectedMsgParts);
        Throws(() => Throws         (() => "",  typeof(InvalidOperationException)        ), expectedMsgParts);
        Throws(() => ThrowsException(() => "",  typeof(InvalidOperationException)        ), expectedMsgParts);
        Throws(() => Throws         (() => { }, typeof(InvalidOperationException), "murp"), expectedMsgParts);
        Throws(() => Throws         (() => "",  typeof(InvalidOperationException), "murp"), expectedMsgParts);
        Throws(() => ThrowsException(() => "",  typeof(InvalidOperationException), "murp"), expectedMsgParts);
    }

    [TestMethod]
    public void Test_AssertCore_Throws_WrongExceptionType()
    {
        string[] expectedMsgParts = [ "NullReference should have been thrown" ];

        Throws(() => Throws         <NullReferenceException>(ThrowingAction), expectedMsgParts);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc  ), expectedMsgParts);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc  ), expectedMsgParts);
        Throws(() => Throws         <NullReferenceException>(ThrowingAction, "boom"), expectedMsgParts);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc  , "boom"), expectedMsgParts);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc  , "boom"), expectedMsgParts);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException)), expectedMsgParts);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException)), expectedMsgParts);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException)), expectedMsgParts);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException), "boom"), expectedMsgParts);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException), "boom"), expectedMsgParts);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException), "boom"), expectedMsgParts);
    }

    [TestMethod]
    public void Test_AssertCore_Throws_WrongMessage()
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
    public void Test_AssertCore_Throws_WrongExceptionType_And_WrongMessage()
    {
        string[] expectedMsgParts = [ "NullReference should have been thrown", "with message containing: \"murp\""];

        Throws(() => Throws         <NullReferenceException>(ThrowingAction, "murp"), expectedMsgParts);
        Throws(() => Throws         <NullReferenceException>(ThrowingFunc,   "murp"), expectedMsgParts);
        Throws(() => ThrowsException<NullReferenceException>(ThrowingFunc,   "murp"), expectedMsgParts);
        Throws(() => Throws         (ThrowingAction, typeof(NullReferenceException), "murp"), expectedMsgParts);
        Throws(() => Throws         (ThrowingFunc,   typeof(NullReferenceException), "murp"), expectedMsgParts);
        Throws(() => ThrowsException(ThrowingFunc,   typeof(NullReferenceException), "murp"), expectedMsgParts);
    }

    [TestMethod]
    public void Test_AssertCore_ThrowsOnOtherThread()
    {
        ThrowsOnOtherThread         (ThrowingAction);
        ThrowsOnOtherThread         (ThrowingFunc);
        ThrowsExceptionOnOtherThread(ThrowingFunc);
    }

    [TestMethod]
    public void Test_AssertCore_ThrowsOnOtherThread_DidNotThrow()
    {
        const string expectedMsgPart = "An exception should have";

        Throws(() => ThrowsOnOtherThread         (() => { }), expectedMsgPart);
        Throws(() => ThrowsOnOtherThread         (() => ""), expectedMsgPart);
        Throws(() => ThrowsExceptionOnOtherThread(() => ""), expectedMsgPart);
    }

    private void ThrowingAction() => throw new InvalidOperationException("boom");
    private object ThrowingFunc() => throw new InvalidOperationException("boom");
}