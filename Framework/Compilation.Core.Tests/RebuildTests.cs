#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class RebuildTests : DotNetTestHelper
{
    public RebuildTests() => InitRestore();

    [TestMethod]
    public void Test_Rebuild_MainCase()
    {
        Assert(Rebuild(Opt()));
    }

    [TestMethod]
    public void Test_Rebuild_AsCommandEnum()
    {
        Assert(DotNet.Exe(rebuild, Opt() with { AutoRestore = true })); // AutoRestore for the heck of it.
    }

    [TestMethod]
    public void Test_Rebuild_AsCommandText()
    {
        Assert(DotNet.Exe("build", "--no-incremental", Opt() with { AutoRestore = true })); // AutoRestore for the heck of it.
    }

    [TestMethod]
    public void Test_Rebuild_WithFile()
    {
        Assert(Rebuild(Opt() with { File = CsProjName }));
    }

    [TestMethod]
    public void Test_Rebuild_WithoutFile()
    {
        Assert(Rebuild(Opt() with { File = "" }));
    }

    [TestMethod]
    public void Test_Rebuild_WithDir()
    {
        Assert(Rebuild(Opt() with { Dir = TempDir }));
    }

    [TestMethod]
    public void Test_Rebuild_WithoutDir_WithFullFilePath()
    {
        Assert(Rebuild(Opt() with { Dir = "", File = CsProjPath }));
    }

    [TestMethod]
    public void Test_Rebuild_WithoutDir_WithChDir() => InTempDir(() => 
    {
        Assert(Rebuild(Opt() with { Dir = "" }));
    });

    [TestMethod]
    public void Test_Rebuild_Conf()
    {
        Assert(Rebuild(Opt() with { BuildConf = "Release" }), release: true);
    }

    [TestMethod]
    public void Test_Rebuild_Args() 
    {
        Assert(Rebuild("-low", Opt()));
    }

    [TestMethod]
    public void Test_Rebuild_NoOptions() => InTempDir(() =>
    {
        Assert(Rebuild());
    });
    
    [TestMethod]
    public void Test_Rebuild_OptsAllOn()
    {
        var result = Rebuild("-low", OptsAllOn());
        AssertOptsAllOnResultForBuild(result);
    }

    [TestMethod]
    public void Test_Rebuild_VsBuild()
    {
        var opt = Opt() with { Verbosity = UnlessHigh(Detailed) }; // Verbosity trying to see up-to-date message where expected.

        {
            var build = Build(opt);
            var rebuild = Rebuild(opt);

            AssertResultOk(build);
            AssertResultOk(rebuild);

            AssertContains   (build,   "dotnet build");
            AssertNotContains(rebuild, "dotnet build");

            AssertNotContains(build,   "dotnet rebuild | build");
            AssertContains   (rebuild, "dotnet rebuild | build");

            AssertNotContains(build,   "--no-incremental");
            AssertContains   (rebuild, "--no-incremental");
        }

        // Catch the up-to-date message
        {
            var build = Build(opt);
            var rebuild = Rebuild(opt);

            AssertResultOk(build);
            AssertResultOk(rebuild);

            // Shorter text "up-to-date" is mentioned in both msbuild and msrebuild (e.g. packages up-to-date).
            const string upToDateMessage = "Skipping target \"CoreCompile\" because all output files are up-to-date";

            AssertContains   (build,   upToDateMessage);
            AssertNotContains(rebuild, upToDateMessage);
        }
    }

    // Error Case

    [TestMethod]
    public void Test_Rebuild_ErrorCase_NoOptions_EmptyDir() => InEmptyDir(() =>
    {
        LogNormal("Error = expected");

        Exception ex = Throws(Rebuild);

        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1003");
        AssertContains(ex.Message, "Specify a project or solution file");

        LogNormal($"{ex}");
    });

    // Overloads

    // TODO: Ones already covered above: Comment out for perf (but keep for overview).

    [TestMethod] public void Test_Rebuild_Overload_Method()        => InTempDir(() => Assert(           Rebuild(             )));
    [TestMethod] public void Test_Rebuild_Overload_MethodOpt()     =>                 Assert(           Rebuild(         Opt()));
    [TestMethod] public void Test_Rebuild_Overload_MethodArgs()    => InTempDir(() => Assert(           Rebuild( "-low"      )));
    [TestMethod] public void Test_Rebuild_Overload_MethodArgsOpt() =>                 Assert(           Rebuild( "-low", Opt()));
    [TestMethod] public void Test_Rebuild_Overload_Enum()          => InTempDir(() => Assert(DotNet.Exe(rebuild              )));
    [TestMethod] public void Test_Rebuild_Overload_EnumOpt()       =>                 Assert(DotNet.Exe(rebuild,         Opt()));
    [TestMethod] public void Test_Rebuild_Overload_EnumArgs()      => InTempDir(() => Assert(DotNet.Exe(rebuild, "-low"      )));
    [TestMethod] public void Test_Rebuild_Overload_EnumArgsOpt()   =>                 Assert(DotNet.Exe(rebuild, "-low", Opt()));

    // Helpers

    private void Assert(DotNetResult result, bool release = false)
    {
        string dllPath = release ? DllPathRelease : DllPath;

        AssertResultOk(result);
        AssertContains(result, "rebuild | build");
        AssertContains(result, "build succeeded");
        AssertContains(result, "--no-incremental");
        AssertContains(result, ProjectName + " -> " + dllPath);
        AssertContains(result, result.Args.Args);

        if (release) AssertContains(result, "release");

        AssertExists(dllPath);
    }
}
