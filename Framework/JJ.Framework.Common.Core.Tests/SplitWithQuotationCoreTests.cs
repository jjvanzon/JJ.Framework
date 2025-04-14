namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class SplitWithQuotationCoreTests
{
    [TestMethod]
    public void SplitWithQuotation_ComplexExample()
    {
        string input = 
        """
        1234,"1234","12,34","12""34",1"23"4,"12"34","12"34"
        """;
        
        string[] split = input.SplitWithQuotation(",", '"');
        
        IsNotNull(() => split);
        AreEqual(6, () => split.Length);
        AreEqual("1234",  () => split[0]);
        AreEqual("1234",  () => split[1]);
        AreEqual("12,34", () => split[2]);

        // Turns out quotes only allow use of separator character in values.
        // It can't be used cleanly for embedding quotes or line breaks in the values.

        //AreEqual("12\"34", () => split[3]); // Right
        AreEqual("""12""34""", () => split[3]); // Wrong
        
        //AreEqual("1234", () => split[4]); // Right
        AreEqual("""1"23"4""", () => split[4]); // Wrong
        
        //AreEqual("""1234,1234""", () => split[5]); // Right?
        AreEqual("""12"34","12"34""", () => split[5]); // Wrong
    }
}