// ReSharper disable UseSymbolAlias

namespace JJ.Framework.Configuration.Core;

/// <inheritdoc cref="_customconfigmanagercore" />
public static class CustomConfigManagerCore
{
    private static readonly CultureInfo _culture = GetCultureInfo("en-US");

    // Cache

    private static readonly Dictionary<(Type, string), object> _cache = new();
    private static readonly Lock _lock = new();

    // GetSection

    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>()
    {
        var sectionName = ResolveSectionName<TConfig>();
        return GetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>(Assembly assembly)
    {
        var sectionName = ResolveSectionName(assembly);
        return GetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>(string sectionName)
    {
        TConfig? config = TryGetSection<TConfig>(sectionName);
        if (config == null) 
        {
            throw new Exception($"Config section '{sectionName}' not found.");
        }
        return config;
    }

    // TryGetSection

    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>()
    {
        var sectionName = ResolveSectionName<TConfig>();
        return TryGetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>(Assembly assembly)
    {
        var sectionName = ResolveSectionName(assembly);
        return TryGetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>(string sectionName)
    {
        var key = (typeof(TConfig), sectionName);

        lock (_lock)
        {
            if (_cache.TryGetValue(key, out object config))
            {
                return (TConfig)config;
            }

                 
        }

        throw new NotImplementedException();
    }

    // SetSection

    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(                      TConfig obj) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly,    TConfig obj) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(string   sectionName, TConfig obj) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(                      string xml                                                               ) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(                      byte[] bytes,    Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(                      Stream stream,   Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(                      string filePath, Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly,    string xml                                                               ) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly,    byte[] bytes,    Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly,    Stream stream,   Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly,    string filePath, Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(string   sectionName, string xml                                                               ) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(string   sectionName, byte[] bytes,    Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(string   sectionName, Stream stream,   Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(string   sectionName, string filePath, Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();

    // RefreshSection

    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection<TConfig>() => throw new NotImplementedException();
    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection(Assembly assembly) => throw new NotImplementedException();
    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection(string  sectionName) => throw new NotImplementedException();
    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection<TConfig>(Assembly assembly) => throw new NotImplementedException();
    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection<TConfig>(string  sectionName) => throw new NotImplementedException();

    // Resolve

    private static string ResolveSectionName<TConfig>() => ResolveSectionName(typeof(TConfig).Assembly);
    private static string ResolveSectionName(Assembly assembly) => assembly.NotNull().GetName().Name.NotNull().ToLower(_culture);
    private static string ResolveConfigFile() => throw new NotImplementedException();
}