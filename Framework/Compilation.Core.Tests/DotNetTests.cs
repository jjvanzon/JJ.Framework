namespace JJ.Framework.Compilation.Core.Tests;

/// <summary>
/// Tests the public <see cref="DotNet"/> facade by running real dotnet processes against a minimal temp project.
/// Output assertions verify that meaningful text was produced; disk assertions confirm that artifacts land on disk.
/// No-option overloads run via <see cref="InTempDir"/>, which temporarily sets the process CWD so the
/// child dotnet process finds the temp project without an explicit Dir in options.
/// </summary>
[TestClass]
public class DotNetTests : IDisposable
{
    private const string PackId  = "JJ.Framework.Common.Core";
    private const string PackVer = "4.6.6251";

    // TODO: Add Message ItBuilt as MSBuild scripting in CsprojContent and assert it's in the output.

    // Minimal project targeting net8.0 (broadly available SDK; no external packages needed).
    private static string CsprojContent(string targetFramework) => $"""
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>{targetFramework}</TargetFramework>
            <Nullable>enable</Nullable>
            <ImplicitUsings>enable</ImplicitUsings>
            <LangVersion>latest</LangVersion>
            <NoWarn>$(NoWarn);NETSDK1138</NoWarn> <!--The target framework 'net7.0' is out of support-->
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
        
        _tempDir          = Path.Combine(Path.GetTempPath(), "JJ.CompilationCoreTests", Path.GetRandomFileName().Replace(".", "")); //Guid.NewGuid().ToString());
        _csprojPath       = Path.Combine(_tempDir, "Temp.csproj");
        _outputDllDebug   = Path.Combine(_tempDir, "bin", "Debug",   targetFramework, "Temp.dll");
        _outputDllRelease = Path.Combine(_tempDir, "bin", "Release", targetFramework, "Temp.dll");
        _assetsFilePath   = Path.Combine(_tempDir, "obj", "project.assets.json");
        
        Directory.CreateDirectory(_tempDir);
        WriteAllText(_csprojPath, CsprojContent(targetFramework));
        WriteAllText(Path.Combine(_tempDir, "Program.cs"), ProgramContent);

        // TODO: Different types of options aren't tested.
        // TODO: Logging isn't used nor tested.
        _opt = new DotNetOptions
        {
            Dir        = _tempDir,
            File       = _csprojPath,
            BuildConf  = "Release",
            //TimeOutSec = 300,
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
        try { if (Directory.Exists(_tempDir)) Directory.Delete(_tempDir, recursive: true); }
        catch { /* ignore */ }
    }

    // Helpers

    private void Log(string msg) => Console.WriteLine(msg);

    private void AssertAssetsFile()            => IsTrue(Exists(_assetsFilePath),   message: _assetsFilePath  );
    private void AssertReleaseDll()            => IsTrue(Exists(_outputDllRelease), message: _outputDllRelease);
    private void AssertDebugDll()              => IsTrue(Exists(_outputDllDebug),   message: _outputDllDebug  );
    private void AssertExists(string filePath) => IsTrue(Exists(filePath), message: filePath);
    private void AssertContains(string part, string whole) => IsTrue(whole.Contains(part), $"Expected '{part}' in: {whole}");

    private static readonly Lock _tempDirLock = new();

    /// <summary>
    /// Temporarily sets the process working directory to the temp project folder 
    /// so no-option overloads find the project file.
    /// Temporarily, to not influence other tests, that may rely on explicit file path parameterization.
    /// </summary>
    private void InTempDir(Action action)
    {
        lock (_tempDirLock)
        {
            string saved = Directory.GetCurrentDirectory();
            try 
            { 
                Directory.SetCurrentDirectory(_tempDir);
                action(); 
            }
            finally
            {
                
                try { Directory.SetCurrentDirectory(saved); }
                catch { /* Error tolerance: previous cur dir may be deleted any time. */ }
            }
        }
    }

    // Restore

    private void TestRestore(Func<string> call)
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains("restore"), message: output);
        IsTrue(output.Contains("Restored") || output.Contains("up-to-date"), message: output);
        AssertAssetsFile();
    }

    private void TestRestore_ChDir(Func<string> call) => InTempDir(() => TestRestore(call));

    [TestMethod] public void Test_Restore_ByMethod()          => TestRestore_ChDir(() => Restore());
    [TestMethod] public void Test_Restore_ByMethod_Opt()      => TestRestore      (() => Restore(_optNoFile));
    [TestMethod] public void Test_Restore_ByMethod_Args()     => TestRestore_ChDir(() => Restore("--no-cache"));
    [TestMethod] public void Test_Restore_ByMethod_Args_Opt() => TestRestore      (() => Restore("--no-cache", _optNoFile));
    [TestMethod] public void Test_Restore_ByEnum()            => TestRestore_ChDir(() => DotNet.Exe(restore));
    [TestMethod] public void Test_Restore_ByEnum_Opt()        => TestRestore      (() => DotNet.Exe(restore, _optNoFile));
    [TestMethod] public void Test_Restore_ByEnum_Args()       => TestRestore_ChDir(() => DotNet.Exe(restore, "--no-cache"));
    [TestMethod] public void Test_Restore_ByEnum_Args_Opt()   => TestRestore      (() => DotNet.Exe(restore, "--no-cache", _optNoFile));
    [TestMethod] public void Test_Restore_ByName()            => TestRestore_ChDir(() => DotNet.Exe("restore"));
    [TestMethod] public void Test_Restore_ByName_Opt()        => TestRestore      (() => DotNet.Exe("restore", _optNoFile));
    [TestMethod] public void Test_Restore_ByName_Args()       => TestRestore_ChDir(() => DotNet.Exe("restore", "--no-cache"));
    [TestMethod] public void Test_Restore_ByName_Args_Opt()   => TestRestore      (() => DotNet.Exe("restore", "--no-cache", _optNoFile));

    // Build

    public void TestBuild_Debug(Func<string> call) => InTempDir(() => TestBuild(call, _outputDllDebug));
    public void TestBuild_Release(Func<string> call) => TestBuild(call, _outputDllRelease);
    public void TestBuild(Func<string> call, string filePath)
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains("Build succeeded"), message: output);
        IsTrue(output.Contains(filePath), $"Expected '{filePath}' in: {output}");
        AssertExists(filePath);
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

    public void TestRebuild_Debug(Func<string> call) => InTempDir(() => 
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains("Build succeeded"), message: output);
        IsTrue(output.Contains(_outputDllDebug), $"Expected '{_outputDllDebug}' in: {output}");
        AssertDebugDll(); // no-option overload defaults to Debug
    });

    public void TestRebuild_Release(Func<string> call)
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains("Build succeeded"), message: output);
        IsTrue(output.Contains(_outputDllRelease), $"Expected '{_outputDllRelease}' in: {output}");
        AssertReleaseDll();
    }

    [TestMethod] public void Test_Rebuild_ByMethod()          => TestRebuild_Debug  (() => Rebuild());
    [TestMethod] public void Test_Rebuild_ByMethod_Opt()      => TestRebuild_Release(() => Rebuild(_opt));
    [TestMethod] public void Test_Rebuild_ByMethod_Args()     => TestRebuild_Debug  (() => Rebuild("--no-incremental"));
    [TestMethod] public void Test_Rebuild_ByMethod_Args_Opt() => TestRebuild_Release(() => Rebuild("--no-incremental", _opt));
    [TestMethod] public void Test_Rebuild_ByEnum()            => TestRebuild_Debug  (() => DotNet.Exe(rebuild));
    [TestMethod] public void Test_Rebuild_ByEnum_Opt()        => TestRebuild_Release(() => DotNet.Exe(rebuild, _opt));
    [TestMethod] public void Test_Rebuild_ByEnum_Args()       => TestRebuild_Debug  (() => DotNet.Exe(rebuild, "--no-incremental"));
    [TestMethod] public void Test_Rebuild_ByEnum_Args_Opt()   => TestRebuild_Release(() => DotNet.Exe(rebuild, "--no-incremental", _opt));

    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.
    
    private void TestMSBuild_Debug(Func<string> call) => InTempDir(() => TestMSBuild(call, _outputDllDebug));
    private void TestMSBuild_Release(Func<string> call) => TestMSBuild(call, _outputDllRelease);
    private void TestMSBuild(Func<string> call, string dllFilePath)
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains(dllFilePath), message: output);
        AssertExists(dllFilePath);
    }

    [TestMethod] public void Test_MSBuild_ByMethod()          => TestMSBuild_Debug  (() => MSBuild());
    [TestMethod] public void Test_MSBuild_ByMethod_Opt()      => TestMSBuild_Release(() => MSBuild(_opt));
    [TestMethod] public void Test_MSBuild_ByMethod_Args()     => TestMSBuild_Debug  (() => MSBuild("/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByMethod_Args_Opt() => TestMSBuild_Release(() => MSBuild("/p:TreatWarningsAsErrors=false", _opt));
    [TestMethod] public void Test_MSBuild_ByEnum()            => TestMSBuild_Debug  (() => DotNet.Exe(msbuild));
    [TestMethod] public void Test_MSBuild_ByEnum_Opt()        => TestMSBuild_Release(() => DotNet.Exe(msbuild, _opt));
    [TestMethod] public void Test_MSBuild_ByEnum_Args()       => TestMSBuild_Debug  (() => DotNet.Exe(msbuild, "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByEnum_Args_Opt()   => TestMSBuild_Release(() => DotNet.Exe(msbuild, "/p:TreatWarningsAsErrors=false", _opt));
    [TestMethod] public void Test_MSBuild_ByName()            => TestMSBuild_Debug  (() => DotNet.Exe("msbuild"));
    [TestMethod] public void Test_MSBuild_ByName_Opt()        => TestMSBuild_Release(() => DotNet.Exe("msbuild", _opt));
    [TestMethod] public void Test_MSBuild_ByName_Args()       => TestMSBuild_Debug  (() => DotNet.Exe("msbuild", "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByName_Args_Opt()   => TestMSBuild_Release(() => DotNet.Exe("msbuild", "/p:TreatWarningsAsErrors=false", _opt));

    // MSRebuild

    private void TestMSRebuild_Debug(Func<string> call) => InTempDir(() => 
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains(_outputDllDebug), message: output);
        AssertDebugDll();
    });

    private void TestMSRebuild_Release(Func<string> call)
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains(_outputDllRelease), message: output);
        AssertReleaseDll();
    }

    [TestMethod] public void Test_MSRebuild_ByMethod()          => TestMSRebuild_Debug  (() => MSRebuild());
    [TestMethod] public void Test_MSRebuild_ByMethod_Opt()      => TestMSRebuild_Release(() => MSRebuild(_opt));
    [TestMethod] public void Test_MSRebuild_ByMethod_Args()     => TestMSRebuild_Debug  (() => MSRebuild("/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSRebuild_ByMethod_Args_Opt() => TestMSRebuild_Release(() => MSRebuild("/p:TreatWarningsAsErrors=false", _opt));
    [TestMethod] public void Test_MSRebuild_ByEnum()            => TestMSRebuild_Debug  (() => DotNet.Exe(msrebuild));
    [TestMethod] public void Test_MSRebuild_ByEnum_Opt()        => TestMSRebuild_Release(() => DotNet.Exe(msrebuild, _opt));
    [TestMethod] public void Test_MSRebuild_ByEnum_Args()       => TestMSRebuild_Debug  (() => DotNet.Exe(msrebuild, "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSRebuild_ByEnum_Args_Opt()   => TestMSRebuild_Release(() => DotNet.Exe(msrebuild, "/p:TreatWarningsAsErrors=false", _opt));
    
    // TODO: How about testing what happens if a build actually fails?

    // InstallPackage

    private void TestInstallPack_ChDir(Func<string> call) => InTempDir(() => TestInstallPack(call));
    private void TestInstallPack(Func<string> call)
    {
        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains(PackId), output);

        string content = ReadAllText(_csprojPath);
        IsTrue(content.Contains(PackId), content);
        IsTrue(content.Contains(PackVer), content);
    }

    [TestMethod] public void Test_InstallPackage_ByMethod()          => TestInstallPack_ChDir(() => InstallPackage(PackId, PackVer));
    [TestMethod] public void Test_InstallPackage_ByMethod_Args()     => TestInstallPack_ChDir(() => InstallPackage(PackId, PackVer, ""));
    [TestMethod] public void Test_InstallPackage_ByMethod_Opt()      => TestInstallPack      (() => InstallPackage(PackId, PackVer, _optNoFile));
    [TestMethod] public void Test_InstallPackage_ByMethod_Args_Opt() => TestInstallPack      (() => InstallPackage(PackId, PackVer, "--no-restore", _optNoFile));
    // ByEnum and ByName variants won't work unless you specify id and ver as args.

    // UninstallPackage

    private void TestUninstallPack_ChDir(Func<string> call) => InTempDir(() => TestUninstallPack(call));
    private void TestUninstallPack(Func<string> call)
    {
        InstallPackage(PackId, PackVer, _optNoFile);

        string output = call();
        NotNullOrWhiteSpace(output);
        IsTrue(output.Contains(PackId), output);

        string content = ReadAllText(_csprojPath);
        IsFalse(content.Contains(PackId));
        IsFalse(content.Contains(PackVer));
    }

    [TestMethod] public void Test_UninstallPackage()          => TestUninstallPack_ChDir(() => UninstallPackage(PackId));
    [TestMethod] public void Test_UninstallPackage_Args()     => TestUninstallPack_ChDir(() => UninstallPackage(PackId, ""));
    [TestMethod] public void Test_UninstallPackage_Opt()      => TestUninstallPack      (() => UninstallPackage(PackId, _optNoFile));
    [TestMethod] public void Test_UninstallPackage_Args_Opt() => TestUninstallPack      (() => UninstallPackage(PackId, "", _optNoFile));
    // Enum and name won't work unless you specify id and ver as args.
}
