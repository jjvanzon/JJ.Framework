#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

public class TestHelper : IDisposable
{
    internal static DotNetVerbosity Verbosity { get; set; } = Normal;

    // Vars

    internal const    string ProjectName    = "Temp";
    internal const    string CsProjName = "Temp.csproj";
    internal const    string ID  = "JJ.Framework.Common.Core";
    internal const    string Ver = "4.6.6251";
    internal          string TempDir        { get; }
    internal          string CsProjPath     { get; }
    internal          string DllPath        { get; }
    internal          string DllPathRelease { get; }
    internal          string AssetsFilePath { get; }

    private  const    string DllFileName    = "Temp.dll";
    private  const    string PROGRAM_CONTENT = "Console.WriteLine(\"hello\");";
    private  readonly string _randomLetters;

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

    public TestHelper()
    {
        string targetFramework = RunningTargetFramework;

        // HACK: Temporarily prevent .NET 4x failure.
        if (targetFramework.StartsWith("net4"))
        {
            targetFramework = "net8.0";
        }

        _randomLetters = Path.GetRandomFileName().Replace(".", "");
        TempDir        = Path.Combine(Path.GetTempPath(), "JJ.CompilationCoreTests", _randomLetters);
        CsProjPath     = Path.Combine(TempDir, CsProjName);
        DllPath        = Path.Combine(TempDir, "bin", "Debug",   targetFramework, DllFileName);
        DllPathRelease = Path.Combine(TempDir, "bin", "Release", targetFramework, DllFileName);
        AssetsFilePath = Path.Combine(TempDir, "obj", "project.assets.json");
        
        Directory.CreateDirectory(TempDir);

        WriteAllText(CsProjPath, GetCsprojContent(targetFramework));
        WriteAllText(Path.Combine(TempDir, "Program.cs"), PROGRAM_CONTENT);
    }

    private void Cleanup()
    {
        try { if (Directory.Exists(TempDir)) Directory.Delete(TempDir, recursive: true); }
        catch { /* ignore */ }
    }

    void IDisposable.Dispose() => Cleanup();
    ~TestHelper() => Cleanup(); // ncrunch: no coverage
        
    /// <summary>
    /// Restore so obj/project.assets.json exists for all build/rebuild/msbuild/msrebuild tests.
    /// </summary>
    public void InitRestore()
    {
        var opt = Opt() with { File = "", Verbosity = UnlessHigh(Minimal) };

        Restore(opt);
    }

    // Asserts

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

    private static void AssertResultBase(DotNetResult result)
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

        // Args and Opts mentioned in text result.
        AssertContains(result,    result.Args.Command      );
        AssertContains(result, $"{result.Args.CommandEnum}");
        AssertContains(result,    result.Args.ID           );
        AssertContains(result,    result.Args.Ver          );
        AssertContains(result,    result.Args.Args         );
        AssertContains(result,    result.Args.FullArgs     );
       
        AssertContains(result,    result.Opt.Dir);
        AssertContains(result,    result.Opt.File);
        AssertContains(result,    result.Opt.BuildConf);
        AssertContains(result,    result.Opt.Args);

        // Conditional checks

        if (result.HasErrorInOutput)
        {
            AssertContains(result.OutputText, "[error]");
        }

        if (Has(result.Opt.TimeOutSec) && result.Opt.TimeOutSec != DefaultOptions.TimeOutSec)
        {
            AssertContains(result, $"{result.Opt.TimeOutSec}");
        }

        if (result.Opt.Verbosity != DefaultOptions.Verbosity)
        {
            AssertContains(result, $"{result.Opt.Verbosity}");
        }
    }

    internal static void AssertOptsAllOn(DotNetResult result, bool checkArgsArgs = true, bool checkOptArgs = true)
    {
        AssertResultOk(result);

        NotNullOrWhiteSpace(      result.Opt.Dir);
        NotNullOrWhiteSpace(      result.Opt.File);
        NotNullOrWhiteSpace(      result.Opt.BuildConf);
        IsTrue(                   result.Opt.AutoRestore);
        IsFalse(                  result.Opt.ParallelRestore); // Kept off. Parallel restore evil.
        IsTrue(                   result.Opt.NodeReuse);
        AssertContains(result, $"timeout: {result.Opt.TimeOutSec}");
        AreSame(Log,              result.Opt.LogAction);
        NotEqual(default,         result.Opt.Verbosity);
        AssertContains(result, $"{result.Opt.Verbosity}"); 
        NotNullOrWhiteSpace(      result.Opt.LogFile);
        AssertExists(             result.Opt.LogFile);
        //AssertContains(result,  result.Opt.LogFile); // Might be shown later, currently not command line, not in descriptor.
        NotNullOrWhiteSpace(      result.Opt.BinLog); // Only exists for build tasks.
        //AssertContains(result,  result.Opt.BinLog); // Currently not shown: not in descriptor.

        if (checkArgsArgs)
        {
            NotNullOrWhiteSpace(result.Args.Args);
        }

        if (checkOptArgs)
        {
            NotNullOrWhiteSpace(result.Opt.Args);
        }
    }

    internal void AssertOptsAllOnForBuild(DotNetResult result)
    {
        AssertOptsAllOn(result);

        AssertContains(result, ProjectName + " -> " + DllPathRelease);
        AssertContains(result, result.Opt.BinLog);
        AssertExists(result.Opt.BinLog);
        AssertDllRelease();
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
    /// <inheritdoc cref="_getopt" />
    internal DotNetOptions GetOpt([Caller] string testName = "") 
        => new()
        {
            Dir  = TempDir,
            File = CsProjName,
            LogAction = Log,
            Verbosity = Verbosity,
            BinLog    = Verbosity == Diagnostic ? BinLogInAppDir(testName) : "",
            // Limit LogFiles to one TFM, because they are huge and stored as artifacts.
            LogFile   = Verbosity == Diagnostic && RunningTargetFramework == "net10.0" ? LogFileInAppDir(testName) : ""
        };

    internal DotNetOptions OptsAllOn([Caller] string testName = "") => new() 
    {
        Dir             = TempDir,
        File            = CsProjPath,

        BuildConf       = "Release",
        Args            = "--no-logo",
        
        AutoRestore     = true,
        ParallelRestore = false, // Keep false. Parallel restore can choke up the whole system.
        
        NodeReuse       = true,
        TimeOutSec      = 123,
                        
        LogAction       = Log,
        Verbosity       = UnlessHigh(Minimal),
        LogFile         = LogFileInTempDir(testName),
        BinLog          = BinLogInTempDir(testName),
    };

    // File
    
    private string AppDir => AppContext.BaseDirectory;
    
    /// <summary>
    /// Generate a file path (for log files) 
    /// </summary>
    private string GenerateFileName(string testName = "")
    {
        Assembly asm = typeof(TestHelper).Assembly;
        return $"{asm.GetAssemblyName()}.{RunningTargetFramework}.{testName}.{_randomLetters}";
    }

    /// <summary>
    /// Specifically not in the temp folder, 
    /// but in the test env bin folder, so they don't get cleared out immedaite after the test. 
    /// </summary>
    internal string LogFileInAppDir ([Caller] string testName = "") => Path.Combine(AppDir,  GenerateFileName(testName)) + ".log";
    internal string LogFileInTempDir([Caller] string testName = "") => Path.Combine(TempDir, GenerateFileName(testName)) + ".log";
    /// <summary>
    /// Specifically not in the temp folder, 
    /// but in the test env bin folder, so they don't get cleared out immedaite after the test. 
    /// </summary>
    internal string BinLogInAppDir  ([Caller] string testName = "") => Path.Combine(AppDir,  GenerateFileName(testName)) + ".binlog";
    internal string BinLogInTempDir ([Caller] string testName = "") => Path.Combine(TempDir, GenerateFileName(testName)) + ".binlog";

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
