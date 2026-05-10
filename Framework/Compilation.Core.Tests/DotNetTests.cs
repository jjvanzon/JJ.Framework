using static System.IO.Directory;
using static System.IO.File;
using static System.IO.Path;

namespace JJ.Framework.Compilation.Core.Tests;

/// <summary>
/// Tests the public <see cref="DotNet"/> facade by running real dotnet processes against a minimal temp project.
/// Success is asserted by the method not throwing (the library throws on non-zero exit codes).
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

    // Minimal project: no external NuGet packages.
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
    private readonly DotNetOptions _opt;     // with file + dir
    private readonly DotNetOptions _optNoFile; // with dir only (for restore / package commands)

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
        try { if (Directory.Exists(_tempDir)) Delete(_tempDir, recursive: true); }
        catch { /* ignore */ }
    }

    /// <summary>
    /// Temporarily sets the process working directory to the temp project folder so no-option
    /// overloads (which inherit the process CWD as their working directory) find the project file.
    /// </summary>
    private void InTempDir(Action action)
    {
        string saved = GetCurrentDirectory();

        SetCurrentDirectory(_tempDir);
        try
        { 
            action(); 
        }
        finally 
        { 
            SetCurrentDirectory(saved); 
        }
    }

    // Exe: string command overloads
    // (use --version: needs no project, always produces stdout)

    [TestMethod] public void Exe_String()                   => IsTrue(DotNet.Exe("--version").Contains("Output ="));
    [TestMethod] public void Exe_String_Args()              => IsTrue(DotNet.Exe("--version", "").Contains("Output ="));
    [TestMethod] public void Exe_String_Opt()
    {
        string logged = "";
        IsTrue(DotNet.Exe("--version", new DotNetOptions { Log = x => logged = x, Verbosity = Normal }).Contains("Output ="));
        IsTrue(logged.Contains("dotnet --version"));
    }
    [TestMethod] public void Exe_String_Args_Opt()    => IsTrue(DotNet.Exe("--version", "", new DotNetOptions { Log = _ => { } }).Contains("Output ="));

    // TODO: "" as args is not very "testy".
    // TODO: Do check output for an expected piece of info, indicating success.

    // Exe: enum command overloads

    [TestMethod] public void Exe_Enum()                     => InTempDir(() => NotNullOrWhiteSpace(DotNet.Exe(restore)));
    [TestMethod] public void Exe_Enum_Args()                => InTempDir(() => NotNullOrWhiteSpace(DotNet.Exe(restore, "")));
    [TestMethod] public void Exe_Enum_Opt()                 =>                 NotNullOrWhiteSpace(DotNet.Exe(restore, _optNoFile));
    [TestMethod] public void Exe_Enum_Args_Opt()            =>                 NotNullOrWhiteSpace(DotNet.Exe(restore, "", _optNoFile));
                                                            
    [TestMethod] public void Test_Restore()                 => InTempDir(() => NotNullOrWhiteSpace(Restore()));
    [TestMethod] public void Test_Restore_Args()            => InTempDir(() => NotNullOrWhiteSpace(Restore("")));
    [TestMethod] public void Test_Restore_Opt()             =>                 NotNullOrWhiteSpace(Restore(_optNoFile));
    [TestMethod] public void Test_Restore_Args_Opt()        =>                 NotNullOrWhiteSpace(Restore("", _optNoFile));
                                                            
    [TestMethod] public void Test_Build()                   => InTempDir(() => NotNullOrWhiteSpace(Build()));
    [TestMethod] public void Test_Build_Args()              => InTempDir(() => NotNullOrWhiteSpace(Build("")));
    [TestMethod] public void Test_Build_Opt()               =>                 NotNullOrWhiteSpace(Build(_opt));
    [TestMethod] public void Test_Build_Args_Opt()          =>                 NotNullOrWhiteSpace(Build("", _opt));
                                                            
    [TestMethod] public void Test_Rebuild()                 => InTempDir(() => NotNullOrWhiteSpace(Rebuild()));
    [TestMethod] public void Test_Rebuild_Args()            => InTempDir(() => NotNullOrWhiteSpace(Rebuild("")));
    [TestMethod] public void Test_Rebuild_Opt()             =>                 NotNullOrWhiteSpace(Rebuild(_opt));
    [TestMethod] public void Test_Rebuild_Args_Opt()        =>                 NotNullOrWhiteSpace(Rebuild("", _opt));
                                                            
    [TestMethod] public void Test_MSBuild()                 => InTempDir(() => NotNullOrWhiteSpace(MSBuild()));
    [TestMethod] public void Test_MSBuild_Args()            => InTempDir(() => NotNullOrWhiteSpace(MSBuild("")));
    [TestMethod] public void Test_MSBuild_Opt()             =>                 NotNullOrWhiteSpace(MSBuild(_opt));
    [TestMethod] public void Test_MSBuild_Args_Opt()        =>                 NotNullOrWhiteSpace(MSBuild("", _opt));
                                                            
    [TestMethod] public void Test_MSRebuild()               => InTempDir(() => NotNullOrWhiteSpace(MSRebuild()));
    [TestMethod] public void Test_MSRebuild_Args()          => InTempDir(() => NotNullOrWhiteSpace(MSRebuild("")));
    [TestMethod] public void Test_MSRebuild_Opt()           =>                 NotNullOrWhiteSpace(MSRebuild(_opt));
    [TestMethod] public void Test_MSRebuild_Args_Opt()      =>                 NotNullOrWhiteSpace(MSRebuild("", _opt));

    [TestMethod] public void Test_InstallPackage()          => InTempDir(() => NotNullOrWhiteSpace(InstallPackage(PackageId, PackageVer)));
    [TestMethod] public void Test_InstallPackage_Args()     => InTempDir(() => NotNullOrWhiteSpace(InstallPackage(PackageId, PackageVer, "")));
    [TestMethod] public void Test_InstallPackage_Opt()      =>                 NotNullOrWhiteSpace(InstallPackage(PackageId, PackageVer, _optNoFile));
    [TestMethod] public void Test_InstallPackage_Args_Opt() =>                 NotNullOrWhiteSpace(InstallPackage(PackageId, PackageVer, "", _optNoFile));

    // UninstallPackage overloads

    // (each test installs first since each instance gets a fresh temp project)

    [TestMethod] public void UninstallPackage_()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        InTempDir(() => NotNullOrWhiteSpace(UninstallPackage(PackageId)));
    }

    [TestMethod] public void UninstallPackage_Args()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        InTempDir(() => NotNullOrWhiteSpace(UninstallPackage(PackageId, "")));
    }

    [TestMethod] public void UninstallPackage_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        NotNullOrWhiteSpace(UninstallPackage(PackageId, _optNoFile));
    }

    [TestMethod] public void UninstallPackage_Args_Opt()
    {
        InstallPackage(PackageId, PackageVer, _optNoFile);
        NotNullOrWhiteSpace(UninstallPackage(PackageId, "", _optNoFile));
    }
}
