namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_String_Core_Tests
{
    [TestMethod]
    public void PlatformCompatibility_String_IsNullOrWhiteSpace_Core_Test()
    {
        string nullString = null;
        string emptyString = "";
        string whiteSpaceString = "   ";
        string nonWhiteSpaceString = "abc";
        
        IsTrue (() => string.IsNullOrWhiteSpace(nullString));
        IsTrue (() => string.IsNullOrWhiteSpace(emptyString));
        IsTrue (() => string.IsNullOrWhiteSpace(whiteSpaceString));
        IsFalse(() => string.IsNullOrWhiteSpace(nonWhiteSpaceString));
        
        IsTrue (() => String_PlatformSupport.IsNullOrWhiteSpace(nullString));
        IsTrue (() => String_PlatformSupport.IsNullOrWhiteSpace(emptyString));
        IsTrue (() => String_PlatformSupport.IsNullOrWhiteSpace(whiteSpaceString));
        IsFalse(() => String_PlatformSupport.IsNullOrWhiteSpace(nonWhiteSpaceString));
        
        IsTrue (() => PlatformHelperLegacy.String_IsNullOrWhiteSpace_PlatformSupport(nullString));
        IsTrue (() => PlatformHelperLegacy.String_IsNullOrWhiteSpace_PlatformSupport(emptyString));
        IsTrue (() => PlatformHelperLegacy.String_IsNullOrWhiteSpace_PlatformSupport(whiteSpaceString));
        IsFalse(() => PlatformHelperLegacy.String_IsNullOrWhiteSpace_PlatformSupport(nonWhiteSpaceString));
    }
}