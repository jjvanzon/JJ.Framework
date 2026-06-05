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
        var opt = Opt();
       
        Assert(() => Build(opt));
    }

    [TestMethod]
    public void Test_Build_BuildConf() 
    {
        AssertInitialState();

        var opt = Opt() with { BuildConf = "Release" };
        var result = Build(opt);

        AssertContains(result, "release");

        AssertResult(result);
       
        AssertDllRelease();
    }

    [TestMethod]
    public void Test_Build_AsCommandEnum() => Assert(() => DotNet.Exe(build, Opt()));

    [TestMethod]
    public void Test_Build_AsCommandText() => Assert(() => DotNet.Exe("build", Opt()));

    [TestMethod]
    public void Test_Build_Args() 
    {
        AssertInitialState();

        var result = Build("--help", Opt());

        AssertResultOk(result);

        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);

        AssertContains(result, "Usage:");
        AssertContains(result, "dotnet build [<PROJECT | SOLUTION | FILE>...] [options]");
    }
 
    [TestMethod]
    public void Test_Build_WithFile()
    {
        Assert(() => Build(Opt() with { File = CsProjFileName }));
    }

    [TestMethod]
    public void Test_Build_WithoutFile()
    {
        Assert(() => Build(Opt() with { File = "" }));
    }

    [TestMethod]
    public void Test_Build_WithDir()
    {
        Assert(() => Build(Opt() with { Dir = TempDir }));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithFullFilePath()
    {
        Assert(() => Build(Opt() with { Dir = "", File = CsprojPath }));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithChDir() 
    {
        InTempDir(() => Assert(() => Build(Opt() with { Dir = "" })));
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
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
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

        AssertDll();
    }
}