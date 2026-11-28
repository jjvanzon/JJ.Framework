// ReSharper disable MethodOverloadWithOptionalParameter
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Configuration.Core;

internal static class ConfigLoader
{
    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        string fileName = ConfigFileResolver.GetConfigFileName();
        return LoadConfig<TConfig>(sectionName, filePath: fileName);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig? TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName) 
        where TConfig : class, new()
    {
        string? fileName = ConfigFileResolver.TryGetConfigFileName();
        return TryLoadConfig<TConfig>(sectionName, filePath: fileName);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string filePath, NameOvl ovl1 = default) 
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
            return null;

        if (!Exists(filePath))
            return null; // ncrunch: no coverage

        XmlDocument doc = new();
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            doc.Load(stream);
        }
        return TryLoadConfig<TConfig>(sectionName, doc);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, Stream stream)
        where TConfig : class, new()
    {
        XmlDocument doc = new();
        doc.Load(stream);

        return LoadConfig<TConfig>(sectionName, doc);
    }

    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    public static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes)
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
    public static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xml, NameOvl ovl1 = default, NameOvl ovl2 = default) 
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
            throw ConfigFileResolver.CreateNotFoundException(sectionName);
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

    #region Enforce Argument Names

    #pragma warning disable IDE0051
    // ncrunch: no coverage start
    // ReSharper disable UnusedTypeParameter
    // ReSharper disable UnusedMember.Global
    // ReSharper disable UnusedMember.Local
    // ReSharper disable UnusedParameter.Global
    // ReSharper disable UnusedParameter.Local

    [Obsolete(SPECIFY_XML_OR_FILE_PATH, true)]
    private static TConfig LoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xmlOrFilePath) => throw new NotSupportedException(SPECIFY_XML_OR_FILE_PATH);

    [Obsolete(SPECIFY_XML_OR_FILE_PATH, true)]
    private static TConfig TryLoadConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xmlOrFilePath) => throw new NotSupportedException(SPECIFY_XML_OR_FILE_PATH);

    #endregion
}