namespace JJ.Framework.Compilation.Core.Tests;

using static DiagnosticsFormatterAccessor;

[TestClass]
public class DiagnosticsFormatterTests
{
    /*
    // Descriptor (public entry point)

    [TestMethod]
    public void Descriptor_NullArgs_ReturnsNullPlaceholder()
        => AreEqual("<DotNetArgs=null>", Descriptor(null));

    [TestMethod]
    public void Descriptor_CommandAndIDVer_JoinedWithSpace()
    {
        var args = new DotNetArgs(build) { ID = "MyPkg", Ver = "1.0.0" };
        AreEqual("build MyPkg 1.0.0", Descriptor(args));
    }

    [TestMethod]
    public void Descriptor_CommandAndArgs_JoinedWithPipe()
    {
        var acc = new DotNetArgsAccessor(build) { FullArgs = "build --nologo" };
        AreEqual("build | build --nologo", Descriptor(acc.Obj));
    }

    [TestMethod]
    public void Descriptor_CommandIDVerAndArgs_AllThreeParts()
    {
        var acc = new DotNetArgsAccessor(build) { FullArgs = "build \"Pkg\" 2.0 --nologo" };
        acc.Obj.ID  = "Pkg";
        acc.Obj.Ver = "2.0";
        AreEqual("build Pkg 2.0 | build \"Pkg\" 2.0 --nologo", Descriptor(acc.Obj));
    }

    [TestMethod]
    public void Descriptor_NoCommandNoIDVerNoArgs_OnlyNoCommandText()
    {
        var args = new DotNetArgs();
        AreEqual("<no command>", Descriptor(args));
    }
    */

    // CommandDescriptor

    [TestMethod]
    public void CommandDescriptor_Nullies_ShowAsNoCommand()
    {
        AreEqual("<no command>", CommandDescriptor(default,   default, default));
        AreEqual("<no command>", CommandDescriptor(default,   default, false  ));
        AreEqual("<no command>", CommandDescriptor(default,   null,    default));
        AreEqual("<no command>", CommandDescriptor(default,   null,    false  ));
        AreEqual("<no command>", CommandDescriptor(default,   "",      default));
        AreEqual("<no command>", CommandDescriptor(default,   "",      false  ));
        AreEqual("<no command>", CommandDescriptor(default,   " ",     default));
        AreEqual("<no command>", CommandDescriptor(default,   " ",     false  ));
        AreEqual("<no command>", CommandDescriptor(undefined, default, default));
        AreEqual("<no command>", CommandDescriptor(undefined, default, false  ));
        AreEqual("<no command>", CommandDescriptor(undefined, null,    default));
        AreEqual("<no command>", CommandDescriptor(undefined, null,    false  ));
        AreEqual("<no command>", CommandDescriptor(undefined, "",      default));
        AreEqual("<no command>", CommandDescriptor(undefined, "",      false  ));
        AreEqual("<no command>", CommandDescriptor(undefined, " ",     default));
        AreEqual("<no command>", CommandDescriptor(undefined, " ",     false  ));
    }

    [TestMethod]
    public void CommandDescriptor_IsRebuildAndNullies_ShowsAsReWithNoCommand()
    {
        AreEqual("(re-)<no command>", CommandDescriptor(default,   default, true));
        AreEqual("(re-)<no command>", CommandDescriptor(default,   null,    true));
        AreEqual("(re-)<no command>", CommandDescriptor(default,   "",      true));
        AreEqual("(re-)<no command>", CommandDescriptor(default,   " ",     true));
        AreEqual("(re-)<no command>", CommandDescriptor(undefined, default, true));
        AreEqual("(re-)<no command>", CommandDescriptor(undefined, null,    true));
        AreEqual("(re-)<no command>", CommandDescriptor(undefined, "",      true));
        AreEqual("(re-)<no command>", CommandDescriptor(undefined, " ",     true));
    }

    [TestMethod]
    public void CommandDescriptor_CommandStringOnly()
    {
        AreEqual("build",    CommandDescriptor(default,   "build",    default));
        AreEqual("build",    CommandDescriptor(default,   "build",    false  ));
        AreEqual("build",    CommandDescriptor(undefined, "build",    default));
        AreEqual("build",    CommandDescriptor(undefined, "build",    false  ));
        AreEqual("rebuild",  CommandDescriptor(default,   "rebuild",  default));
        AreEqual("rebuild",  CommandDescriptor(default,   "rebuild",  false  ));
        AreEqual("rebuild",  CommandDescriptor(undefined, "rebuild",  default));
        AreEqual("rebuild",  CommandDescriptor(undefined, "rebuild",  false  ));
        AreEqual("debuild",  CommandDescriptor(default,   "debuild",  default));
        AreEqual("debuild",  CommandDescriptor(default,   "debuild",  false  ));
        AreEqual("debuild",  CommandDescriptor(undefined, "debuild",  default));
        AreEqual("debuild",  CommandDescriptor(undefined, "debuild",  false  ));
        AreEqual("whatever", CommandDescriptor(default,   "whatever", default));
        AreEqual("whatever", CommandDescriptor(default,   "whatever", false  ));
        AreEqual("whatever", CommandDescriptor(undefined, "whatever", default));
        AreEqual("whatever", CommandDescriptor(undefined, "whatever", false  ));
    }

    [TestMethod]
    public void CommandDescriptor_CommandStringWithReFlag()
    {
        AreEqual("(re)whatever", CommandDescriptor(undefined, "whatever", true));
    }

    /*

    [TestMethod]
    public void CommandDescriptor_WithEnumNoCommandNoRebuild_ReturnsEnum()
        => AreEqual("build", CommandDescriptor(build, null, false));

    [TestMethod]
    public void CommandDescriptor_WithEnumNoCommandWithRebuild_ReturnsReEnum()
        => AreEqual("(re)build", CommandDescriptor(build, null, true));

    [TestMethod]
    public void CommandDescriptor_WithEnumWithCommandNoRebuild_ReturnsEnumSlashCommand()
        => AreEqual("build/custom", CommandDescriptor(build, "custom", false));

    [TestMethod]
    public void CommandDescriptor_WithEnumWithCommandWithRebuild_ReturnsEnumSlashReCommand()
        => AreEqual("build/(re)custom", CommandDescriptor(build, "custom", true));
    */

    [TestMethod]
    public void CommandDescriptor_WithReCommandEnumAndIsRebuild()
        => AreEqual("rebuild", CommandDescriptor(rebuild, default, true));

    [TestMethod]
    public void CommandDescriptor_CommandSameAsEnum_OnlyShowsOnlyOne()
        => AreEqual("build", CommandDescriptor(build, "build", default));

    // IDVerDescriptor

    [TestMethod]
    public void IDVerDescriptor_IDAndVer()
        => AreEqual("MyPkg 1.0.0", IDVerDescriptor("MyPkg", "1.0.0"));

    [TestMethod]
    public void IDVerDescriptor_OnlyID()
    {
        AreEqual("MyPkg", IDVerDescriptor("MyPkg", null));
        AreEqual("MyPkg", IDVerDescriptor("MyPkg", ""  ));
        AreEqual("MyPkg", IDVerDescriptor("MyPkg", " " ));
    }

    [TestMethod]
    public void IDVerDescriptor_OnlyVer()
    {
        AreEqual("1.0.0", IDVerDescriptor(null, "1.0.0"));
        AreEqual("1.0.0", IDVerDescriptor("",   "1.0.0"));
        AreEqual("1.0.0", IDVerDescriptor(" ",  "1.0.0"));
    }

    [TestMethod]
    public void IDVerDescriptor_NullyCases()
    {
        AreEqual("", IDVerDescriptor(null, null));
        AreEqual("", IDVerDescriptor(null, ""  ));
        AreEqual("", IDVerDescriptor(null, " " ));
        AreEqual("", IDVerDescriptor("",   null));
        AreEqual("", IDVerDescriptor("",   ""  ));
        AreEqual("", IDVerDescriptor("",   " " ));
        AreEqual("", IDVerDescriptor(" ",  null));
        AreEqual("", IDVerDescriptor(" ",  ""  ));
        AreEqual("", IDVerDescriptor(" ",  " " ));
    }

    // ArgsDescriptor

    [TestMethod]
    public void ArgsDescriptor_FullArgsDoesNotContainArgs_ReturnsBothWithPipe()
        => AreEqual("--output ./out | --no-restore", ArgsDescriptor("--output ./out", "--no-restore"));

    [TestMethod]
    public void ArgsDescriptor_NullyArgs()
    {
        AreEqual("build --output ./out", ArgsDescriptor(null, "build --output ./out"));
        AreEqual("build --output ./out", ArgsDescriptor("",   "build --output ./out"));
        AreEqual("build --output ./out", ArgsDescriptor(" ",  "build --output ./out"));
    }

    [TestMethod]
    public void ArgsDescriptor_NullyFullArgs()
    {
        AreEqual("--output ./out", ArgsDescriptor("--output ./out", null));
        AreEqual("--output ./out", ArgsDescriptor("--output ./out", ""  ));
        AreEqual("--output ./out", ArgsDescriptor("--output ./out", " " ));
    }

    [TestMethod]
    public void ArgsDescriptor_ArgsInFullArgs_ReturnsOnlyFullArgs()
        => AreEqual(
            "-f net8.0 --output ./out  --no-restore", 
            ArgsDescriptor("--output ./out", "  -f net8.0 --output ./out  --no-restore"));

    [TestMethod]
    public void ArgsDescriptor_NullyCases()
    {
        AreEqual("", ArgsDescriptor(null, null));
        AreEqual("", ArgsDescriptor(null, ""  ));
        AreEqual("", ArgsDescriptor(null, " " ));
        AreEqual("", ArgsDescriptor("",   null));
        AreEqual("", ArgsDescriptor("",   ""  ));
        AreEqual("", ArgsDescriptor("",   " " ));
        AreEqual("", ArgsDescriptor(" ",  null));
        AreEqual("", ArgsDescriptor(" ",  ""  ));
        AreEqual("", ArgsDescriptor(" ",  " " ));
    }
}
