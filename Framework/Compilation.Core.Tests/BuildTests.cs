#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class BuildTests : DotNetTestHelper
{
    public BuildTests() => InitRestore();

    [TestMethod]
    public void Test_Build_MainCase()
    {
        Assert(() => Build(Opt()));
    }
    
    [TestMethod]
    public void Test_Build_AsCommandEnum()
    {
        Assert(() => DotNet.Exe(build, Opt()));
    }

    [TestMethod]
    public void Test_Build_AsCommandText()
    {
        Assert(() => DotNet.Exe("build", Opt()));
    }

    [TestMethod]
    public void Test_Build_WithFile()
    {
        Assert(() => Build(Opt() with { File = CsProjName }));
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
        Assert(() => Build(Opt() with { Dir = "", File = CsProjPath }));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithChDir() => InTempDir(() =>
    {
        Assert(() => Build(Opt() with { Dir = "" }));
    });

    [TestMethod]
    public void Test_Build_Conf()
    {
        Assert(() => Build(Opt() with { BuildConf = "Release" }), release: true);
    }

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
    public void Test_Build_NoOptions() => InTempDir(() =>
    {
        Assert(Build);
    });

    [TestMethod]
    public void Test_Build_AllOptsOn() 
    { 
        AssertInitialState();

        var result = Build("-low", OptsAllOn());

        AssertContains(result, "dotnet build");
        AssertOptsAllOnResultForBuild(result);
    }

    [TestMethod]
    public void Test_Build_ErrorCase_WithoutDir() => InEmptyDir(() =>
    {
        LogNormal("Error = expected");

        AssertInitialState();

        DotNetOptions opt = Opt() with { Dir = "" };
        DotNetResult? build = null;

        Exception ex = Throws(() => build = Build(opt));

        IsNull(build);
        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1009");
        AssertContains(ex.Message, "Project file does not exist");

        LogNormal($"{ex}");
    });

    [TestMethod]
    public void Test_Build_ErrorCase_NoOptions_EmptyDir() => InEmptyDir(() =>
    {
        LogNormal("Error = expected");

        AssertInitialState();

        DotNetResult? build = null;

        Exception ex = Throws(() => build = Build());

        IsNull(build);
        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1003");
        AssertContains(ex.Message, "Specify a project or solution file");

        LogNormal($"{ex}");
    });

    // Overloads

    [TestMethod] public void Test_Build_Overload_Method()        => AssertNoDir(() =>             Build(                ));
    [TestMethod] public void Test_Build_Overload_MethodOpt()     => Assert     (() =>             Build(           Opt()));
    [TestMethod] public void Test_Build_Overload_MethodArgs()    => AssertNoDir(() =>             Build(  "--low"       ));
    [TestMethod] public void Test_Build_Overload_MethodArgsOpt() => Assert     (() =>             Build(  "--low", Opt()));
    [TestMethod] public void Test_Build_Overload_Enum()          => AssertNoDir(() => DotNet.Exe( build                 ));
    [TestMethod] public void Test_Build_Overload_EnumOpt()       => Assert     (() => DotNet.Exe( build,           Opt()));
    [TestMethod] public void Test_Build_Overload_EnumArgs()      => AssertNoDir(() => DotNet.Exe( build,  "--low"       ));
    [TestMethod] public void Test_Build_Overload_EnumArgsOpt()   => Assert     (() => DotNet.Exe( build,  "--low", Opt()));
    [TestMethod] public void Test_Build_Overload_Name()          => AssertNoDir(() => DotNet.Exe("build"                ));
    [TestMethod] public void Test_Build_Overload_NameOpt()       => Assert     (() => DotNet.Exe("build",          Opt()));
    [TestMethod] public void Test_Build_Overload_NameArgs()      => AssertNoDir(() => DotNet.Exe("build", "--low"       ));
    [TestMethod] public void Test_Build_Overload_NameArgsOpt()   => Assert     (() => DotNet.Exe("build", "--low", Opt()));

    // Helpers

    private void AssertInitialState()
    {
        AssertExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    private void Assert(Func<DotNetResult> call, bool release = false)
    {
        string dllPath = release ? DllPathRelease : DllPath;

        AssertInitialState();

        var result = call();

        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> " + dllPath);

        if (release) AssertContains(result, "release");

        AssertExists(dllPath);
    }

    private void AssertNoDir(Func<DotNetResult> call) => InTempDir(() => Assert(call));
}