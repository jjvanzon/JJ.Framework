// ReSharper disable RedundantExplicitParamsArrayCreation
// ReSharper disable AppendToCollectionExpression

#pragma warning disable IDE0017
namespace JJ.Framework.Business.Legacy.Tests;

[TestClass]
public class ResultTestsEx
{
    [TestMethod]
    public void Test_IResult()
    {
        IResult result = GenerateNum(1, 10);
        IsTrue(result.Success);
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);
    }

    [TestMethod]
    public void Test_ResultOfT()
    {
        Result<int> result = GenerateNum(1, 10);

        IsTrue(result.Success);
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);

        int num = result.Data;

        IsTrue(num >= 1);
        IsTrue(num <= 10);
    }
    
    [TestMethod]
    public void Test_ResultOfT_Error()
    {
        Result<int> result = GenerateNum(10, 1);
        IsFalse(result.Success);
        NotNull(result.Messages);
        AreEqual(default, result.Data);
        AreEqual(1, result.Messages.Count);
        AreEqual("min > max", result.Messages[0]);
    }

    [TestMethod]
    public void Test_Result_Construct_Init_Success()
    {
        {
            var result = new Result();
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
        {
            var result = new Result(success: true);
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
        {
            var result = new Result { Success = true };
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
        {
            var result = new Result(success: false);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
        {
            var result = new Result { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
    }

    [TestMethod]
    public void Test_Result_Construct_Init_OneMessage()
    {
        {
            var result = new Result("Just a warning.");
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Just a warning.", result.Messages[0]);
        }
        {
            var result = new Result([ "Just a warning." ]);
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Just a warning.", result.Messages[0]);
        }
        {
            var result = new Result { Messages = [ "Just a warning." ] };
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Just a warning.", result.Messages[0]);
        }
    }

    [TestMethod]
    public void Test_Result_Construct_Init_MultipleMessages()
    {
        {
            var result = new Result("Just some warnings.", "You may want to take a look.");
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Just some warnings.", result.Messages[0]);
            AreEqual("You may want to take a look.", result.Messages[1]);
        }
        {
            var result = new Result([ "Just some warnings.", "You may want to take a look." ]);
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Just some warnings.", result.Messages[0]);
            AreEqual("You may want to take a look.", result.Messages[1]);
        }
        {
            var result = new Result { Messages = [ "Just some warnings.", "You may want to take a look." ] };
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Just some warnings.", result.Messages[0]);
            AreEqual("You may want to take a look.", result.Messages[1]);
        }
    }

    [TestMethod]
    public void Test_Result_Construct_Init_SuccessFalseAndMessages()
    {
        {
            var result = new Result(success: false, "Oops");
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
        }
        {
            var result = new Result(success: false, [ "Oops" ]);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
        }
        {
            var result = new Result(success: false, "Oops", "a daisy");
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
        {
            var result = new Result(success: false, [ "Oops", "a daisy" ]);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
        {
            var result = new Result([ "Oops", "a daisy" ], success: false);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
        {
            var result = new Result(success: false) { Messages = [ "Oops", "a daisy" ] };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
        // Success Initializer
        {
            var result = new Result("Oops") { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
        }
        {
            var result = new Result([ "Oops" ]) { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
        }
        {
            var result = new Result("Oops", "a daisy") { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
        {
            var result = new Result([ "Oops", "a daisy" ]) { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
        {
            var result = new Result([ "Oops", "a daisy" ]) { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
        {
            var result = new Result { Messages = [ "Oops", "a daisy" ], Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
    }

    [TestMethod]
    public void Test_Result_NullMessagesCollection()
    {
        Throws(() => new Result ( messages : null! ), "messages", "null");
        Throws(() => new Result { Messages = null! }, "messages", "null");
        Throws(() => { Result result = new(); result.Messages = null!; }, "messages", "null");
    }

    [TestMethod]
    public void Test_Result_DirectUseSuccessProp_StillWorks()
    {
        var result = new Result();

        result.Success = true;
        IsTrue(result.Success);

        result.Success = false;
        IsFalse(result.Success);
    }

    [TestMethod]
    public void Test_Result_DirectUseMessagesProp_StillWorks()
    {
        var result = new Result();

        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);

        result.Messages = [ "Hi", "How ya doin" ];
        result.Messages.Add("Fine thanks");
        NotNull(                result.Messages);
        AreEqual(3,             result.Messages.Count);
        AreEqual("Hi",          result.Messages[0]);
        AreEqual("How ya doin", result.Messages[1]);
        AreEqual("Fine thanks", result.Messages[2]);

        result.Messages.Clear();
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);


        List<string> messages = [ "Ok", "I will assign" ];
        result.Messages = messages;
        NotNull(                  result.Messages);
        AreEqual(2,               result.Messages.Count);
        AreEqual("Ok",            result.Messages[0]);
        AreEqual("I will assign", result.Messages[1]);
    }
    
    [TestMethod]
    public void Test_Result_Messages_AreCloned_ByConstructor()
    {
        IList<string> messages = [ "I am here" ];
        var result = new Result(messages);

        result.Messages = messages;
        AreEqual(1, result.Messages.Count);

        messages.Add("I am elusive");
        AreEqual(2, messages.Count);
        AreEqual(1, result.Messages.Count);
    }
    
    [TestMethod]
    public void Test_Result_Messages_AreCloned_ByProp()
    {
        var result = new Result();
        IList<string> messages = [ "I am here" ];

        result.Messages = messages;
        AreEqual(1, result.Messages.Count);

        messages.Add("I am elusive");
        AreEqual(2, messages.Count);
        AreEqual(1, result.Messages.Count);
    }
    
    [TestMethod]
    public void Test_Result_Messages_CollectionTypes()
    {
        // TODO: Test using some different collectiont types.
    }
    
    [TestMethod]
    public void Test_Result_DiagnosticsTexts()
    {
    }

    [TestMethod]
    public void Test_ResultOfT_Data()
    {
        // TODO: Test all the ways to assign/init data. Even with null.
    }

    [TestMethod]
    public void Test_ResultOfT_Init()
    {
        // TODO: ResultOfT has its own copies of the constructors that need to be hit. 
    }

    private Result<int> GenerateNum(int min, int max)
    {
        if (min > max)
        {
            return new (success: false, "min > max");
        }

        int num = RandomizerLegacy.GetInt32(min, max);
        return new (success: true) { Data = num };
    }
}
