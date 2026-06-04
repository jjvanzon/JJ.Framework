namespace JJ.Framework.Compilation.Core.Tests;

public class DotNetTestHelper : IDisposable
{
    // HACK: Update to Visual Studio 18.6.0 and 18.6.2 gave dotnet.exe perf hit.
    //static DotNetTestHelper() => SetEnvironmentVariable("MSBuildDisableFeaturesFromVersion", "18.6");

    // Vars

    private  const    string CS_PROJ_FILE_NAME = "Temp.csproj";
    private  const    string PROGRAM_CONTENT = "Console.WriteLine(\"hello\");";
    private  readonly string _randomLetters;

    internal const    string        PackID  = "JJ.Framework.Common.Core";
    internal const    string        PackVer = "4.6.6251";
    internal          string        TempDir            { get; }
    internal          string        CsprojPath         { get; }
    internal          string        DebugDllFilePath   { get; }
    internal          string        ReleaseDllFilePath { get; }
    internal          string        AssetsFilePath     { get; }
    internal          DotNetOptions BasicOpt           { get; }

    // TODO: Add Message ItBuilt as MSBuild scripting in CsprojContent and assert it's in the output.

    private static string GetCsprojContent(string targetFrameworks) =>
        $"""
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFrameworks>{targetFrameworks}</TargetFrameworks>
            <Nullable>enable</Nullable>
            <ImplicitUsings>enable</ImplicitUsings>
            <LangVersion>latest</LangVersion>
            <NoWarn>$(NoWarn);NETSDK1138</NoWarn> <!--The target framework 'net7.0' is out of support-->
          </PropertyGroup>
        </Project>
        """;

    // Init

    public DotNetTestHelper()
    {
        string targetFramework = RunningTargetFramework;

        // HACK: Temporarily prevent .NET 4x failure.
        if (targetFramework.StartsWith("net4"))
        {
            targetFramework = "net8.0";
        }

        _randomLetters     = Path.GetRandomFileName().Replace(".", "");
        TempDir            = Path.Combine(Path.GetTempPath(), "JJ.CompilationCoreTests", _randomLetters);
        CsprojPath         = Path.Combine(TempDir, CS_PROJ_FILE_NAME);
        DebugDllFilePath   = Path.Combine(TempDir, "bin", "Debug",   targetFramework, "Temp.dll");
        ReleaseDllFilePath = Path.Combine(TempDir, "bin", "Release", targetFramework, "Temp.dll");
        AssetsFilePath     = Path.Combine(TempDir, "obj", "project.assets.json");
        
        BasicOpt = CreateBasicOpt();

        Directory.CreateDirectory(TempDir);

        WriteAllText(CsprojPath, GetCsprojContent(targetFramework));
        WriteAllText(Path.Combine(TempDir, "Program.cs"), PROGRAM_CONTENT);
    }

    private void Cleanup()
    {
        try { if (Directory.Exists(TempDir)) Directory.Delete(TempDir, recursive: true); }
        catch { /* ignore */ }
    }

    void IDisposable.Dispose() => Cleanup();
    ~DotNetTestHelper() => Cleanup(); // ncrunch: no coverage

    // Assert

    internal void AssertExists(string filePath) => IsTrue(Exists(filePath), message: filePath);
    internal void AssertNotExists(string filePath) => IsFalse(Exists(filePath), message: filePath);
    internal void AssertDebugDll() => AssertExists(DebugDllFilePath);

    internal void AssertContains(string whole, string part)
    {
        IsTrue(whole.Contains(part, OrdinalIgnoreCase), $"Expected '{part}' in: {whole}");
    }

    internal void AssertNotContains(string whole, string part)
    {
        IsTrue(!whole.Contains(part, OrdinalIgnoreCase), $"Unexpected '{part}' found in: {whole}");
    }

    internal void AssertContainsAny(string whole, params string[] parts)
    {
        string partsFormatted = Join(", ", parts.Select(x => $"'{x}'"));
        IsTrue(parts.Any(x => whole.Contains(x, OrdinalIgnoreCase)), $"Expected one of {partsFormatted} in: {whole}");
    }
    
    internal void AssertResultOk(DotNetResult result)
    {
        AssertResultBase(result);

        IsTrue(result.Successful);
        NotNullOrWhiteSpace(result);
        NotNullOrWhiteSpace(result.Text);
        NotNullOrWhiteSpace(result.OutputText);
        IsFalse(result.HasExitCode);
        IsFalse(result.HasErrorInOutput);
        IsFalse(result.HasTimeOut);
        AreEqual(0, result.ExitCode);
    }

    internal void AssertResultBase(DotNetResult result)
    {
        // Nulls
        NotNull(result);
        NotNull(result.Text);
        NotNull(result.Args);
        NotNull(result.ErrorText);
        NotNull(result.OutputText);

        // Text Equality
        AreEqual(result.Text, result.ToString());
        AreEqual(result.Text, (string)result);

        // Logical Consistency
        NotEqual(result.Opt,           default);
        AreEqual(result.HasExitCode,   result.ExitCode != 0);
        AreEqual(result.HasErrorText,  !IsNullOrWhiteSpace(result.ErrorText));
        AreEqual(result.HasOutputText, !IsNullOrWhiteSpace(result.OutputText));
        AreEqual(result.Successful,    !(result.HasExitCode || result.HasErrorInOutput || result.HasTimeOut));

        if (result.HasErrorInOutput)
        {
            AssertContains(result.OutputText, "[error]");
        }
    }

    // Helpers

    internal void LogLine() => Log("");
    internal void Log(string msg) => Console.WriteLine(msg);

    internal DotNetOptions GetOptNoFile([Caller] string testName = "")
        => GetOpt(testName) with { File = "" };

    // TODO: Create once per instance, not once per call.
    // ReSharper disable once UnusedParameter.Global
    internal DotNetOptions GetOpt([Caller] string testName = "") => BasicOpt with
    {
        BuildConf = "Release",
        LogAction = Log,
        Verbosity = Normal,
        //BinLog    = GetBinLogFilePath(testName),
        // Limit LogFiles to one TFM, because they are huge and stored as artifacts.
        //LogFile   = RunningTargetFramework == "net10.0" ? GetLogFilePath(testName) : ""
    };

    private DotNetOptions CreateBasicOpt() => new()
    {
        Dir  = TempDir,
        File = CS_PROJ_FILE_NAME,
    };

    internal string GetLogFilePath([Caller] string testName = "") => GenerateFilePathNoExt(testName) + ".log";
    internal string GetBinLogFilePath([Caller] string testName = "") => GenerateFilePathNoExt(testName) + ".binlog";

    /// <summary>
    /// Generate a file path (for log files) specifically not in the temp folder, 
    /// but in the test env bin folder, so they don't get cleared out immedaite after the test. 
    /// </summary>
    private string GenerateFilePathNoExt([Caller] string testName = "")
    {
        Assembly asm = typeof(DotNetTests).Assembly;
        string folderPath = AppContext.BaseDirectory; 
        string fileName = $"{asm.GetAssemblyName()}.{RunningTargetFramework}.{testName}.{_randomLetters}";
        string filePath = Path.Combine(folderPath, fileName);
        return filePath;
    }
}
