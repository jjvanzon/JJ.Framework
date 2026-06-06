#pragma warning disable IDE0002
namespace JJ.Framework.Compilation.Core.Tests;

using static Path;

[TestClass]
public class RebuildTests : DotNetTestHelper
{
    // Most logic is already hit by BuildTests

    // TODO: Test:
    // x~ Command Text? > Requires an explicit re-parameter on/off?
    // x~ Rebuild vs Build > Can't use check for "up-to-date" text.
    // - Overload space
    // - File options on/off

    // Just look in BuildTests to see which are worth repeating for Rebuild.
    // Do explicit restores inside the methods themselves instead of constructor,
    // since that will get logging options applied to it.

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

        // TODO: Might like a re argument for easy variable re option?
        var result = DotNet.Exe("build", "--no-incremental", opt);

        AssertResult(result);
    }

    [TestMethod]
    public void Test_Rebuild_NoOpt() => InTempDir(() =>
    {
        AssertInitialState();
        Restore();
        var result = Rebuild();
        AssertResult(result);
    });

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
            AssertNotContains(rebuild, "up-to-date"); // TODO: Still contains "up-to-date"
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

    // TODO: Make helper for checking with all opt, because there's lots of repetition compared to BuildTests.

    [TestMethod]
    public void Test_Rebuild_AllOptsOn()
    {
        AssertInitialState();

        string logPath    = Combine(TempDir, Name() + ".log");
        string binLogPath = Combine(TempDir, Name() + ".binlog");

        var allOpt = new DotNetOptions
        {
            Dir             = TempDir,
            File            = CsprojPath,

            BuildConf       = "Release",
            Args            = "--no-logo",
            
            AutoRestore     = true,
            ParallelRestore = false, // Keep false. Parallel restore can choke up the whole system.
            
            NodeReuse       = true,
            TimeOutSec      = 123,
                            
            Verbosity       = UnlessHigh(Minimal),
            LogFile         = logPath,
            BinLog          = binLogPath,
            LogAction       = Log
        };

        var result = Rebuild("-low", allOpt);

        AssertDllRelease();
        AssertExists(logPath);
        AssertExists(binLogPath);
        AssertResultOk(result);
        AssertContains(result, "dotnet rebuild | build");
        AssertContains(result, "build succeeded");
        AssertContains(result, "release");
        AssertContains(result, "timeout: 123");
        AssertContains(result, "--no-logo");
        AssertContains(result, "-low");
        AssertContains(result, binLogPath);
        AssertContains(result, ProjectName + " -> " + DllPathRelease);
        //AssertContains(result, logPath); // Currently not shown: not in command line, not in descriptor.
        //AssertContains(result, "minimal"); // Verbosity overrides interfere
    }

    [TestMethod]
    public void Test_Rebuild_Overloads()
    {
    }

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
    }
}
