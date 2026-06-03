namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetOptionsTests : DotNetTestHelper
{
    // Constructor

    [TestMethod]
    public void DotNetOptions_New_InitializedDefaults()
    {
        var opt = new DotNetOptions();
        
        // File
        AreEqual("",         opt.Dir            );
        AreEqual("",         opt.File           );

        // Build
        AreEqual("",         opt.BuildConf      );
        AreEqual("",         opt.Args           );

        // Restore
        IsFalse (            opt.AutoRestore    );
        IsFalse (            opt.ParallelRestore);

        // Process
        IsFalse (            opt.NodeReuse      );
        AreEqual(5 * 60,     opt.TimeOutSec     );

        // Logging
        AreEqual(Normal,     opt.Verbosity      );
        AreEqual("",         opt.LogFile        );
        AreEqual("",         opt.BinLog         );
        AreEqual(NullAction, opt.LogAction      );
    }

    [TestMethod]
    public void DotNetOptions_New_DefaultLog_CanBeInvoked()
    {
        var opt = new DotNetOptions();
        opt.LogAction("hello");
    }

    // TODO: Test:
    // - Args
    // - AutoRestore/ParallelRestore
    // - NodeReuse (how?), TimeOutSec
    //  Do not test: 
    // - Dir/File/BuildConf (already adequately tested)
    // - 
    // - Log options (logging tested separately).

    // LogFile

    [TestMethod]
    public void Test_DotNetOptions_LogFile()
    {
        var opt = BasicOpt() with { LogFile = GetLogFilePath() };
        Compile(opt);
        AssertExists(opt.LogFile);
    }

    [TestMethod]
    public void Test_DotNetOptions_NoLogFile()
    {
        var opt = BasicOpt() with { LogFile = "" };
        Compile(opt);
        AssertNotExists(opt.LogFile);
    }

    // BinLog

    [TestMethod]
    public void Test_DotNetOptions_BinLog()
    {
        var opt = BasicOpt() with { BinLog = GetBinLogFilePath() };
        Compile(opt);
        AssertExists(opt.BinLog);
    }

    [TestMethod]
    public void Test_DotNetOptions_NoBinLog()
    {
        var opt = BasicOpt() with { BinLog = "" };
        Compile(opt);
        AssertNotExists(opt.BinLog);
    }

    // Helpers

    private void Compile(DotNetOptions opt)
    {
        Restore(opt);
        var result = Build(opt);
        AssertResultOk(result);
    }
}
