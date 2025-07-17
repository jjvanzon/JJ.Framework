// ReSharper disable RedundantBoolCompare


namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    public static void IsTrue(bool value, [ArgExpress(nameof(value))] string message = "") 
        => Check(value == true, message: message);
    
    public static void IsFalse(bool value, [ArgExpress(nameof(value))] string message = "") 
        => Check(value == false, message: message);
    
    public static void Fail() 
        => throw new Exception(GetFailureMessageLegacy("", ""));
    
    public static void Fail(string message) 
        => throw new Exception(GetFailureMessageLegacy("", message));
            
    // Partial String Comparison
            
    public static void Contains(string? expectedText, string? actualText)
    {
        actualText ??= "";
        expectedText ??= "";
        
        if (!actualText.Contains(expectedText, ignoreCase: true))
        {
            throw new Exception($"Message does not contain: '{expectedText}'. Full message: '{actualText}'");
        }
    }
}
