// ReSharper disable ConvertToLambdaExpression
// ReSharper disable InvertIf
// ReSharper disable InlineTemporaryVariable
// ReSharper disable ReplaceWithSingleCallToCount

namespace JJ.Framework.Compilation.Core.Tests;

using T = RestoreTests;

[TestClass]
public class RestoreTests : DotNetTestHelper
{
    // TODO: Test Without File
    // TODO: Make test console output look better.

    [TestMethod]
    public void Test_ExplicitRestore()
    {
        AssertInitialState();

        DotNetResult restore = Restore(GetOpt());

        AssertExists(AssetsFilePath);

        AssertResultOk(restore);
        AssertContains(restore, "dotnet restore");
        AssertContains(restore, "determining projects to restore");
        AssertContains(restore, "restored " + CsprojPath);
    }

    [TestMethod]
    public void Test_AutoRestore()
    {
        AssertInitialState();

        DotNetOptions opt = GetOpt() with { AutoRestore = true };
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

        var opt = GetOpt() with { AutoRestore = true };

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

        var opt = GetOpt() with { AutoRestore = false };
        
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
    public void Test_Restore_DisableParallel_ByDefault()
    {
        DotNetResult result = Restore(GetOpt());
        AssertContains(result, "--disable-parallel");
    }

    /// <summary>
    /// Basically parallel restore doesn't work. It deadlocks under heavy parallel work.
    /// 
    /// Assert the option can be set, but not if the effect is consistent.
    /// Build might succeed. Exception might occur with time-out.
    /// </summary>
    [TestMethod]
    public void Test_ParallelRestore_EvilDoesNotWork()
    {
        #if NET5_0
            Log("Skip .NET 5. Too slow. Check other .NET version.");
            return;
        #endif

        Log("Parallel restore unstable. Test provokes and tolerates exceptions but still checks the outcome.");
        LogLine();

        AssertInitialState();

        // Add tight time-out or test might take long.
        // It's a bit like rigging the test to produce exceptions,
        // but I think it's representative for behavior experienced.
        const int timeOutSec = 8;
        const int count = 72;

        // Init in advance so loop is tight
        var infos = new RestoreInfo[count];
        var tasks = new Task[count];

        // Manage your own tasks - better guarantees parallelism than parallel loop.
        for (int i = 0; i < count; i++)
        {
            DotNetTestHelper helper = new();
            DotNetOptions opt = helper.GetOpt() with { ParallelRestore = true, TimeOutSec = timeOutSec };
            RestoreInfo info = new(helper);

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
        WaitAll(tasks);

        // Report exception count
        int exceptionCount = infos.Where(x => Has(x.Exception)).Count();
        Log($"{exceptionCount} exceptions occurred. {count} restores run.");

        // Evaluate afterwards, keeps parallel loop tight and exception more likely.
        foreach (var x in infos)
        {
            // Having both a result and and exception, shouldn't happen.
            IsFalse(Has(x.Result) && Has(x.Exception));

            if (x.Result != null)
            {
                AssertResultOk(x.Result);
                AssertContains(x.Result, "dotnet restore");
                AssertContains(x.Result, "determining projects to restore");
                AssertContains(x.Result, "restored " + x.Helper.CsprojPath);
            }

            if (x.Exception != null)
            {
                AssertContainsAny(x.Exception.Message, "Timeout", "Access is denied", "Cannot process request");
                LogLine();
                Log($"{x.Exception}");
            }
        }
    }

    // Overloads

    [TestMethod]
    public void Test_Restore_Overloads()
    {
        { T x = new(); x.AssertNoDir(() =>      Restore(                          )); }
        { T x = new(); x.Assert     (() =>      Restore(                x.GetOpt())); }
        { T x = new(); x.AssertNoDir(() =>      Restore(  "--no-cache"            )); }
        { T x = new(); x.Assert     (() =>      Restore(  "--no-cache", x.GetOpt())); }
        { T x = new(); x.AssertNoDir(() => Exe( restore                           )); }
        { T x = new(); x.Assert     (() => Exe( restore,                x.GetOpt())); }
        { T x = new(); x.AssertNoDir(() => Exe( restore,  "--no-cache"            )); }
        { T x = new(); x.Assert     (() => Exe( restore,  "--no-cache", x.GetOpt())); }
        { T x = new(); x.AssertNoDir(() => Exe("restore"                          )); }
        { T x = new(); x.Assert     (() => Exe("restore",               x.GetOpt())); }
        { T x = new(); x.AssertNoDir(() => Exe("restore", "--no-cache"            )); }
        { T x = new(); x.Assert     (() => Exe("restore", "--no-cache", x.GetOpt())); }
    }

    // Helpers

    private record RestoreInfo(DotNetTestHelper Helper)
    {
        public DotNetResult? Result { get; set; }
        public Exception? Exception { get; set; }
    }

    private void AssertNoDir(Func<DotNetResult> call) => InTempDir(() => Assert(call));
    private void Assert(Func<DotNetResult> call)
    {
        AssertInitialState();
        DotNetResult result = call();
        AssertExists(AssetsFilePath);
        AssertResultOk(result);
        AssertContains(result, "dotnet restore");
        AssertContains(result, "determining projects to restore");
        AssertContains(result, "restored " + CsprojPath);
    }

    private void AssertInitialState()
    {
        AssertNotExists(AssetsFilePath);
        AssertNotExists(DebugDllFilePath);
        AssertNotExists(ReleaseDllFilePath);
    }

}
