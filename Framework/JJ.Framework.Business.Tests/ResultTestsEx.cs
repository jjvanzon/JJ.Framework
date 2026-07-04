
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
    public void Test_Result_Constructors()
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
            var result = new Result(success: false);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(0, result.Messages.Count);
        }
        {
            var result = new Result("Just a warning.");
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(1, result.Messages.Count);
            AreEqual("Just a warning.", result.Messages[0]);
        }
        {
            var result = new Result("Just some warnings.", "You may want to take a look.");
            IsTrue(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Just some warnings.", result.Messages[0]);
            AreEqual("You may want to take a look.", result.Messages[1]);
        }
        {
            var result = new Result(success: false, "Oops");
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
            var result = new Result([ "Oops", "a daisy" ], success: false);
            IsFalse(result.Success);
            NotNull(result.Messages);
            AreEqual(2, result.Messages.Count);
            AreEqual("Oops", result.Messages[0]);
            AreEqual("a daisy", result.Messages[1]);
        }
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
