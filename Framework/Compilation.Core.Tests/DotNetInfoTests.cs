namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetInfoTests
{
    [TestMethod]
    public void Constructor_WithCommandEnum_SetsCommandEnum()
    {
        var info = new DotNetArgsAccessor(restore);
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
        var info = new DotNetArgsAccessor("custom");
        AreEqual("custom", info.Command);
        AreEqual(default, info.CommandEnum);
    }

    [TestMethod]
    public void Constructor_Default_InitializesEmptyProperties()
    {
        var info = new DotNetArgsAccessor();
        AreEqual(default, info.CommandEnum);
        AreEqual("", info.Command);
        AreEqual("", info.ID);
        AreEqual("", info.Ver);
        AreEqual("", info.Args);
        IsFalse(info.IsRebuild);
    }
}
