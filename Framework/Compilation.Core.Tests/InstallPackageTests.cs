namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class InstallPackageTests : DotNetTestHelper
{
    // TODO: Test:
    // - Main case
    // - Invalid package name syntax
    // - Invalid version syntax
    // - Package does not exist (might pass, just to break compilation)
    // - Package version does not exist
    // - All options on
    // - No opt
    // - File situations
    // - Overload space

    //private const string ID = "JJ.Framework.Common.Core";
    //private const string Ver = ""

    [TestMethod]
    public void Test_InstallPackage()
    {
        AssertInitialState();

        var result = InstallPackage(PackID, PackVer, Opt());
        
        AssertResultOk(result);
        AssertContains(result, "dotnet installpackage | add package");
        AssertContains(result, $"package '{PackID}' version '{PackVer}' added");

        AssertExists(AssetsFilePath);

        string content = ReadAllText(CsprojPath);
        NotNullOrWhiteSpace(content);
        AssertContains(content, PackID);
        AssertContains(content, PackVer);
    }

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }
}
