namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Prios - Overload with explicitly passed message comes first, which includes the argument expression as well.

    public static void AreSame(object? expected, object? actual, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression, () => ReferenceEquals(expected, actual));

    [Prio(1)]
    public static void AreSame(object? expected, object? actual, string message, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression + " " + message, () => ReferenceEquals(expected, actual));
    
    public static void AreSame<T>(T expected, T actual, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression, () => ReferenceEquals(expected, actual));

    [Prio(1)]
    public static void AreSame<T>(T expected, T actual, string message, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression + " " + message, () => ReferenceEquals(expected, actual));

    public static void NotSame(object expected, object actual, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression, () => !ReferenceEquals(expected, actual));

    [Prio(1)]
    public static void NotSame(object expected, object actual, string message, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression + " " + message, () => !ReferenceEquals(expected, actual));
    
    public static void NotSame<T>(T expected, T actual, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression, () => !ReferenceEquals(expected, actual));

    [Prio(1)]
    public static void NotSame<T>(T expected, T actual, string message, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression + " " + message, () => !ReferenceEquals(expected, actual));
    
    public static void AreNotSame(object expected, object actual, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression, () => !ReferenceEquals(expected, actual));

    [Prio(1)]
    public static void AreNotSame(object expected, object actual, string message, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression + " " + message, () => !ReferenceEquals(expected, actual));
    
    public static void AreNotSame<T>(T expected, T actual, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression, () => !ReferenceEquals(expected, actual));

    [Prio(1)]
    public static void AreNotSame<T>(T expected, T actual, string message, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression + " " + message, () => !ReferenceEquals(expected, actual));
}