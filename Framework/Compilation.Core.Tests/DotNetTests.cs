#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

/// <summary>
/// Tests the public <see cref="DotNet"/> facade by running real dotnet processes against a minimal temp project.
/// Output assertions verify that meaningful text was produced; disk assertions confirm that artifacts land on disk.
/// No-option overloads run via <see cref="DotNetTestHelper.InTempDir"/>, which temporarily sets the process command window
/// so the child dotnet process finds the temp project without an explicit Dir in options.
/// </summary>
[TestClass]
public class DotNetTests : DotNetTestHelper
{
    // TODO: Different types of options aren't tested.
    // TODO: Logging isn't really tested.

    // Rebuild

    public void TestRebuild_ChDir(Func<DotNetResult> call) => InTempDir(() => TestRebuild(call));
    public void TestRebuild(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, "Build succeeded");
        AssertContains(output, DllPath);
        AssertExists(DllPath);
    }

    [TestMethod] public void Test_Rebuild_ByMethod()                => TestRebuild_ChDir(() =>            Rebuild(                   ));
    [TestMethod] public void Test_Rebuild_ByMethod_WithOpt()        => TestRebuild      (() =>            Rebuild(              Opt()));
    [TestMethod] public void Test_Rebuild_ByMethod_WithArgs()       => TestRebuild_ChDir(() =>            Rebuild( "--no-logo"       ));
    [TestMethod] public void Test_Rebuild_ByMethod_WithArgsAndOpt() => TestRebuild      (() =>            Rebuild( "--no-logo", Opt()));
    [TestMethod] public void Test_Rebuild_ByEnum()                  => TestRebuild_ChDir(() => DotNet.Exe(rebuild                    ));
    [TestMethod] public void Test_Rebuild_ByEnum_WithOpt()          => TestRebuild      (() => DotNet.Exe(rebuild,              Opt()));
    [TestMethod] public void Test_Rebuild_ByEnum_WithArgs()         => TestRebuild_ChDir(() => DotNet.Exe(rebuild, "--no-logo"       ));
    [TestMethod] public void Test_Rebuild_ByEnum_WithArgsAndOpt()   => TestRebuild      (() => DotNet.Exe(rebuild, "--no-logo", Opt()));

    // MSBuild
    // MSBuild output doesn't say "Build succeeded"; it shows "MSBuild version" + "Temp ->"; check for the dll path.
    
    private void TestMSBuild_ChDir(Func<DotNetResult> call) => InTempDir(() => TestMSBuild(call));
    private void TestMSBuild(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, DllPath);
        AssertExists(DllPath);
    }

    [TestMethod] public void Test_MSBuild_ByMethod()                => TestMSBuild_ChDir(() =>             MSBuild(               ));
    [TestMethod] public void Test_MSBuild_ByMethod_WithOpt()        => TestMSBuild      (() =>             MSBuild(          Opt()));
    [TestMethod] public void Test_MSBuild_ByMethod_WithArgs()       => TestMSBuild_ChDir(() =>             MSBuild(  "-low"       ));
    [TestMethod] public void Test_MSBuild_ByMethod_WithArgsAndOpt() => TestMSBuild      (() =>             MSBuild(  "-low", Opt()));
    [TestMethod] public void Test_MSBuild_ByEnum()                  => TestMSBuild_ChDir(() => DotNet.Exe( msbuild                ));
    [TestMethod] public void Test_MSBuild_ByEnum_WithOpt()          => TestMSBuild      (() => DotNet.Exe( msbuild,          Opt()));
    [TestMethod] public void Test_MSBuild_ByEnum_WithArgs()         => TestMSBuild_ChDir(() => DotNet.Exe( msbuild,  "-low"       ));
    [TestMethod] public void Test_MSBuild_ByEnum_WithArgsAndOpt()   => TestMSBuild      (() => DotNet.Exe( msbuild,  "-low", Opt()));
    [TestMethod] public void Test_MSBuild_ByName()                  => TestMSBuild_ChDir(() => DotNet.Exe("msbuild"               ));
    [TestMethod] public void Test_MSBuild_ByName_WithOpt()          => TestMSBuild      (() => DotNet.Exe("msbuild",         Opt()));
    [TestMethod] public void Test_MSBuild_ByName_WithArgs()         => TestMSBuild_ChDir(() => DotNet.Exe("msbuild", "-low"       ));
    [TestMethod] public void Test_MSBuild_ByName_WithArgsAndOpt()   => TestMSBuild      (() => DotNet.Exe("msbuild", "-low", Opt()));

    // MSRebuild

    private void TestMSRebuild_ChDir(Func<DotNetResult> call) => InTempDir(() => TestMSRebuild(call));
    private void TestMSRebuild(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, DllPath);
        AssertExists(DllPath);
    }

    [TestMethod] public void Test_MSRebuild_ByMethod()                => TestMSRebuild_ChDir  (() =>            MSRebuild(              ));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithOpt()        => TestMSRebuild        (() =>            MSRebuild(         Opt()));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithArgs()       => TestMSRebuild_ChDir  (() =>            MSRebuild( "-low"       ));
    [TestMethod] public void Test_MSRebuild_ByMethod_WithArgsAndOpt() => TestMSRebuild        (() =>            MSRebuild( "-low", Opt()));
    [TestMethod] public void Test_MSRebuild_ByEnum()                  => TestMSRebuild_ChDir  (() => DotNet.Exe(msrebuild               ));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithOpt()          => TestMSRebuild        (() => DotNet.Exe(msrebuild,         Opt()));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithArgs()         => TestMSRebuild_ChDir  (() => DotNet.Exe(msrebuild, "-low"       ));
    [TestMethod] public void Test_MSRebuild_ByEnum_WithArgsAndOpt()   => TestMSRebuild        (() => DotNet.Exe(msrebuild, "-low", Opt()));
    
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
    [TestMethod] public void Test_InstallPackage_ByMethod_WithOpt()        => TestInstallPack      (() => InstallPackage(PackID, PackVer, Opt()));
    [TestMethod] public void Test_InstallPackage_ByMethod_WithArgsAndOpt() => TestInstallPack      (() => InstallPackage(PackID, PackVer, "--no-restore", Opt()));
    // ByEnum and ByName variants won't work unless you specify id and ver as args.

    // UninstallPackage

    private void TestUninstallPack_ChDir(Func<DotNetResult> call) => InTempDir(() => TestUninstallPack(call));
    private void TestUninstallPack(Func<DotNetResult> call)
    {
        AssertInitialState();

        InstallPackage(PackID, PackVer, Opt());

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, PackID);

        string content = ReadAllText(CsprojPath);
        IsFalse(content.Contains(PackID));
        IsFalse(content.Contains(PackVer));
    }

    [TestMethod] public void Test_UninstallPackage()                => TestUninstallPack_ChDir(() => UninstallPackage(PackID));
    [TestMethod] public void Test_UninstallPackage_WithArgs()       => TestUninstallPack_ChDir(() => UninstallPackage(PackID, "--interactive"));
    [TestMethod] public void Test_UninstallPackage_WithOpt()        => TestUninstallPack      (() => UninstallPackage(PackID, Opt()));
    [TestMethod] public void Test_UninstallPackage_WithArgsAndOpt() => TestUninstallPack      (() => UninstallPackage(PackID, "--interactive", Opt()));
    // Enum and name won't work unless you specify id and ver as args.

    // Helpers

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }
}
