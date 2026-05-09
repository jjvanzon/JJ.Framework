namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetInfoTests
{
    [TestMethod]
    public void Constructor_WithCommandEnum_SetsCommandEnum()
    {
        var info = new DotNetInfo(restore);

        AreEqual(restore, info.CommandEnum);
        AreEqual("", info.Command);
        IsFalse(info.IsRebuild);
        AreEqual("", info.ID);
        AreEqual("", info.Ver);
        AreEqual("", info.Args);
    }

    [TestMethod]
    public void Constructor_WithCommandString_SetsCommand()
    {
        var info = new DotNetInfo("custom");

        AreEqual("custom", info.Command);
        AreEqual(default, info.CommandEnum);
    }

    [TestMethod]
    public void Constructor_Default_InitializesEmptyProperties()
    {
        var info = new DotNetInfo();

        AreEqual(default, info.CommandEnum);
        AreEqual("", info.Command);
        IsFalse(info.IsRebuild);
        AreEqual("", info.ID);
        AreEqual("", info.Ver);
        AreEqual("", info.Args);
    }
}
