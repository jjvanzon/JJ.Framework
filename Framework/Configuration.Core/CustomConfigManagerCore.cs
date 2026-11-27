// ReSharper disable UseSymbolAlias

// TODO: Enable these warning again once implementation and tests are complete.
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Global

using static System.Reflection.Assembly;

namespace JJ.Framework.Configuration.Core;

/// <inheritdoc cref="_customconfigmanagercore" />
public static class CustomConfigManagerCore
{
    private const string TrimWarning = PropertyTypeAnd + ObjectGetType;
    private const string AotWarning = GenericList;

    private static readonly CultureInfo _culture = GetCultureInfo("en-US");
    private static readonly Dictionary<(Type, string), object?> _cache = new();
    private static readonly Lock _lock = new();

    #region GetSection
    /// <inheritdoc cref="_getsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig GetSection<[Dyn(AllProps)]TConfig>() 
        where TConfig : class, new()
    {
        var sectionName = ResolveSectionName<TConfig>();
        return GetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_getsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig GetSection<[Dyn(AllProps)]TConfig>(Assembly assembly) 
        where TConfig : class, new()
    {
        var sectionName = ResolveSectionName(assembly);
        return GetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_getsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig GetSection<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        TConfig? config = TryGetSection<TConfig>(sectionName);
        if (config == null) 
        {
            throw new Exception($"Config section '{sectionName}' not found.");
        }
        return config;
    }
    #endregion

    #region TryGetSection
    /// <inheritdoc cref="_trygetsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryGetSection<[Dyn(AllProps)]TConfig>() 
        where TConfig : class, new()
    {
        var sectionName = ResolveSectionName<TConfig>();
        return TryGetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_trygetsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryGetSection<[Dyn(AllProps)]TConfig>(Assembly assembly)
        where TConfig : class, new()
    {
        var sectionName = ResolveSectionName(assembly);
        return TryGetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_trygetsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryGetSection<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        var key = (typeof(TConfig), sectionName);

        lock (_lock)
        {
            if (_cache.TryGetValue(key, out object? obj))
            {
                return (TConfig?)obj;
            }

            var config = LoadConfig<TConfig>(sectionName);
             _cache[key] = config;

            return config;
        }
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        string configFileName = ResolveConfigFileName();
        if (!Has(configFileName)) 
             return null;

        string content = ReadAllText(configFileName);
        if (!Has(content))
            return null;

        var doc = new XmlDocument();
        doc.Load(content); // TODO: Is Stream faster?
        XmlElement docElement = doc.DocumentElement.NotNull();
        XmlElement? sectionElement = XmlHelper.TryGetElement(docElement, sectionName);
        // If config section name not found, assume we're mapping the whole XML.
        sectionElement ??= docElement;

        var converter = new XmlToObjectConverter<TConfig>();
        TConfig config = converter.Convert(sectionElement);
        return config;
    }

    #endregion

    #region SetSection
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
    #endregion

    #region RefreshSection
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
    #endregion

    #region Resolve
    private static string ResolveSectionName<TConfig>()
    {
        Assembly assembly = typeof(TConfig).Assembly;
        return ResolveSectionName(assembly);
    }

    private static string ResolveSectionName(Assembly assembly)
    {
        return assembly.NotNull().GetName().Name.NotNull().ToLower(_culture);
    }

    private static string ResolveConfigFileName()
    {
        // TODO: What if more configs exist and the section is in only one?
        if (Exists("app.config"))
        {
            return "app.config";
        }

        if (Exists("web.config"))
        {
            return "web.config";
        }

        // {YourProjectName}.dll.config
        string? dllConfigFileName = TryGetDllConfigFileName();
        if (Has(dllConfigFileName) && Exists(dllConfigFileName))
        {
            return dllConfigFileName;
        }

        if (Exists("testhost.dll.config"))
        {
            return "testhost.dll.config";
        }

        if (Exists("nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"))
        {
            return "nCrunch.TaskRunner.DotNetCore.20.x64.dll.config";
        }

        throw new Exception(
            "No config files found with expected file names " +
            $"'app.config', 'web.config'. '{dllConfigFileName}', " +
            "'testhost.dll.config' or 'nCrunch.TaskRunner.DotNetCore.20.x64.dll.config' " +
            $"in folder: {CurrentDirectory}");
    }

    private static string? TryGetDllConfigFileName()
    {
        string? entryAssemblyName = GetEntryAssembly()?.GetName().Name;

        if (Has(entryAssemblyName))
        {
            return $"{entryAssemblyName}.dll.config";
        }

        return null;
    }

    #endregion
}