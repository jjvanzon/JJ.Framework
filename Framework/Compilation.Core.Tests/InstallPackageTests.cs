#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class InstallPackageTests : DotNetTestHelper
{
    // TODO: Test:
    // x Main case
    // - As command enum
    // - As command text
    // - Invalid package name syntax
    // - Invalid version syntax
    // - Package does not exist (might pass, just to break compilation)
    // - Package version does not exist
    // - All options on
    // - No opt
    // - File situations
    // - Overload space
    // - With Args
    // - With AutoRestore (should be irrelevant but still work).
    // - Without opt

    private const string ID = "JJ.Framework.Common.Core";
    private const string Ver = "4.6.6251";

    [TestMethod]
    public void Test_InstallPackage_MainCase()
    {
        AssertInitialState();
        var result = InstallPackage(ID, Ver, Opt());
        Assert(result);
    }

    [TestMethod]
    public void Test_InstallPackage_NoOpt() => InTempDir(() =>
    {
        AssertInitialState();
        var result = InstallPackage(ID, Ver);
        Assert(result);
    });

    [TestMethod]
    public void Test_InstallPackage_AsCommandEnum()
    {
        AssertInitialState();
        var result = DotNet.Exe(installpackage, $"{ID} -v {Ver}", Opt());
        Assert(result);
    }

    [TestMethod]
    public void Test_InstallPackage_AsCommandEnum_NoOpt() => InTempDir(() =>
    {
        AssertInitialState();
        var result = DotNet.Exe(installpackage, $"{ID} -v {Ver}");
        Assert(result);
    });

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextAndArgs()
    {
        AssertInitialState();
        var result = DotNet.Exe("add package ", $"{ID} -v {Ver}", Opt());
        Assert(result);
    }

    // TODO: --project parameter expected.

    /*
    [TestMethod]
    public void Test_InstallPackage_AsCommandTextOnly()
    {
        AssertInitialState();
        var result = DotNet.Exe($"package add {ID} -v {Ver}", Opt());
        Assert(result);
    }

    [TestMethod]
    public void Test_InstallPackage_NoCommandAsArgOnly()
    {
        AssertInitialState();
        var result = DotNet.Exe("", $"package add {ID} -v {Ver}", Opt());
        Assert(result);
    }
    */

    // Assertion

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    private void Assert(DotNetResult result)
    {
        AssertResultOk(result);
        AssertContains(result, "dotnet installpackage | add package");
        AssertContains(result, $"package '{ID}' version '{Ver}' added");

        AssertExists(AssetsFilePath);

        string content = ReadAllText(CsprojPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, ID);
        AssertContains(content, Ver);
    }
}
