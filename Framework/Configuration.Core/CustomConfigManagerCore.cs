#pragma warning disable IDE0060 // Unused parameter
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local
// ReSharper disable UseSymbolAlias
// ReSharper disable MethodOverloadWithOptionalParameter
using JJ.Framework.Common.Core;

namespace JJ.Framework.Configuration.Core;

/// <inheritdoc cref="_customconfigmanagercore" />
public static class CustomConfigManagerCore
{
    private const string TrimWarning = PropertyTypeAnd + ObjectGetType;
    private const string AotWarning = GenericList;

    private static readonly CultureInfo _culture = GetCultureInfo("en-US");
    private static readonly Dictionary<string, object> _cache = new();
    private static readonly Lock _lock = new();

    #region Resolve Config Path
    /// <inheritdoc cref="_supportedconfigfilenames" />
    public static IList<string> SupportedConfigFileNames 
    {
        get; set => field = value.NotNull(); 
    } = InitSupportedConfigFileNames();

    private static IList<string> InitSupportedConfigFileNames()
    {
        List<string> list = [];

        // {YourProjectName}.dll.config
        string? dllConfigFileName = TryGetDllConfigFileName();
        if (Has(dllConfigFileName))
        {
            list.Add(dllConfigFileName);
        }

        list.Add("app.config");
        list.Add("web.config");
        list.Add("testhost.dll.config");
        list.Add("nCrunch.TaskRunner.DotNetCore.20.x64.dll.config");

        return list;
    }

    /// <inheritdoc cref="_trygetconfigfilename"/>
    public static string? TryGetConfigFileName()
    {
        foreach (string fileName in SupportedConfigFileNames.ToArray())
        {
            if (Exists(fileName))
            {
                return fileName;
            }
        }

        return null;
    }
    
    /// <inheritdoc cref="_getconfigfilename"/>
    public static string GetConfigFileName()
    {
        string? configFileName = TryGetConfigFileName();

        if (Has(configFileName))
        {
            return configFileName;
        }

        string? dllConfigFileName = TryGetDllConfigFileName();

        throw new Exception(
            $"No config file found with expected file names " +
            $"'app.config', 'web.config'. '{dllConfigFileName}', " +
            $"'testhost.dll.config' or 'nCrunch.TaskRunner.DotNetCore.20.x64.dll.config' " +
            $"in folder: {CurrentDirectory}");
    }

    private static Exception NewNotFoundException(string sectionName)
    {
        string? dllConfigFileName = TryGetDllConfigFileName();
        return new Exception(
            $"Config section '{sectionName}' not found in any config with expected file names " +
            $"'app.config', 'web.config'. '{dllConfigFileName}', " +
            $"'testhost.dll.config' or 'nCrunch.TaskRunner.DotNetCore.20.x64.dll.config' " +
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
            TConfig config = LoadConfig<TConfig>(sectionName);
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
            var config = TryLoadConfig<TConfig>(sectionName);
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
    {
        SetSection(GetSectionName<TConfig>(), obj);
    }

    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly, [NotNull] TConfig obj)
    {
        SetSection(GetSectionName(assembly), obj);
    }

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

    #region From Text or Bytes
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, string xml, NameOvl ovl1 = default)
        where TConfig : class, new()
    {
        TConfig obj = LoadConfig<TConfig>(sectionName, xml: xml);
        SetSection(sectionName, obj);
    }
    
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string xml, NameOvl ovl1 = default)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName(assembly), xml: xml);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string xml, NameOvl ovl1 = default)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName<TConfig>(), xml: xml);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes)
        where TConfig : class, new()
    {
        TConfig obj = LoadConfig<TConfig>(sectionName, bytes);
        SetSection(sectionName, obj);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, byte[] bytes)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName(assembly), bytes);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<TConfig>(byte[] bytes)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName<TConfig>(), bytes);
    }
    #endregion

    #region From File Or Stream
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, Stream stream)
        where TConfig : class, new()
    {
        TConfig obj = LoadConfig<TConfig>(sectionName, stream);
        SetSection(sectionName, obj);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Stream stream)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName<TConfig>(), stream);
    }
    
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, Stream stream)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName(assembly), stream);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string sectionName, string filePath, NameOvl ovl1 = default, NameOvl ovl2 = default)
        where TConfig : class, new()
    {
        TConfig obj = LoadConfig<TConfig>(sectionName, filePath: filePath);
        SetSection(sectionName, obj);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(string filePath, NameOvl ovl1 = default, NameOvl ovl2 = default)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName<TConfig>(), filePath: filePath);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static void SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string filePath, NameOvl ovl1 = default, NameOvl ovl2 = default)
        where TConfig : class, new()
    {
        SetSection<TConfig>(GetSectionName(assembly), filePath: filePath);
    }
    #endregion

    #region Refresh
    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection<TConfig>()
    {
        RefreshSection(GetSectionName<TConfig>());
    }

    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection(Assembly assembly)
    {
        RefreshSection(GetSectionName(assembly));
    }

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

    #region Load
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        string fileName = GetConfigFileName();
        return LoadConfig<TConfig>(sectionName, filePath: fileName);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        string? fileName = TryGetConfigFileName();
        return TryLoadConfig<TConfig>(sectionName, filePath: fileName);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string filePath, NameOvl ovl1 = default) 
        where TConfig : class, new()
    {
        if (!Has(filePath))
        {
            throw new Exception($"No {nameof(filePath)} provided.");
        }

        if (!Exists(filePath))
        {
            throw new Exception("File not found.");
        }

        XmlDocument doc = new();
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            doc.Load(stream);
        }
        return LoadConfig<TConfig>(sectionName, doc);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string? filePath, NameOvl ovl1 = default) 
        where TConfig : class, new()
    {
        if (!Has(filePath)) 
        {
            return null;
        }

        if (!Exists(filePath))
        {
            return null;
        }

        XmlDocument doc = new();
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            doc.Load(stream);
        }
        return TryLoadConfig<TConfig>(sectionName, doc);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, Stream stream)
        where TConfig : class, new()
    {
        XmlDocument doc = new();
        doc.Load(stream);

        return LoadConfig<TConfig>(sectionName, doc);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes)
        where TConfig : class, new()
    {
        if (!Has(bytes))
        {
            throw new Exception($"No {nameof(bytes)}.");
        }

        Stream stream = BytesToStream(bytes);

        return LoadConfig<TConfig>(sectionName, stream);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xml, NameOvl ovl1 = default, NameOvl ovl2 = default) 
        where TConfig : class, new()
    {
        if (!Has(xml))
        {
            throw new Exception($"No {nameof(xml)}.");
        }

        XmlDocument doc = new();
        doc.LoadXml(xml);

        return LoadConfig<TConfig>(sectionName, doc);
    }
    
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig LoadConfig<[Dyn(AllProps)] TConfig>(string sectionName, XmlDocument doc)
        where TConfig : class, new()
    {
        var config = TryLoadConfig<TConfig>(sectionName, doc);
        if (config == null)
        {
            throw NewNotFoundException(sectionName);
        }
        return config;
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)] TConfig>(string sectionName, XmlDocument doc)
        where TConfig : class, new()
    {
        XmlElement docElement = doc.DocumentElement.NotNull();
        XmlElement? sectionElement = XmlHelper.TryGetElement(docElement, sectionName); // TODO: Nested sections. How does that work?

        if (sectionElement == null) 
        {
            return null;
        }

        var converter = new XmlToObjectConverter<TConfig>();
        TConfig config = converter.Convert(sectionElement);
        return config;
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

    [Obsolete(SPECIFY_XML_OR_FILE_PATH, true)]
    private static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xmlOrFilePath) => throw new NotSupportedException(SPECIFY_XML_OR_FILE_PATH);

    [Obsolete(SPECIFY_XML_OR_FILE_PATH, true)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xmlOrFilePath) => throw new NotSupportedException(SPECIFY_XML_OR_FILE_PATH);

    // ReSharper restore UnusedTypeParameter
    // ReSharper restore UnusedMember.Global
    // ReSharper restore UnusedMember.Local
    // ReSharper restore UnusedParameter.Global
    // ncrunch: no coverage end
    #pragma warning restore IDE0051
    #endregion
}