#pragma warning disable IDE0002
// ReSharper disable ReplaceAutoPropertyWithComputedProperty

namespace JJ.Framework.Compilation.Core.Tests;

public class DotNetTestHelper : IDisposable
{
    // HACK: Update to Visual Studio 18.6.0 and 18.6.2 gave dotnet.exe perf hit.
    //static DotNetTestHelper() => SetEnvironmentVariable("MSBuildDisableFeaturesFromVersion", "18.6");

    internal static DotNetVerbosity Verbosity { get; set; } = Normal;

    // Vars

    internal const    string ProjectName    = "Temp";
    internal const    string CsProjFileName = "Temp.csproj";
    internal const    string DllFileName    = "Temp.dll";
    private  const    string PROGRAM_CONTENT = "Console.WriteLine(\"hello\");";
    private  readonly string _randomLetters;

    internal const    string PackID  = "JJ.Framework.Common.Core";
    internal const    string PackVer = "4.6.6251";
    internal          string TempDir        { get; }
    internal          string CsprojPath     { get; }
    internal          string DllPath        { get; }
    internal          string DllPathRelease { get; }
    internal          string AssetsFilePath { get; }

    // Init

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

    public DotNetTestHelper()
    {
        string targetFramework = RunningTargetFramework;

        // HACK: Temporarily prevent .NET 4x failure.
        if (targetFramework.StartsWith("net4"))
        {
            targetFramework = "net8.0";
        }

        _randomLetters = Path.GetRandomFileName().Replace(".", "");
        TempDir        = Path.Combine(Path.GetTempPath(), "JJ.CompilationCoreTests", _randomLetters);
        CsprojPath     = Path.Combine(TempDir, CsProjFileName);
        DllPath        = Path.Combine(TempDir, "bin", "Debug",   targetFramework, DllFileName);
        DllPathRelease = Path.Combine(TempDir, "bin", "Release", targetFramework, DllFileName);
        AssetsFilePath = Path.Combine(TempDir, "obj", "project.assets.json");
        
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
        
    /// <summary>
    /// Restore so obj/project.assets.json exists for all build/rebuild/msbuild/msrebuild tests.
    /// </summary>
    public void InitRestore()
    {
        var opt = Opt() with { File = "", Verbosity = UnlessHigh(Minimal) };

        Restore(opt);
    }

    // Assert

    internal static void AssertExists(string filePath) => IsTrue(Exists(filePath), message: filePath);
    internal static void AssertNotExists(string filePath) => IsFalse(Exists(filePath), message: filePath);
    internal void AssertDll() => AssertExists(DllPath);
    internal void AssertDllRelease() => AssertExists(DllPathRelease);

    internal static void AssertContains(string whole, string part)
    {
        IsTrue(whole.Contains(part, OrdinalIgnoreCase), $"Expected '{part}' in: {whole}");
    }

    internal static void AssertNotContains(string whole, string part)
    {
        IsTrue(!whole.Contains(part, OrdinalIgnoreCase), $"Unexpected '{part}' found in: {whole}");
    }

    internal static void AssertContainsAny(string whole, params string[] parts)
    {
        string partsFormatted = Join(", ", parts.Select(x => $"'{x}'"));
        IsTrue(parts.Any(x => whole.Contains(x, OrdinalIgnoreCase)), $"Expected one of {partsFormatted} in: {whole}");
    }
    
    internal static void AssertResultOk(DotNetResult result)
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

    internal static void AssertResultBase(DotNetResult result)
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

    // Logging

    // ReSharper disable once UnusedMember.Global
    internal static void LogLine() => Log("");
    internal static void Log(string msg) => Console.WriteLine(msg);
    
    /// <summary>
    /// Downgrade verbosity if not very detailed already.
    /// </summary>
    internal static DotNetVerbosity UnlessHigh(DotNetVerbosity replacement)
    {
        if (Verbosity > Normal) return Verbosity;
        return replacement;
    }

    internal static void LogMinimal(string text)
    {
        if (Verbosity >= Minimal) Log(text);
    }

    internal static void LogNormal(string text)
    {
        if (Verbosity >= Normal) Log(text);
    }

    // Options

    /// <inheritdoc cref="_getopt" />
    internal DotNetOptions Opt([Caller] string testName = "") => GetOpt(testName);
    // ReSharper disable once UnusedParameter.Global
    /// <inheritdoc cref="_getopt" />
    internal DotNetOptions GetOpt([Caller] string testName = "") 
        => new()
        {
            Dir  = TempDir,
            File = CsProjFileName,
            LogAction = Log,
            Verbosity = Verbosity,
            BinLog    = Verbosity == Diagnostic ? GetBinLogFilePath(testName) : "",
            // Limit LogFiles to one TFM, because they are huge and stored as artifacts.
            LogFile   = Verbosity == Diagnostic && RunningTargetFramework == "net10.0" ? GetLogFilePath(testName) : ""
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

    internal DotNetOptions AllOptsOn([Caller] string testName = "") => new() 
    {
        Dir             = TempDir,
        File            = CsprojPath,

        BuildConf       = "Release",
        Args            = "--no-logo",
        
        AutoRestore     = true,
        ParallelRestore = false, // Keep false. Parallel restore can choke up the whole system.
        
        NodeReuse       = true,
        TimeOutSec      = 123,
                        
        LogAction       = Log,
        Verbosity       = UnlessHigh(Minimal),
        LogFile         = Path.Combine(TempDir, testName + ".log"),
        BinLog          = Path.Combine(TempDir, testName + ".binlog"),
    };

    internal void AssertAllOptsOn(DotNetResult result, DotNetOptions opt)
    {
        AssertDllRelease();
        AssertExists(opt.LogFile);
        AssertExists(opt.BinLog);
        AssertResultOk(result);
        AssertContains(result, "build succeeded");
        AssertContains(result, "release");
        AssertContains(result, "timeout: 123");
        AssertContains(result, "--no-logo");
        AssertContains(result, "-low");
        AssertContains(result, opt.BinLog);
        AssertContains(result, ProjectName + " -> " + DllPathRelease);
        //AssertContains(result, logPath); // Currently not shown: not in command line, not in descriptor.
        //AssertContains(result, "minimal"); // Verbosity overrides interfere
    }

    // File Stuff

    private static readonly Lock _tempDirLock = new();

    /// <summary>
    /// Temporarily sets the process working directory to the temp project folder 
    /// so no-option overloads find the project file.
    /// Temporarily, to not influence other tests, that may rely on explicit file path parameterization.
    /// Thread safe.
    /// </summary>
    internal void InTempDir(Action action)
    {
        lock (_tempDirLock)
        {
            string saved = Directory.GetCurrentDirectory();
            try 
            { 
                Directory.SetCurrentDirectory(TempDir);
                action(); 
            }
            finally
            {
                
                try { Directory.SetCurrentDirectory(saved); }
                catch { /* Error tolerance: previous cur dir may be deleted any time. */ }
            }
        }
    }

    internal void InEmptyDir(Action action)
    {
        // Do it thread-safe in the temp dir, or all hell breaks looose, 
        // when not specifying dir with the dotnet command.
        InTempDir(() =>
        {
            // CsProj was set up in base class initialization.
            // Create and move to a sub-directory, so we emulate the csproj not being found.
            Directory.CreateDirectory("SubDir");
            CurrentDirectory = Path.Combine(CurrentDirectory, "SubDir");

            // Now do our test.
            action();
        });
    }
}
