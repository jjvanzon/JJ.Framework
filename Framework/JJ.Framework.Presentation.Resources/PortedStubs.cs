// Ported from "The King": legacy branch HEAD

// ReSharper disable ConvertToExtensionBlock

namespace JJ.Framework.StringResources.Legacy;

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
    public static void SetCurrentCultureName(string cultureName) => SetCurrentCulture(GetCultureInfo(cultureName));
    
    /// <inheritdoc cref="_portedstubs" />
    public static CultureInfo GetCurrentCulture() => CurrentThread.CurrentCulture;
}

/// <inheritdoc cref="_portedstubs" />
internal static class ReflectionExtensions
{
    /// <inheritdoc cref="_portedstubs" />
    public static bool IsProperty(this MethodBase method)
    {
        return method.Name.StartsWith("get_") ||
               method.Name.StartsWith("set_");
    }
}

/// <inheritdoc cref="_portedstubs" />
internal class UnexpectedTypeException : Exception
{
    // ncrunch: no coverage start

    /// <inheritdoc cref="_portedstubs" />
    public UnexpectedTypeException(Func<object> func, [ArgExpress(nameof(func))] string name = "")
    {
        string typeName = func.Invoke()?.GetType().Name ?? "<null>";
        Message = $"{name} has an unexpected type: {typeName}.";
    }

    /// <inheritdoc cref="_portedstubs" />
    public override string Message { get; }

    // ncrunch: no coverage end
}
