#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class InstallPackageTests : DotNetTestHelper
{
    // TODO: Test:
    // x Main case
    // x As command enum
    // x As command text
    // x As args only
    // - No opt
    // x Rework: Recognize command in text and arg in Enricher, which adjusts behavior in CmdFormatter.
    // - Invalid package name syntax
    // - Invalid version syntax
    // - Package does not exist (might pass, just to break compilation)
    // - Package version does not exist
    // - All options on
    // - File situations
    // - Overload space
    // - With Args
    // - With AutoRestore (should be irrelevant but still work).

    public InstallPackageTests() => AssertInitialState();

    private const string ID = "JJ.Framework.Common.Core";
    private const string Ver = "4.6.6251";

    [TestMethod]
    public void Test_InstallPackage_MainCase() 
        => Assert(InstallPackage(ID, Ver, Opt()));

    [TestMethod]
    public void Test_InstallPackage_NoOpt() => InTempDir(() 
        => Assert(InstallPackage(ID, Ver)));

    [TestMethod]
    public void Test_InstallPackage_AsCommandEnum() 
        => Assert(DotNet.Exe(installpackage, $"{ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_InstallPackage_AsCommandEnum_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe(installpackage, $"{ID} -v {Ver}")));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextAndArgs() 
        => Assert(DotNet.Exe("add package", $"{ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextAndArgs_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("add package", $"{ID} -v {Ver}")));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextOnly() 
        => Assert(DotNet.Exe($"add package {ID} -v {Ver}", Opt()));

    [TestMethod]
    public void Test_InstallPackage_AsCommandTextOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe($"add package {ID} -v {Ver}")));

    [TestMethod]
    public void Test_InstallPackage_NoCommandAsArgOnly_NoOpt() => InTempDir(()
        => Assert(DotNet.Exe("", $"add package {ID} -v {Ver}")));

    // Error Cases
    
    [TestMethod]
    public void Test_InstallPackage_ErrorCase_NoCommand_ArgOnly_WithOpt_Limitation_DoesNotWork()
    {
        // Args placed at the end, after file; no resolution.
        Throws(
            () => DotNet.Exe("", $"add package {ID} -v {Ver}", Opt()), 
            $"--project \"Temp.csproj\" add package {ID} -v {Ver}");
    }

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
        AssertContains(result, $"package '{ID}' version '{Ver}' added");

        AssertExists(AssetsFilePath);

        string content = ReadAllText(CsprojPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, ID);
        AssertContains(content, Ver);
    }
}
