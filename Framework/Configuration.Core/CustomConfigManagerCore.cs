// ReSharper disable UseSymbolAlias
// ReSharper disable MethodOverloadWithOptionalParameter

// TODO: Enable these warning again once implementation and tests are complete.
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Global

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
        string sectionName = GetSectionName<TConfig>();
        return GetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_getsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig GetSection<[Dyn(AllProps)]TConfig>(Assembly assembly) 
        where TConfig : class, new()
    {
        string sectionName = GetSectionName(assembly);
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
            throw NewNotFoundException(sectionName);
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
        string sectionName = GetSectionName<TConfig>();
        return TryGetSection<TConfig>(sectionName);
    }

    /// <inheritdoc cref="_trygetsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryGetSection<[Dyn(AllProps)]TConfig>(Assembly assembly)
        where TConfig : class, new()
    {
        string sectionName = GetSectionName(assembly);
        return TryGetSection<TConfig>(sectionName);
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

    #region SetSection
    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(TConfig obj)
    {
        SetSection(GetSectionName<TConfig>(), obj);
    }

    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(Assembly assembly, TConfig obj)
    {
        SetSection(GetSectionName(assembly), obj);
    }

    /// <inheritdoc cref="_setsection" />
    public static void SetSection<TConfig>(string sectionName, [NotNull] TConfig obj)
    {
        AssertSectionName(sectionName);
        ThrowIfNull(obj);

        lock (_lock)
        {
            _cache[sectionName] = obj;
        }
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(string sectionName, string xml)
        where TConfig : class, new()
    {
        TConfig? obj = TryLoadConfig<TConfig>(sectionName, xml);
        SetSection(sectionName, obj);
        return obj;
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes, Encoding? encoding = null)
        where TConfig : class, new()
    {
        TConfig? obj = TryLoadConfig<TConfig>(sectionName, bytes, encoding);
        SetSection(sectionName, obj);
        return obj;
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(string sectionName, Stream stream, Encoding? encoding = null)
        where TConfig : class, new()
    {
        TConfig? obj = TryLoadConfig<TConfig>(sectionName, stream, encoding);
        SetSection(sectionName, obj);
        return obj;
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(string sectionName, string filePath, Encoding? encoding = null)
        where TConfig : class, new()
    {
        TConfig? obj = TryLoadConfig<TConfig>(sectionName, filePath, encoding);
        SetSection(sectionName, obj);
        return obj;
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(string xml)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName<TConfig>(), xml);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<TConfig>(byte[] bytes, Encoding? encoding = null)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName<TConfig>(), bytes, encoding);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(Stream stream, Encoding? encoding = null)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName<TConfig>(), stream, encoding);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(string filePath, Encoding? encoding = null)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName<TConfig>(), filePath, encoding);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string xml)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName(assembly), xml);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, byte[] bytes, Encoding? encoding = null)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName(assembly), bytes, encoding);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, Stream stream, Encoding? encoding = null)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName(assembly), stream, encoding);
    }

    /// <inheritdoc cref="_setsection" />
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig SetSection<[Dyn(AllProps)]TConfig>(Assembly assembly, string filePath, Encoding? encoding = null)
        where TConfig : class, new()
    {
        return SetSection<TConfig>(GetSectionName(assembly), filePath, encoding);
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
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, Encoding? encoding = null) 
        where TConfig : class, new()
    {
        string? fileName = TryResolveConfigFileName();
        if (!Has(fileName)) 
        {
             return null;
        }
        return TryLoadConfig<TConfig>(sectionName, fileName, encoding);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string fileName, Encoding? encoding) 
        where TConfig : class, new()
    {
        byte[] bytes;
        using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            bytes = StreamToBytes(stream);
        }
        return TryLoadConfig<TConfig>(sectionName, bytes, encoding);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, Stream stream, Encoding? encoding)
        where TConfig : class, new()
    {
        byte[] bytes = StreamToBytes(stream);

        return TryLoadConfig<TConfig>(sectionName, bytes, encoding);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes, Encoding? encoding)
        where TConfig : class, new()
    {
        if (!Has(bytes))
        {
            return null;
        }

        string text = BytesToString(bytes, encoding ?? UTF8);

        return TryLoadConfig<TConfig>(sectionName, text);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xml) 
        where TConfig : class, new()
    {
        if (!Has(xml))
        {
            return null;
        }

        XmlDocument doc = new();
        doc.Load(xml); // TODO: Is Stream faster?

        XmlElement docElement = doc.DocumentElement.NotNull();

        // TODO: Nested sections. How does that work?
        XmlElement? sectionElement = XmlHelper.TryGetElement(docElement, sectionName);

        // If config section name not found, assume we're mapping the whole XML.
        sectionElement ??= docElement;

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