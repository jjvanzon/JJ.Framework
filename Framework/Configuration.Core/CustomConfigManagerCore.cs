namespace JJ.Framework.Configuration.Core;

/// <inheritdoc cref="_customconfigmanagercore" />
public static class CustomConfigManagerCore
{
    // Cache

    private static readonly Dictionary<(Type, string), object> _cache = new();
    private static readonly Lock _lock = new();

    // GetSection

    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>() => throw new NotImplementedException();
    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>(Assembly assembly) => throw new NotImplementedException();
    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>(string sectionName) => throw new NotImplementedException();

    // TryGetSection

    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>() => throw new NotImplementedException();
    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>(Assembly assembly) => throw new NotImplementedException();
    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>(string sectionName) => throw new NotImplementedException();

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

    private static string ResolveSectionName() => throw new NotImplementedException();
    private static string ResolveConfigFile() => throw new NotImplementedException();
}