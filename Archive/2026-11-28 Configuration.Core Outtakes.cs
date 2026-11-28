    <NoWarn>$(NoWarn);CS1591</NoWarn> <!--Missing doc lenience-->


// TODO: Enable these warning again once implementation and tests are complete.
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedParameter.Global

#pragma warning disable IDE0051 // Never used private

    #region Clear

    public static void ClearSection<TConfig>()
    {
        string sectionName = GetSectionName<TConfig>();
        ClearSection(sectionName);
    }

    public static void ClearSection(Assembly assembly)
    {
        string sectionName = GetSectionName(assembly);
        ClearSection(sectionName);
    }

    public static void ClearSection(string sectionName)
    {
        lock (_lock)
        {
            _cache.Remove(sectionName);
        }
    }
    #endregion


    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryParseConfig<[Dyn(AllProps)]TConfig>(string sectionName, byte[] bytes)
        where TConfig : class, new()
    {
        if (!Has(bytes))
        {
            return null;
        }

        Stream stream = BytesToStream(bytes);

        return LoadConfig<TConfig>(sectionName, stream);
    }


    [TrimWarn(TrimWarning), AotWarn(AotWarning)]
    private static TConfig? TryParseConfig<[Dyn(AllProps)]TConfig>(string sectionName, string xml) 
        where TConfig : class, new()
    {
        if (!Has(xml))
        {
            return null;
        }

        XmlDocument doc = new();
        doc.LoadXml(xml);

        return ParseConfig<TConfig>(sectionName, doc);
    }

        //sectionElement ??= docElement; // If config section name not found, assume we're mapping the whole XML.
