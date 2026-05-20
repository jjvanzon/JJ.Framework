
namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Prios - Overload with explicitly passed message comes first, which includes the argument expression as well.

    // TODO: Add variants IsType<int>(myType). Sure it'd be like equality check for the type, but it gets the intent clear, just like IsTrue just checks equality to true. It's a syntax sugar / the syntax is expected to work, but currently doesn't.

    public static void IsType<TValue>(
        Type expected, TValue value,
        [ArgExpress(nameof(value))] string expression = "")
    {
        var actual = CompileTimeType(value);
        Check(expected, actual, expression, () => expected == actual);
    }

    [Prio(1)]
    public static void IsType<TValue>(
        Type expected, TValue value,
        string message, [ArgExpress(nameof(value))] string expression = "")
    {
        var actual = CompileTimeType(value);
        Check(expected, actual, expression + " " + message, () => expected == actual);
    }
    
    public static void IsType(
        Type expected, Type actual,
        [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression, () => expected == actual);
    
    [Prio(1)]
    public static void IsType(
        Type expected, Type actual,
        string message, [ArgExpress(nameof(actual))] string expression = "") 
        => Check(expected, actual, expression + " " + message, () => expected == actual);
    
    public static void NotType<TValue>(
        Type expected, TValue value,
        [ArgExpress(nameof(value))] string expression = "")
    {
        var actual = CompileTimeType(value);
        Check(expected, actual, expression, () => expected != actual);
    }
    
    [Prio(1)]
    public static void NotType<TValue>(
        Type expected, TValue value,
        string message, [ArgExpress(nameof(value))] string expression = "")
    {
        var actual = CompileTimeType(value);
        Check(expected, actual, expression + " " + message, () => expected != actual);
    }
    
    public static void NotType(
        Type expected, Type actual, 
        [ArgExpress(nameof(actual))] string expression = "")
        => Check(expected, actual, expression, () => expected != actual);
    
    [Prio(1)]
    public static void NotType(
        Type expected, Type actual, 
        string message, [ArgExpress(nameof(actual))] string expression = "")
        => Check(expected, actual, expression + " " + message, () => expected != actual);
}