// ReSharper disable ConvertToLambdaExpression
namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class RestoreTests : DotNetTestHelper
{

    // TODO: Implement each behavioral test

    [TestMethod]
    public void Test_Restore_Explicit()
    {
        AssertInitialState();

        DotNetResult restore = Restore(BasicOpt);

        AssertExists(AssetsFilePath);

        AssertResultOk(restore);
        AssertContains(restore, "dotnet restore");
        AssertContains(restore, "determining projects to restore");
        AssertContains(restore, "restored " + CsprojPath);
    }

    [TestMethod]
    public void Test_Restore_AutoRestore_True()
    {
        AssertInitialState();

        DotNetOptions opt = BasicOpt with { AutoRestore = true };
        DotNetResult build = Build(opt);
        AssertResultOk(build);

        // Assert Restore happened
        AssertExists(AssetsFilePath);
        AssertContains(build, "restore: auto");
        AssertContains(build, "determining projects to restore");
        AssertContains(build, "restored " + CsprojPath);

        // Assert Build Happened
        AssertDebugDll();
        AssertContains(build, DebugDllFilePath);
        AssertContains(build, "dotnet build");
        AssertContains(build, "build succeeded");
    }
    
    [TestMethod]
    public void Test_Restore_UpToDate()
    {
        AssertInitialState();

        var opt = BasicOpt with { AutoRestore = true };

        // Build with AutoRestore
        {
            DotNetResult build = Build(opt);
            AssertResultOk(build);
            AssertContains(build, "restored " + CsprojPath);
            AssertExists(AssetsFilePath);
        }

        // Restore and see "up to date" message
        {
            DotNetResult restore = Restore(opt);
            AssertResultOk(restore);
            AssertContains(restore, "dotnet restore");
            AssertContains(restore, "determining projects to restore");
            AssertContains(restore, "up-to-date");
        }
    }

    [TestMethod]
    public void Test_NoRestore_Builds_WithPainfulException()
    {
        AssertInitialState();

        var opt = BasicOpt with { AutoRestore = false };
        
        string msg = Throws(() => Build(opt)).Message;

        NotNullOrWhiteSpace(msg);
        AssertContains(msg, "--no-restore");

        AssertContains(msg, "Build failed");
        AssertContains(msg, "Exit Code 1");
        AssertContains(msg, "NETSDK1004");
        AssertContains(msg, "Run a NuGet package restore");
        AssertContains(msg, "Assets file '" + AssetsFilePath + "' not found.");

        AssertNotExists(AssetsFilePath);
        AssertNotContains(msg, "restored");
        AssertNotContains(msg, "up-to-date");
    }

    [TestMethod]
    public void Test_DotNet_Restore_ParallelRestore()
    {
        // TODO: Not sure how to test this.
        // Basically parallel restore doesn't work. It deadlocks in parallel.
        // So assert the disable parallel argument is there by default?

        // Assert the option can be set, but not if the effect is consistent.
        // Build might succeed. Exception might occur with time-out.
    }

    [TestMethod]
    public void Test_DotNet_Restore_Overloads()
    {
    }

    // Helpers

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DebugDllFilePath);
        AssertNotExists(ReleaseDllFilePath);
    }
}
