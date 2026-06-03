namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetOptionsTests : DotNetTestHelper
{
    [TestMethod]
    public void DotNetOptions_New_InitializedDefaults()
    {
        var opt = new DotNetOptions();
        AreEqual ("",     opt.Dir        );
        AreEqual ("",     opt.File       );
        AreEqual ("",     opt.BuildConf  );
        AreEqual ("",     opt.Args       );
        AreEqual (Normal, opt.Verbosity  );
        IsFalse  (        opt.AutoRestore);
        AreEqual (5 * 60, opt.TimeOutSec );
        IsNotNull(        opt.LogAction        );
    }

    [TestMethod]
    public void DotNetOptions_New_DefaultLog_CanBeInvoked()
    {
        var opt = new DotNetOptions();
        opt.LogAction("hello");
    }


    [TestMethod]
    public void Test_DotNet_LogFile()
    {
        var opt = BasicOpt() with
        {
            LogFile = GetLogFilePath()
        };

        Compile(opt);

        AssertExists(opt.LogFile);
    }

    [TestMethod]
    public void Test_DotNet_BinLog()
    {
        var opt = BasicOpt() with
        {
            BinLog = GetBinLogFilePath()
        };

        Compile(opt);

        AssertExists(opt.BinLog);
    }

    private void Compile(DotNetOptions opt)
    {
        Restore(opt);
        var result = Build(opt);
        AssertResultOk(result);
    }
}
