namespace JJ.Framework.Compilation.Core.Tests;

public class DotNetTestHelper : IDisposable
{
    // HACK: Update to Visual Studio 18.6.0 and 18.6.2 gave dotnet.exe perf hit.
    //static DotNetTestHelper() => SetEnvironmentVariable("MSBuildDisableFeaturesFromVersion", "18.6");

    // Vars

    private  const    string CS_PROJ_FILE_NAME = "Temp.csproj";
    private  const    string PROGRAM_CONTENT = "Console.WriteLine(\"hello\");";
    internal const    string PACK_ID  = "JJ.Framework.Common.Core";
    internal const    string PACK_VER = "4.6.6251";
    internal readonly string _randomLetters;
    internal readonly string _tempDir;
    internal readonly string _csprojPath;
    internal readonly string _outputDllDebug;
    internal readonly string _outputDllRelease;
    internal readonly string _assetsFilePath;

    // TODO: Add Message ItBuilt as MSBuild scripting in CsprojContent and assert it's in the output.

    private static string CsprojContent(string targetFrameworks) =>
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
        _tempDir           = Path.Combine(Path.GetTempPath(), "JJ.CompilationCoreTests", _randomLetters);
        _csprojPath        = Path.Combine(_tempDir, CS_PROJ_FILE_NAME);
        _outputDllDebug    = Path.Combine(_tempDir, "bin", "Debug",   targetFramework, "Temp.dll");
        _outputDllRelease  = Path.Combine(_tempDir, "bin", "Release", targetFramework, "Temp.dll");
        _assetsFilePath    = Path.Combine(_tempDir, "obj", "project.assets.json");
        
        Directory.CreateDirectory(_tempDir);

        WriteAllText(_csprojPath, CsprojContent(targetFramework));
        WriteAllText(Path.Combine(_tempDir, "Program.cs"), PROGRAM_CONTENT);
    }

    private void Cleanup()
    {
        try { if (Directory.Exists(_tempDir)) Directory.Delete(_tempDir, recursive: true); }
        catch { /* ignore */ }
    }

    void IDisposable.Dispose() => Cleanup();
    ~DotNetTestHelper() => Cleanup(); // ncrunch: no coverage

    // Assert

    internal void AssertExists(string filePath) => IsTrue(Exists(filePath), message: filePath);

    internal void AssertContains(string whole, string part)
    {
        IsTrue(whole.Contains(part, OrdinalIgnoreCase), $"Expected '{part}' in: {whole}");
    }

    internal void AssertContainsAny(string whole, params string[] parts)
    {
        string partsFormatted = Join(", ", parts.Select(x => $"'{x}'"));
        IsTrue(parts.Any(x => whole.Contains(x, OrdinalIgnoreCase)), $"Expected one of {partsFormatted} in: {whole}");
    }

    internal void AssertResultCore(DotNetResult result)
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

    internal void AssertResultOk(DotNetResult result)
    {
        AssertResultCore(result);
        IsTrue(result.Successful);
        NotNullOrWhiteSpace(result.Text);
        NotNullOrWhiteSpace(result.OutputText);
        IsFalse(result.HasExitCode);
        IsFalse(result.HasErrorInOutput);
        IsFalse(result.HasTimeOut);
        AreEqual(0, result.ExitCode);
    }

    // Helpers
    
    private void Log(string msg) => Console.WriteLine(msg);

    internal DotNetOptions GetOptNoFile([Caller] string testName = "")
        => GetOpt(testName) with { File = "" };


    // ReSharper disable once UnusedParameter.Global
    internal DotNetOptions GetOpt([Caller] string testName = "") => new()
    {
        Dir       = _tempDir,
        File      = CS_PROJ_FILE_NAME,
        BuildConf = "Release",
        LogAction = Log,
        Verbosity = Normal,
        //BinLog    = GetBinLogFilePath(testName),
        // Limit LogFiles to one TFM, because they are huge and stored as artifacts.
        //LogFile   = RunningTargetFramework == "net10.0" ? GetLogFilePath(testName) : ""
    };

    internal DotNetOptions BasicOpt() => new()
    {
        Dir       = _tempDir,
        File      = CS_PROJ_FILE_NAME,
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
