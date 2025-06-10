// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Generalized Methods
        
    internal static void Check<T>(
        T expected, Expression<Func<T>> actualExpression, 
        Func<T, bool> condition, [CallerMemberName] string methodName = null)
        => Check(expected, actualExpression, "", condition, methodName);

    internal static void Check<T>(
        T expected, Expression<Func<T>> actualExpression, string message,
        Func<T, bool> condition, [CallerMemberName] string methodName = null)
    {
        T actual = GetValue(actualExpression);
        message = Coalesce(message, GetText(actualExpression));
        Check(expected, actual, message, condition, methodName);
    }

    private static void Check<T>(
        T expected, T actual, 
        Func<T, T, bool> condition,
        [CallerMemberName] string methodName = null)
        => Check(expected, actual, "", () => condition(expected, actual), methodName);
    
    private static void Check<T>(
        T expected, T actual, string message,
        Func<T, T, bool> condition, 
        [CallerMemberName] string methodName = null)
        => Check(expected, actual, message, () => condition(expected, actual), methodName);
    
    private static void Check<T>(
        T expected, T actual, 
        Func<T, bool> condition, [CallerMemberName] string methodName = null)
        => Check(expected, actual, "", () => condition(actual), methodName);

    private static void Check<T>(
        T expected, T actual, string message,
        Func<T, bool> condition, [CallerMemberName] string methodName = null)
        => Check(expected, actual, message, () => condition(actual), methodName);
        
    private static void Check<T>(
        T expected, T actual, 
        Func<bool> condition,
        [CallerMemberName] string methodName = null)
        => Check(expected, actual, "", () => condition(), methodName);

    private static void Check<T>(
        T expected, string message,
        Func<bool> condition, [CallerMemberName] string methodName = null)
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
        Func<bool> condition, [CallerMemberName] string methodName = null)
    {
        if (!condition())
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetExpectedActualMessageLegacy(methodName, expected, actual, message);
            throw new Exception(fullMessage);
        }
    }

    private static void Check(Func<bool> condition, [CallerMemberName] string methodName = null)
        => Check(condition(), "", methodName);

    private static void Check(bool condition, [CallerMemberName] string methodName = null)
        => Check(condition, "", methodName);

    private static void Check(bool condition, string message, [CallerMemberName] string methodName = null)
    {
        if (!condition)
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetFailureMessageLegacy(methodName, message);
            throw new Exception(fullMessage);
        }
    }
    
    private static string GetExpectedMessage<T>(string methodName, T expected, string message)
        => $@"Assert.{methodName} failed. Expected <{(expected != null ? expected.ToString() : "null")}>.{(!IsNullOrEmpty(message) ? " " : "")}{message}";
}
