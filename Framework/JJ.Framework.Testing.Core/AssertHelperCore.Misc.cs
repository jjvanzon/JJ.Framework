// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    // Basics
    
    public static void IsNotNull(object? value) 
        => Check(value != null);
    
    public static void IsNotNull(object? value, string message) 
        => Check(value != null, message: message);
    
    public static void IsTrue(bool value) 
        => Check(value == true);
    
    public static void IsTrue(bool value, string message) 
        => Check(value == true, message: message);
    
    public static void IsFalse(bool value) 
        => Check(value == false);
    
    public static void IsFalse(bool value, string message) 
        => Check(value == false, message: message);

    public static void Fail() 
        => throw new Exception(GetFailureMessageLegacy("", ""));
    
    public static void Fail(string message) 
        => throw new Exception(GetFailureMessageLegacy("", message));
            
    // Partial String Comparison
            
    public static void Contains(string expectedText, string actualText)
    {
        actualText ??= "";
        expectedText ??= "";
        
        if (!actualText.Contains(expectedText, ignoreCase: true))
        {
            throw new Exception($"Message does not contain: '{expectedText}'. Full message: '{actualText}'");
        }
    }
}
