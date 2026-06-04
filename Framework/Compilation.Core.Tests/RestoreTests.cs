// ReSharper disable ConvertToLambdaExpression

using static System.Threading.Tasks.Parallel;

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

        AssertNotExists(AssetsFilePath);
        AssertNotContains(msg, "restored");
        AssertNotContains(msg, "up-to-date");

        AssertContains(msg, "Build failed");
        AssertContains(msg, "Exit Code 1");
        AssertContains(msg, "NETSDK1004");
        AssertContains(msg, "Run a NuGet package restore");
        AssertContains(msg, "Assets file '" + AssetsFilePath + "' not found.");
    }

    [TestMethod]
    public void Test_DotNet_Restore_ParallelRestore()
    {
        // TODO: Not sure how to test this.

        // Basically parallel restore doesn't work well.
        // It deadlocks in parallel.
        // So assert the disable parallel argument is there by default?

        // Assert the option can be set, but not if the effect is consistent.
        // Build might succeed. Exception might occur with time-out.

        AssertInitialState();

        // Init in advance so loop is tight
        const int count = 128;

        var testHelpers = new DotNetTestHelper[count];
        var opts        = new DotNetOptions   [count];
        var results     = new DotNetResult?   [count];
        var exceptions  = new Exception?      [count];

        for (int i = 0; i < count; i++)
        {
            testHelpers[i] = new DotNetTestHelper();
            // Add tight time-out or test might take long.
            // It's a bit like rigging the test to produce exceptions,
            // but I think it's representative for behavior experienced currently (as of 2026-06).
            opts[i] = testHelpers[i].BasicOpt with { ParallelRestore = true, TimeOutSec = 20 };
        }

        // TODO: Manage your own tasks, which should give better guarantees to degree of parallelism.

        // Tight loop (makes exceptions more likely)
        var parallelOpts = new ParallelOptions { MaxDegreeOfParallelism = count };
        For(0, count, parallelOpts, i =>
        {
            try
            {
                results[i] = Restore(opts[i]);
            }
            catch (Exception ex)
            {
                exceptions[i] = ex;
            }
        });

        // Evaluate after parallel loop, keeps loop tight and exception more likely.
        for (int i = 0; i < count; i++)
        {
            DotNetTestHelper testHelper = testHelpers[i];
            DotNetResult?    result     = results    [i];
            Exception?       ex         = exceptions [i];

            // Having both a result and and exception, shouldn't happen.
            IsFalse(Has(result) && Has(ex));

            if (result != null)
            {
                AssertContains(result, "dotnet restore");
                AssertContains(result, "determining projects to restore");
                AssertContains(result, "restored " + testHelper.CsprojPath);
                // TODO: Assert more
            }

            if (ex != null)
            {
                AssertContainsAny(ex.Message, "Timeout", "Access is denied");
                Log($"{ex}");
            }
        }
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
