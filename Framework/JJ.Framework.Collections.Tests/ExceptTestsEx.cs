namespace JJ.Framework.Collections.Legacy.Tests;

[TestClass]
public class ExceptTestsEx
{
    [TestMethod]
    public void Test_Except_ByCollections()
    {
        string[] input = [ "Alice", "Bob", "Ross", "JJ", "The Dude" ];
        string[] output = input.Except([ "Bob", "JJ" ]).ToArray();

        IsNotNull(input);
        AreEqual(5, input.Length);
        AreEqual("Alice",    input[0]);
        AreEqual("Bob",      input[1]);
        AreEqual("Ross",     input[2]);
        AreEqual("JJ",       input[3]);
        AreEqual("The Dude", input[4]);

        IsNotNull(output);
        AreEqual(3, output.Length);
        AreEqual("Alice",    output[0]);
        AreEqual("Ross",     output[1]);
        AreEqual("The Dude", output[2]);
    }

    [TestMethod]
    public void Test_Except_ByPredicate()
    {
        string[] input = [ "Alice", "Bob", "Ross", "JJ", "The Dude" ];
        string[] output = input.Except(x => x.Contains("o")).ToArray();

        IsNotNull(input);
        AreEqual(5, input.Length);
        AreEqual("Alice",    input[0]);
        AreEqual("Bob",      input[1]);
        AreEqual("Ross",     input[2]);
        AreEqual("JJ",       input[3]);
        AreEqual("The Dude", input[4]);
     
        IsNotNull(output);
        AreEqual(3, output.Length);
        AreEqual("Alice",    output[0]);
        AreEqual("JJ",       output[1]);
        AreEqual("The Dude", output[2]);
    }
}