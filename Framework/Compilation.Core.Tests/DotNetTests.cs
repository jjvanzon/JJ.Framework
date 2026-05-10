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

    // Minimal project: no external NuGet packages, so build works without an explicit restore.
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
        _tempDir    = Path.Combine(Path.GetTempPath(), "JJ.Framework.Compilation.Core.TestRuns", Path.GetRandomFileName().Replace(".", ""));
        _csprojPath = Path.Combine(_tempDir, "Temp.csproj");

        Directory.CreateDirectory(_tempDir);
        File.WriteAllText(_csprojPath,                          CsprojContent);
        File.WriteAllText(Path.Combine(_tempDir, "Program.cs"), ProgramContent);

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
        DotNet.Restore(_optNoFile);
    }

    void IDisposable.Dispose() => Cleanup();
    ~DotNetTests() => Cleanup(); // ncrunch: no coverage

    private void Cleanup()
    {
        try { if (Directory.Exists(_tempDir)) Directory.Delete(_tempDir, recursive: true); }
        catch { /* ignore */ }
    }

    /// <summary>
    /// Temporarily sets the process working directory to the temp project folder so no-option
    /// overloads (which inherit the process CWD as their working directory) find the project file.
    /// </summary>
    private void InTempDir(Action action)
    {
        string saved = Directory.GetCurrentDirectory();
        Directory.SetCurrentDirectory(_tempDir);
        try   { action(); }
        finally { Directory.SetCurrentDirectory(saved); }
    }

    // -- Exe: string command overloads --
    // (use --version: needs no project, always produces stdout)

    [TestMethod] public void Exe_String()             => IsTrue(Exe("--version").Contains("Output ="));
    [TestMethod] public void Exe_String_Args()        => IsTrue(Exe("--version", "").Contains("Output ="));
    [TestMethod] public void Exe_String_Opt()
    {
        string logged = "";
        IsTrue(Exe("--version", new DotNetOptions { Log = x => logged = x, Verbosity = Normal }).Contains("Output ="));
        IsTrue(logged.Contains("dotnet --version"));
    }
    [TestMethod] public void Exe_String_Args_Opt()    => IsTrue(Exe("--version", "", new DotNetOptions { Log = _ => { } }).Contains("Output ="));

    // -- Exe: enum command overloads --

    [TestMethod] public void Exe_Enum()              => InTempDir(() => IsNotNull(Exe(restore)));
    [TestMethod] public void Exe_Enum_Args()         => InTempDir(() => IsNotNull(Exe(restore, "")));
    [TestMethod] public void Exe_Enum_Opt()          => IsNotNull(Exe(restore, _optNoFile));
    [TestMethod] public void Exe_Enum_Args_Opt()     => IsNotNull(Exe(restore, "", _optNoFile));

    // -- Restore overloads --

    [TestMethod] public void Restore_()              => InTempDir(() => IsNotNull(DotNet.Restore()));
    [TestMethod] public void Restore_Args()          => InTempDir(() => IsNotNull(DotNet.Restore("")));
    [TestMethod] public void Restore_Opt()           => IsNotNull(DotNet.Restore(_optNoFile));
    [TestMethod] public void Restore_Args_Opt()      => IsNotNull(DotNet.Restore("", _optNoFile));

    // -- Build overloads --
    // (project has no external packages so --no-restore is safe)

    [TestMethod] public void Build_()                => InTempDir(() => IsNotNull(DotNet.Build()));
    [TestMethod] public void Build_Args()            => InTempDir(() => IsNotNull(DotNet.Build("")));
    [TestMethod] public void Build_Opt()             => IsNotNull(DotNet.Build(_opt));
    [TestMethod] public void Build_Args_Opt()        => IsNotNull(DotNet.Build("", _opt));

    // -- Rebuild overloads --

    [TestMethod] public void Rebuild_()              => InTempDir(() => IsNotNull(DotNet.Rebuild()));
    [TestMethod] public void Rebuild_Args()          => InTempDir(() => IsNotNull(DotNet.Rebuild("")));
    [TestMethod] public void Rebuild_Opt()           => IsNotNull(DotNet.Rebuild(_opt));
    [TestMethod] public void Rebuild_Args_Opt()      => IsNotNull(DotNet.Rebuild("", _opt));

    // -- MSBuild overloads --

    [TestMethod] public void MSBuild_()              => InTempDir(() => IsNotNull(DotNet.MSBuild()));
    [TestMethod] public void MSBuild_Args()          => InTempDir(() => IsNotNull(DotNet.MSBuild("")));
    [TestMethod] public void MSBuild_Opt()           => IsNotNull(DotNet.MSBuild(_opt));
    [TestMethod] public void MSBuild_Args_Opt()      => IsNotNull(DotNet.MSBuild("", _opt));

    // -- MSRebuild overloads --

    [TestMethod] public void MSRebuild_()            => InTempDir(() => IsNotNull(DotNet.MSRebuild()));
    [TestMethod] public void MSRebuild_Args()        => InTempDir(() => IsNotNull(DotNet.MSRebuild("")));
    [TestMethod] public void MSRebuild_Opt()         => IsNotNull(DotNet.MSRebuild(_opt));
    [TestMethod] public void MSRebuild_Args_Opt()    => IsNotNull(DotNet.MSRebuild("", _opt));

    // -- InstallPackage overloads --

    [TestMethod] public void InstallPackage_()           => InTempDir(() => IsNotNull(DotNet.InstallPackage(PackageId, PackageVer)));
    [TestMethod] public void InstallPackage_Args()       => InTempDir(() => IsNotNull(DotNet.InstallPackage(PackageId, PackageVer, "")));
    [TestMethod] public void InstallPackage_Opt()        => IsNotNull(DotNet.InstallPackage(PackageId, PackageVer, _optNoFile));
    [TestMethod] public void InstallPackage_Args_Opt()   => IsNotNull(DotNet.InstallPackage(PackageId, PackageVer, "", _optNoFile));

    // -- UninstallPackage overloads --
    // (each test installs first since each instance gets a fresh temp project)

    [TestMethod] public void UninstallPackage_()
    {
        DotNet.InstallPackage(PackageId, PackageVer, _optNoFile);
        InTempDir(() => IsNotNull(DotNet.UninstallPackage(PackageId)));
    }
    [TestMethod] public void UninstallPackage_Args()
    {
        DotNet.InstallPackage(PackageId, PackageVer, _optNoFile);
        InTempDir(() => IsNotNull(DotNet.UninstallPackage(PackageId, "")));
    }
    [TestMethod] public void UninstallPackage_Opt()
    {
        DotNet.InstallPackage(PackageId, PackageVer, _optNoFile);
        IsNotNull(DotNet.UninstallPackage(PackageId, _optNoFile));
    }
    [TestMethod] public void UninstallPackage_Args_Opt()
    {
        DotNet.InstallPackage(PackageId, PackageVer, _optNoFile);
        IsNotNull(DotNet.UninstallPackage(PackageId, "", _optNoFile));
    }
}
