namespace JJ.Framework.Compilation.Core.Tests;

/// <summary>
/// Tests the public <see cref="DotNet"/> facade by running real dotnet processes against a minimal temp project.
/// Output assertions verify that meaningful text was produced; disk assertions confirm that artifacts land on disk.
/// No-option overloads run via <see cref="InTempDir"/>, which temporarily sets the process CWD so the
/// child dotnet process finds the temp project without an explicit Dir in options.
/// </summary>
[TestClass]
public class DotNetTests : DotNetTestHelper
{
    // TODO: Different types of options aren't tested.
    // TODO: Logging isn't really tested.
    
    /// <summary>
    /// Restore so obj/project.assets.json exists for all build/rebuild/msbuild/msrebuild tests.
    /// </summary>
    private void InitRestore() => Restore(GetOptNoFile());

    // Restore

    private void TestRestore_ChDir(Func<DotNetResult> call) => InTempDir(() => TestRestore(call));
    private void TestRestore(Func<DotNetResult> call)
    {
        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, "restore");
        AssertContainsAny(output, "restored", "up-to-date");
        AssertExists(AssetsFilePath);
    }

    [TestMethod] public void Test_Restore_ByMethod()                => TestRestore_ChDir(() => Restore());
    [TestMethod] public void Test_Restore_ByMethod_WithOpt()        => TestRestore      (() => Restore(GetOpt()));
    [TestMethod] public void Test_Restore_ByMethod_WithArgs()       => TestRestore_ChDir(() => Restore("--no-cache"));
    [TestMethod] public void Test_Restore_ByMethod_WithArgsAndOpt() => TestRestore      (() => Restore("--no-cache", GetOpt()));
    [TestMethod] public void Test_Restore_ByEnum()                  => TestRestore_ChDir(() => DotNet.Exe(restore));
    [TestMethod] public void Test_Restore_ByEnum_WithOpt()          => TestRestore      (() => DotNet.Exe(restore, GetOpt()));
    [TestMethod] public void Test_Restore_ByEnum_WithArgs()         => TestRestore_ChDir(() => DotNet.Exe(restore, "--no-cache"));
    [TestMethod] public void Test_Restore_ByEnum_WithArgsAndOpt()   => TestRestore      (() => DotNet.Exe(restore, "--no-cache", GetOpt()));
    [TestMethod] public void Test_Restore_ByName()                  => TestRestore_ChDir(() => DotNet.Exe("restore"));
    [TestMethod] public void Test_Restore_ByName_WithOpt()          => TestRestore      (() => DotNet.Exe("restore", GetOpt()));
    [TestMethod] public void Test_Restore_ByName_WithArgs()         => TestRestore_ChDir(() => DotNet.Exe("restore", "--no-cache"));
    [TestMethod] public void Test_Restore_ByName_WithArgsAndOpt()   => TestRestore      (() => DotNet.Exe("restore", "--no-cache", GetOpt()));

    // Build

    public void TestBuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestBuild(call, DebugDllFilePath));
    public void TestBuild_Release(Func<DotNetResult> call) => TestBuild(call, ReleaseDllFilePath);
    public void TestBuild(Func<DotNetResult> call, string filePath)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, "build succeeded");
        AssertContains(output, filePath);
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

    public void TestRebuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestRebuild(call, DebugDllFilePath));
    public void TestRebuild_Release(Func<DotNetResult> call) => TestRebuild(call, ReleaseDllFilePath);
    public void TestRebuild(Func<DotNetResult> call, string dllFileName)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, "Build succeeded");
        AssertContains(output, dllFileName);
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
    
    private void TestMSBuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestMSBuild(call, DebugDllFilePath));
    private void TestMSBuild_Release(Func<DotNetResult> call) => TestMSBuild(call, ReleaseDllFilePath);
    private void TestMSBuild(Func<DotNetResult> call, string dllFilePath)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, dllFilePath);
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

    private void TestMSRebuild_Debug(Func<DotNetResult> call) => InTempDir(() => TestMSRebuild(call, DebugDllFilePath));
    private void TestMSRebuild_Release(Func<DotNetResult> call) => TestMSRebuild(call, ReleaseDllFilePath);
    private void TestMSRebuild(Func<DotNetResult> call, string dllFilePath)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, dllFilePath);
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
        AssertInitialState();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, PackID);

        string content = ReadAllText(CsprojPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, PackID);
        AssertContains(content, PackVer);
    }

    [TestMethod] public void Test_InstallPackage_ByMethod()                => TestInstallPack_ChDir(() => InstallPackage(PackID, PackVer));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithArgs()       => TestInstallPack_ChDir(() => InstallPackage(PackID, PackVer, "--no-restore"));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithOpt()        => TestInstallPack      (() => InstallPackage(PackID, PackVer, GetOpt()));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithArgsAndOpt() => TestInstallPack      (() => InstallPackage(PackID, PackVer, "--no-restore", GetOpt()));
    // ByEnum and ByName variants won't work unless you specify id and ver as args.

    // UninstallPackage

    private void TestUninstallPack_ChDir(Func<DotNetResult> call) => InTempDir(() => TestUninstallPack(call));
    private void TestUninstallPack(Func<DotNetResult> call)
    {
        AssertInitialState();

        InstallPackage(PackID, PackVer, GetOpt());

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, PackID);

        string content = ReadAllText(CsprojPath);
        IsFalse(content.Contains(PackID));
        IsFalse(content.Contains(PackVer));
    }

    [TestMethod] public void Test_UninstallPackage()                => TestUninstallPack_ChDir(() => UninstallPackage(PackID));
    [TestMethod] public void Test_UninstallPackage_WithArgs()       => TestUninstallPack_ChDir(() => UninstallPackage(PackID, "--interactive"));
    [TestMethod] public void Test_UninstallPackage_WithOpt()        => TestUninstallPack      (() => UninstallPackage(PackID, GetOpt()));
    [TestMethod] public void Test_UninstallPackage_WithArgsAndOpt() => TestUninstallPack      (() => UninstallPackage(PackID, "--interactive", GetOpt()));
    // Enum and name won't work unless you specify id and ver as args.
}
