// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    // Basics
    
    public static void IsNotNull(object? value) 
        => Check(() => value != null, GetCurrentMethod().Name);
    
    public static void IsTrue(bool value) 
        => Check(() => value == true, GetCurrentMethod().Name);
    
    public static void IsTrue(bool value, string messageOrName) 
        => Check(() => value == true, GetCurrentMethod().Name, messageOrName);
    
    public static void IsFalse(bool value) 
        => Check(() => value == false, GetCurrentMethod().Name);
    
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
