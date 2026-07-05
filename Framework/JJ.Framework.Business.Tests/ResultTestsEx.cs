#pragma warning disable IDE0300
#pragma warning disable IDE0017
#pragma warning disable CA1859 // Use concrete type for performance.

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
        result.Assert();
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
    
        result.Assert();
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
        Throws(result.Assert, "min > max");
    }

    [TestMethod]
    public void Test_Result_Construct_Init_Success()
    {
        {
            var result = new Result();
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
            result.Assert();
        }
        {
            var result = new Result(success: true);
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
            result.Assert();
        }
        {
            var result = new Result { Success = true };
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
            result.Assert();
        }
    }

    [TestMethod]
    public void Test_Result_Construct_Init_SuccessFalse()
    {
        {
            var result = new Result(success: false);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
            Throws(result.Assert, "Failed without message");
        }
        {
            var result = new Result { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
            Throws(result.Assert, "Failed without message");
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
            result.Assert();
        }
        {
            var result = new Result([ "Just a warning." ]);
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Just a warning.", result.Messages[0]);
            result.Assert();
        }
        {
            var result = new Result { Messages = [ "Just a warning." ] };
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Just a warning.", result.Messages[0]);
            result.Assert();
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
            result.Assert();
        }
        {
            var result = new Result([ "Just some warnings.", "You may want to take a look." ]);
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Just some warnings.", result.Messages[0]);
            AreEqual("You may want to take a look.", result.Messages[1]);
            result.Assert();
        }
        {
            var result = new Result { Messages = [ "Just some warnings.", "You may want to take a look." ] };
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Just some warnings.", result.Messages[0]);
            AreEqual("You may want to take a look.", result.Messages[1]);
            result.Assert();
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
            Throws(result.Assert, "Oops");
        }
        {
            var result = new Result(success: false, [ "Oops" ]);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            Throws(result.Assert, "Oops");
        }
        {
            var result = new Result(success: false, "Oops", "a daisy");
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
        }
        {
            var result = new Result(success: false, [ "Oops", "a daisy" ]);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
        }
        {
            var result = new Result([ "Oops", "a daisy" ], success: false);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
        }
        {
            var result = new Result(success: false) { Messages = [ "Oops", "a daisy" ] };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
        }
        {
            var result = new Result("Oops") { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            Throws(result.Assert, "Oops");
        }
        {
            var result = new Result([ "Oops" ]) { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            Throws(result.Assert, "Oops");
        }
        {
            var result = new Result("Oops", "a daisy") { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
        }
        {
            var result = new Result([ "Oops", "a daisy" ]) { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
        }
        {
            var result = new Result([ "Oops", "a daisy" ]) { Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
        }
        {
            var result = new Result { Messages = [ "Oops", "a daisy" ], Success = false };
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
            Throws(result.Assert, "Oops, a daisy");
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
        result.Assert();

        result.Success = false;
        IsFalse(result.Success);
        Throws(result.Assert, "Failed without message");
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
        result.Assert();

        result.Messages.Clear();
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);
        result.Assert();

        List<string> messages = [ "Ok", "I will assign" ];
        result.Messages = messages;
        NotNull(                  result.Messages);
        AreEqual(2,               result.Messages.Count);
        AreEqual("Ok",            result.Messages[0]);
        AreEqual("I will assign", result.Messages[1]);
        result.Assert();
    }
    
    [TestMethod]
    public void Test_Result_Messages_AreCloned_ByConstructor()
    {
        IList<string> messages = [ "I am here" ];
        var result = new Result(messages);
        result.Assert();

        result.Messages = messages;
        AreEqual(1, result.Messages.Count);
        result.Assert();

        messages.Add("I am elusive");
        AreEqual(2, messages.Count);
        AreEqual(1, result.Messages.Count);
        result.Assert();
    }
    
    [TestMethod]
    public void Test_Result_Messages_AreCloned_ByProp()
    {
        var result = new Result();
        IList<string> messages = [ "I am here" ];
        result.Assert();

        result.Messages = messages;
        AreEqual(1, result.Messages.Count);
        result.Assert();

        messages.Add("I am elusive");
        AreEqual(2, messages.Count);
        AreEqual(1, result.Messages.Count);
        result.Assert();
    }
    
    [TestMethod]
    public void Test_Result_Messages_CollectionTypes()
    {
        // Array
        {
            var messages = new string[] { "Hi", "Hello" };
            new Result ( messages ).Assert();
            new Result { Messages = messages }.Assert();
            Result result = new(); result.Messages = messages;
            result.Assert();
        }
        // List
        {
            var messages = new List<string> { "Hi", "Hello" };
            new Result ( messages ).Assert();
            new Result { Messages = messages }.Assert();
            Result result = new();
            result.Messages = messages;
            result.Assert();
        }
        // IList
        {
            IList<string> messages = new List<string> { "Hi", "Hello" };
            new Result ( messages ).Assert();
            new Result { Messages = messages }.Assert();
            Result result = new();
            result.Messages = messages;
            result.Assert();
        }
        // As ICollection > Constructor Only
        {
            ICollection<string> messages = new List<string> { "Hi", "Hello" };
            new Result ( messages ).Assert();
            // Oops, IList<T> only
            //new Result { Messages = messages }.Assert();
            //Result result = new();
            //result.Messages = messages;
            //result.Assert();
        }
        // HashSet > Constructor only
        {
            var messages = new HashSet<string> { "Hi", "Hello" };
            new Result ( messages ).Assert();
            // Oops, IList<T> only
            //new Result { Messages = messages }.Assert();
            //Result result = new();
            //result.Messages = messages;
            //result.Assert();
        }
        // IEnumarable > Constructor only
        {
            IEnumerable<string> messages = new List<string> { "Hi", "Hello" };
            new Result ( messages ).Assert();
            // Oops, IList<T> only
            //new Result { Messages = messages }.Assert();
            //Result result = new();
            //result.Messages = messages;
            //result.Assert();
        }
    }

    [TestMethod]
    public void Test_IResult_SuccessPropSetter()
    {
        IResult result = GenerateNum(1, 10);
        IsTrue(result.Success);
        result.Assert();

        result.Success = false;
        IsFalse(result.Success);
        Throws(result.Assert, "Failed without message");

        result.Success = true;
        IsTrue(result.Success);
        result.Assert();
    }
        
    [TestMethod]
    public void Test_IResult_MessagesPropSetter()
    {
        IResult result = GenerateNum(1, 10);

        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);
        result.Assert();

        result.Messages = [ "I am", "assigned" ];
        NotNull(result.Messages);
        AreEqual(2, result.Messages.Count);
        AreEqual("I am", result.Messages[0]);
        AreEqual("assigned", result.Messages[1]);
        result.Assert();

        result.Messages.Add("I am added");
        AreEqual(3, result.Messages.Count);
        AreEqual("I am", result.Messages[0]);
        AreEqual("assigned", result.Messages[1]);
        AreEqual("I am added", result.Messages[2]);
        result.Assert();

        result.Messages = [ ];
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);
        result.Assert();
    }

    private static readonly CultureInfo _nlNL = GetCultureInfo("nl-NL");

    [TestMethod]
    public void Test_ResultOfT_Data_Filled()
    {
        Result<CultureInfo> result = new() { Data = _nlNL };

        AreEqual(_nlNL, result.Data);

        IsTrue(result.Success);
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);
        result.Assert();
    }

    [TestMethod]
    public void Test_ResultOfT_Data_Empty_CanReportSuccessAnyway()
    {
        Result<CultureInfo> result = new();

        IsNull(result.Data);

        IsTrue(result.Success);
        NotNull(result.Messages);
        AreEqual(0, result.Messages.Count);
        result.Assert();

        result.Data = _nlNL;
        AreEqual(_nlNL, result.Data);
        result.Assert();
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
            result.Assert();
        }
        {
            var result = new Result<string>(success: false);
            IsNull(result.Data);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
            Throws(result.Assert, "Failed without message");
        }
        {
            var result = new Result<string>("I have", "no Data");

            IsTrue(result.Success);

            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("I have", result.Messages[0]);
            AreEqual("no Data", result.Messages[1]);

            IsNull(result.Data);

            result.Assert();
        }
        {
            var result = new Result<string>([ "I cannot", "give you data..." ]);

            IsTrue(result.Success);

            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("I cannot", result.Messages[0]);
            AreEqual("give you data...", result.Messages[1]);

            IsNull(result.Data);

            result.Assert();
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

            Throws(result.Assert, "Our data, is lacking, and so is our, success");
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
        
            Throws(result.Assert, "Success, is not a given, and neither, is Data");
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

            Throws(result.Assert, "My final report, on our lack of success..., and Data");
        }
    }
    
    [TestMethod]
    public void Test_Result_ToString()
    {
        var result = new Result<double?>();

        AreEqual("{Result`1} Success", result.ToString()); // Bit ugly the `1, but ok.

        result.Messages = [ "I am success", "incarnate" ];
        AreEqual("{Result`1} Success: I am success, incarnate", result.ToString());

        result.Data = 100;
        AreEqual("{Result`1} Success: I am success, incarnate", result.ToString());

        result.Messages.Add("As proof");
        result.Messages.Add("I bring data.");
        AreEqual("{Result`1} Success: I am success, incarnate, As proof, I bring data.", result.ToString());

        result.Success = false;
        result.Messages = [ "Oh no", "I failed" ];
        AreEqual("{Result`1} Failed: Oh no, I failed", result.ToString());
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
