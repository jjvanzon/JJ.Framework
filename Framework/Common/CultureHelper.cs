namespace JJ.Framework.Common;

/// <inheritdoc cref="_culturehelper" />
public static partial class CultureHelper
{
    /// <inheritdoc cref="_culturehelper" />
    public static void SetCurrentCulture(CultureInfo cultureInfo)
    {
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;
    }

    /// <inheritdoc cref="_culturehelper" />
    public static void SetCurrentCultureName(string cultureName)
    {
        var cultureInfo = new CultureInfo(cultureName);
        SetCurrentCulture(cultureInfo);
    }

    /// <inheritdoc cref="_culturehelper" />
    public static CultureInfo GetCurrentCulture() => Thread.CurrentThread.CurrentCulture;

    /// <inheritdoc cref="_culturehelper" />
    public static string GetCurrentCultureName() => Thread.CurrentThread.CurrentCulture.Name;
}