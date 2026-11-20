// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertCore
{
    // Generalized Methods

    private static void Check<T>(
        T expected, T actual, string message,
        Func<T, bool> condition, [Caller] string methodName = "")
        => Check(expected, actual, message, () => condition(actual), methodName);

    private static void Check<T>(
        T expected, T actual, string message,
        Func<bool> condition, [Caller] string methodName = "")
    {
        if (!condition())
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetExpectedActualMessage(methodName, expected, actual, message);
            throw new Exception(fullMessage);
        }
    }

    private static void Check(
        bool condition, string message, [Caller] string methodName = "")
    {
        if (!condition)
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetFailureMessage(methodName, message);
            throw new Exception(fullMessage);
        }
    }

    // Message Formatting

    private static string FormatTestedExpressionMessage(string messageOrExpression) 
        => Has(messageOrExpression) ? $"Tested: '{messageOrExpression}'." : "";

    // TODO: This message build-up could be customized
    //  independently from Legacy. Does not need to be like legacy.
        
    private static string GetExpectedActualMessage<T>(string methodName, T expected, T actual, string message)
        => $@"Assert.{methodName} failed. Expected <{(expected != null ? expected.ToString() : "null")}>, Actual <{(actual != null ? actual.ToString() : "null")}>.{(!string.IsNullOrEmpty(message) ? " " : "")}{message}";
        
    private static string GetFailureMessage(string methodName, string message)
    {
        string separator = Has(message) ? " " : "";

        return $"Assert.{methodName} failed.{separator}{message}";
    }
}
