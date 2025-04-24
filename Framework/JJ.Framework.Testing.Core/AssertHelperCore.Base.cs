// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    // Generalized Methods
    
    internal static void ExpectedActualCheckCore<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression, string? nameOrMessage = null)
    {
        T actual = ExpressionHelper.GetValue(actualExpression);
        
        if (IsNullOrWhiteSpace(nameOrMessage))
        {
            nameOrMessage = ExpressionHelper.GetText(actualExpression);
        }
        
        ExpectedActualCheckCore(condition, methodName, expected, actual, nameOrMessage);
    }

    private static void ExpectedActualCheckCore<T>(Func<T, T, bool> condition, string methodName, T expected, T actual, string? nameOrMessage = null)
        => ExpectedActualCheckCore(() => condition(expected, actual), methodName, expected, actual, nameOrMessage);

    private static void ExpectedActualCheckCore<T>(Func<T, bool> condition, string methodName, T expected, T actual, string? nameOrMessage = null)
        => ExpectedActualCheckCore(() => condition(actual), methodName, expected, actual, nameOrMessage);

    private static void ExpectedActualCheckCore<T>(Func<bool> condition, string methodName, T expected, T actual, string? nameOrMessage = null)
    {
        if (!condition())
        {
            string message = FormatTestedPropertyMessageLegacy(nameOrMessage);
            string fullMessage = GetExpectedActualMessageLegacy(methodName, expected, actual, message);
            throw new Exception(fullMessage);
        }
    }
    
    private static void Check(Func<bool> condition, string methodName, string? name = null)
        => Check(condition(), methodName, name);
    
    private static void Check(bool condition, string methodName, string? name = null)
    {
        if (!condition)
        {
            string message = FormatTestedPropertyMessageLegacy(name);
            string fullMessage = GetFailureMessageLegacy(methodName, message);
            throw new Exception(fullMessage);
        }
    }
}
