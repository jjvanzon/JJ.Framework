#pragma warning disable IDE0002
namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class RebuildTests : DotNetTestHelper
{
    // Most logic is already hit by BuildTests

    // TODO: Test:
    // x Normal call
    // x Command Enum
    // ~ Command Text? > Requires an explicit re-parameter on/off?
    // x Test output
    // .. Rebuild vs Build
    // .. Overload space
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

    /// <summary>
    /// Do everything else with AutoRestore on just for the heck of it.
    /// </summary>
    private DotNetOptions TestOpt() => Opt() with { AutoRestore = true };

    [TestMethod]
    public void Test_Rebuild_AsCommandEnum()
    {
        AssertInitialState();

        var opt = TestOpt();

        var result = DotNet.Exe(rebuild, opt);

        AssertResult(result);
    }

    [TestMethod]
    public void Test_Rebuild_AsCommandText()
    {
        AssertInitialState();

        var opt = TestOpt();

        // TODO: Might like a re argument for easy variable re option?
        var result = DotNet.Exe("build", "--no-incremental", opt);

        AssertResult(result);
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
        {
            var build = Build(opt);
            var rebuild = Rebuild(opt);

            AssertResultOk(build);
            AssertResultOk(rebuild);

            // TODO: Assert the up-to-date message.

            AssertContains   (build,   "up-to-date");
            // AssertNotContains(rebuild, "up-to-date"); // TODO: Still contains "up-to-date"
        }
    }

    [TestMethod]
    public void Test_Rebuild_NoOpt()
    {
    }

    // TODO: File opts missing / not missing?

    [TestMethod]
    public void Test_Rebuild_AllOptsOn()
    {
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
}
