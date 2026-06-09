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

    // UninstallPackage

    private void TestUninstallPack_ChDir(Func<DotNetResult> call) => InTempDir(() => TestUninstallPack(call));
    private void TestUninstallPack(Func<DotNetResult> call)
    {
        AssertInitialState();

        InstallPackage(PackID, PackVer, Opt());

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, PackID);

        string content = ReadAllText(CsProjPath);
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
