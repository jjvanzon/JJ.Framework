#pragma warning disable IDE0002
// ReSharper disable ConvertToLambdaExpression
// ReSharper disable InvertIf
// ReSharper disable InlineTemporaryVariable
// ReSharper disable ReplaceWithSingleCallToCount

namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class RestoreTests : DotNetTestHelper
{
    [TestMethod]
    public void Test_ExplicitRestore()
    {
        DotNetResult restore = Restore(GetOpt());

        AssertExists(AssetsFilePath);

        AssertResultOk(restore);
        AssertContains(restore, "dotnet restore");
        AssertContains(restore, "determining projects to restore");
        AssertContains(restore, "restored " + CsProjPath);

        LogOutput(restore.OutputText);
    }

    [TestMethod]
    public void Test_Restore_WithoutFile()
    {
        DotNetOptions opt = GetOpt() with { File = "" };
        DotNetResult restore = Restore(opt);

        AssertExists(AssetsFilePath);

        AssertResultOk(restore);
        AssertContains(restore, "dotnet restore");
        AssertContains(restore, "determining projects to restore");
        AssertContains(restore, "restored " + CsProjPath);

        LogOutput(restore.OutputText);
    }

    [TestMethod]
    public void Test_AutoRestore()
    {
        DotNetOptions opt = GetOpt() with { AutoRestore = true };
        DotNetResult build = Build(opt);
        AssertResultOk(build);

        // Assert Restore happened
        AssertExists(AssetsFilePath);
        AssertContains(build, "restore: auto");
        AssertContains(build, "determining projects to restore");
        AssertContains(build, "restored " + CsProjPath);

        // Assert Build Happened
        AssertDll();
        AssertContains(build, DllPath);
        AssertContains(build, "dotnet build");
        AssertContains(build, "build succeeded");

        LogOutput(build.OutputText);
    }
    
    [TestMethod]
    public void Test_Restore_UpToDate()
    {
        var opt = GetOpt() with { AutoRestore = true };

        // Build with AutoRestore
        {
            DotNetResult build = Build(opt);
            AssertResultOk(build);
            AssertContains(build, "restored " + CsProjPath);
            AssertExists(AssetsFilePath);
            LogOutput(build.OutputText);
        }

        LogOutput("");

        // Restore and see "up to date" message
        {
            DotNetResult restore = Restore(opt);
            AssertResultOk(restore);
            AssertContains(restore, "dotnet restore");
            AssertContains(restore, "determining projects to restore");
            AssertContains(restore, "up-to-date");
            LogOutput(restore.OutputText);
        }
    }

    [TestMethod]
    public void Test_Restore_OptsAllOn() 
    { 
        var result = Restore("-low", OptsAllOn());

        AssertOptsAllOnResult(result);
        AssertExists(AssetsFilePath);
        
        AssertContains(result, "dotnet restore");
        AssertContains(result, "determining projects to restore");
        AssertContains(result, "restored " + CsProjPath);
        AssertContains(result, "-low");
    }

    // Painful

    [TestMethod]
    public void Test_NoRestore_PainfulException()
    {
        LogNormal("Error = expected");
        LogNormal("");

        var opt = GetOpt() with { AutoRestore = false };
        
        Exception ex = Throws(() => Build(opt));

        NotNullOrWhiteSpace(ex.Message);
        AssertContains(ex.Message, "--no-restore");

        AssertNotExists(AssetsFilePath);
        AssertNotContains(ex.Message, "restored");
        AssertNotContains(ex.Message, "up-to-date");

        AssertContains(ex.Message, "Build failed");
        AssertContains(ex.Message, "Exit Code 1");
        AssertContains(ex.Message, "NETSDK1004");
        AssertContains(ex.Message, "Run a NuGet package restore");
        AssertContains(ex.Message, "Assets file '" + AssetsFilePath + "' not found.");

        LogNormal(ex.Message);
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
            LogMinimal("Skip .NET 5. Too slow. Check other .NET version.");
            return;
        #endif

        LogMinimal("Parallel restore unstable. Test provokes and tolerates exceptions but still checks the outcome.");
        LogMinimal("");

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

            var opt = helper.Opt() with 
            {
                ParallelRestore = true, 
                TimeOutSec = timeOutSec,
                Verbosity = UnlessHigh(Quiet)
            };

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
        LogMinimal($"{exceptionCount} exceptions occurred. {count} restores run.");

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
                AssertContains(x.Result, "restored " + x.Helper.CsProjPath);
            }

            if (x.Exception != null)
            {
                AssertContainsAny(x.Exception.Message, "Timeout", "Access is denied", "Cannot process request");
                LogNormal("");
                LogNormal($"{x.Exception}");
            }
        }
    }

    // Overloads

    [TestMethod] public void Test_Restore_Overload_Method()        => AssertNoDir(() =>             Restore(                     ));
    [TestMethod] public void Test_Restore_Overload_MethodOpt()     => Assert     (() =>             Restore(                Opt()));
    [TestMethod] public void Test_Restore_Overload_MethodArgs()    => AssertNoDir(() =>             Restore(  "--no-cache"       ));
    [TestMethod] public void Test_Restore_Overload_MethodArgsOpt() => Assert     (() =>             Restore(  "--no-cache", Opt()));
    [TestMethod] public void Test_Restore_Overload_Enum()          => AssertNoDir(() => DotNet.Exe( restore                      ));
    [TestMethod] public void Test_Restore_Overload_EnumOpt()       => Assert     (() => DotNet.Exe( restore,                Opt()));
    [TestMethod] public void Test_Restore_Overload_EnumArgs()      => AssertNoDir(() => DotNet.Exe( restore,  "--no-cache"       ));
    [TestMethod] public void Test_Restore_Overload_EnumArgsOpt()   => Assert     (() => DotNet.Exe( restore,  "--no-cache", Opt()));
    [TestMethod] public void Test_Restore_Overload_Name()          => AssertNoDir(() => DotNet.Exe("restore"                     ));
    [TestMethod] public void Test_Restore_Overload_NameOpt()       => Assert     (() => DotNet.Exe("restore",               Opt()));
    [TestMethod] public void Test_Restore_Overload_NameArgs()      => AssertNoDir(() => DotNet.Exe("restore", "--no-cache"       ));
    [TestMethod] public void Test_Restore_Overload_NameArgsOpt()   => Assert     (() => DotNet.Exe("restore", "--no-cache", Opt()));

    // Helpers

    private record RestoreInfo(DotNetTestHelper Helper)
    {
        public DotNetResult? Result { get; set; }
        public Exception? Exception { get; set; }
    }
    
    private void LogOutput(string text)
    {
        bool alreadyLogged = Verbosity > Normal;
        if (alreadyLogged) return;
        LogNormal(text); // ncrunch: no coverage
    }

    private void AssertNoDir(Func<DotNetResult> call) => InTempDir(() => Assert(call));
    private void Assert(Func<DotNetResult> call)
    {
        DotNetResult result = call();
        AssertExists(AssetsFilePath);
        AssertResultOk(result);
        AssertContains(result, "dotnet restore");
        AssertContains(result, "determining projects to restore");
        AssertContains(result, "restored " + CsProjPath);
    }
}
