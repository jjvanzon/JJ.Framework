using static System.IO.Directory;
using static System.IO.File;
using static System.IO.Path;

namespace JJ.Framework.Compilation.Core.Tests;

/// <summary>
/// Tests the public <see cref="DotNet"/> facade by running real dotnet processes against a minimal temp project.
/// Output assertions verify that meaningful text was produced; disk assertions confirm that artifacts land on disk.
/// No-option overloads run via <see cref="InTempDir"/>, which temporarily sets the process CWD so the
/// child dotnet process finds the temp project without an explicit Dir in options.
/// </summary>
[TestClass]
[DoNotParallelize]
public class DotNetTests : IDisposable
{
    private const int    TimeOutSec = 240;
    private const string PackageId  = "Newtonsoft.Json";
    private const string PackageVer = "13.0.3";

    // TODO: Make all tests no-op unless TargetFramework matches (`#if NET8_0`)

    // Minimal project targeting net8.0 (broadly available SDK; no external packages needed).
    private const string CsprojContent = """
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>net8.0</TargetFramework>
            <Nullable>enable</Nullable>
            <ImplicitUsings>enable</ImplicitUsings>
          </PropertyGroup>
        </Project>
        """;

    private const string ProgramContent = "Console.WriteLine(\"hello\");";

    private readonly string        _tempDir;
    private readonly string        _csprojPath;
    private readonly DotNetOptions _opt;       // with file + dir
    private readonly DotNetOptions _optNoFile; // with dir only (restore / package commands)

    public DotNetTests()
    {
        _tempDir    = Combine(GetTempPath(), "JJ.Framework.Compilation.Core.TestRuns", GetRandomFileName().Replace(".", ""));
        _csprojPath = Combine(_tempDir, "Temp.csproj");

        CreateDirectory(_tempDir);
        WriteAllText(_csprojPath, CsprojContent);
        WriteAllText(Combine(_tempDir, "Program.cs"), ProgramContent);

        _opt = new DotNetOptions
        {
            Dir        = _tempDir,
            File       = _csprojPath,
            BuildConf  = "Release",
            TimeOutSec = TimeOutSec,
            Log        = _ => { }
        };

        _optNoFile = _opt with { File = "" };

        // Restore once so obj/project.assets.json exists for all build/rebuild/msbuild/msrebuild tests.
        Restore(_optNoFile);
    }

    void IDisposable.Dispose() => Cleanup();
    ~DotNetTests() => Cleanup(); // ncrunch: no coverage

    private void Cleanup()
    {
        try { if (DirectoryExists(_tempDir)) Delete(_tempDir, recursive: true); }
        catch { /* ignore */ }
    }

    /// <summary>
    /// Temporarily sets the process working directory to the temp project folder so no-option
    /// overloads (which inherit the process CWD) find the project file.
    /// </summary>
    private void InTempDir(Action action)
    {
        string saved = GetCurrentDirectory();
        SetCurrentDirectory(_tempDir);
        try   { action(); }
        finally { SetCurrentDirectory(saved); }
    }

    // Helpers

    /// <summary>Returns the path to the built dll for the given configuration (Debug or Release).</summary>
    private string DllFilePath(string conf) => Combine(_tempDir, "bin", conf, "net8.0", "Temp.dll");

    private string AssetsFilePath => Combine(_tempDir, "obj", "project.assets.json");

    /// <summary>Asserts result contains "Output =" (dotnet produced stdout) and an expected text in output.</summary>
    private static void AssertTextOut(string result, string expectedInOutput)
    {
        NotNullOrWhiteSpace(result);
        IsTrue(result.Contains("Output ="), $"Expected 'Output =' in: {result}");
        IsTrue(result.Contains(expectedInOutput), $"Expected '{expectedInOutput}' in: {result}");
    }

    private void AssertAssetsFile() 
        => IsTrue(FileExists(AssetsFilePath), $"Expected assets file: {AssetsFilePath}");

    private void AssertDllExists(string conf = "Release") 
        => IsTrue(FileExists(DllFilePath(conf)), $"Expected build output: {DllFilePath(conf)}");

    private static bool FileExists(string path)      => System.IO.File.Exists(path);
    private static bool DirectoryExists(string path) => System.IO.Directory.Exists(path);

    // Restore

    [TestMethod]
    public void Test_Restore()
    {
        InTempDir(() => AssertTextOut(Restore(), expectedInOutput: "restore"));
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Args()
    {
        InTempDir(() => AssertTextOut(Restore("--no-cache"), expectedInOutput: "restore"));
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Opt()
    {
        AssertTextOut(Restore(_optNoFile), expectedInOutput: "restore");
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Args_Opt()
    {
        AssertTextOut(Restore("--no-cache", _optNoFile), expectedInOutput: "restore");
        AssertAssetsFile();
    }

    // Build

    [TestMethod]
    public void Test_Build()
    {
        InTempDir(() => AssertTextOut(Build(), expectedInOutput: "Build succeeded"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Build_Args()
    {
        InTempDir(() => AssertTextOut(Build("--no-incremental"), expectedInOutput: "Build succeeded"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Build_Opt()
    {
        AssertTextOut(Build(_opt), expectedInOutput: "Build succeeded");
        AssertDllExists();
    }

    [TestMethod]
    public void Test_Build_Args_Opt()
    {
        AssertTextOut(Build("--no-incremental", _opt), expectedInOutput: "Build succeeded");
        AssertDllExists();
    }

    // Rebuild

    [TestMethod]
    public void Test_Rebuild()
    {
        InTempDir(() => AssertTextOut(Rebuild(), expectedInOutput: "Build succeeded"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Rebuild_Args()
    {
        InTempDir(() => AssertTextOut(Rebuild("--no-incremental"), expectedInOutput: "Build succeeded"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Rebuild_Opt()
    {
        AssertTextOut(Rebuild(_opt), expectedInOutput: "Build succeeded");
        AssertDllExists();
    }

    [TestMethod]
    public void Test_Rebuild_Args_Opt()
    {
        AssertTextOut(Rebuild("--no-incremental", _opt), expectedInOutput: "Build succeeded");
        AssertDllExists();
    }

    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.

    [TestMethod]
    public void Test_MSBuild()
    {
        InTempDir(() => AssertTextOut(MSBuild(), expectedInOutput: "Temp"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSBuild_Args()
    {
        InTempDir(() => AssertTextOut(MSBuild("/p:TreatWarningsAsErrors=false"), expectedInOutput: "Temp"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSBuild_Opt()
    {
        AssertTextOut(MSBuild(_opt), expectedInOutput: "Temp");
        AssertDllExists();
    }

    [TestMethod]
    public void Test_MSBuild_Args_Opt()
    {
        AssertTextOut(MSBuild("/p:TreatWarningsAsErrors=false", _opt), expectedInOutput: "Temp");
        AssertDllExists();
    }

    // MSRebuild

    [TestMethod]
    public void Test_MSRebuild()
    {
        InTempDir(() => AssertTextOut(MSRebuild(), expectedInOutput: "Temp"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSRebuild_Args()
    {
        InTempDir(() => AssertTextOut(MSRebuild("/p:TreatWarningsAsErrors=false"), expectedInOutput: "Temp"));
        AssertDllExists("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSRebuild_Opt()
    {
        AssertTextOut(MSRebuild(_opt), expectedInOutput: "Temp");
        AssertDllExists();
    }

    [TestMethod]
    public void Test_MSRebuild_Args_Opt()
    {
        AssertTextOut(MSRebuild("/p:TreatWarningsAsErrors=false", _opt), expectedInOutput: "Temp");
        AssertDllExists();
    }

    // InstallPackage
    // After install the csproj should contain a PackageReference for the installed package.

    [TestMethod]
    public void Test_InstallPackage()
    {
        InTempDir(() => AssertTextOut(InstallPackage(PackageId, PackageVer), expectedInOutput: PackageId));
        IsTrue(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Args()
    {
        // Pass empty args; --no-restore would skip adding to csproj which defeats the purpose.
        InTempDir(() => AssertTextOut(InstallPackage(PackageId, PackageVer, ""), expectedInOutput: PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Opt()
    {
        AssertTextOut(InstallPackage(PackageId, PackageVer, _optNoFile), expectedInOutput: PackageId);
        IsTrue(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Args_Opt()
    {
        AssertTextOut(InstallPackage(PackageId, PackageVer, "--no-restore", _optNoFile), expectedInOutput: PackageId);
    }

    // UninstallPackage
    // Each test installs first since each instance gets a fresh temp project.
    // After uninstall the csproj should no longer reference the package.

    [TestMethod]
    public void Test_UninstallPackage()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        InTempDir(() => AssertTextOut(UninstallPackage(PackageId), expectedInOutput: PackageId));
        IsFalse(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_UninstallPackage_Args()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        // Pass empty string as extra args; --no-restore is not a valid flag for dotnet remove package.
        InTempDir(() => AssertTextOut(UninstallPackage(PackageId, ""), expectedInOutput: PackageId));
    }

    [TestMethod]
    public void UninstallPackage_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        AssertTextOut(UninstallPackage(PackageId, _optNoFile), expectedInOutput: PackageId);
        IsFalse(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void UninstallPackage_Args_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        // Pass empty string as extra args; --no-restore is not a valid flag for dotnet remove package.
        AssertTextOut(UninstallPackage(PackageId, "", _optNoFile), expectedInOutput: PackageId);
    }

    // Exe: string command overloads
    // --version requires no project and always emits stdout with the SDK version number.

    [TestMethod]
    public void Test_Exe_String()
    {
        string result = DotNet.Exe("--version");
        AssertTextOut(result, "Output =");
        // The SDK version number looks like "8.0.xxx" or "10.0.xxx".
        IsTrue(result.Contains('.'), $"Expected a version number in: {result}");
    }

    [TestMethod]
    public void Test_Exe_String_Args()
    {
        // Pass --list-sdks as the command; lists installed SDKs, reliable stdout with no project needed.
        string result = DotNet.Exe("--list-sdks", "");
        AssertTextOut(result, "Output =");
    }

    [TestMethod]
    public void Test_Exe_String_Opt()
    {
        string logged = "";
        var opt = new DotNetOptions { Log = x => logged = x, Verbosity = Normal };
        string result = DotNet.Exe("--version", opt);
        AssertTextOut(result, "Output =");
        // Normal verbosity logs the invocation line.
        IsTrue(logged.Contains("dotnet"), $"Expected log to mention dotnet, got: {logged}");
    }

    [TestMethod]
    public void Test_Exe_String_Args_Opt()
    {
        string result = DotNet.Exe("--list-sdks", "", new DotNetOptions { Log = _ => { } });
        AssertTextOut(result, "Output =");
    }

    // Exe: enum command overloads

    // Restore output says "up-to-date" when already restored; look for "restore" (case-insensitive substring).
    [TestMethod] public void Test_Exe_Enum()          
        => InTempDir(() => AssertTextOut(Exe(restore),                           expectedInOutput: "restore"));
    [TestMethod] public void Test_Exe_Enum_Args()    
        => InTempDir(() => AssertTextOut(Exe(restore, "--no-cache"),             expectedInOutput: "restore"));
    [TestMethod] public void Test_Exe_Enum_Opt()      
        =>                 AssertTextOut(Exe(restore,               _optNoFile), expectedInOutput: "restore");
    [TestMethod] public void Test_Exe_Enum_Args_Opt() 
        =>                 AssertTextOut(Exe(restore, "--no-cache", _optNoFile), expectedInOutput: "restore");
}
