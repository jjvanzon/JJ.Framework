// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Prios - Overload with explicitly passed message comes first, and includes the tested expression as well.

    public static void IsTrue(bool value, [ArgExpress(nameof(value))] string expr = "") 
        => Check(value == true, message: expr);
    
    [Prio(1)]
    public static void IsTrue(bool value, string message, [ArgExpress(nameof(value))] string expr = "") 
        => Check(value == true, message: expr + " " + message);
    
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
