#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core.Tests;

using static Path;

[TestClass]
public class BuildTests : DotNetTestHelper
{
    public BuildTests() => InitRestore();

    // TODO: Test:
    // x Build
    // x BuildConf
    // x As CommandEnum
    // x As Command text
    // x Args
    // x With File / Without File
    // x With Dir / Without Dir
    // x Test with all options on and see if it still works.
    // - Error cases

    // TODO: Make test console output look better with LogAction and Verbosity settings.

    [TestMethod]
    public void Test_Build_MainCase()
    {
        var opt = Opt();
       
        Assert(() => Build(opt));
    }
    
    [TestMethod]
    public void Test_Build_AsCommandEnum()
    {
        Assert(() => DotNet.Exe(build, Opt()));
    }

    [TestMethod]
    public void Test_Build_AsCommandText()
    {
        Assert(() => DotNet.Exe("build", Opt()));
    }

    [TestMethod]
    public void Test_Build_WithFile()
    {
        Assert(() => Build(Opt() with { File = CsProjFileName }));
    }

    [TestMethod]
    public void Test_Build_WithoutFile()
    {
        Assert(() => Build(Opt() with { File = "" }));
    }

    [TestMethod]
    public void Test_Build_WithDir()
    {
        Assert(() => Build(Opt() with { Dir = TempDir }));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithFullFilePath()
    {
        Assert(() => Build(Opt() with { Dir = "", File = CsprojPath }));
    }

    [TestMethod]
    public void Test_Build_WithoutDir_WithChDir() 
    {
        InTempDir(() => Assert(() => Build(Opt() with { Dir = "" })));
    }

    
    [TestMethod]
    public void Test_Build_Conf() 
    {
        AssertInitialState();

        var opt = Opt() with { BuildConf = "Release" };
        var result = Build(opt);

        AssertDllRelease();

        AssertResultOk(result);
        AssertContains(result, "release");
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> " + DllPathRelease);
    }

    [TestMethod]
    public void Test_Build_Args() 
    {
        AssertInitialState();

        var result = Build("--help", Opt());

        AssertResultOk(result);

        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);

        AssertContains(result, "Usage:");
        AssertContains(result, "dotnet build [<PROJECT | SOLUTION | FILE>...] [options]");
    }

    [TestMethod]
    public void Test_Build_AllOptsOn() 
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
            ParallelRestore = true,
            
            NodeReuse       = true,
            TimeOutSec      = 123,
                            
            Verbosity       = Detailed,
            LogFile         = logPath,
            BinLog          = binLogPath,
            LogAction       = Log
        };

        var result = Build("-low", allOpt);

        AssertDllRelease();
        AssertExists(logPath);
        AssertExists(binLogPath);

        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> " + DllPathRelease);
    }

    [TestMethod]
    public void Test_Build_ErrorCases() 
    {
        // E.g. call with no opt, leads to error no project or solution file in cur dir.
        //Build();

        // E.g. WithoutDir
    }

    // Helpers

    private void AssertInitialState()
    {
        AssertExists(AssetsFilePath);
        AssertNotExists(DllPath);
        AssertNotExists(DllPathRelease);
    }

    private void AssertResult(DotNetResult result)
    {
        AssertResultOk(result);
        AssertContains(result, "dotnet build");
        AssertContains(result, "build succeeded");
        AssertContains(result, ProjectName + " -> " + DllPath);
    }

    private void Assert(Func<DotNetResult> call)
    {
        AssertInitialState();

        DotNetResult result = call();

        AssertResult(result);

        AssertDll();
    }
}