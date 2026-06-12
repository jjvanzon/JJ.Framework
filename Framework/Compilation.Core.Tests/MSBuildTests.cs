#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class MSBuildTests : DotNetTestHelper
{
    public MSBuildTests() => InitRestore();

    [TestMethod]
    public void Test_MSBuild_MainCase()
    {
        Assert(MSBuild(Opt()));
    }
    
    [TestMethod]
    public void Test_MSBuild_AsCommandEnum()
    {
        Assert(DotNet.Exe(msbuild, Opt()));
    }

    [TestMethod]
    public void Test_MSBuild_AsCommandText()
    {
        Assert(DotNet.Exe("msbuild", Opt()));
    }

    [TestMethod]
    public void Test_MSBuild_WithFile()
    {
        Assert(MSBuild(Opt() with { File = CsProjName }));
    }

    [TestMethod]
    public void Test_MSBuild_WithoutFile()
    {
        Assert(MSBuild(Opt() with { File = "" }));
    }

    [TestMethod]
    public void Test_MSBuild_WithDir()
    {
        Assert(MSBuild(Opt() with { Dir = TempDir }));
    }

    [TestMethod]
    public void Test_MSBuild_WithoutDir_WithFullFilePath()
    {
        Assert(MSBuild(Opt() with { Dir = "", File = CsProjPath }));
    }

    [TestMethod]
    public void Test_MSBuild_WithoutDir_WithChDir() => InTempDir(() =>
    {
        Assert(MSBuild(Opt() with { Dir = "" }));
    });

    [TestMethod]
    public void Test_MSBuild_Conf()
    {
        Assert(MSBuild(Opt() with { BuildConf = "Release" }), release: true);
    }

    [TestMethod]
    public void Test_MSBuild_Args() 
    {
        Assert(MSBuild("-low", Opt()));
    }
    
    [TestMethod]
    public void Test_MSBuild_NoOptions() => InTempDir(() =>
    {
        Assert(MSBuild());
    });

    [TestMethod]
    public void Test_MSBuild_AllOptsOn() 
    { 
        var result = MSBuild("-low", OptsAllOn());
        AssertOptsAllOnForBuild(result);
    }

    [TestMethod]
    public void Test_MSBuild_ErrorCase_WithoutDir() => InEmptyDir(() =>
    {
        LogNormal("Error = expected");
        LogNormal("");

        Exception ex = Throws(() => MSBuild(Opt() with { Dir = "" }));

        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1009");
        AssertContains(ex.Message, "Project file does not exist");

        LogNormal($"{ex}");
    });

    [TestMethod]
    public void Test_MSBuild_ErrorCase_NoOptions_EmptyDir() => InEmptyDir(() =>
    {
        LogNormal("Error = expected");
        LogNormal("");

        Exception ex = Throws(MSBuild);

        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1003");
        AssertContains(ex.Message, "Specify a project or solution file");

        LogNormal($"{ex}");
    });

    // Overloads (comment = already tested)

  //[TestMethod] public void Test_MSBuild_Overload_Method()        => InTempDir(() => Assert(            MSBuild(               )));
  //[TestMethod] public void Test_MSBuild_Overload_MethodOpt()     =>                 Assert(            MSBuild(           Opt()));
    [TestMethod] public void Test_MSBuild_Overload_MethodArgs()    => InTempDir(() => Assert(            MSBuild(  "--low"      )));
  //[TestMethod] public void Test_MSBuild_Overload_MethodArgsOpt() =>                 Assert(            MSBuild(  "--low", Opt()));
    [TestMethod] public void Test_MSBuild_Overload_Enum()          => InTempDir(() => Assert(DotNet.Exe( msbuild                )));
  //[TestMethod] public void Test_MSBuild_Overload_EnumOpt()       =>                 Assert(DotNet.Exe( msbuild,           Opt()));
    [TestMethod] public void Test_MSBuild_Overload_EnumArgs()      => InTempDir(() => Assert(DotNet.Exe( msbuild,  "--low"      )));
    [TestMethod] public void Test_MSBuild_Overload_EnumArgsOpt()   =>                 Assert(DotNet.Exe( msbuild,  "--low", Opt()));
    [TestMethod] public void Test_MSBuild_Overload_Name()          => InTempDir(() => Assert(DotNet.Exe("msbuild"               )));
  //[TestMethod] public void Test_MSBuild_Overload_NameOpt()       =>                 Assert(DotNet.Exe("msbuild",          Opt()));
    [TestMethod] public void Test_MSBuild_Overload_NameArgs()      => InTempDir(() => Assert(DotNet.Exe("msbuild", "--low"      )));
    [TestMethod] public void Test_MSBuild_Overload_NameArgsOpt()   =>                 Assert(DotNet.Exe("msbuild", "--low", Opt()));

    // Helpers

    private void Assert(DotNetResult result, bool release = false)
    {
        string dllPath = release ? DllPathRelease : DllPath;

        AssertResultOk(result);
        AssertContains(result, "dotnet msbuild");
        AssertContains(result, ProjectName + " -> " + dllPath);

        if (release) AssertContains(result, "release");

        AssertExists(dllPath);
    }
}