
namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    public static void IsType<TValue>(Type expected, TValue value, [ArgExpress(nameof(value))] string message = "")
    {
        var actual = CompileTimeType(value);
        IsType(expected, actual, message);
    }
    
    private static void IsType(Type expected, Type actual, [ArgExpress(nameof(actual))] string message = "") 
        => Check(expected, actual, message, () => expected == actual);
    
    public static void NotType<TValue>(Type expected, TValue value, [ArgExpress(nameof(value))] string message = "")
    {
        var actual = CompileTimeType(value);
        NotType(expected, actual, message);
    }
    
    public static void NotType(Type expected, Type actual, [ArgExpress(nameof(actual))] string message = "")
    {
        Check(expected, actual, message, () => expected != actual);
    }
    
    #region Obsolete

    // ReSharper disable UnusedTypeParameter
    // ReSharper disable UnusedParameter.Local
    // ReSharper disable EntityNameCapturedOnly.Local

    private const string ObsoleteTExpectedArg 
        = "Overload unworkable. Here the argument is always the expected type, and a null/not-null difference cannot be evaluated.";
        
    private const string ObsoleteObjectArg
        = "Overload unworkable. Here the argument is object? and the return type info from the argument is lost.";

    [Obsolete(ObsoleteTExpectedArg, true)]
    private static void IsType<TExpected>(TExpected value, [ArgExpress(nameof(value))] string message = "") 
        => throw new NotSupportedException(ObsoleteTExpectedArg);
    
    [Obsolete(ObsoleteTExpectedArg, true)]
    private static void NotType<TExpected>(TExpected value, [ArgExpress(nameof(value))] string message = "") 
        => throw new NotSupportedException(ObsoleteTExpectedArg);
        
    [Obsolete(ObsoleteObjectArg, true)]
    private static void NotType<TExpected>(object? value, [ArgExpress(nameof(value))] string message = "") 
        => throw new NotSupportedException(ObsoleteObjectArg);
    
    #endregion
        
}