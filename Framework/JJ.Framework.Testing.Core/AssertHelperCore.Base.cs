// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Testing.Core;

public static partial class AssertHelperCore
{
    // Generalized Methods
    
    internal static void ExpectedActualCheckCore<T>(Func<T, bool> condition, string methodName, T expected, Expression<Func<T>> actualExpression, string? name = null)
    {
        T actual = ExpressionHelper.GetValue(actualExpression);
        
        if (IsNullOrWhiteSpace(name))
        {
            name = ExpressionHelper.GetText(actualExpression);
        }
        
        ExpectedActualCheckCore(() => condition(actual), methodName, expected, actual, name);
    }
    
    private static void ExpectedActualCheckCore<T>(Func<bool> condition, string methodName, T expected, T actual, string? name = null)
    {
        if (!condition())
        {
            string message = FormatTestedPropertyMessageLegacy(name);
            string fullMessage = GetExpectedActualMessageLegacy(methodName, expected, actual, message);
            throw new Exception(fullMessage);
        }
    }
    
    public static void Check(Func<bool> condition, string methodName, string? name = null)
        => Check(condition(), methodName, name);
    
    public static void Check(bool condition, string methodName, string? name = null)
    {
        if (!condition)
        {
            string message = FormatTestedPropertyMessageLegacy(name);
            string fullMessage = GetFailureMessageLegacy(methodName, message);
            throw new Exception(fullMessage);
        }
    }
}
