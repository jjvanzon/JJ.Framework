// ReSharper disable ConvertToExtensionBlock

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
        if (!Equals(expected, actual)) throw new Exception($"AreEqual assertion failed. Tested: {name}. Expected: '{expected}'. Actual: '{actual}'");
    }

    /// <inheritdoc cref="_portedstubs" />
    public static void NotNullOrWhiteSpace(Func<string> actualFunc, [ArgExpress(nameof(actualFunc))] string name = "")
    {
        string actual = actualFunc();
        if (string.IsNullOrWhiteSpace(actual)) throw new Exception($"NotNullOrWhiteSpace assertion failed. Tested: {name}");
    }

    /// <inheritdoc cref="_portedstubs" />
    public static void IsOfType<T>(Func<object> objFunc, [ArgExpress(nameof(objFunc))] string name = "")
    {
        Type actual = objFunc?.Invoke()?.GetType();
        Type expected = typeof(T);
        if (expected != actual) throw new Exception($"IsOfType assertion failed. Tested: {name}. Expected: '{expected}'. Actual: '{actual}'");
    }
}

/// <inheritdoc cref="_portedstubs" />
internal static class ReflectionExtensions
{
    /// <inheritdoc cref="_portedstubs" />
    public static object GetValue(this PropertyInfo prop)
    {
        ThrowIfNull(prop);
        return prop.GetValue(null);
    }

    public static object Invoke(this MethodBase method, object[] parameters)
    {
        ThrowIfNull(method);
        ThrowIfNull(parameters);
        return method.Invoke(null, parameters);
    }

    public static bool IsProperty(this MethodBase method)
    {
        ThrowIfNull(method);
        ThrowIfNull(method.Name);
        return method.Name.StartsWith("get_") ||
               method.Name.StartsWith("set_");
    }
}

internal class UnexpectedTypeException : Exception
{
    // ncrunch: no coverage start
    public UnexpectedTypeException(Func<object> func, [ArgExpress(nameof(func))] string name = "")
    {
        string typeName = func?.Invoke()?.GetType().Name ?? "<null>";
        Message = $"{name} has an unexpected type: {typeName}.";
    }

    public override string Message { get; }
    // ncrunch: no coverage end
}
