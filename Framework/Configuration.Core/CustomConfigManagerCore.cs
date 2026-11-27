// ReSharper disable UseSymbolAlias

// TODO: Enable these warning again once implementation and tests are complete.
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Global
#pragma warning disable IDE0051 // Never used private

namespace JJ.Framework.Configuration.Core;

/// <inheritdoc cref="_customconfigmanagercore" />
public static class CustomConfigManagerCore
{
    private const string TrimWarning = PropertyTypeAnd + ObjectGetType;
    private const string AotWarning = GenericList;

    private static readonly CultureInfo _culture = GetCultureInfo("en-US");
    private static readonly Dictionary<string, object> _cache = new();
    private static readonly Lock _lock = new();

    #region GetSection
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
            string fileName = ResolveConfigFileName();
            XmlDocument doc = new();
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                doc.Load(stream);
            }

            TConfig config = ParseConfig<TConfig>(sectionName, doc);
            _cache[sectionName] = config;
            return config;
        }
    }
    #endregion

    #region TryGetSection
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
            TConfig? config;
            string? fileName = TryResolveConfigFileName();
            if (!Has(fileName))
            {
                config = null;
            }
            else
            {
                XmlDocument doc = new();
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    doc.Load(stream);
                }
                config = ParseConfig<TConfig>(sectionName, doc);
            }

            if (config != null) 
            {
                _cache[sectionName] = config;
            }
            return config;
        }
    }
    #endregion

    #region SetSection
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

    #region ParseSection
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig ParseSection<[Dyn(AllProps)]TConfig>(string sectionName, string xml)
        where TConfig : class, new()
    {
        if (!Has(xml))
        {
            throw new Exception($"No {nameof(xml)}.");
        }

        XmlDocument doc = new();
        doc.Load(xml);

        TConfig obj = ParseConfig<TConfig>(sectionName, doc);

        SetSection(sectionName, obj);

        return obj;
    }
    
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig ParseSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string xml)
        where TConfig : class, new()
    {
        return ParseSection<TConfig>(GetSectionName(assembly), xml);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig ParseSection<[Dyn(AllProps)]TConfig>(string xml)
        where TConfig : class, new()
    {
        return ParseSection<TConfig>(GetSectionName<TConfig>(), xml);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig ParseSection<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes)
        where TConfig : class, new()
    {
        if (!Has(bytes))
        {
            throw new Exception($"No {nameof(bytes)}.");
        }

        Stream stream = BytesToStream(bytes);

        XmlDocument doc = new();
        doc.Load(stream);

        TConfig obj = ParseConfig<TConfig>(sectionName, doc);

        SetSection(sectionName, obj);

        return obj;
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig ParseSection<[Dyn(AllProps)]TConfig>(Assembly assembly, byte[] bytes)
        where TConfig : class, new()
    {
        return ParseSection<TConfig>(GetSectionName(assembly), bytes);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig ParseSection<TConfig>(byte[] bytes)
        where TConfig : class, new()
    {
        return ParseSection<TConfig>(GetSectionName<TConfig>(), bytes);
    }
    #endregion

    #region LoadSection
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadSection<[Dyn(AllProps)]TConfig>(string sectionName, Stream stream)
        where TConfig : class, new()
    {
        XmlDocument doc = new();
        doc.Load(stream);

        TConfig obj = ParseConfig<TConfig>(sectionName, doc);

        SetSection(sectionName, obj);

        return obj;
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadSection<[Dyn(AllProps)]TConfig>(Stream stream)
        where TConfig : class, new()
    {
        return LoadSection<TConfig>(GetSectionName<TConfig>(), stream);
    }
    
    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadSection<[Dyn(AllProps)]TConfig>(Assembly assembly, Stream stream)
        where TConfig : class, new()
    {
        return LoadSection<TConfig>(GetSectionName(assembly), stream);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadSection<[Dyn(AllProps)]TConfig>(string sectionName, string filePath)
        where TConfig : class, new()
    {
        XmlDocument doc = new();

        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            doc.Load(stream);
        }

        TConfig obj = ParseConfig<TConfig>(sectionName, doc);

        SetSection(sectionName, obj);

        return obj;
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadSection<[Dyn(AllProps)]TConfig>(string filePath)
        where TConfig : class, new()
    {
        return LoadSection<TConfig>(GetSectionName<TConfig>(), filePath);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string filePath)
        where TConfig : class, new()
    {
        return LoadSection<TConfig>(GetSectionName(assembly), filePath);
    }
    #endregion

    #region RefreshSection
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
    #endregion

    #region Clear
    public static void Clear()
    {
        lock (_lock)
        {
            _cache.Clear();
        }
    }
    #endregion

    #region Load

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig ParseConfig<[Dyn(AllProps)] TConfig>(string sectionName, XmlDocument doc)
        where TConfig : class, new()
    {
        XmlElement docElement = doc.DocumentElement.NotNull();
        XmlElement? sectionElement = XmlHelper.TryGetElement(docElement, sectionName); // TODO: Nested sections. How does that work?
        sectionElement ??= docElement; // If config section name not found, assume we're mapping the whole XML.

        var converter = new XmlToObjectConverter<TConfig>();
        TConfig config = converter.Convert(sectionElement);
        return config;
    }

    #endregion

    #region Resolve
    private static void AssertSectionName(string sectionName)
    {
        if (!Has(sectionName)) 
            throw new Exception($"{nameof(sectionName)} not filled in.");
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
        {
            throw new Exception("Assembly has no name.");
        }
        return name.ToLower(_culture);
    }

    private static string? TryResolveConfigFileName()
    {
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

        return null;
    }
    
    private static string ResolveConfigFileName()
    {
        string? configFileName = TryResolveConfigFileName();

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
}