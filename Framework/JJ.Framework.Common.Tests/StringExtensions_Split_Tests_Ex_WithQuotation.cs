// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Legacy.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class StringExtensions_Split_Tests_Ex_WithQuotation
{
    private static readonly string? _null = null;
    
    [TestMethod]
    public void SplitWithQuotation_SimpleExample()
    {
        string[] actual   = "apple|~banana|split~|cherry".SplitWithQuotation("|", '~').ToArray();
        string[] expected = [ "apple", "banana|split", "cherry" ];
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SplitWithQuotation_ComplexExample()
    {
        string input = 
        """
        1234,"1234","12,34","12""34",1"23"4,"12"34","12"34"
        """;
        
        string[] split = input.SplitWithQuotation(",", '"').ToArray();
        
        IsNotNull(         () => split);
        AreEqual(6,        () => split.Length);
        AreEqual("1234",   () => split[0]);
        AreEqual("1234",   () => split[1]);
        AreEqual("12,34",  () => split[2]);
        AreEqual("12\"34", () => split[3]);

        // Quirk: Quotes in the middle are untouched:
        
        //AreEqual("1234", split[4]); // Right
        AreEqual("1\"23\"4", () => split[4]); // Wrong
        
        //AreEqual("""1234,1234""", split[5]); // Right?
        AreEqual("""12"34","12"34""", () => split[5]); // Wrong
    }

    [TestMethod]
    public void SplitWithQuotation_WithoutCharQuote_BehavesLikeNormalSplit()
    {
        string[] expected = [ "a", "b", "c", "e" ];
        string[] split    = "a, b, c, , e".SplitWithQuotation(", ", RemoveEmptyEntries, null).ToArray();
        CollectionAssert.AreEqual(expected, split);
    }
    
    [TestMethod]
    public void SplitWithQuotation_NoSeparator_ThrowsException()
    {
        Throws<ArgumentNullException>(() => "1234".SplitWithQuotation(null, '"'), "separator", "cannot be null");
        
        // "" is not technically null, but it calls it that in the error anyway.
        Throws<ArgumentNullException>(() => "1234".SplitWithQuotation("", '"'), "separator", "cannot be null");
        
        // Space is fine though.
        "1234".SplitWithQuotation(" ", '"');
    }
    
    [TestMethod]
    public void SplitWithQuotation_NullOrEmptyInput_ReturnsEmptyCollection()
    {
        string[] split1 = "".SplitWithQuotation(",", '"').ToArray();
        IsNotNull(() => split1);
        AreEqual(0, () => split1.Length);
     
        // null input still returns non-null collection.
        string[] split2 = _null.SplitWithQuotation(",", '"').ToArray();
        IsNotNull(() => split2);
        AreEqual(0, () => split2.Length);
    }
}