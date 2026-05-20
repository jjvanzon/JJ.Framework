// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Prios - Overload with explicitly passed message comes first, and includes the tested expression as well.

    public static void IsTrue(bool value, [ArgExpress(nameof(value))] string expression = "") 
        => Check(value == true, message: expression);
    
    [Prio(1)]
    public static void IsTrue(bool value, string message, [ArgExpress(nameof(value))] string expression = "") 
        => Check(value == true, message: expression + " " + message);
    
    public static void IsFalse(bool value, [ArgExpress(nameof(value))] string expr = "") 
        => Check(value == false, message: expr);
    
    [Prio(1)]
    public static void IsFalse(bool value, string message, [ArgExpress(nameof(value))] string expression = "") 
        => Check(value == false, message: expression + " " + message);
    
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
