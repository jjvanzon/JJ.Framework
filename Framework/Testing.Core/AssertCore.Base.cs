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
            string fullMessage = GetExpectedActualMessageLegacy(methodName, expected, actual, message);
            throw new Exception(fullMessage);
        }
    }

    private static void Check(
        bool condition, string message, [Caller] string methodName = "")
    {
        if (!condition)
        {
            message = FormatTestedExpressionMessage(message);
            string fullMessage = GetFailureMessageLegacy(methodName, message);
            throw new Exception(fullMessage);
        }
    }
}
