namespace JJ.Framework.Collections.Tests;

[TestClass]
public class ExceptTestsEx
{
    [TestMethod]
    public void Test_Except_ByCollections()
    {
        string[] input = [ "Alice", "Bob", "Ross", "JJ", "The Dude" ];
        string[] output = input.Except([ "Bob", "JJ" ]).ToArray();

        IsTrue(input.SequenceEqual([ "Alice", "Bob", "Ross", "JJ", "The Dude" ]));
        IsTrue(output.SequenceEqual([ "Alice", "Ross", "The Dude" ]));
    }

    [TestMethod]
    public void Test_Except_ByPredicate()
    {
        string[] input = [ "Alice", "Bob", "Ross", "JJ", "The Dude" ];
        string[] output = input.Except(x => x.Contains("o")).ToArray();

        IsTrue(input.SequenceEqual([ "Alice", "Bob", "Ross", "JJ", "The Dude" ]));
        IsTrue(output.SequenceEqual([ "Alice", "JJ", "The Dude" ]));
    }
}