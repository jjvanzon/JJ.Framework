#pragma warning disable IDE0300
#pragma warning disable IDE0017

// ReSharper disable RedundantExplicitParamsArrayCreation
// ReSharper disable AppendToCollectionExpression
// ReSharper disable RedundantExplicitArrayCreation
// ReSharper disable ObjectCreationAsStatement

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
        // Array
        {
            var messages = new string[] { "Hi", "Hello" };
            new Result ( messages );
            new Result { Messages = messages };
            Result result = new(); result.Messages = messages;
        }
        // List
        {
            var messages = new List<string> { "Hi", "Hello" };
            new Result ( messages );
            new Result { Messages = messages };
            Result result = new();
            result.Messages = messages;
        }
        // IList
        {
            IList<string> messages = new List<string> { "Hi", "Hello" };
            new Result ( messages );
            new Result { Messages = messages };
            Result result = new();
            result.Messages = messages;
        }
        // As ICollection > Constructor Only
        {
            ICollection<string> messages = new List<string> { "Hi", "Hello" };
            new Result ( messages );
            // Oops, IList<T>
            //new Result { Messages = messages };
            //Result result = new();
            //result.Messages = messages;
        }
        // HashSet > Constructor only
        {
            var messages = new HashSet<string> { "Hi", "Hello" };
            new Result ( messages );
            // Oops, IList<T>
            //new Result { Messages = messages };
            //Result result = new();
            //result.Messages = messages;
        }
        // IEnumarable > Constructor only
        {
            IEnumerable<string> messages = new List<string> { "Hi", "Hello" };
            new Result ( messages );
            // Oops, IList<T>
            //new Result { Messages = messages };
            //Result result = new();
            //result.Messages = messages;
        }
    }

    [TestMethod]
    public void Test_IResult_SuccessPropSetter()
    {
        IResult result = GenerateNum(1, 10);
        IsTrue(result.Success);
        result.Success = false;
        IsFalse(result.Success);
        result.Success = true;
        IsTrue(result.Success);
    }
        
    [TestMethod]
    public void Test_IResult_MessagesPropSetter()
    {
        IResult result = GenerateNum(1, 10);

        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);

        result.Messages = [ "I am", "assigned" ];
        NotNull(result.Messages);
        AreEqual(2, result.Messages.Count);
        AreEqual("I am", result.Messages[0]);
        AreEqual("assigned", result.Messages[1]);

        result.Messages.Add("I am added");
        AreEqual(3, result.Messages.Count);
        AreEqual("I am", result.Messages[0]);
        AreEqual("assigned", result.Messages[1]);
        AreEqual("I am added", result.Messages[2]);

        result.Messages = [ ];
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);
    }

    private static readonly CultureInfo _nlNL = GetCultureInfo("nl-NL");

    [TestMethod]
    public void Test_ResultOfT_Data()
    {
        {
            Result<CultureInfo> result = new() { Data = _nlNL };

            AreEqual(_nlNL, result.Data);

            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);

        }
        {
            Result<CultureInfo> result = new();

            IsNull(result.Data);

            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);

            result.Data = _nlNL;
            AreEqual(_nlNL, result.Data);
        }
    }

    [TestMethod]
    public void Test_ResultOfT_Constructors_HaveNoData()
    {
        {
            var result = new Result<string>(success: true);
            IsNull(result.Data);
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
        {
            var result = new Result<string>(success: false);
            IsNull(result.Data);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
        {
            var result = new Result<string>("I have", "no Data");
            IsTrue(result.Success);

            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("I have", result.Messages[0]);
            AreEqual("no Data", result.Messages[1]);

            IsNull(result.Data);
        }
        {
            var result = new Result<string>([ "I cannot", "give you data..." ]);
            IsTrue(result.Success);

            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("I cannot", result.Messages[0]);
            AreEqual("give you data...", result.Messages[1]);

            IsNull(result.Data);
        }
        {
            var result = new Result<string>([ "Our data", "is lacking", "and so is our", "success" ], success: false);
            IsFalse(result.Success);

            NotNull(result.Messages);
            AreEqual(4, result.Messages.Count);
            AreEqual("Our data", result.Messages[0]);
            AreEqual("is lacking", result.Messages[1]);
            AreEqual("and so is our", result.Messages[2]);
            AreEqual("success", result.Messages[3]);

            IsNull(result.Data);
        }
        {
            var result = new Result<string>(success: false, "Success", "is not a given", "and neither", "is Data");
            IsFalse(result.Success);

            NotNull(result.Messages);
            AreEqual(4, result.Messages.Count);
            AreEqual("Success", result.Messages[0]);
            AreEqual("is not a given", result.Messages[1]);
            AreEqual("and neither", result.Messages[2]);
            AreEqual("is Data", result.Messages[3]);

            IsNull(result.Data);
        }
        { 
            var result = new Result<string>(success: false, [ "My final report", "on our lack of success...", "and Data" ]);
            IsFalse(result.Success);

            NotNull(result.Messages);
            AreEqual(3, result.Messages.Count);
            AreEqual("My final report", result.Messages[0]);
            AreEqual("on our lack of success...", result.Messages[1]);
            AreEqual("and Data", result.Messages[2]);

            IsNull(result.Data);
        }
    }
    
    [TestMethod]
    public void Test_Result_DiagnosticsTexts()
    {
        // TODO
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

    // TODO: Reuse more?

    //private static void AssertDefault(IResult result)
    //{
    //    IsTrue(result.Success);
    //    NotNull(result.Messages);
    //    AreEqual(0, result.Messages.Count);
    //}
}
