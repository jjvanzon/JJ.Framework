namespace JJ.Framework.Compilation.Core.Tests.PrimitivesTests;

[TestClass]
public class DotNetArgsTests
{
    [TestMethod]
    public void DotNetArgs_New_WithCommandEnum()
    {
        var args = new DotNetArgsAccessor(restore);
        AreEqual(restore, args.CommandEnum);
        AreEqual("", args.Command);
        AreEqual("", args.ID);
        AreEqual("", args.Ver);
        AreEqual("", args.Args);
        AreEqual("", args.FullArgs);
        IsFalse(args.IsRebuild);
    }

    [TestMethod]
    public void DotNetArgs_New_WithCommandString()
    {
        var args = new DotNetArgsAccessor("custom");
        AreEqual("custom", args.Command);
        AreEqual(default, args.CommandEnum);
    }

    [TestMethod]
    public void DotNetArgs_New_Default_InitializesEmptyProperties()
    {
        var args = new DotNetArgsAccessor();
        AreEqual(default, args.CommandEnum);
        AreEqual("", args.Command);
        AreEqual("", args.ID);
        AreEqual("", args.Ver);
        AreEqual("", args.Args);
        AreEqual("", args.FullArgs);
        IsFalse(args.IsRebuild);
    }
}
