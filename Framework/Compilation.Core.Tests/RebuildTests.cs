#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class RebuildTests : DotNetTestHelper
{
    [TestMethod]
    public void Test_Rebuild_ExplicitRestore()
    {
        AssertInitialState();

        var opt = Opt();
        Restore(opt);
        var result = Rebuild(opt);

        AssertResult(result);
    }

    [TestMethod]
    public void Test_Rebuild_AutoRestore()
    {
        AssertInitialState();

        var opt = Opt() with { AutoRestore = true };
        var result = Rebuild(opt);

        AssertResult(result);
    }

    [TestMethod]
    public void Test_Rebuild_AsCommandEnum()
    {
        AssertInitialState();

        var opt = Opt() with { AutoRestore = true }; // AutoRestore for the heck of it.

        var result = DotNet.Exe(rebuild, opt);

        AssertResult(result);
    }

    [TestMethod]
    public void Test_Rebuild_AsCommandText()
    {
        AssertInitialState();

        var opt = Opt() with { AutoRestore = true }; // AutoRestore for the heck of it.

        var result = DotNet.Exe("build", "--no-incremental", opt);

        AssertResult(result);
    }

    [TestMethod]
    public void Test_Rebuild_NoOptions() => InTempDir(() =>
    {
        AssertInitialState();
        Restore();
        var result = Rebuild();
        AssertResult(result);
    });
    
    [TestMethod]
    public void Test_Rebuild_AllOptsOn()
    {
        AssertInitialState();

        var opt = AllOptsOn();
        var result = Rebuild("-low", opt);

        AssertAllOptsOn(result, opt);
        AssertContains(result, "dotnet rebuild | build");
    }

    [TestMethod]
    public void Test_Rebuild_VsBuild()
    {
        AssertInitialState();

        var opt = Opt() with { Verbosity = UnlessHigh(Detailed) }; // Verbosity trying to see up-to-date message where expected.

        Restore(opt);

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

    // File Options

    [TestMethod]
    public void Test_Rebuild_WithFile()
    {
        Assert(Rebuild, Opt() with { File = CsProjFileName });
    }

    [TestMethod]
    public void Test_Rebuild_WithoutFile()
    {
        Assert(Rebuild, Opt() with { File = "" });
    }

    [TestMethod]
    public void Test_Rebuild_WithDir()
    {
        Assert(Rebuild, Opt() with { Dir = TempDir });
    }

    [TestMethod]
    public void Test_Rebuild_WithoutDir_WithFullFilePath()
    {
        Assert(Rebuild, Opt() with { Dir = "", File = CsprojPath });
    }

    [TestMethod]
    public void Test_Rebuild_WithoutDir_WithChDir() => InTempDir(() => 
    {
        Assert(Rebuild, Opt() with { Dir = "" });
    });

    [TestMethod]
    public void Test_Rebuild_ErrorCase_ForgotRestore()
    {
        LogNormal("Error = expected");

        AssertInitialState();

        DotNetResult? result = null;

        Exception ex = Throws(() => result = Rebuild(Opt()));

        IsNull(result);
        AssertContains(ex.Message, "Exit code 1");
        AssertContains(ex.Message, "NETSDK1004");
        AssertContains(ex.Message, "Run a NuGet package restore");

        LogNormal($"{ex}");
    }

    // Overloads

    [TestMethod] public void Test_Rebuild_Overload_Method()        => AssertNoDir(() =>            Rebuild(              ));
    [TestMethod] public void Test_Rebuild_Overload_MethodOpt()     => Assert     (() =>            Rebuild(         Opt()));
    [TestMethod] public void Test_Rebuild_Overload_MethodArgs()    => AssertNoDir(() =>            Rebuild( "-low"       ));
    [TestMethod] public void Test_Rebuild_Overload_MethodArgsOpt() => Assert     (() =>            Rebuild( "-low", Opt()));
    [TestMethod] public void Test_Rebuild_Overload_Enum()          => AssertNoDir(() => DotNet.Exe(rebuild               ));
    [TestMethod] public void Test_Rebuild_Overload_EnumOpt()       => Assert     (() => DotNet.Exe(rebuild,         Opt()));
    [TestMethod] public void Test_Rebuild_Overload_EnumArgs()      => AssertNoDir(() => DotNet.Exe(rebuild, "-low"       ));
    [TestMethod] public void Test_Rebuild_Overload_EnumArgsOpt()   => Assert     (() => DotNet.Exe(rebuild, "-low", Opt()));

    // Helpers

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    private void AssertResult(DotNetResult result)
    {
        AssertResultOk(result);
        AssertContains(result, "rebuild | build");
        AssertContains(result, "build succeeded");
        AssertContains(result, "--no-incremental");
        AssertContains(result, ProjectName + " -> " + DllPath);
    }

    private void Assert(Func<DotNetOptions, DotNetResult> call, DotNetOptions opt)
    {
        AssertInitialState();
        Restore(opt);
        var result = call(opt);
        AssertResult(result);
        AssertDll();
    }

    private void Assert(Func<DotNetResult> call)
    {
        AssertInitialState();
        InitRestore();
        var result = call();
        AssertResult(result);
        AssertDll();
    }

    private void AssertNoDir(Func<DotNetResult> call) => InTempDir(() => Assert(call));
}
