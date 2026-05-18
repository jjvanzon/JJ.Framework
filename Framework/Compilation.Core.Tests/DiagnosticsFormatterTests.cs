namespace JJ.Framework.Compilation.Core.Tests;

using static DiagnosticsFormatterAccessor;

[TestClass]
public class DiagnosticsFormatterTests
{
    private const bool re = true;
    private static readonly DotNetCommandEnum[] _enumNullies = [ 0, default, undefined ];
    private static readonly string?[] _textNullies = [ null, default, "", " " ];
    private static readonly bool[] _boolNullies = [ default, false ];

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
    public void CommandDescriptor_CommandStringOnly()
    {
        foreach(var nully1 in _enumNullies)
        foreach(var nully2 in _boolNullies)
        {
            AreEqual("build",    CommandDescriptor(nully1, "build",    nully2));
            AreEqual("rebuild",  CommandDescriptor(nully1, "rebuild",  nully2));
            AreEqual("debuild",  CommandDescriptor(nully1, "debuild",  nully2));
            AreEqual("whatever", CommandDescriptor(nully1, "whatever", nully2));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumOnly()
    {
        foreach (var nully1 in _textNullies)
        foreach (var nully2 in _boolNullies)
        {
            AreEqual("build",            CommandDescriptor(build,            nully1, nully2));
            AreEqual("rebuild",          CommandDescriptor(rebuild,          nully1, nully2));
            AreEqual("msbuild",          CommandDescriptor(msbuild,          nully1, nully2));
            AreEqual("msrebuild",        CommandDescriptor(msrebuild,        nully1, nully2));
            AreEqual("restore",          CommandDescriptor(restore,          nully1, nully2));
            AreEqual("installpackage",   CommandDescriptor(installpackage,   nully1, nully2));
            AreEqual("uninstallpackage", CommandDescriptor(uninstallpackage, nully1, nully2));
        }
    }

    [TestMethod]
    public void CommandDescriptor_CommandStringWithReFlag()
    {
        foreach(var nully in _enumNullies)
        {
            AreEqual("(re)build",    CommandDescriptor(nully, "build",    re));
            AreEqual("(re)msbuild",  CommandDescriptor(nully, "msbuild",  re));
            AreEqual("(re)restore",  CommandDescriptor(nully, "restore",  re));
            AreEqual("(re)add",      CommandDescriptor(nully, "add",      re));
            AreEqual("(re)remove",   CommandDescriptor(nully, "remove",   re));
            AreEqual("(re)whatever", CommandDescriptor(nully, "whatever", re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumShowsReFlag_EvenWhenMisapplied()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("(re)build",            CommandDescriptor(build,            nully, re));
            AreEqual("(re)msbuild",          CommandDescriptor(msbuild,          nully, re));
            AreEqual("(re)restore",          CommandDescriptor(restore,          nully, re)); // Misapplied (should still show as diagnostics)
            AreEqual("(re)installpackage",   CommandDescriptor(installpackage,   nully, re));
            AreEqual("(re)uninstallpackage", CommandDescriptor(uninstallpackage, nully, re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumAndReFlag_AlreadyInThere()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("rebuild",   CommandDescriptor(rebuild,   nully, re));
            AreEqual("msrebuild", CommandDescriptor(msrebuild, nully, re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumAndText()
    {
        AreEqual("build / blah",               CommandDescriptor(build,            "blah",    default));
        AreEqual("rebuild / blah",             CommandDescriptor(rebuild,          "blah",    default));
        AreEqual("msbuild / blah",             CommandDescriptor(msbuild,          "blah",    default));
        AreEqual("msrebuild / blah",           CommandDescriptor(msrebuild,        "blah",    default));
        AreEqual("restore / blah",             CommandDescriptor(restore,          "blah",    default));
        AreEqual("installpackage / blah",      CommandDescriptor(installpackage,   "blah",    default));
        AreEqual("uninstallpackage / blah",    CommandDescriptor(uninstallpackage, "blah",    default));
                                                                                            
        AreEqual("build",                      CommandDescriptor(build,            "build",   default));
        AreEqual("rebuild / build",            CommandDescriptor(rebuild,          "build",   default));
        AreEqual("msbuild / build",            CommandDescriptor(msbuild,          "build",   default));
        AreEqual("msrebuild / build",          CommandDescriptor(msrebuild,        "build",   default));
        AreEqual("restore / build",            CommandDescriptor(restore,          "build",   default));
        AreEqual("installpackage / build",     CommandDescriptor(installpackage,   "build",   default));
        AreEqual("uninstallpackage / build",   CommandDescriptor(uninstallpackage, "build",   default));
        
        AreEqual("build / rebuild",            CommandDescriptor(build,            "rebuild", default));
        AreEqual("rebuild",                    CommandDescriptor(rebuild,          "rebuild", default));
        AreEqual("msbuild / rebuild",          CommandDescriptor(msbuild,          "rebuild", default));
        AreEqual("msrebuild / rebuild",        CommandDescriptor(msrebuild,        "rebuild", default));
        AreEqual("restore / rebuild",          CommandDescriptor(restore,          "rebuild", default));
        AreEqual("installpackage / rebuild",   CommandDescriptor(installpackage,   "rebuild", default));
        AreEqual("uninstallpackage / rebuild", CommandDescriptor(uninstallpackage, "rebuild", default));
        
        AreEqual("build / msbuild",            CommandDescriptor(build,            "msbuild", default));
        AreEqual("rebuild / msbuild",          CommandDescriptor(rebuild,          "msbuild", default));
        AreEqual("msbuild",                    CommandDescriptor(msbuild,          "msbuild", default));
        AreEqual("msrebuild / msbuild",        CommandDescriptor(msrebuild,        "msbuild", default));
        AreEqual("restore / msbuild",          CommandDescriptor(restore,          "msbuild", default));
        AreEqual("installpackage / msbuild",   CommandDescriptor(installpackage,   "msbuild", default));
        AreEqual("uninstallpackage / msbuild", CommandDescriptor(uninstallpackage, "msbuild", default));
        
        AreEqual("build / add",                CommandDescriptor(build,            "add",     default));
        AreEqual("rebuild / add",              CommandDescriptor(rebuild,          "add",     default));
        AreEqual("msbuild / add",              CommandDescriptor(msbuild,          "add",     default));
        AreEqual("msrebuild / add",            CommandDescriptor(msrebuild,        "add",     default));
        AreEqual("restore / add",              CommandDescriptor(restore,          "add",     default));
        AreEqual("installpackage / add",       CommandDescriptor(installpackage,   "add",     default));
        AreEqual("uninstallpackage / add",     CommandDescriptor(uninstallpackage, "add",     default));
        
        AreEqual("build / restore",            CommandDescriptor(build,            "restore", default));
        AreEqual("rebuild / restore",          CommandDescriptor(rebuild,          "restore", default));
        AreEqual("msbuild / restore",          CommandDescriptor(msbuild,          "restore", default));
        AreEqual("msrebuild / restore",        CommandDescriptor(msrebuild,        "restore", default));
        AreEqual("restore",                    CommandDescriptor(restore,          "restore", default));
        AreEqual("installpackage / restore",   CommandDescriptor(installpackage,   "restore", default));
        AreEqual("uninstallpackage / restore", CommandDescriptor(uninstallpackage, "restore", default));
        
        AreEqual("build / remove",             CommandDescriptor(build,            "remove",  default));
        AreEqual("rebuild / remove",           CommandDescriptor(rebuild,          "remove",  default));
        AreEqual("msbuild / remove",           CommandDescriptor(msbuild,          "remove",  default));
        AreEqual("msrebuild / remove",         CommandDescriptor(msrebuild,        "remove",  default));
        AreEqual("restore / remove",           CommandDescriptor(restore,          "remove",  default));
        AreEqual("installpackage / remove",    CommandDescriptor(installpackage,   "remove",  default));
        AreEqual("uninstallpackage / remove",  CommandDescriptor(uninstallpackage, "remove",  default));
    }

    // TODO: Split the normaler cases from the weirder ones.

    [TestMethod]
    public void CommandDescriptor_WithSlashText_WithReFlag()
    {
        AreEqual("build / (re)blah",               CommandDescriptor(build,            "blah",    re));
        AreEqual("rebuild / blah",                 CommandDescriptor(rebuild,          "blah",    re)); // re not mentioned; already implied
        AreEqual("msbuild / (re)blah",             CommandDescriptor(msbuild,          "blah",    re));
        AreEqual("msrebuild / blah",               CommandDescriptor(msrebuild,        "blah",    re)); // re not mentioned; already implied
        AreEqual("restore / (re)blah",             CommandDescriptor(restore,          "blah",    re));
        AreEqual("installpackage / (re)blah",      CommandDescriptor(installpackage,   "blah",    re));
        AreEqual("uninstallpackage / (re)blah",    CommandDescriptor(uninstallpackage, "blah",    re));
                                
        AreEqual("(re)build",                      CommandDescriptor(build,            "build",   re));
        AreEqual("rebuild / build",                CommandDescriptor(rebuild,          "build",   re));
        AreEqual("msbuild / (re)build",            CommandDescriptor(msbuild,          "build",   re));
        AreEqual("msrebuild / build",              CommandDescriptor(msrebuild,        "build",   re));
        AreEqual("restore / (re)build",            CommandDescriptor(restore,          "build",   re));
        AreEqual("installpackage / (re)build",     CommandDescriptor(installpackage,   "build",   re));
        AreEqual("uninstallpackage / (re)build",   CommandDescriptor(uninstallpackage, "build",   re));
        
        // Reallly weird (re) flags, but the data is inconsistent. And rebuild isn't even a 
        AreEqual("build / (re)rebuild",            CommandDescriptor(build,            "rebuild", re));
        AreEqual("rebuild",                        CommandDescriptor(rebuild,          "rebuild", re)); // TODO: `rebuild / rebuild` would make sense here, since 2nd rebuild is weird data.
        AreEqual("msbuild / (re)rebuild",          CommandDescriptor(msbuild,          "rebuild", re));
        AreEqual("msrebuild / rebuild",            CommandDescriptor(msrebuild,        "rebuild", re));
        AreEqual("restore / (re)rebuild",          CommandDescriptor(restore,          "rebuild", re));
        AreEqual("installpackage / (re)rebuild",   CommandDescriptor(installpackage,   "rebuild", re));
        AreEqual("uninstallpackage / (re)rebuild", CommandDescriptor(uninstallpackage, "rebuild", re));
        
        AreEqual("build / (re)msbuild",            CommandDescriptor(build,            "msbuild", re));
        AreEqual("rebuild / msbuild",              CommandDescriptor(rebuild,          "msbuild", re));
        AreEqual("(re)msbuild",                    CommandDescriptor(msbuild,          "msbuild", re));
        AreEqual("msrebuild / msbuild",            CommandDescriptor(msrebuild,        "msbuild", re));
        AreEqual("restore / (re)msbuild",          CommandDescriptor(restore,          "msbuild", re));
        AreEqual("installpackage / (re)msbuild",   CommandDescriptor(installpackage,   "msbuild", re));
        AreEqual("uninstallpackage / (re)msbuild", CommandDescriptor(uninstallpackage, "msbuild", re));
        
        AreEqual("build / (re)add",                CommandDescriptor(build,            "add",     re));
        AreEqual("rebuild / add",                  CommandDescriptor(rebuild,          "add",     re));
        AreEqual("msbuild / (re)add",              CommandDescriptor(msbuild,          "add",     re));
        AreEqual("msrebuild / add",                CommandDescriptor(msrebuild,        "add",     re));
        AreEqual("restore / (re)add",              CommandDescriptor(restore,          "add",     re));
        AreEqual("installpackage / (re)add",       CommandDescriptor(installpackage,   "add",     re));
        AreEqual("uninstallpackage / (re)add",     CommandDescriptor(uninstallpackage, "add",     re));
        
        AreEqual("build / (re)restore",            CommandDescriptor(build,            "restore", re));
        AreEqual("rebuild / restore",              CommandDescriptor(rebuild,          "restore", re));
        AreEqual("msbuild / (re)restore",          CommandDescriptor(msbuild,          "restore", re));
        AreEqual("msrebuild / restore",            CommandDescriptor(msrebuild,        "restore", re));
        AreEqual("(re)restore",                    CommandDescriptor(restore,          "restore", re));
        AreEqual("installpackage / (re)restore",   CommandDescriptor(installpackage,   "restore", re));
        AreEqual("uninstallpackage / (re)restore", CommandDescriptor(uninstallpackage, "restore", re));
        
        AreEqual("build / (re)remove",             CommandDescriptor(build,            "remove",  re));
        AreEqual("rebuild / remove",               CommandDescriptor(rebuild,          "remove",  re));
        AreEqual("msbuild / (re)remove",           CommandDescriptor(msbuild,          "remove",  re));
        AreEqual("msrebuild / remove",             CommandDescriptor(msrebuild,        "remove",  re));
        AreEqual("restore / (re)remove",           CommandDescriptor(restore,          "remove",  re));
        AreEqual("installpackage / (re)remove",    CommandDescriptor(installpackage,   "remove",  re));
        AreEqual("uninstallpackage / (re)remove",  CommandDescriptor(uninstallpackage, "remove",  re));
    }

    /*
    // TODO: More cases where Enum and Text are same (so with the re flag then).

    // TODO: More elaborate
    [TestMethod]
    public void CommandDescriptor_WithReCommandEnumAndReFlag()
        => AreEqual("rebuild", CommandDescriptor(rebuild, default, true));

    // TODO: More elaborate
    [TestMethod]
    public void CommandDescriptor_CommandSameAsEnum_OnlyShowsOnlyOne()
        => AreEqual("build", CommandDescriptor(build, "build", default));
    */

    [TestMethod]
    public void CommandDescriptor_Nullies_ShowAsNoCommand()
    {
        foreach (var nully1 in _enumNullies)
        foreach (var nully2 in _textNullies)
        foreach (var nully3 in _boolNullies)
        {
            AreEqual("<no command>", CommandDescriptor(nully1, nully2, nully3));
        }
    }

    [TestMethod]
    public void CommandDescriptor_IsRebuildAndNullies_ShowsAsReWithNoCommand()
    {
        foreach (var nully1 in _enumNullies)
        foreach (var nully2 in _textNullies)
        {
            AreEqual("(re-)<no command>", CommandDescriptor(nully1, nully2, re));
        }
    }

    // IDVerDescriptor

    [TestMethod]
    public void IDVerDescriptor_IDAndVer()
        => AreEqual("MyPkg 1.0.0", IDVerDescriptor("MyPkg", "1.0.0"));

    [TestMethod]
    public void IDVerDescriptor_OnlyID()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("MyPkg", IDVerDescriptor("MyPkg", nully));
        }
    }

    [TestMethod]
    public void IDVerDescriptor_OnlyVer()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("1.0.0", IDVerDescriptor(nully, "1.0.0"));
        }
    }

    [TestMethod]
    public void IDVerDescriptor_NullyCases()
    {
        foreach (var nully1 in _textNullies)
        foreach (var nully2 in _textNullies)
        {
            AreEqual("", IDVerDescriptor(nully1, nully2));
        }
    }

    // ArgsDescriptor

    [TestMethod]
    public void ArgsDescriptor_FullArgsDoesNotContainArgs_ReturnsBothWithPipe()
        => AreEqual("--output ./out | --no-restore", ArgsDescriptor("--output ./out", "--no-restore"));

    [TestMethod]
    public void ArgsDescriptor_NullyArgs()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("build --output ./out", ArgsDescriptor(nully, "build --output ./out"));
        }
    }

    [TestMethod]
    public void ArgsDescriptor_NullyFullArgs()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("--output ./out", ArgsDescriptor("--output ./out", nully));
        }
    }

    [TestMethod]
    public void ArgsDescriptor_ArgsInFullArgs_ReturnsOnlyFullArgs()
        => AreEqual(
            "-f net8.0 --output ./out  --no-restore", 
            ArgsDescriptor("--output ./out", "  -f net8.0 --output ./out  --no-restore"));

    [TestMethod]
    public void ArgsDescriptor_NullyCases()
    {
        foreach (var nully1 in _textNullies)
        foreach (var nully2 in _textNullies)
        {
            AreEqual("", ArgsDescriptor(nully1, nully2));
        }
    }
}
