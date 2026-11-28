namespace JJ.Framework.Configuration.Core;

internal static class ConfigFileResolver
{
    /// <inheritdoc cref="_supportedconfigfilenames" />
    public static IList<string> SupportedConfigFileNames 
    { get; set => field = value.NotNull(); } = InitSupportedConfigFileNames();
    
    /// <inheritdoc cref="_getconfigfilename"/>
    public static string GetConfigFileName()
    {
        string? fileName = TryGetConfigFileName();
        if (Has(fileName))
        {
            return fileName;
        }

        throw new Exception(
            $"No config file found with expected file names " +
            $"{FormatSupportedFileNames()} " +
            $"in folder: {CurrentDirectory}");
    }

    /// <inheritdoc cref="_trygetconfigfilename"/>
    public static string? TryGetConfigFileName()
    {
        foreach (string fileName in SupportedConfigFileNames.ToArray())
        {
            if (Exists(fileName))
                return fileName;
        }

        return null;
    }

    public static Exception CreateNotFoundException(string sectionName)
    {
        return new Exception(
            $"Config section '{sectionName}' not found in any config with expected file names " +
            $"{FormatSupportedFileNames()} " +
            $"in folder: {CurrentDirectory}");
    }

    private static List<string> InitSupportedConfigFileNames()
    {
        return new[]
        {
            TryGetDllConfigFileName(),
            "app.config",
            "web.config",
            "testhost.dll.config",
            "nCrunch.TaskRunner.DotNetCore.20.x64.dll.config"
        }.Where(FilledIn).ToList()!;
    }

    /// <summary> {YourProjectName}.dll.config </summary>
    private static string? TryGetDllConfigFileName()
    {
        // 
        string? entryAssemblyName = GetEntryAssembly()?.GetName().Name;
        if (Has(entryAssemblyName))
        {
            return $"{entryAssemblyName}.dll.config";
        }
        return null;
    }

    private static string FormatSupportedFileNames() 
        => Join(", ", SupportedConfigFileNames.ToArray().Select(x => "'" + x + "'" ));

}