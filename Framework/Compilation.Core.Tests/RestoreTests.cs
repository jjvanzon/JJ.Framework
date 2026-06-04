// ReSharper disable ConvertToLambdaExpression
// ReSharper disable InvertIf
// ReSharper disable InlineTemporaryVariable
// ReSharper disable ReplaceWithSingleCallToCount

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

    private record RestoreInfo(DotNetTestHelper Helper, DotNetOptions Opt)
    {
        public Task? Task { get; set; }
        public DotNetResult? Result { get; set; }
        public Exception? Exception { get; set; }

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
        Log("Parallel restore unstable. Test provokes exceptions but still checks the outcome.");

        AssertInitialState();

        // Add tight time-out or test might take long.
        // It's a bit like rigging the test to produce exceptions,
        // but I think it's representative for behavior experienced.
        const int timeOutSec = 10;

        // Init in advance so loop is tight
        const int count = 96;

        var infos = new RestoreInfo[count];
        var tasks = new Task[count];

        // Manage your own tasks - better guarantees parallelism than parallel loop.
        for (int i = 0; i < count; i++)
        {

            DotNetTestHelper helper = new();
            DotNetOptions opt = helper.BasicOpt with { ParallelRestore = true, TimeOutSec = timeOutSec  };
            RestoreInfo info = new(helper, opt);

            var task = new Task(() =>
            {
                try
                {
                    info.Result = Restore(opt);
                }
                catch (Exception ex)
                {
                    info.Exception = ex;
                }
            });

            tasks[i] = task;
            infos[i] = info;
        }

        // Tight loop (makes exceptions more likely)
        for (int i = 0; i < count; i++)
        {
            tasks[i].Start();
        }
       
        // Wait till finished
        Task.WaitAll(tasks);

        // Report exception count
        int exceptionCount = infos.Where(x => Has(x.Exception)).Count();
        Log($"{exceptionCount} exceptions occurred. {count} restores run.");

        // Evaluate afterwards, keeps parallel loop tight and exception more likely.
        foreach (RestoreInfo info in infos)
        {
            // Having both a result and and exception, shouldn't happen.
            IsFalse(Has(info.Result) && Has(info.Exception));

            if (info.Result != null)
            {
                AssertContains(info.Result, "dotnet restore");
                AssertContains(info.Result, "determining projects to restore");
                AssertContains(info.Result, "restored " + info.Helper.CsprojPath);
                // TODO: Assert more
            }

            if (info.Exception != null)
            {
                AssertContainsAny(info.Exception.Message, "Timeout", "Access is denied");
                LogLine();
                Log($"{info.Exception}");
            }
        }

        // TODO: Assert the disable parallel argument is there by default.
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
