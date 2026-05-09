namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetOptionsTests
{
    [TestMethod]
    public void Constructor_Default_InitializesExpectedDefaults()
    {
        var options = new DotNetOptions();

        AreEqual("", options.Dir);
        AreEqual("", options.File);
        AreEqual("", options.BuildConf);
        AreEqual("", options.Args);
        AreEqual(DotNetVerbosity.Normal, options.Verbosity);
        IsFalse(options.AutoRestore);
        AreEqual(180, options.TimeOutSec);
        IsNotNull(options.Log);
    }

    [TestMethod]
    public void Constructor_DefaultLog_CanBeInvoked()
    {
        var options = new DotNetOptions();

        options.Log("hello");
    }
}
