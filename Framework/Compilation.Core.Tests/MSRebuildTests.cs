#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class MSRebuildTests : DotNetTestHelper
{
    public MSRebuildTests() => InitRestore();

    [TestMethod]
    public void Test_MSRebuild_MainCase()
    {
        Assert(MSRebuild(Opt()));
    }

    [TestMethod]
    public void Test_MSRebuild_AsCommandEnum()
    {
        Assert(DotNet.Exe(msrebuild, Opt() with { AutoRestore = true })); // AutoRestore for the heck of it.
    }

    [TestMethod]
    public void Test_MSRebuild_AsCommandText()
    {
        Assert(DotNet.Exe("msbuild", "/t:Rebuild", Opt() with { AutoRestore = true })); // AutoRestore for the heck of it.
    }

    [TestMethod]
    public void Test_MSRebuild_WithFile()
    {
        Assert(MSRebuild(Opt() with { File = CsProjName }));
    }

    [TestMethod]
    public void Test_MSRebuild_WithoutFile()
    {
        Assert(MSRebuild(Opt() with { File = "" }));
    }

    [TestMethod]
    public void Test_MSRebuild_WithDir()
    {
        Assert(MSRebuild(Opt() with { Dir = TempDir }));
    }

    [TestMethod]
    public void Test_MSRebuild_WithoutDir_WithFullFilePath()
    {
        Assert(MSRebuild(Opt() with { Dir = "", File = CsProjPath }));
    }

    [TestMethod]
    public void Test_MSRebuild_WithoutDir_WithChDir() => InTempDir(() => 
    {
        Assert(MSRebuild(Opt() with { Dir = "" }));
    });

    [TestMethod]
    public void Test_MSRebuild_Conf()
    {
        Assert(MSRebuild(Opt() with { BuildConf = "Release" }), release: true);
    }

    [TestMethod]
    public void Test_MSRebuild_Args() 
    {
        Assert(MSRebuild("-low", Opt()));
    }

    [TestMethod]
    public void Test_MSRebuild_NoOptions() => InTempDir(() =>
    {
        Assert(MSRebuild());
    });
    
    [TestMethod]
    public void Test_MSRebuild_OptsAllOn()
    {
        var result = MSRebuild("-low", OptsAllOn());
        AssertOptsAllOnResultForBuild(result);
    }

    [TestMethod]
    public void Test_MSRebuild_VsMSBuild()
    {
        var opt = Opt() with { Verbosity = UnlessHigh(Detailed) }; // Verbosity trying to see up-to-date message where expected.

        {
            var msbuild = MSBuild(opt);
            var msrebuild = MSRebuild(opt);

            AssertResultOk(msbuild);
            AssertResultOk(msrebuild);

            AssertContains   (msbuild,   "dotnet msbuild");
            AssertNotContains(msrebuild, "dotnet msbuild");

            AssertNotContains(msbuild,   "dotnet msrebuild | msbuild");
            AssertContains   (msrebuild, "dotnet msrebuild | msbuild");

            AssertNotContains(msbuild,   "/t:Rebuild");
            AssertContains   (msrebuild, "/t:Rebuild");
        }

        // Catch the up-to-date message

        //throw new NotImplementedException();
        // Wasn't able to distinguish them. In rebuild lots of sthings are still "up-to-date".
        /*
        {
            var build = Build(opt);
            var rebuild = Rebuild(opt);

            AssertResultOk(build);
            AssertResultOk(rebuild);

            // TODO: Assert the up-to-date message.

            AssertContains   (build,   "up-to-date");
            AssertNotContains(rebuild, "up-to-date"); // TODO: Still contains "up-to-date" (packages)
        }
        */
    }

    // Error Case

    [TestMethod]
    public void Test_MSRebuild_ErrorCase_NoOptions_EmptyDir() => InEmptyDir(() =>
    {
        LogNormal("Error = expected");

        Exception ex = Throws(MSRebuild);

        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "MSB1003");
        AssertContains(ex.Message, "Specify a project or solution file");

        LogNormal($"{ex}");
    });

    // Overloads

    [TestMethod] public void Test_MSRebuild_Overload_Method()        => InTempDir(() => Assert(           MSRebuild(             )));
    [TestMethod] public void Test_MSRebuild_Overload_MethodOpt()     =>                 Assert(           MSRebuild(         Opt()));
    [TestMethod] public void Test_MSRebuild_Overload_MethodArgs()    => InTempDir(() => Assert(           MSRebuild( "-low"      )));
    [TestMethod] public void Test_MSRebuild_Overload_MethodArgsOpt() =>                 Assert(           MSRebuild( "-low", Opt()));
    [TestMethod] public void Test_MSRebuild_Overload_Enum()          => InTempDir(() => Assert(DotNet.Exe(msrebuild              )));
    [TestMethod] public void Test_MSRebuild_Overload_EnumOpt()       =>                 Assert(DotNet.Exe(msrebuild,         Opt()));
    [TestMethod] public void Test_MSRebuild_Overload_EnumArgs()      => InTempDir(() => Assert(DotNet.Exe(msrebuild, "-low"      )));
    [TestMethod] public void Test_MSRebuild_Overload_EnumArgsOpt()   =>                 Assert(DotNet.Exe(msrebuild, "-low", Opt()));

    // Helpers

    private void Assert(DotNetResult result, bool release = false)
    {
        string dllPath = release ? DllPathRelease : DllPath;

        AssertResultOk(result);
        AssertContains(result, "msrebuild | msbuild");
        //AssertContains(result, "build succeeded");
        AssertContains(result, "/t:Rebuild");
        AssertContains(result, ProjectName + " -> " + dllPath);
        AssertContains(result, result.Args.Args);

        if (release) AssertContains(result, "release");

        AssertExists(dllPath);
    }
}
