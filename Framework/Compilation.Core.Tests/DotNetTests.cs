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

    // UninstallPackage

    private void TestUninstallPack_ChDir(Func<DotNetResult> call) => InTempDir(() => TestUninstallPack(call));
    private void TestUninstallPack(Func<DotNetResult> call)
    {
        AssertInitialState();

        InstallPackage(ID, Ver, Opt());

        DotNetResult output = call();
        AssertResultOk(output);
        AssertContains(output, ID);

        string content = ReadAllText(CsProjPath);
        IsFalse(content.Contains(ID));
        IsFalse(content.Contains(Ver));
    }

    [TestMethod] public void Test_UninstallPackage()                => TestUninstallPack_ChDir(() => UninstallPackage(ID));
    [TestMethod] public void Test_UninstallPackage_WithArgs()       => TestUninstallPack_ChDir(() => UninstallPackage(ID, "--interactive"));
    [TestMethod] public void Test_UninstallPackage_WithOpt()        => TestUninstallPack      (() => UninstallPackage(ID, Opt()));
    [TestMethod] public void Test_UninstallPackage_WithArgsAndOpt() => TestUninstallPack      (() => UninstallPackage(ID, "--interactive", Opt()));
    // Enum and name won't work unless you specify id and ver as args.

    // Helpers

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }
}
