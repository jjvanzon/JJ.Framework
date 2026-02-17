// ReSharper disable InvokeAsExtensionMember
using static System.StringSplitOptions;
namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class SplitCoreTests
{
    private static readonly string? _null = null;
    
    // Split With Char Sep
    
    [TestMethod]
    public void Split_CharAndOptions_CoreTest()
    {
        string[] expected = [ "a", "b", "c", "e" ];
        
        string[] split1   = StringExtensions_Split.Split("a,b,c,,e", ',', RemoveEmptyEntries);
        string[] split2   = "a,b,c,,e".Split(',', RemoveEmptyEntries);
        
        CollectionAssert.AreEqual(expected, split1);
        CollectionAssert.AreEqual(expected, split2);
    }
    
    [TestMethod]
    public void Split_CharAndOptions_NullInputException()
    {
        ThrowsException(() => StringExtensions_Split.Split(_null, ',', RemoveEmptyEntries));
        ThrowsException(() => _null!.Split(',', RemoveEmptyEntries));
    }
    
    [TestMethod]
    public void Split_Char_AndInvalidOptions()
    {
        ThrowsException(() => StringExtensions_Split.Split("a,b,c", ',', (StringSplitOptions)(-1)));
        ThrowsException(() => "a,b,c".Split(',', (StringSplitOptions)(-1)));
    }
    
    // Split with String Sep
    
    [TestMethod]
    public void Split_StringSepAndOptions_CoreTest()
    {
        string[] expected = [ "a", "b", "c", "e" ];
        
        string[] split1   = StringExtensions_Split.Split("a, b, c, , e", ", ", RemoveEmptyEntries);
        string[] split2   = "a, b, c, , e".Split(", ", RemoveEmptyEntries);
        
        CollectionAssert.AreEqual(expected, split1);
        CollectionAssert.AreEqual(expected, split2);
    }
    
    [TestMethod]
    public void Split_StringSepOptions_NullInputException()
    {
        ThrowsException(() => StringExtensions_Split.Split(_null, ", ", RemoveEmptyEntries));
        ThrowsException(() => _null!.Split(", ", RemoveEmptyEntries));
    }
        
    [TestMethod]
    public void Split_StringSep_AndInvalidOptions()
    {
        ThrowsException(() => StringExtensions_Split.Split("a, b, c", ", ", (StringSplitOptions)(-1)));
        ThrowsException(() => "a, b, c".Split(", ", (StringSplitOptions)(-1)));
    }

    [TestMethod]
    public void Split_StringSepAndOptions_NullOrEmptySep_NoSplit()
    {
        // Apparently a null separator is ok to .NET, and doesn't throw exceptions.
        //ThrowsException(() => StringExtensions_Split.Split("a, b, c", _null, RemoveEmptyEntries));
        //ThrowsException(() => StringExtensions_Split.Split("a, b, c", "", RemoveEmptyEntries));
        //ThrowsException(() => "a, b, c".Split(_null, RemoveEmptyEntries));
        //ThrowsException(() => "a, b, c".Split("", RemoveEmptyEntries));
        
        IList<string[]> splits =
        [
            StringExtensions_Split.Split("a, b, c", _null, RemoveEmptyEntries),
            StringExtensions_Split.Split("a, b, c", "",    RemoveEmptyEntries),
            "a, b, c".Split(_null, RemoveEmptyEntries),
            "a, b, c".Split("",    RemoveEmptyEntries)
        ];
        
        foreach (string[] split in splits)
        {
            IsNotNull(split);
            AreEqual(1, split.Length);
            IsNotNull(split[0]);
            AreEqual("a, b, c", split[0]);
        }
    }

    // Split with Params Seps

    [TestMethod]
    public void Split_ParamsSeps_Example()
    {
        string[] result   = "apple-banana|cherry".Split("-", "|");
        string[] expected = [ "apple", "banana", "cherry" ];
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void Split_ParamsSeps_CoreTest()
    {
        string   input   = "a, b|c, , e";
        string[] expected = [ "a", "b", "c", "", "e" ];
        string[] split1 = StringExtensions_Split.Split(input, ", ", "|");
        string[] split2 = input.Split(", ", "|");
        
        CollectionAssert.AreEqual(expected, split1);
        CollectionAssert.AreEqual(expected, split2);
    }
    
    [TestMethod]
    public void Split_ParamsSeps_NullInputException()
    {
        ThrowsException(() => StringExtensions_Split.Split(_null, ", ", "|"));
        ThrowsException(() => _null.Split(", ", "|"));
    }
    
    [TestMethod]
    public void Split_ParamsStringSeps_NullOrEmptySep_NoEffect()
    {
        // Apparently a null separator is ok to .NET and doesn't throw exceptions:
        //ThrowsException(() => StringExtensions_Split.Split("a,b|c", _null, "|"));
        //ThrowsException(() => StringExtensions_Split.Split("a,b|c", "", "|"));
        //ThrowsException(() => "a,b|c".Split(_null, "|"));
        //ThrowsException(() => "a,b|c".Split("", "|"));
        
        IList<string[]> splits =
        [
            StringExtensions_Split.Split("a,b|c", _null, "|"),
            StringExtensions_Split.Split("a,b|c", "", "|"),
            "a,b|c".Split(_null, "|"),
            "a,b|c".Split("", "|")
        ];
        
        foreach (string[] split in splits)
        {
            IsNotNull(split);
            AreEqual(2, split.Length);
            IsNotNull(split[0]);
            IsNotNull(split[1]);
            AreEqual("a,b", split[0]);
            AreEqual("c", split[1]);
        }
    }
}