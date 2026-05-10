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
    private const string TargetFramework = "net8.0";
    private const int    TimeOutSec = 240;
    private const string PackageId  = "Newtonsoft.Json";
    private const string PackageVer = "13.0.3";

    // TODO: Make all tests no-op unless TargetFramework matches (`#if NET8_0`)

    // Minimal project targeting net8.0 (broadly available SDK; no external packages needed).
    private const string CsprojContent = $"""
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>{TargetFramework}</TargetFramework>
            <Nullable>enable</Nullable>
            <ImplicitUsings>enable</ImplicitUsings>
          </PropertyGroup>
        </Project>
        """;

    private const string ProgramContent = "Console.WriteLine(\"hello\");";

    private readonly string _tempDir;
    private readonly string _csprojPath;
    private readonly string _outputDllDebug;
    private readonly string _outputDllRelease;
    private readonly string _assetsFilePath;
    private readonly DotNetOptions _opt;       // with file + dir
    private readonly DotNetOptions _optNoFile; // with dir only (restore / package commands)

    public DotNetTests()
    {
        _tempDir          = Combine(GetTempPath(), "JJ.Framework.Compilation.Core.TestRuns", GetRandomFileName().Replace(".", ""));
        _csprojPath       = Combine(_tempDir, "Temp.csproj");
        _outputDllDebug   = Combine(_tempDir, "bin", "Debug",   TargetFramework, "Temp.dll");
        _outputDllRelease = Combine(_tempDir, "bin", "Release", TargetFramework, "Temp.dll");
        _assetsFilePath   = Combine(_tempDir, "obj", "project.assets.json");
        
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
        // TODO: This influences test results beyond regular usage.
        Restore(_optNoFile);
    }

    void IDisposable.Dispose() => Cleanup();
    ~DotNetTests() => Cleanup(); // ncrunch: no coverage

    private void Cleanup()
    {
        try { if (Directory.Exists(_tempDir)) Delete(_tempDir, recursive: true); }
        catch { /* ignore */ }
    }

    // Helpers

    private void AssertAssetsFile() => IsTrue(File.Exists(_assetsFilePath), $"Expected assets file:  {_assetsFilePath  }");
    private void AssertReleaseDll() => IsTrue(File.Exists(_outputDllRelease), $"Expected build output: {_outputDllRelease}");
    private void AssertDebugDll  () => IsTrue(File.Exists(_outputDllDebug), $"Expected build output: {_outputDllDebug  }");

    /// <summary>Asserts result contains "Output =" (dotnet produced stdout) and an expected text in output.</summary>
    private static void AssertOutputText(string outputText, string expectedInOutput)
    {
        NotNullOrWhiteSpace(outputText);
        IsTrue(outputText.Contains("Output ="), $"Expected 'Output =' in: {outputText}");
        IsTrue(outputText.Contains(expectedInOutput), $"Expected '{expectedInOutput}' in: {outputText}");
    }

    /// <summary>
    /// Temporarily sets the process working directory to the temp project folder so no-option
    /// overloads (which inherit the process CWD) find the project file.
    /// This to not influence other tests, that may rely on explicit file path parameterization.
    /// </summary>
    private void InTempDir(Action action)
    {
        string saved = GetCurrentDirectory();
        SetCurrentDirectory(_tempDir);
        try { action(); }
        finally { SetCurrentDirectory(saved); }
    }

    // Restore

    [TestMethod]
    public void Test_Restore()
    {
        InTempDir(() => AssertOutputText(Restore(), expectedInOutput: "restore"));
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Args()
    {
        InTempDir(() => AssertOutputText(Restore("--no-cache"), expectedInOutput: "restore"));
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Opt()
    {
        AssertOutputText(Restore(_optNoFile), expectedInOutput: "restore");
        AssertAssetsFile();
    }

    [TestMethod]
    public void Test_Restore_Args_Opt()
    {
        AssertOutputText(Restore("--no-cache", _optNoFile), expectedInOutput: "restore");
        AssertAssetsFile();
    }

    // Build

    [TestMethod]
    public void Test_Build()
    {
        InTempDir(() => AssertOutputText(Build(), expectedInOutput: "Build succeeded"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Build_Args()
    {
        InTempDir(() => AssertOutputText(Build("--no-incremental"), expectedInOutput: "Build succeeded"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Build_Opt()
    {
        AssertOutputText(Build(_opt), expectedInOutput: "Build succeeded");
        AssertReleaseDll();
    }

    [TestMethod]
    public void Test_Build_Args_Opt()
    {
        AssertOutputText(Build("--no-incremental", _opt), expectedInOutput: "Build succeeded");
        AssertReleaseDll();
    }

    // Rebuild

    [TestMethod]
    public void Test_Rebuild()
    {
        InTempDir(() => AssertOutputText(Rebuild(), expectedInOutput: "Build succeeded"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Rebuild_Args()
    {
        InTempDir(() => AssertOutputText(Rebuild("--no-incremental"), expectedInOutput: "Build succeeded"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_Rebuild_Opt()
    {
        AssertOutputText(Rebuild(_opt), expectedInOutput: "Build succeeded");
        AssertReleaseDll();
    }

    [TestMethod]
    public void Test_Rebuild_Args_Opt()
    {
        AssertOutputText(Rebuild("--no-incremental", _opt), expectedInOutput: "Build succeeded");
        AssertReleaseDll();
    }

    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.

    [TestMethod]
    public void Test_MSBuild()
    {
        InTempDir(() => AssertOutputText(MSBuild(), expectedInOutput: "Temp"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSBuild_Args()
    {
        InTempDir(() => AssertOutputText(MSBuild("/p:TreatWarningsAsErrors=false"), expectedInOutput: "Temp"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSBuild_Opt()
    {
        AssertOutputText(MSBuild(_opt), expectedInOutput: "Temp");
        AssertReleaseDll();
    }

    [TestMethod]
    public void Test_MSBuild_Args_Opt()
    {
        AssertOutputText(MSBuild("/p:TreatWarningsAsErrors=false", _opt), expectedInOutput: "Temp");
        AssertReleaseDll();
    }

    // MSRebuild

    [TestMethod]
    public void Test_MSRebuild()
    {
        InTempDir(() => AssertOutputText(MSRebuild(), expectedInOutput: "Temp"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSRebuild_Args()
    {
        // TODO: This doesn't actually test if the parameter even comes through.
        InTempDir(() => AssertOutputText(MSRebuild("/p:TreatWarningsAsErrors=false"), expectedInOutput: "Temp"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    [TestMethod]
    public void Test_MSRebuild_Opt()
    {
        AssertOutputText(MSRebuild(_opt), expectedInOutput: "Temp");
        AssertReleaseDll();
    }

    [TestMethod]
    public void Test_MSRebuild_Args_Opt()
    {
        AssertOutputText(MSRebuild("/p:TreatWarningsAsErrors=false", _opt), expectedInOutput: "Temp");
        AssertReleaseDll();
    }
    
    // TODO: How about testing what happens if a build actually fails?

    // InstallPackage

    [TestMethod]
    public void Test_InstallPackage()
    {
        InTempDir(() => AssertOutputText(InstallPackage(PackageId, PackageVer), expectedInOutput: PackageId));
        IsTrue(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Args()
    {
        // Pass empty args; --no-restore would skip adding to csproj which defeats the purpose.
        // TODO: So pass another one.
        InTempDir(() => AssertOutputText(InstallPackage(PackageId, PackageVer, ""), expectedInOutput: PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Opt()
    {
        AssertOutputText(InstallPackage(PackageId, PackageVer, _optNoFile), expectedInOutput: PackageId);
        IsTrue(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_InstallPackage_Args_Opt()
    {
        AssertOutputText(InstallPackage(PackageId, PackageVer, "--no-restore", _optNoFile), expectedInOutput: PackageId);
    }

    // UninstallPackage
    // Each test installs first since each instance gets a fresh temp project.
    // After uninstall the csproj should no longer reference the package.

    [TestMethod]
    public void Test_UninstallPackage()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        InTempDir(() => AssertOutputText(UninstallPackage(PackageId), expectedInOutput: PackageId));
        IsFalse(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void Test_UninstallPackage_Args()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        // Pass empty string as extra args; --no-restore is not a valid flag for dotnet remove package.
        InTempDir(() => AssertOutputText(UninstallPackage(PackageId, ""), expectedInOutput: PackageId));
    }

    [TestMethod]
    public void UninstallPackage_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        AssertOutputText(UninstallPackage(PackageId, _optNoFile), expectedInOutput: PackageId);
        IsFalse(ReadAllText(_csprojPath).Contains(PackageId));
    }

    [TestMethod]
    public void UninstallPackage_Args_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        // Pass empty string as extra args; --no-restore is not a valid flag for dotnet remove package.
        // TODO: Isn't there another optional parameter that we can use?
        AssertOutputText(UninstallPackage(PackageId, "", _optNoFile), expectedInOutput: PackageId);
    }

    // Exe: string command overloads
    // --version requires no project and always emits stdout with the SDK version number.

    // TODO: Test string variants of "known" commands
    // TODO: Test empty command, but -- parameter in arg.

    [TestMethod]
    public void Test_Exe_String()
    {
        string result = DotNet.Exe("--version");
        AssertOutputText(result, "Output =");
        // The SDK version number looks like "8.0.xxx" or "10.0.xxx".
        IsTrue(result.Contains('.'), $"Expected a version number in: {result}");
    }

    [TestMethod]
    public void Test_Exe_String_Args()
    {
        // TODO: Empty args is a 'not so good' test.
        // Pass --list-sdks as the command; lists installed SDKs, reliable stdout with no project needed.
        string result = DotNet.Exe("--list-sdks", "");
        AssertOutputText(result, "Output =");
    }

    [TestMethod]
    public void Test_Exe_String_Opt()
    {
        string msg = "";
        var opt = new DotNetOptions { Log = x => msg = x, Verbosity = Normal };
        string result = DotNet.Exe("--version", opt);
        AssertOutputText(result, "Output =");
        // Normal verbosity logs the invocation line.
        IsTrue(msg.Contains("dotnet"), $"Expected log to mention dotnet, got: {msg}");
    }

    [TestMethod]
    public void Test_Exe_String_Args_Opt()
    {
        // TODO: Empty args is a 'not so good' test.
        string result = DotNet.Exe("--list-sdks", "", new DotNetOptions { Log = _ => { } });
        AssertOutputText(result, "Output =");
    }

    // Exe: enum command overloads

    // TODO: enum and string variants should be tested the for each known command exactly the same way as the explicit methods.
    // Perhaps using a synonyms pattern (see e.g. the test ItemTypes_WithCollectionType in JJ.Framework.Reflection.Legacy.Tests)

    // Restore output says "up-to-date" when already restored; look for "restore" (case-insensitive substring).
    [TestMethod] public void Test_Exe_Enum()          
        => InTempDir(() => AssertOutputText(DotNet.Exe(restore                          ), expectedInOutput: "restore"));
    [TestMethod] public void Test_Exe_Enum_Args()    
        => InTempDir(() => AssertOutputText(DotNet.Exe(restore, "--no-cache"            ), expectedInOutput: "restore"));
    [TestMethod] public void Test_Exe_Enum_Opt()      
        =>                 AssertOutputText(DotNet.Exe(restore,               _optNoFile), expectedInOutput: "restore");
    [TestMethod] public void Test_Exe_Enum_Args_Opt() 
        =>                 AssertOutputText(DotNet.Exe(restore, "--no-cache", _optNoFile), expectedInOutput: "restore");
}
