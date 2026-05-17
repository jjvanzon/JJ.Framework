namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetArgsTests
{
    [TestMethod]
    public void Constructor_WithCommandEnum_SetsCommandEnum()
    {
        var args = new DotNetArgs(restore);
        AreEqual(restore, args.CommandEnum);
        AreEqual("", args.Command);
        AreEqual("", args.ID);
        AreEqual("", args.Ver);
        AreEqual("", args.Args);
        IsFalse(args.IsRebuild);
    }

    [TestMethod]
    public void Constructor_WithCommandString_SetsCommand()
    {
        var args = new DotNetArgs("custom");
        AreEqual("custom", args.Command);
        AreEqual(default, args.CommandEnum);
    }

    [TestMethod]
    public void Constructor_Default_InitializesEmptyProperties()
    {
        var args = new DotNetArgs();
        AreEqual(default, args.CommandEnum);
        AreEqual("", args.Command);
        AreEqual("", args.ID);
        AreEqual("", args.Ver);
        AreEqual("", args.Args);
        IsFalse(args.IsRebuild);
    }
}
