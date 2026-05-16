namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetArgsTests
{
    [TestMethod]
    public void Constructor_WithCommandEnum_SetsCommandEnum()
    {
        var info = new DotNetArgs(restore);
        AreEqual(restore, info.CommandEnum);
        AreEqual("", info.Command);
        AreEqual("", info.ID);
        AreEqual("", info.Ver);
        AreEqual("", info.Args);
        IsFalse(info.IsRebuild);
    }

    [TestMethod]
    public void Constructor_WithCommandString_SetsCommand()
    {
        var info = new DotNetArgs("custom");
        AreEqual("custom", info.Command);
        AreEqual(default, info.CommandEnum);
    }

    [TestMethod]
    public void Constructor_Default_InitializesEmptyProperties()
    {
        var info = new DotNetArgs();
        AreEqual(default, info.CommandEnum);
        AreEqual("", info.Command);
        AreEqual("", info.ID);
        AreEqual("", info.Ver);
        AreEqual("", info.Args);
        IsFalse(info.IsRebuild);
    }
}
