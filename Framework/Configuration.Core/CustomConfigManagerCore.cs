#pragma warning disable IDE0060 // Unused parameter
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local
// ReSharper disable UseSymbolAlias
// ReSharper disable MethodOverloadWithOptionalParameter

namespace JJ.Framework.Configuration.Core;

/// <inheritdoc cref="_customconfigmanagercore" />
public static class CustomConfigManagerCore
{
    private static readonly CultureInfo _culture = GetCultureInfo("en-US");
    private static readonly Dictionary<string, object> _cache = new();
    private static readonly Lock _lock = new();

    #region Resolve Config File
    /// <inheritdoc cref="_supportedconfigfilenames" />
    public static IList<string> SupportedConfigFileNames
    { 
        get => ConfigFileResolver.SupportedConfigFileNames; 
        set => ConfigFileResolver.SupportedConfigFileNames = value;
    }

    /// <inheritdoc cref="_trygetconfigfilename"/>
    public static string? TryGetConfigFileName() => ConfigFileResolver.TryGetConfigFileName();
    
    /// <inheritdoc cref="_getconfigfilename"/>
    public static string GetConfigFileName() => ConfigFileResolver.GetConfigFileName();
    #endregion

    #region Get
    /// <inheritdoc cref="_getsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig GetSection<[Dyn(AllProps)]TConfig>() 
        where TConfig : class, new()
    {
        return GetSection<TConfig>(GetSectionName<TConfig>());
    }

    /// <inheritdoc cref="_getsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig GetSection<[Dyn(AllProps)]TConfig>(Assembly assembly) 
        where TConfig : class, new()
    {
        return GetSection<TConfig>(GetSectionName(assembly));
    }

    /// <inheritdoc cref="_getsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig GetSection<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        AssertSectionName(sectionName);

        lock (_lock)
        {
            if (_cache.TryGetValue(sectionName, out object? obj))
            {
                return (TConfig)obj;
            }
        }

        lock (_lock)
        {
            TConfig config = ConfigLoader.LoadConfig<TConfig>(sectionName);
            _cache[sectionName] = config;
            return config;
        }
    }
    #endregion

    #region TryGet
    /// <inheritdoc cref="_trygetsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryGetSection<[Dyn(AllProps)]TConfig>() 
        where TConfig : class, new()
    {
        return TryGetSection<TConfig>(GetSectionName<TConfig>());
    }

    /// <inheritdoc cref="_trygetsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryGetSection<[Dyn(AllProps)]TConfig>(Assembly assembly)
        where TConfig : class, new()
    {
        return TryGetSection<TConfig>(GetSectionName(assembly));
    }

    /// <inheritdoc cref="_trygetsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryGetSection<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        AssertSectionName(sectionName);

        lock (_lock)
        {
            if (_cache.TryGetValue(sectionName, out object? obj))
            {
                return (TConfig)obj;
            }
        }

        lock (_lock)
        {
            var config = ConfigLoader.TryLoadConfig<TConfig>(sectionName);
            if (config != null) 
            {
                _cache[sectionName] = config;
            }
            return config;
        }
    }
    #endregion

    #region Set
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>([NotNull] TConfig obj) 
        => SetSection(GetSectionName<TConfig>(), obj);

    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly, [NotNull] TConfig obj) 
        => SetSection(GetSectionName(assembly), obj);

    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(string sectionName, [NotNull] TConfig obj)
    {
        ThrowIfNull(obj);
        AssertSectionName(sectionName);

        lock (_lock)
        {
            _cache[sectionName] = obj;
        }
    }
    #endregion

    #region Set by Text or Bytes
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, string xml, NameOvl ovl1 = default)
        where TConfig : class, new()
    {
        TConfig obj = ConfigLoader.LoadConfig<TConfig>(sectionName, xml: xml);
        SetSection(sectionName, obj);
    }
    
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string xml, NameOvl ovl1 = default)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName(assembly), xml: xml);

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string xml, NameOvl ovl1 = default)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName<TConfig>(), xml: xml);

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes)
        where TConfig : class, new()
    {
        TConfig obj = ConfigLoader.LoadConfig<TConfig>(sectionName, bytes);
        SetSection(sectionName, obj);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, byte[] bytes)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName(assembly), bytes);

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<TConfig>(byte[] bytes)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName<TConfig>(), bytes);

    #endregion

    #region Set by File Or Stream
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, Stream stream)
        where TConfig : class, new()
    {
        TConfig obj = ConfigLoader.LoadConfig<TConfig>(sectionName, stream);
        SetSection(sectionName, obj);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Stream stream)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName<TConfig>(), stream);

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, Stream stream)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName(assembly), stream);

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, string filePath, NameOvl ovl1 = default, NameOvl ovl2 = default)
        where TConfig : class, new()
    {
        TConfig obj = ConfigLoader.LoadConfig<TConfig>(sectionName, filePath: filePath);
        SetSection(sectionName, obj);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string filePath, NameOvl ovl1 = default, NameOvl ovl2 = default)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName<TConfig>(), filePath: filePath);

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string filePath, NameOvl ovl1 = default, NameOvl ovl2 = default)
        where TConfig : class, new()
        => SetSection<TConfig>(GetSectionName(assembly), filePath: filePath);

    #endregion

    #region Refresh
    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection<TConfig>() 
        => RefreshSection(GetSectionName<TConfig>());

    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection(Assembly assembly) 
        => RefreshSection(GetSectionName(assembly));

    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection(string sectionName)
    {
        AssertSectionName(sectionName);

        lock (_lock)
        {
            _cache.Remove(sectionName);
        }
    }

    /// <inheritdoc cref="_refreshallsections" />
    public static void RefreshAllSections()
    {
        lock (_lock)
        {
            _cache.Clear();
        }
    }
    #endregion

    #region Helpers
    private static void AssertSectionName(string sectionName)
    {
        if (!Has(sectionName)) 
            throw new Exception($"No {nameof(sectionName)}.");
    }

    private static string GetSectionName<TConfig>()
    {
        Assembly assembly = typeof(TConfig).Assembly;
        return GetSectionName(assembly);
    }

    private static string GetSectionName(Assembly assembly)
    {
        var name = assembly.NotNull().GetName().Name;

        if (!Has(name))
            throw new Exception("Assembly has no name."); // ncrunch: no coverage

        return name.ToLower(_culture);
    }
    #endregion
    
    #region Enforce Argument Names

    #pragma warning disable IDE0051
    // ncrunch: no coverage start
    // ReSharper disable UnusedTypeParameter
    // ReSharper disable UnusedMember.Global
    // ReSharper disable UnusedMember.Local
    // ReSharper disable UnusedParameter.Global

    private const string SPECIFY_XML_OR_FILE_PATH = "Specify argument name xml: or filePath: to disambiguate";

    /// <inheritdoc cref="_setsection" />
    [Obsolete(SPECIFY_XML_OR_FILE_PATH, true)]
    public static void SetSection<TConfig>(string sectionName, string xmlOrFilePath) => throw new NotSupportedException(SPECIFY_XML_OR_FILE_PATH);

    /// <inheritdoc cref="_setsection" />
    [Obsolete(SPECIFY_XML_OR_FILE_PATH, true)]
    public static void SetSection<TConfig>(Assembly assembly, string xmlOrFilePath) => throw new NotSupportedException(SPECIFY_XML_OR_FILE_PATH);

    /// <inheritdoc cref="_setsection" />
    [Obsolete(SPECIFY_XML_OR_FILE_PATH, true)]
    public static void SetSection<TConfig>(string xmlOrFilePath) => throw new NotSupportedException(SPECIFY_XML_OR_FILE_PATH);

    #endregion
}