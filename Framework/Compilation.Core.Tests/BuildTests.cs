#pragma warning disable IDE0002
namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class BuildTests : DotNetTestHelper
{
    public BuildTests() => InitRestore();

    // TODO: Test:
    // x Build
    // x BuildConf
    // x As CommandEnum
    // x As Command text
    // x Args
    // - With File / Without File
    // - With Dir / Without Dir
    // - Error cases
    // - Test with all options on and see if it still works.

    // TODO: Make test console output look better with LogAction and Verbosity settings.

    [TestMethod]
    public void Test_Build_MainCase()
    {
        AssertInitialState();

        var opt = GetOpt();
        var result = Build(opt);

        AssertResult(result);

        AssertDebugDll();
    }

    [TestMethod]
    public void Test_Build_BuildConf() 
    {
        AssertInitialState();

        var opt = GetOpt() with { BuildConf = "Release" };
        var result = Build(opt);

        AssertContains(result, "release");

        AssertResult(result);
       
        AssertReleaseDll();
    }

    [TestMethod]
    public void Test_Build_AsCommandEnum()
    {
        AssertInitialState();

        var result = DotNet.Exe(build, GetOpt());

        AssertResult(result);

        AssertDebugDll();
    }

    [TestMethod]
    public void Test_Build_AsCommandText() 
    {
        AssertInitialState();

        var result = DotNet.Exe("build", GetOpt());

        AssertResult(result);

        AssertDebugDll();
    }

    [TestMethod]
    public void Test_Build_Args() 
    {
        AssertInitialState();

        var result = Build("--help", GetOpt());

        AssertResultOk(result);

        AssertNotExists(DebugDllFilePath);
        AssertNotExists(ReleaseDllFilePath);

        AssertContains(result, "Usage:");
        AssertContains(result, "dotnet build [<PROJECT | SOLUTION | FILE>...] [options]");
    }
 
    [TestMethod]
    public void Test_Build_WithFile()
    {
        AssertInitialState();

        var opt = GetOpt() with { File = CsProjFileName };
        var result = Build(opt);

        AssertResult(result);

        AssertDebugDll();
    }
        
    [TestMethod]
    public void Test_Build_WithoutFile() 
    {
        AssertInitialState();

        var opt = GetOpt() with { File = "" };
        var result = Build(opt);

        AssertResult(result);

        AssertDebugDll();
    }

    // TODO: One with full file path?

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

    private void AssertResult(DotNetResult result)
    {
        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> ");
    }
}