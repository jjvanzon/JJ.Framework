// ReSharper disable ConvertToLambdaExpression
// ReSharper disable InvertIf

using static System.Threading.Tasks.Parallel;
// ReSharper disable InlineTemporaryVariable

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class RestoreTests : DotNetTestHelper
{
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
    public void Test_Restore_AutoRestore()
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
    public void Test_NoRestore_PainfulException()
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

    /// <summary>
    /// Basically parallel restore doesn't work. It deadlocks under heavy parallel work.
    /// 
    /// Assert the option can be set, but not if the effect is consistent.
    /// Build might succeed. Exception might occur with time-out.
    /// </summary>
    [TestMethod]
    public void Test_Restore_ParallelRestore_EvilDoesNotWork()
    {
        // TODO: Assert the disable parallel argument is there by default.

        Log("Parallel restore unstable. Test provokes exceptions but still checks the outcome.");

        AssertInitialState();

        // Add tight time-out or test might take long.
        // It's a bit like rigging the test to produce exceptions,
        // but I think it's representative for behavior experienced.
        const int timeOutSec = 10;

        // Init in advance so loop is tight
        const int count = 96;

        var testHelpers = new DotNetTestHelper[count];
        var opts        = new DotNetOptions   [count];
        var results     = new DotNetResult?   [count];
        var exceptions  = new Exception?      [count];
        var tasks       = new Task            [count];

        // Manage your own tasks - better guarantees parallelism than parallel loop.
        for (int i = 0; i < count; i++)
        {
            testHelpers[i] = new DotNetTestHelper();
            opts[i] = testHelpers[i].BasicOpt with { ParallelRestore = true, TimeOutSec = timeOutSec  };

            // Snapshot variables locally.
            var frozenIndex = i; 
            var fronzenOpt = opts[i];

            // TODO: Hmm... would hoist a lot of data. Use tuple array for above objects?

            tasks[i] = new(() =>
            {
                try
                {
                    results[frozenIndex] = Restore(fronzenOpt);
                }
                catch (Exception ex)
                {
                    exceptions[frozenIndex] = ex;
                }
            });
        }

        // Tight loop (makes exceptions more likely)
        for (int i = 0; i < count; i++)
        {
            tasks[i].Start();
        }
       
        // Wait till finished
        Task.WaitAll(tasks);

        // Report exception count
        int exceptionCount = exceptions.Where(FilledIn).Count();
        Log($"{exceptionCount} exceptions occurred. {count} restores run.");

        // Evaluate only after parallel loop, keeps loop tight and exception more likely.
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
                LogLine();
                Log($"{ex}");
            }
        }

    }

    [TestMethod]
    public void Test_DotNet_Restore_Overloads()
    {
        // TODO: Implement.
    }

    // Helpers

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DebugDllFilePath);
        AssertNotExists(ReleaseDllFilePath);
    }
}
