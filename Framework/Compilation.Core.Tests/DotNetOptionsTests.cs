namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetOptionsTests
{
    [TestMethod]
    public void DotNetOptions_Constructor_InitializedDefaults()
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
    public void Constructor_DefaultLog_CanBeInvoked()
    {
        var opt = new DotNetOptions();
        opt.LogAction("hello");
    }
}
