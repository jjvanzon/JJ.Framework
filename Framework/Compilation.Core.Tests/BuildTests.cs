#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class BuildTests : TestHelper
{
    public BuildTests() { InitRestore(); }

    [TestMethod]
    public void Test_Build_MainCase()
    {
        Assert(Build(Opt()));
    }
    
    [TestMethod]
    public void Test_Build_AsCommandEnum()
    {
        Assert(DotNet.Exe(build, Opt()));
    }

    [TestMethod]
    public void Test_Build_AsCommandText()
    {
        Assert(DotNet.Exe("build", Opt()));
    }

    [TestMethod]
    public void Test_Build_WithFile()
    {
        Assert(Build(Opt() with { File = CsProjName }));
    }

    [TestMethod]
    public void Test_Build_WithoutFile()
    {
        Assert(Build(Opt() with { File = "" }));
    }

    [TestMethod]
    public void Test_Build_WithDir()
    {
        Assert(Build(Opt() with { Dir = TempDir }));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithFullFilePath()
    {
        Assert(Build(Opt() with { Dir = "", File = CsProjPath }));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithChDir() => InTempDir(() =>
    {
        Assert(Build(Opt() with { Dir = "" }));
    });

    [TestMethod]
    public void Test_Build_Conf()
    {
        Assert(Build(Opt() with { BuildConf = "Release" }), release: true);
    }

    [TestMethod]
    public void Test_Build_Args() 
    {
        Assert(Build("-low", Opt()));
    }
    
    [TestMethod]
    public void Test_Build_NoOptions() => InTempDir(() =>
    {
        Assert(Build());
    });

    [TestMethod]
    public void Test_Build_OptsAllOn() 
    { 
        var result = Build("-low", OptsAllOn());
        AssertOptsAllOnForBuild(result);
    }

    [TestMethod]
    public void Test_Build_ErrorCase_WithoutDir() => InEmptyDir(() =>
    {
        LogNormal("ERROR = EXPECTED");
        LogNormal("");

        Exception ex = Throws(() => Build(Opt() with { Dir = "" }));

        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1009");
        AssertContains(ex.Message, "Project file does not exist");

        LogNormal($"{ex}");
    });

    [TestMethod]
    public void Test_Build_ErrorCase_NoOptions_EmptyDir() => InEmptyDir(() =>
    {
        LogNormal("ERROR = EXPECTED");
        LogNormal("");

        Exception ex = Throws(Build);

        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1003");
        AssertContains(ex.Message, "Specify a project or solution file");

        LogNormal($"{ex}");
    });

    // Overloads (commented = tested elsewhere)

  //[TestMethod] public void Test_Build_Overload_Method()        => InTempDir(() => Assert(            Build(               )));
  //[TestMethod] public void Test_Build_Overload_MethodOpt()     =>                 Assert(            Build(           Opt()));
    [TestMethod] public void Test_Build_Overload_MethodArgs()    => InTempDir(() => Assert(            Build(  "--low"      )));
  //[TestMethod] public void Test_Build_Overload_MethodArgsOpt() =>                 Assert(            Build(  "--low", Opt()));
    [TestMethod] public void Test_Build_Overload_Enum()          => InTempDir(() => Assert(DotNet.Exe( build                )));
  //[TestMethod] public void Test_Build_Overload_EnumOpt()       =>                 Assert(DotNet.Exe( build,           Opt()));
    [TestMethod] public void Test_Build_Overload_EnumArgs()      => InTempDir(() => Assert(DotNet.Exe( build,  "--low"      )));
    [TestMethod] public void Test_Build_Overload_EnumArgsOpt()   =>                 Assert(DotNet.Exe( build,  "--low", Opt()));
    [TestMethod] public void Test_Build_Overload_Name()          => InTempDir(() => Assert(DotNet.Exe("build"               )));
  //[TestMethod] public void Test_Build_Overload_NameOpt()       =>                 Assert(DotNet.Exe("build",          Opt()));
    [TestMethod] public void Test_Build_Overload_NameArgs()      => InTempDir(() => Assert(DotNet.Exe("build", "--low"      )));
    [TestMethod] public void Test_Build_Overload_NameArgsOpt()   =>                 Assert(DotNet.Exe("build", "--low", Opt()));

    // Helpers

    private void Assert(DotNetResult result, bool release = false)
    {
        string dllPath = release ? DllPathRelease : DllPath;

        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> " + dllPath);

        if (release) AssertContains(result, "release");

        AssertExists(dllPath);
    }
}