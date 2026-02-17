// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Generalized Methods
        
    #if !NET9_0_OR_GREATER
    [NoTrim(ExpressionsWithArrays)]
    #endif
    internal static void Check<T>(
        T expected, Expression<Func<T>> actualExpression, 
        Func<T, bool> condition, [Caller] string methodName = "")
        => Check(expected, actualExpression, "", condition, methodName);

    #if !NET9_0_OR_GREATER
    [NoTrim(ExpressionsWithArrays)]
    #endif
    internal static void Check<T>(
        T expected, Expression<Func<T>> actualExpression, string message,
        Func<T, bool> condition, [Caller] string methodName = "")
    {
        T actual = GetValue(actualExpression);
        message = Coalesce(message, GetText(actualExpression));
        Check(expected, actual, message, condition, methodName);
    }

    private static void Check<T>(
        T expected, T actual, 
        Func<T, T, bool> condition,
        [Caller] string methodName = "")
        => Check(expected, actual, "", () => condition(expected, actual), methodName);
    
    private static void Check<T>(
        T expected, T actual, string message,
        Func<T, T, bool> condition, 
        [Caller] string methodName = "")
        => Check(expected, actual, message, () => condition(expected, actual), methodName);
    
    private static void Check<T>(
        T expected, T actual, 
        Func<T, bool> condition, [Caller] string methodName = "")
        => Check(expected, actual, "", () => condition(actual), methodName);

    private static void Check<T>(
        T expected, T actual, string message,
        Func<T, bool> condition, [Caller] string methodName = "")
        => Check(expected, actual, message, () => condition(actual), methodName);
        
    private static void Check<T>(
        T expected, T actual, 
        Func<bool> condition,
        [Caller] string methodName = "")
        => Check(expected, actual, "", () => condition(), methodName);

    private static void Check<T>(
        T expected, string message,
        Func<bool> condition, [Caller] string methodName = "")
    {
        if (!condition())
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetExpectedMessage(methodName, expected, message);
            throw new Exception(fullMessage);
        }
    }

    private static void Check<T>(
        T expected, T actual, string message,
        Func<bool> condition, [Caller] string methodName = "")
    {
        if (!condition())
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetExpectedActualMessageLegacy(methodName, expected, actual, message);
            throw new Exception(fullMessage);
        }
    }

    private static void Check(Func<bool> condition, [Caller] string methodName = "")
        => Check(condition(), "", methodName);

    private static void Check(bool condition, [Caller] string methodName = "")
        => Check(condition, "", methodName);

    private static void Check(bool condition, string message, [Caller] string methodName = "")
    {
        if (!condition)
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetFailureMessageLegacy(methodName, message);
            throw new Exception(fullMessage);
        }
    }
    
    private static string GetExpectedMessage<T>(string methodName, T expected, string message)
        => $"Assert.{methodName} failed. Expected <{(expected != null ? expected.ToString() : "null")}>.{(!string.IsNullOrEmpty(message) ? " " : "")}{message}";
}
