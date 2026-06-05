namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class BuildTests : DotNetTestHelper
{
    public BuildTests() => InitRestore();

    // TODO: Test:
    // - Build
    // - BuildConf
    // - Args
    // - As CommandEnum
    // - As Command text
    // - With File / Without File
    // - With Dir / Without Dir
    // - Error cases

    // TODO: Make test console output look better.

    [TestMethod]
    public void Test_Build_MainCase()
    {
        AssertInitialState();
        
        var opt = GetOpt();
        var result = Build(opt);

        AssertDebugDll();

        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> " + DebugDllFilePath);
    }

    [TestMethod]
    public void Test_Build_BuildConf() 
    {
        AssertInitialState();

        var opt = GetOpt() with { BuildConf = "Release" };
        var result = Build(opt);

        AssertReleaseDll();

        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, "release");
        AssertContains(result, ProjectName + " -> " + ReleaseDllFilePath);
    }

    [TestMethod]
    public void Test_Build_Args() { }

    [TestMethod]
    public void Test_Build_AsCommandEnum() { }

    [TestMethod]
    public void Test_Build_AsCommandText() { }

    [TestMethod]
    public void Test_Build_WithFile() { }
        
    [TestMethod]
    public void Test_Build_WithoutFile() { }

    [TestMethod]
    public void Test_Build_WithDir() { }

    [TestMethod]
    public void Test_Build_WithoutDir() { }

    [TestMethod]
    public void Test_Build_ErrorCases() 
    {
        // E.g. call with no opt, leads to error no project or solution file in cur dir.
        //Build();
    }

    // Helpers

    private void AssertInitialState()
    {
        AssertExists(AssetsFilePath);
        AssertNotExists(DebugDllFilePath);
        AssertNotExists(ReleaseDllFilePath);
    }
}