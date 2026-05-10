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
    private string BuildOutput(string conf) => Combine(_tempDir, "bin", conf, "net8.0", "Temp.dll");

    private string AssetsFile => Combine(_tempDir, "obj", "project.assets.json");

    /// <summary>Asserts result contains "Output =" (dotnet produced stdout) and an expected keyword.</summary>
    private static void AssertOutput(string result, string keyword)
    {
        NotNullOrWhiteSpace(result);
        IsTrue(result.Contains("Output ="), $"Expected 'Output =' in: {result}");
        IsTrue(result.Contains(keyword),    $"Expected '{keyword}' in: {result}");
    }

    private void AssertAssetsFile()           => IsTrue(FileExists(AssetsFile),          $"Expected assets file: {AssetsFile}");
    private void AssertBuildOutput(string conf = "Release") => IsTrue(FileExists(BuildOutput(conf)), $"Expected build output: {BuildOutput(conf)}");

    private static bool FileExists(string path)      => System.IO.File.Exists(path);
    private static bool DirectoryExists(string path) => System.IO.Directory.Exists(path);

    // Exe: string command overloads
    // --version requires no project and always emits stdout with the SDK version number.

    [TestMethod]
    public void Test_Exe_String()
    {
        string result = DotNet.Exe("--version");
        AssertOutput(result, "Output =");
        // The SDK version number looks like "8.0.xxx" or "10.0.xxx".
        IsTrue(result.Contains('.'), $"Expected a version number in: {result}");
    }

    [TestMethod]
    public void Test_Exe_String_Args()
    {
        // Pass --list-sdks as the command; lists installed SDKs, reliable stdout with no project needed.
        string result = DotNet.Exe("--list-sdks", "");
        AssertOutput(result, "Output =");
    }

    [TestMethod]
    public void Test_Exe_String_Opt()
    {
        string logged = "";
        var opt = new DotNetOptions { Log = x => logged = x, Verbosity = Normal };
        string result = DotNet.Exe("--version", opt);
        AssertOutput(result, "Output =");
        // Normal verbosity logs the invocation line.
        IsTrue(logged.Contains("dotnet"), $"Expected log to mention dotnet, got: {logged}");
    }

    [TestMethod]
    public void Test_Exe_String_Args_Opt()
    {
        string result = DotNet.Exe("--list-sdks", "", new DotNetOptions { Log = _ => { } });
        AssertOutput(result, "Output =");
    }

    // Exe: enum command overloads

    // Restore output says "up-to-date" when already restored; look for "restore" (case-insensitive substring).
    [TestMethod] public void Test_Exe_Enum()          => InTempDir(() => AssertOutput(DotNet.Exe(restore),               "restore"));
    [TestMethod] public void Test_Exe_Enum_Args()     => InTempDir(() => AssertOutput(DotNet.Exe(restore, "--no-cache"), "restore"));
    [TestMethod] public void Test_Exe_Enum_Opt()      =>                 AssertOutput(DotNet.Exe(restore, _optNoFile),   "restore");
    [TestMethod] public void Test_Exe_Enum_Args_Opt() =>                 AssertOutput(DotNet.Exe(restore, "--no-cache", _optNoFile), "restore");

    // Restore

    [TestMethod]
    public void Test_Restore()
    {
        InTempDir(() => AssertOutput(Restore(), "restore"));
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Args()
    {
        InTempDir(() => AssertOutput(Restore("--no-cache"), "restore"));
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Opt()
    {
        AssertOutput(Restore(_optNoFile), "restore");
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Args_Opt()
    {
        AssertOutput(Restore("--no-cache", _optNoFile), "restore");
        AssertAssetsFile();
    }

    // Build

    [TestMethod]
    public void Test_Build()
    {
        InTempDir(() => AssertOutput(Build(), "Build succeeded"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Build_Args()
    {
        InTempDir(() => AssertOutput(Build("--no-incremental"), "Build succeeded"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Build_Opt()
    {
        AssertOutput(Build(_opt), "Build succeeded");
        AssertBuildOutput();
    }

    [TestMethod]
    public void Test_Build_Args_Opt()
    {
        AssertOutput(Build("--no-incremental", _opt), "Build succeeded");
        AssertBuildOutput();
    }

    // Rebuild

    [TestMethod]
    public void Test_Rebuild()
    {
        InTempDir(() => AssertOutput(Rebuild(), "Build succeeded"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Rebuild_Args()
    {
        InTempDir(() => AssertOutput(Rebuild("--no-incremental"), "Build succeeded"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Rebuild_Opt()
    {
        AssertOutput(Rebuild(_opt), "Build succeeded");
        AssertBuildOutput();
    }

    [TestMethod]
    public void Test_Rebuild_Args_Opt()
    {
        AssertOutput(Rebuild("--no-incremental", _opt), "Build succeeded");
        AssertBuildOutput();
    }

    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.

    [TestMethod]
    public void Test_MSBuild()
    {
        InTempDir(() => AssertOutput(MSBuild(), "Temp"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSBuild_Args()
    {
        InTempDir(() => AssertOutput(MSBuild("/p:TreatWarningsAsErrors=false"), "Temp"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSBuild_Opt()
    {
        AssertOutput(MSBuild(_opt), "Temp");
        AssertBuildOutput();
    }

    [TestMethod]
    public void Test_MSBuild_Args_Opt()
    {
        AssertOutput(MSBuild("/p:TreatWarningsAsErrors=false", _opt), "Temp");
        AssertBuildOutput();
    }

    // MSRebuild

    [TestMethod]
    public void Test_MSRebuild()
    {
        InTempDir(() => AssertOutput(MSRebuild(), "Temp"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSRebuild_Args()
    {
        InTempDir(() => AssertOutput(MSRebuild("/p:TreatWarningsAsErrors=false"), "Temp"));
        AssertBuildOutput("Debug"); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSRebuild_Opt()
    {
        AssertOutput(MSRebuild(_opt), "Temp");
        AssertBuildOutput();
    }

    [TestMethod]
    public void Test_MSRebuild_Args_Opt()
    {
        AssertOutput(MSRebuild("/p:TreatWarningsAsErrors=false", _opt), "Temp");
        AssertBuildOutput();
    }

    // InstallPackage
    // After install the csproj should contain a PackageReference for the installed package.

    [TestMethod]
    public void Test_InstallPackage()
    {
        InTempDir(() => AssertOutput(InstallPackage(PackageId, PackageVer), PackageId));
        IsTrue(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Args()
    {
        // Pass empty args; --no-restore would skip adding to csproj which defeats the purpose.
        InTempDir(() => AssertOutput(InstallPackage(PackageId, PackageVer, ""), PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Opt()
    {
        AssertOutput(InstallPackage(PackageId, PackageVer, _optNoFile), PackageId);
        IsTrue(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Args_Opt()
    {
        AssertOutput(InstallPackage(PackageId, PackageVer, "--no-restore", _optNoFile), PackageId);
    }

    // UninstallPackage
    // Each test installs first since each instance gets a fresh temp project.
    // After uninstall the csproj should no longer reference the package.

    [TestMethod]
    public void Test_UninstallPackage()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        InTempDir(() => AssertOutput(UninstallPackage(PackageId), PackageId));
        IsFalse(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_UninstallPackage_Args()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        // Pass empty string as extra args; --no-restore is not a valid flag for dotnet remove package.
        InTempDir(() => AssertOutput(UninstallPackage(PackageId, ""), PackageId));
    }

    [TestMethod]
    public void UninstallPackage_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        AssertOutput(UninstallPackage(PackageId, _optNoFile), PackageId);
        IsFalse(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void UninstallPackage_Args_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        // Pass empty string as extra args; --no-restore is not a valid flag for dotnet remove package.
        AssertOutput(UninstallPackage(PackageId, "", _optNoFile), PackageId);
    }
}
