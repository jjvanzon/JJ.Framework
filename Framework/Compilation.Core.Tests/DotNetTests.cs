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
    private const string CS_PROJ_FILE_NAME = "Temp.csproj";
    private const string PACK_ID  = "JJ.Framework.Common.Core";
    private const string PACK_VER = "4.6.6251";
    private const string PROGRAM_CONTENT = "Console.WriteLine(\"hello\");";
    private readonly string _randomLetters;
    private readonly string _tempDir;
    private readonly string _csprojPath;
    private readonly string _outputDllDebug;
    private readonly string _outputDllRelease;
    private readonly string _assetsFilePath;
    private readonly DotNetOptions _optNoFile; // with dir only (restore / package commands)

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

    public DotNetTests()
    {
        string targetFramework = RunningTargetFramework;

        // HACK: Temporarily prevent .NET 4x failure.
        if (targetFramework.StartsWith("net4"))
        {
            targetFramework = "net8.0";
        }

        _randomLetters    = Path.GetRandomFileName().Replace(".", "");
        _tempDir           = Path.Combine(Path.GetTempPath(), "JJ.CompilationCoreTests", _randomLetters);
        _csprojPath        = Path.Combine(_tempDir, CS_PROJ_FILE_NAME);
        _outputDllDebug    = Path.Combine(_tempDir, "bin", "Debug",   targetFramework, "Temp.dll");
        _outputDllRelease  = Path.Combine(_tempDir, "bin", "Release", targetFramework, "Temp.dll");
        _assetsFilePath    = Path.Combine(_tempDir, "obj", "project.assets.json");
        
        Directory.CreateDirectory(_tempDir);

        WriteAllText(_csprojPath, CsprojContent(targetFramework));
        WriteAllText(Path.Combine(_tempDir, "Program.cs"), PROGRAM_CONTENT);

        _optNoFile = new DotNetOptions
        {
            Dir        = _tempDir,
            BuildConf  = "Release",
            Log        = Log
        };

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

    // Restore

    private void TestRestore_ChDir(Func<DotNetResult> call) => InTempDir(() => TestRestore(call));
    private void TestRestore(Func<DotNetResult> call)
    {
        DotNetResult output = call();
        AssertResultOk(output);

        NotNullOrWhiteSpace(output);
        AssertContains(output, "restore");
        AssertContainsAny(output, "restored", "up-to-date");
        NotNullOrWhiteSpace(output.OutputText);
        AssertExists(_assetsFilePath);
    }

    [TestMethod] public void Test_Restore_ByMethod()                => TestRestore_ChDir(() => Restore());
    [TestMethod] public void Test_Restore_ByMethod_WithOpt()        => TestRestore      (() => Restore(_optNoFile));
    [TestMethod] public void Test_Restore_ByMethod_WithArgs()       => TestRestore_ChDir(() => Restore("--no-cache"));
    [TestMethod] public void Test_Restore_ByMethod_WithArgsAndOpt() => TestRestore      (() => Restore("--no-cache", _optNoFile));
    [TestMethod] public void Test_Restore_ByEnum()                  => TestRestore_ChDir(() => DotNet.Exe(restore));
    [TestMethod] public void Test_Restore_ByEnum_WithOpt()          => TestRestore      (() => DotNet.Exe(restore, _optNoFile));
    [TestMethod] public void Test_Restore_ByEnum_WithArgs()         => TestRestore_ChDir(() => DotNet.Exe(restore, "--no-cache"));
    [TestMethod] public void Test_Restore_ByEnum_WithArgsAndOpt()   => TestRestore      (() => DotNet.Exe(restore, "--no-cache", _optNoFile));
    [TestMethod] public void Test_Restore_ByName()                  => TestRestore_ChDir(() => DotNet.Exe("restore"));
    [TestMethod] public void Test_Restore_ByName_WithOpt()          => TestRestore      (() => DotNet.Exe("restore", _optNoFile));
    [TestMethod] public void Test_Restore_ByName_WithArgs()         => TestRestore_ChDir(() => DotNet.Exe("restore", "--no-cache"));
    [TestMethod] public void Test_Restore_ByName_WithArgsAndOpt()   => TestRestore      (() => DotNet.Exe("restore", "--no-cache", _optNoFile));

    // Build

    public void TestBuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestBuild(call, _outputDllDebug));
    public void TestBuild_Release(Func<DotNetResult> call) => TestBuild(call, _outputDllRelease);
    public void TestBuild(Func<DotNetResult> call, string filePath)
    {
        DotNetResult output = call();
        AssertResultOk(output);

        NotNullOrWhiteSpace(output);
        AssertContains(output, "build succeeded");
        AssertContains(output, filePath);
        NotNullOrWhiteSpace(output.OutputText);
        AssertExists(filePath);
    }

    [TestMethod] public void Test_Build_ByMethod()                => TestBuild_Debug  (() => Build());
    [TestMethod] public void Test_Build_ByMethod_WithOpt()        => TestBuild_Release(() => Build(GetOpt()));
    [TestMethod] public void Test_Build_ByMethod_WithArgs()       => TestBuild_Debug  (() => Build("--no-logo"));
    [TestMethod] public void Test_Build_ByMethod_WithArgsAndOpt() => TestBuild_Release(() => Build("--no-logo", GetOpt()));
    [TestMethod] public void Test_Build_ByEnum()                  => TestBuild_Debug  (() => DotNet.Exe(build));
    [TestMethod] public void Test_Build_ByEnum_WithOpt()          => TestBuild_Release(() => DotNet.Exe(build, GetOpt()));
    [TestMethod] public void Test_Build_ByEnum_WithArgs()         => TestBuild_Debug  (() => DotNet.Exe(build, "--no-logo"));
    [TestMethod] public void Test_Build_ByEnum_WithArgsAndOpt()   => TestBuild_Release(() => DotNet.Exe(build, "--no-logo", GetOpt()));
    [TestMethod] public void Test_Build_ByName()                  => TestBuild_Debug  (() => DotNet.Exe("build"));
    [TestMethod] public void Test_Build_ByName_WithOpt()          => TestBuild_Release(() => DotNet.Exe("build", GetOpt()));
    [TestMethod] public void Test_Build_ByName_WithArgs()         => TestBuild_Debug  (() => DotNet.Exe("build", "--no-logo"));
    [TestMethod] public void Test_Build_ByName_WithArgsAndOpt()   => TestBuild_Release(() => DotNet.Exe("build", "--no-logo", GetOpt()));

    // Rebuild

    public void TestRebuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestRebuild(call, _outputDllDebug));
    public void TestRebuild_Release(Func<DotNetResult> call) => TestRebuild(call, _outputDllRelease);
    public void TestRebuild(Func<DotNetResult> call, string dllFileName)
    {
        DotNetResult output = call();
        AssertResultOk(output);

        NotNullOrWhiteSpace(output);
        AssertContains(output, "Build succeeded");
        AssertContains(output, dllFileName);
        NotNullOrWhiteSpace(output.OutputText);
        AssertExists(dllFileName);
    }


    [TestMethod] public void Test_Rebuild_ByMethod()                => TestRebuild_Debug  (() => Rebuild());
    [TestMethod] public void Test_Rebuild_ByMethod_WithOpt()        => TestRebuild_Release(() => Rebuild(GetOpt()));
    [TestMethod] public void Test_Rebuild_ByMethod_WithArgs()       => TestRebuild_Debug  (() => Rebuild("--no-logo"));
    [TestMethod] public void Test_Rebuild_ByMethod_WithArgsAndOpt() => TestRebuild_Release(() => Rebuild("--no-logo", GetOpt()));
    [TestMethod] public void Test_Rebuild_ByEnum()                  => TestRebuild_Debug  (() => DotNet.Exe(rebuild));
    [TestMethod] public void Test_Rebuild_ByEnum_WithOpt()          => TestRebuild_Release(() => DotNet.Exe(rebuild, GetOpt()));
    [TestMethod] public void Test_Rebuild_ByEnum_WithArgs()         => TestRebuild_Debug  (() => DotNet.Exe(rebuild, "--no-logo"));
    [TestMethod] public void Test_Rebuild_ByEnum_WithArgsAndOpt()   => TestRebuild_Release(() => DotNet.Exe(rebuild, "--no-logo", GetOpt()));

    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.
    
    private void TestMSBuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestMSBuild(call, _outputDllDebug));
    private void TestMSBuild_Release(Func<DotNetResult> call) => TestMSBuild(call, _outputDllRelease);
    private void TestMSBuild(Func<DotNetResult> call, string dllFilePath)
    {
        DotNetResult output = call();
        AssertResultOk(output);

        NotNullOrWhiteSpace(output);
        AssertContains(output, dllFilePath);
        NotNullOrWhiteSpace(output.OutputText);
        AssertExists(dllFilePath);
    }

    [TestMethod] public void Test_MSBuild_ByMethod()                => TestMSBuild_Debug  (() => MSBuild());
    [TestMethod] public void Test_MSBuild_ByMethod_WithOpt()        => TestMSBuild_Release(() => MSBuild(GetOpt()));
    [TestMethod] public void Test_MSBuild_ByMethod_WithArgs()       => TestMSBuild_Debug  (() => MSBuild("/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByMethod_WithArgsAndOpt() => TestMSBuild_Release(() => MSBuild("/p:TreatWarningsAsErrors=false", GetOpt()));
    [TestMethod] public void Test_MSBuild_ByEnum()                  => TestMSBuild_Debug  (() => DotNet.Exe(msbuild));
    [TestMethod] public void Test_MSBuild_ByEnum_WithOpt()          => TestMSBuild_Release(() => DotNet.Exe(msbuild, GetOpt()));
    [TestMethod] public void Test_MSBuild_ByEnum_WithArgs()         => TestMSBuild_Debug  (() => DotNet.Exe(msbuild, "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByEnum_WithArgsAndOpt()   => TestMSBuild_Release(() => DotNet.Exe(msbuild, "/p:TreatWarningsAsErrors=false", GetOpt()));
    [TestMethod] public void Test_MSBuild_ByName()                  => TestMSBuild_Debug  (() => DotNet.Exe("msbuild"));
    [TestMethod] public void Test_MSBuild_ByName_WithOpt()          => TestMSBuild_Release(() => DotNet.Exe("msbuild", GetOpt()));
    [TestMethod] public void Test_MSBuild_ByName_WithArgs()         => TestMSBuild_Debug  (() => DotNet.Exe("msbuild", "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSBuild_ByName_WithArgsAndOpt()   => TestMSBuild_Release(() => DotNet.Exe("msbuild", "/p:TreatWarningsAsErrors=false", GetOpt()));

    // MSRebuild

    private void TestMSRebuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestMSRebuild(call, _outputDllDebug));
    private void TestMSRebuild_Release(Func<DotNetResult> call) => TestMSRebuild(call, _outputDllRelease);
    private void TestMSRebuild(Func<DotNetResult> call, string dllFilePath)
    {
        DotNetResult output = call();
        AssertResultOk(output);

        NotNullOrWhiteSpace(output);
        AssertContains(output, dllFilePath);
        NotNullOrWhiteSpace(output.OutputText);
        AssertExists(dllFilePath);
    }

    [TestMethod] public void Test_MSRebuild_ByMethod()                => TestMSRebuild_Debug  (() => MSRebuild());
    [TestMethod] public void Test_MSRebuild_ByMethod_WithOpt()        => TestMSRebuild_Release(() => MSRebuild(GetOpt()));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithArgs()       => TestMSRebuild_Debug  (() => MSRebuild("/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithArgsAndOpt() => TestMSRebuild_Release(() => MSRebuild("/p:TreatWarningsAsErrors=false", GetOpt()));
    [TestMethod] public void Test_MSRebuild_ByEnum()                  => TestMSRebuild_Debug  (() => DotNet.Exe(msrebuild));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithOpt()          => TestMSRebuild_Release(() => DotNet.Exe(msrebuild, GetOpt()));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithArgs()         => TestMSRebuild_Debug  (() => DotNet.Exe(msrebuild, "/p:TreatWarningsAsErrors=false"));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithArgsAndOpt()   => TestMSRebuild_Release(() => DotNet.Exe(msrebuild, "/p:TreatWarningsAsErrors=false", GetOpt()));
    
    // TODO: How about testing what happens if a build actually fails?

    // InstallPackage

    private void TestInstallPack_ChDir(Func<DotNetResult> call) => InTempDir(() => TestInstallPack(call));
    private void TestInstallPack(Func<DotNetResult> call)
    {
        DotNetResult output = call();
        AssertResultOk(output);

        NotNullOrWhiteSpace(output);
        AssertContains(output, PACK_ID);
        NotNullOrWhiteSpace(output.OutputText);

        string content = ReadAllText(_csprojPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, PACK_ID);
        AssertContains(content, PACK_VER);
    }

    [TestMethod] public void Test_InstallPackage_ByMethod()                => TestInstallPack_ChDir(() => InstallPackage(PACK_ID, PACK_VER));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithArgs()       => TestInstallPack_ChDir(() => InstallPackage(PACK_ID, PACK_VER, "--no-restore"));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithOpt()        => TestInstallPack      (() => InstallPackage(PACK_ID, PACK_VER, _optNoFile));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithArgsAndOpt() => TestInstallPack      (() => InstallPackage(PACK_ID, PACK_VER, "--no-restore", _optNoFile));
    // ByEnum and ByName variants won't work unless you specify id and ver as args.

    // UninstallPackage

    private void TestUninstallPack_ChDir(Func<DotNetResult> call) => InTempDir(() => TestUninstallPack(call));
    private void TestUninstallPack(Func<DotNetResult> call)
    {
        InstallPackage(PACK_ID, PACK_VER, _optNoFile);

        DotNetResult output = call();
        AssertResultOk(output);

        NotNullOrWhiteSpace(output);
        AssertContains(output, PACK_ID);
        NotNullOrWhiteSpace(output.OutputText);

        string content = ReadAllText(_csprojPath);
        IsFalse(content.Contains(PACK_ID));
        IsFalse(content.Contains(PACK_VER));
    }

    [TestMethod] public void Test_UninstallPackage()                => TestUninstallPack_ChDir(() => UninstallPackage(PACK_ID));
    [TestMethod] public void Test_UninstallPackage_WithArgs()       => TestUninstallPack_ChDir(() => UninstallPackage(PACK_ID, GetProjectArg()));
    [TestMethod] public void Test_UninstallPackage_WithOpt()        => TestUninstallPack      (() => UninstallPackage(PACK_ID, _optNoFile));
    [TestMethod] public void Test_UninstallPackage_WithArgsAndOpt() => TestUninstallPack      (() => UninstallPackage(PACK_ID, GetProjectArg(), _optNoFile));
    // Enum and name won't work unless you specify id and ver as args.

    // Helpers

    private string GetProjectArg() => "--project:" + '"' + CS_PROJ_FILE_NAME + '"';

    private DotNetOptions GetOpt([Caller] string testName = "")
    {
        // TODO: Different types of options aren't tested.
        // TODO: Logging isn't really tested.

        //JJ.Framework.Reflection.Legacy.
        string binLogFilePath = Path.GetFullPath($"{GetAssemblyName()}.{RunningTargetFramework}.{testName}.{_randomLetters}.binlog");

        var opt = new DotNetOptions()
        {
            Dir = _tempDir,
            File = CS_PROJ_FILE_NAME,
            BuildConf = "Release",
            Log = Log,
            Verbosity = Detailed,
            // HACK: Add binlogs (temporarily) for dotnet.exe performance degredation test.
            Args = $"-bl:\"{binLogFilePath}\"" 
        };

        return opt;
    }

    private void Log(string msg) => Trace.WriteLine(msg);

    private void AssertExists(string filePath) => IsTrue(Exists(filePath), message: filePath);

    private void AssertContains(string whole, string part)
    {
        IsTrue(whole.Contains(part, OrdinalIgnoreCase), $"Expected '{part}' in: {whole}");
    }

    private void AssertContainsAny(string whole, params string[] parts)
    {
        string partsFormatted = Join(", ", parts.Select(x => $"'{x}'"));
        IsTrue(parts.Any(x => whole.Contains(x, OrdinalIgnoreCase)), $"Expected one of {partsFormatted} in: {whole}");
    }

    private void AssertResultCore(DotNetResult result)
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

    private void AssertResultOk(DotNetResult result)
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
}
