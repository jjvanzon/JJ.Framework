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
    // x With File / Without File
    // x With Dir / Without Dir
    // - Error cases
    // - Test with all options on and see if it still works.

    // TODO: Make test console output look better with LogAction and Verbosity settings.

    // TODO: More test methods to use teh Assert(delegate) helper.

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
        var opt = GetOpt() with { File = CsProjFileName };

        Assert(() => Build(opt));
    }
        
    [TestMethod]
    public void Test_Build_WithoutFile() 
    {
        var opt = GetOpt() with { File = "" };

        Assert(() => Build(opt));
    }

    [TestMethod]
    public void Test_Build_WithDir() 
    {
        var opt = GetOpt() with { Dir = TempDir };

        Assert(() => Build(opt));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithFullFilePath() 
    {
        var opt = GetOpt() with { Dir = "", File = CsprojPath };

        Assert(() => Build(opt));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithChDir() 
    {
        var opt = GetOpt() with { Dir = "" };

        InTempDir(() => Assert(() => Build(opt)));
    }

    [TestMethod]
    public void Test_Build_ErrorCases() 
    {
        // E.g. call with no opt, leads to error no project or solution file in cur dir.
        //Build();

        // E.g. WithoutDir
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

    private void Assert(Func<DotNetResult> call)
    {
        AssertInitialState();

        DotNetResult result = call();

        AssertResult(result);

        AssertDebugDll();
    }
}