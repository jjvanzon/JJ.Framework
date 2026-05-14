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
//[DoNotParallelize]
public class DotNetTests : IDisposable
{
    private const int    TimeOutSec = 240;
    private const string PackId  = "JJ.Framework.Common.Core";
    private const string PackVer = "4.6.6251";

    // Minimal project targeting net8.0 (broadly available SDK; no external packages needed).
    private static string CsprojContent(string targetFramework) => $"""
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>{targetFramework}</TargetFramework>
            <Nullable>enable</Nullable>
            <ImplicitUsings>enable</ImplicitUsings>
            <LangVersion>latest</LangVersion>
            <!--The target framework 'net7.0' is out of support-->
            <NoWarn>$(NoWarn);NETSDK1138</NoWarn>
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
        //const string TargetFramework = "net8.0";
        string targetFramework = RunningTargetFramework;
        // HACK: Temporarily prevent .NET 4x failure.
        if (targetFramework.StartsWith("net4")) targetFramework = "net8.0";
        
        _tempDir          = Combine(GetTempPath(), "JJ.Framework.Compilation.Core.TestRuns", GetRandomFileName().Replace(".", ""));
        _csprojPath       = Combine(_tempDir, "Temp.csproj");
        _outputDllDebug   = Combine(_tempDir, "bin", "Debug",   targetFramework, "Temp.dll");
        _outputDllRelease = Combine(_tempDir, "bin", "Release", targetFramework, "Temp.dll");
        _assetsFilePath   = Combine(_tempDir, "obj", "project.assets.json");
        
        CreateDirectory(_tempDir);
        WriteAllText(_csprojPath, CsprojContent(targetFramework));
        WriteAllText(Combine(_tempDir, "Program.cs"), ProgramContent);

        // TODO: Different types of options aren't tested.
        // TODO: Logging isn't used nor tested.
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
        // TODO: This influences test results beyond regular usage?
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

    private void AssertAssetsFile() => IsTrue(File.Exists(_assetsFilePath),   "Expected assets file: "  + _assetsFilePath  );
    private void AssertReleaseDll() => IsTrue(File.Exists(_outputDllRelease), "Expected DLL file path: " + _outputDllRelease);
    private void AssertDebugDll  () => IsTrue(File.Exists(_outputDllDebug),   "Expected DLL file path: " + _outputDllDebug  );

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

    private void TestRestore(Func<string> call)
    {
        InTempDir(() =>
        {
            AssertOutputText(call(), "restore");
            AssertAssetsFile();
        });
    }

    [TestMethod] public void Test_Restore_ByMethod()          => TestRestore(() => Restore());
    [TestMethod] public void Test_Restore_ByMethod_Opt()      => TestRestore(() => Restore(_optNoFile));
    [TestMethod] public void Test_Restore_ByMethod_Args()     => TestRestore(() => Restore("--no-cache"));
    [TestMethod] public void Test_Restore_ByMethod_Args_Opt() => TestRestore(() => Restore("--no-cache", _optNoFile));
    [TestMethod] public void Test_Restore_ByEnum()            => TestRestore(() => DotNet.Exe(restore));
    [TestMethod] public void Test_Restore_ByEnum_Opt()        => TestRestore(() => DotNet.Exe(restore, _optNoFile));
    [TestMethod] public void Test_Restore_ByEnum_Args()       => TestRestore(() => DotNet.Exe(restore, "--no-cache"));
    [TestMethod] public void Test_Restore_ByEnum_Args_Opt()   => TestRestore(() => DotNet.Exe(restore, "--no-cache", _optNoFile));
    [TestMethod] public void Test_Restore_ByName()            => TestRestore(() => DotNet.Exe("restore"));
    [TestMethod] public void Test_Restore_ByName_Opt()        => TestRestore(() => DotNet.Exe("restore", _optNoFile));
    [TestMethod] public void Test_Restore_ByName_Args()       => TestRestore(() => DotNet.Exe("restore", "--no-cache"));
    [TestMethod] public void Test_Restore_ByName_Args_Opt()   => TestRestore(() => DotNet.Exe("restore", "--no-cache", _optNoFile));

    // Build

    public void TestBuild_Debug(Func<string> call)
    {
        InTempDir(() => AssertOutputText(call(), expectedInOutput: "Build succeeded"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    public void TestBuild_Release(Func<string> call)
    {
        InTempDir(() => AssertOutputText(call(), expectedInOutput: "Build succeeded"));
        AssertReleaseDll(); // no-option overload defaults to Debug
    }

    [TestMethod] public void Test_Build_ByMethod()          => TestBuild_Debug  (() => Build());
    [TestMethod] public void Test_Build_ByMethod_Opt()      => TestBuild_Release(() => Build(_opt));
    [TestMethod] public void Test_Build_ByMethod_Args()     => TestBuild_Debug  (() => Build("--no-incremental"));
    [TestMethod] public void Test_Build_ByMethod_Args_Opt() => TestBuild_Release(() => Build("--no-incremental", _opt));
    [TestMethod] public void Test_Build_ByEnum()            => TestBuild_Debug  (() => DotNet.Exe(build));
    [TestMethod] public void Test_Build_ByEnum_Opt()        => TestBuild_Release(() => DotNet.Exe(build, _opt));
    [TestMethod] public void Test_Build_ByEnum_Args()       => TestBuild_Debug  (() => DotNet.Exe(build, "--no-incremental"));
    [TestMethod] public void Test_Build_ByEnum_Args_Opt()   => TestBuild_Release(() => DotNet.Exe(build, "--no-incremental", _opt));
    [TestMethod] public void Test_Build_ByName()            => TestBuild_Debug  (() => DotNet.Exe("build"));
    [TestMethod] public void Test_Build_ByName_Opt()        => TestBuild_Release(() => DotNet.Exe("build", _opt));
    [TestMethod] public void Test_Build_ByName_Args()       => TestBuild_Debug  (() => DotNet.Exe("build", "--no-incremental"));
    [TestMethod] public void Test_Build_ByName_Args_Opt()   => TestBuild_Release(() => DotNet.Exe("build", "--no-incremental", _opt));

    // Rebuild

    public void TestRebuild_Debug(Func<string> call)
    {
        InTempDir(() => AssertOutputText(call(), expectedInOutput: "Build succeeded"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    public void TestRebuild_Release(Func<string> call)
    {
        InTempDir(() => AssertOutputText(call(), expectedInOutput: "Build succeeded"));
        AssertReleaseDll(); // no-option overload defaults to Debug
    }

    [TestMethod] public void Test_Rebuild_ByMethod()          => TestRebuild_Debug  (() => Rebuild());
    [TestMethod] public void Test_Rebuild_ByMethod_Args()     => TestRebuild_Debug  (() => Rebuild("--no-incremental"));
    [TestMethod] public void Test_Rebuild_ByMethod_Opt()      => TestRebuild_Release(() => Rebuild(_opt));
    [TestMethod] public void Test_Rebuild_ByMethod_Args_Opt() => TestRebuild_Release(() => Rebuild("--no-incremental", _opt));
    [TestMethod] public void Test_Rebuild_ByEnum()            => TestRebuild_Debug  (() => DotNet.Exe(rebuild));
    [TestMethod] public void Test_Rebuild_ByEnum_Args()       => TestRebuild_Debug  (() => DotNet.Exe(rebuild, "--no-incremental"));
    [TestMethod] public void Test_Rebuild_ByEnum_Opt()        => TestRebuild_Release(() => DotNet.Exe(rebuild, _opt));
    [TestMethod] public void Test_Rebuild_ByEnum_Args_Opt()   => TestRebuild_Release(() => DotNet.Exe(rebuild, "--no-incremental", _opt));

    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.
    
    private void TestMSBuild_Debug(Func<string> call)
    {
        InTempDir(() => AssertOutputText(call(), expectedInOutput: "Temp"));
        AssertDebugDll();
    }

    private void TestMSBuild_Release(Func<string> call)
    {
        AssertOutputText(call(), expectedInOutput: "Temp");
        AssertReleaseDll();
    }

    [TestMethod] public void Test_MSBuild_ByMethod()          => TestMSBuild_Debug  (() => MSBuild());
    [TestMethod] public void Test_MSBuild_ByMethod_Args()     => TestMSBuild_Debug  (() => MSBuild("/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByMethod_Opt()      => TestMSBuild_Release(() => MSBuild(_opt));
    [TestMethod] public void Test_MSBuild_ByMethod_Args_Opt() => TestMSBuild_Release(() => MSBuild("/p:TreatWarningsAsErrors=false", _opt));
    [TestMethod] public void Test_MSBuild_ByEnum()            => TestMSBuild_Debug  (() => DotNet.Exe(msbuild));
    [TestMethod] public void Test_MSBuild_ByEnum_Args()       => TestMSBuild_Debug  (() => DotNet.Exe(msbuild, "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByEnum_Opt()        => TestMSBuild_Release(() => DotNet.Exe(msbuild, _opt));
    [TestMethod] public void Test_MSBuild_ByEnum_Args_Opt()   => TestMSBuild_Release(() => DotNet.Exe(msbuild, "/p:TreatWarningsAsErrors=false", _opt));
    [TestMethod] public void Test_MSBuild_ByName()            => TestMSBuild_Debug  (() => DotNet.Exe("msbuild"));
    [TestMethod] public void Test_MSBuild_ByName_Args()       => TestMSBuild_Debug  (() => DotNet.Exe("msbuild", "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByName_Opt()        => TestMSBuild_Release(() => DotNet.Exe("msbuild", _opt));
    [TestMethod] public void Test_MSBuild_ByName_Args_Opt()   => TestMSBuild_Release(() => DotNet.Exe("msbuild", "/p:TreatWarningsAsErrors=false", _opt));

    // MSRebuild

    private void TestMSRebuild_Debug(Func<string> call)
    {
        InTempDir(() => AssertOutputText(call(), expectedInOutput: "Temp"));
        AssertDebugDll(); // no-option overload defaults to Debug
    }

    private void TestMSRebuild_Release(Func<string> call)
    {
        AssertOutputText(call(), expectedInOutput: "Temp");
        AssertReleaseDll();
    }

    [TestMethod] public void Test_MSRebuild_ByMethod()          => TestMSRebuild_Debug  (() => MSRebuild());
    [TestMethod] public void Test_MSRebuild_ByMethod_Args()     => TestMSRebuild_Debug  (() => MSRebuild("/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSRebuild_ByMethod_Opt()      => TestMSRebuild_Release(() => MSRebuild(_opt));
    [TestMethod] public void Test_MSRebuild_ByMethod_Args_Opt() => TestMSRebuild_Release(() => MSRebuild("/p:TreatWarningsAsErrors=false", _opt));
    [TestMethod] public void Test_MSRebuild_ByEnum()            => TestMSRebuild_Debug  (() => DotNet.Exe(msrebuild));
    [TestMethod] public void Test_MSRebuild_ByEnum_Args()       => TestMSRebuild_Debug  (() => DotNet.Exe(msrebuild, "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSRebuild_ByEnum_Opt()        => TestMSRebuild_Release(() => DotNet.Exe(msrebuild, _opt));
    [TestMethod] public void Test_MSRebuild_ByEnum_Args_Opt()   => TestMSRebuild_Release(() => DotNet.Exe(msrebuild, "/p:TreatWarningsAsErrors=false", _opt));
    
    // TODO: How about testing what happens if a build actually fails?

    // InstallPackage

    private void TestInstallPack_ChDir(Func<string> call)
    {
        InTempDir(() => AssertOutputText(call(), expectedInOutput: PackId));
        IsTrue(ReadAllText(_csprojPath).Contains(PackId));
    }

    private void TestInstallPack(Func<string> call)
    {
        AssertOutputText(call(), expectedInOutput: PackId);
        IsTrue(ReadAllText(_csprojPath).Contains(PackId));
    }

    [TestMethod] public void Test_InstallPackage_ByMethod()          => TestInstallPack_ChDir(() => InstallPackage(PackId, PackVer));
    [TestMethod] public void Test_InstallPackage_ByMethod_Args()     => TestInstallPack_ChDir(() => InstallPackage(PackId, PackVer, ""));
    [TestMethod] public void Test_InstallPackage_ByMethod_Opt()      => TestInstallPack      (() => InstallPackage(PackId, PackVer, _optNoFile));
    [TestMethod] public void Test_InstallPackage_ByMethod_Args_Opt() => TestInstallPack      (() => InstallPackage(PackId, PackVer, "--no-restore", _optNoFile));
    // Enum and name won't work unless you specify id and ver as args.

    // UninstallPackage

    private void TestUninstallPack_ChDir(Func<string> call)
    {
        InstallPackage(PackId, PackVer, _optNoFile);
        InTempDir(() => AssertOutputText(call(), expectedInOutput: PackId));
        IsFalse(ReadAllText(_csprojPath).Contains(PackId));
    }

    private void TestUninstallPack(Func<string> call)
    {
        InstallPackage(PackId, PackVer, _optNoFile);
        AssertOutputText(call(), expectedInOutput: PackId);
        IsFalse(ReadAllText(_csprojPath).Contains(PackId));
    }

    [TestMethod] public void Test_UninstallPackage()          => TestUninstallPack_ChDir(() => UninstallPackage(PackId));
    [TestMethod] public void Test_UninstallPackage_Args()     => TestUninstallPack_ChDir(() => UninstallPackage(PackId, ""));
    [TestMethod] public void Test_UninstallPackage_Opt()      => TestUninstallPack      (() => UninstallPackage(PackId, _optNoFile));
    [TestMethod] public void Test_UninstallPackage_Args_Opt() => TestUninstallPack      (() => UninstallPackage(PackId, "", _optNoFile));
    // Enum and name won't work unless you specify id and ver as args.

    // Exe: string command overloads
    // --version requires no project and always emits stdout with the SDK version number.

    // TODO: Test empty command, but -- parameter in arg.

    private static void TestExeStringOutput(Func<string> call) => AssertOutputText(call(), "Output =");

    [TestMethod]
    public void Test_Exe_String()
    {
        string result = DotNet.Exe("--version");
        TestExeStringOutput(() => result);
        IsTrue(result.Contains('.'), $"Expected a version number in: {result}");
    }

    [TestMethod] public void Test_Exe_String_Args() => TestExeStringOutput(() => DotNet.Exe("--list-sdks", ""));

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

    [TestMethod] public void Test_Exe_String_Args_Opt() => TestExeStringOutput(() => DotNet.Exe("--list-sdks", "", new DotNetOptions { Log = _ => { } }));
}
