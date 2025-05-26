namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    public static void IsType<T>(object? actualObject, [ArgExpress(nameof(actualObject))] string message = null) 
        => IsType(typeof(T), actualObject, message);
    
    public static void IsType(Type expectedType, object actualObject, [ArgExpress(nameof(actualObject))] string message = "") 
        => Check(expectedType, message, () => CompileTimeType(actualObject) == expectedType);
    
    public static void IsType<T>(T actualValue, [ArgExpress(nameof(actualValue))] string message = "") 
        => IsType(typeof(T), actualValue, message);
    
    private static void IsType<T>(Type expectedType, T actualValue, string message) 
        => Check(expectedType, message, () => CompileTimeType(actualValue) == expectedType);
}