AssertCore.Check Variants Removed
=================================

*Grouped by reason removed*

Lambda variants
---------------

```cs
    #if !NET9_0_OR_GREATER
    [TrimWarn(ArrayInit)]
    #endif
    private static void Check<T>(
        T expected, Expression<Func<T>> actualExpression, 
        Func<T, bool> condition, [Caller] string methodName = "")
        => Check(expected, actualExpression, "", condition, methodName);

    #if !NET9_0_OR_GREATER
    [TrimWarn(ArrayInit)]
    #endif
    private static void Check<T>(
        T expected, Expression<Func<T>> actualExpression, string message,
        Func<T, bool> condition, [Caller] string methodName = "")
    {
        T actual = GetValue(actualExpression);
        message = Coalesce(message, GetText(actualExpression));
        Check(expected, actual, message, condition, methodName);
    }
```

Redundant "expected" parameter in Func
---------------------------------------

```cs
    
    private static void Check<T>(
        T expected, T actual, string message,
        Func<T, T, bool> condition, 
        [Caller] string methodName = "")
        => Check(expected, actual, message, () => condition(expected, actual), methodName);
```

Func where bool would suffice
-----------------------------

```cs
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
```

Without message parameter
-------------------------

```cs

    private static void Check<T>(
        T expected, T actual, 
        Func<T, T, bool> condition,
        [Caller] string methodName = "")
        => Check(expected, actual, "", () => condition(expected, actual), methodName);
    
    private static void Check<T>(
        T expected, T actual, 
        Func<T, bool> condition, [Caller] string methodName = "")
        => Check(expected, actual, "", () => condition(actual), methodName);
        
    private static void Check<T>(
        T expected, T actual, 
        Func<bool> condition,
        [Caller] string methodName = "")
        => Check(expected, actual, "", () => condition(), methodName);

    private static void Check(
        Func<bool> condition, [Caller] string methodName = "")
        => Check(condition(), "", methodName);

    private static void Check(
        bool condition, [Caller] string methodName = "")
        => Check(condition, "", methodName);
    
    private static string GetExpectedMessage<T>(string methodName, T expected, string message)
        => $"Assert.{methodName} failed. Expected <{(expected != null ? expected.ToString() : "null")}>.{(!string.IsNullOrEmpty(message) ? " " : "")}{message}";
```