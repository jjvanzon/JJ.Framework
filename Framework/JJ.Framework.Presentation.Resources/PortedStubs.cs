namespace JJ.Framework.ResourceStrings.Legacy;

/// <inheritdoc cref="_portedstubs" />
internal static class CultureHelper
{
    /// <inheritdoc cref="_portedstubs" />
    public static void SetCurrentCulture(CultureInfo cultureInfo)
    {
        CurrentThread.CurrentCulture = cultureInfo;
        CurrentThread.CurrentUICulture = cultureInfo;
    }

    /// <inheritdoc cref="_portedstubs" />
    public static void SetCurrentCultureName(string cultureName) => SetCurrentCulture(new CultureInfo(cultureName));
    
    /// <inheritdoc cref="_portedstubs" />
    public static CultureInfo GetCurrentCulture() => CurrentThread.CurrentCulture;
}

/// <inheritdoc cref="_portedstubs" />
internal static class AssertHelper
{
    /// <inheritdoc cref="_portedstubs" />
    public static void AreEqual<T>(T expected, Func<T> actualFunc, [ArgExpress(nameof(actualFunc))] string name = "")
    {
        T actual = actualFunc();

        if (!Equals(expected, actual))
        {
           throw new Exception($"AreEqual failed. Expected: '{expected}'. Actual: '{actual}'. Tested: {name}");
        }
    }

    /// <inheritdoc cref="_portedstubs" />
    public static void NotNullOrWhiteSpace(Func<string> actualFunc, string name)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="_portedstubs" />
    public static void IsOfType<T>(Func<object> actualFunc, object name)
    {
        throw new NotImplementedException();
    }
}

/// <inheritdoc cref="_portedstubs" />
internal static class ReflectionExtensions
{
    /// <inheritdoc cref="_portedstubs" />
    public static object GetValue(this PropertyInfo prop)
    {
        throw new NotImplementedException();
    }

    public static object Invoke(this MethodBase method, object[] parameters)
    {
        throw new NotImplementedException();
    }

    public static bool IsProperty(this MethodBase method)
    {
        throw new NotImplementedException();
    }
}

internal class UnexpectedTypeException : Exception
{
    public UnexpectedTypeException(Func<object> func, [ArgExpress(nameof(func))] string name = "")
    {
        string typeName = func?.Invoke()?.GetType().Name ?? "<null>";
        Message = $"{name} has an unexpected type: {typeName}.";
    }

    public override string Message { get; }

}
