namespace JJ.Framework.Compilation.Core.Tests;

using static DiagnosticsFormatterAccessor;

[TestClass]
public class DiagnosticsFormatterTests
{
    private const bool re = true;
    private static readonly DotNetCommandEnum[] _enumNullies = [ 0, default, undefined ];
    private static readonly string?[] _textNullies = [ null, default, "", " " ];
    private static readonly bool[] _boolNullies = [ default, false ];

    // DotNetArgs

    [TestMethod]
    public void DotNetArgs_Descriptor_NullArgs()
        => AreEqual("<DotNetArgs=null>", Descriptor(null));

    [TestMethod]
    public void DotNetArgs_Descriptor_EnumAndCommandText_MSRebuild()
    {
        var args = new DotNetArgsAccessor(msrebuild) { Command = "msbuild" }.Obj;
        AreEqual("msrebuild / msbuild", Descriptor(args));
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_EnumAndFullArgs_Build()
    {
        var args = new DotNetArgsAccessor(build) { FullArgs = "build --no-restore" }.Obj;
        AreEqual("build | build --no-restore", Descriptor(args));
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_Rebuild_Enum_CommandText_IsRebuild_FullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = rebuild, 
            Command = "build", 
            IsRebuild = true, 
            FullArgs = "build --no-incremental" 
        };

        AreEqual("rebuild / build | build --no-incremental", Descriptor(args.Obj));
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_CommandEnum_FullArgsAndArgs()
    {
        var args = new DotNetArgsAccessor
        {
            CommandEnum = restore,
            Args = "--bogus-arg",
            FullArgs = "--dummy-arg"
        };
        AreEqual("restore | --bogus-arg | --dummy-arg", Descriptor(args.Obj));
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_FullContainsArgs()
    {
        // TODO
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandEnumAndIDVer()
    {
        var args = new DotNetArgsAccessor(installpackage) { ID = "JJ.Framework.Common", Ver = "1.0.0" }.Obj;
        AreEqual("installpackage JJ.Framework.Common 1.0.0", Descriptor(args));
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandTextAndIDVer()
    {
        var args = new DotNetArgsAccessor("add") { ID = "JJ.Framework.Common", Ver = "1.0.0" }.Obj;
        AreEqual("add JJ.Framework.Common 1.0.0", Descriptor(args));
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandTextAndID()
    {
        var args = new DotNetArgsAccessor("remove") { ID = "JJ.Framework.Common" }.Obj;
        AreEqual("remove JJ.Framework.Common", Descriptor(args));
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandEnumTextIDVerAndArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = installpackage, 
            Command = "add", 
            ID = "JJ.Framework.Common", 
            Ver = "1.0.0",
            Args = "--no-cache"
        }.Obj;
        AreEqual("installpackage / add JJ.Framework.Common 1.0.0 | --no-cache", Descriptor(args));
    }

    /*

    [TestMethod]
    public void Descriptor_NoCommandNoIDVerNoArgs_OnlyNoCommandText()
    {
        var args = new DotNetArgs();
        AreEqual("<no command>", Descriptor(args));
    }
    */

    // CommandDescriptor

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
    public void CommandDescriptor_CommandStringOnly()
    {
        foreach(var nully1 in _enumNullies)
        foreach(var nully2 in _boolNullies)
        {
            AreEqual("build",     CommandDescriptor(nully1, "build",     nully2));
            AreEqual("rebuild",   CommandDescriptor(nully1, "rebuild",   nully2)); // Unrealistic command string (should be "build" + re-flag)
            AreEqual("msbuild",   CommandDescriptor(nully1, "msbuild",   nully2));
            AreEqual("msrebuild", CommandDescriptor(nully1, "msrebuild", nully2)); // Unrealistic command string (should be "msbuild" + re-flag)
            AreEqual("restore",   CommandDescriptor(nully1, "restore",   nully2));
            AreEqual("add",       CommandDescriptor(nully1, "add",       nully2));
            AreEqual("remove",    CommandDescriptor(nully1, "remove",    nully2));
            AreEqual("debuild",   CommandDescriptor(nully1, "debuild",   nully2)); // Unrealistic command string
            AreEqual("whatever",  CommandDescriptor(nully1, "whatever",  nully2)); // Unrealistic command string
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumAndText()
    {
        foreach (var nully in _boolNullies)
        {
            AreEqual("build / blah",               CommandDescriptor(build,            "blah",    nully));
            AreEqual("rebuild / blah",             CommandDescriptor(rebuild,          "blah",    nully));
            AreEqual("msbuild / blah",             CommandDescriptor(msbuild,          "blah",    nully));
            AreEqual("msrebuild / blah",           CommandDescriptor(msrebuild,        "blah",    nully));
            AreEqual("restore / blah",             CommandDescriptor(restore,          "blah",    nully));
            AreEqual("installpackage / blah",      CommandDescriptor(installpackage,   "blah",    nully));
            AreEqual("uninstallpackage / blah",    CommandDescriptor(uninstallpackage, "blah",    nully));
                                                                                                
            AreEqual("build",                      CommandDescriptor(build,            "build",   nully));
            AreEqual("rebuild / build",            CommandDescriptor(rebuild,          "build",   nully));
            AreEqual("msbuild / build",            CommandDescriptor(msbuild,          "build",   nully));
            AreEqual("msrebuild / build",          CommandDescriptor(msrebuild,        "build",   nully));
            AreEqual("restore / build",            CommandDescriptor(restore,          "build",   nully));
            AreEqual("installpackage / build",     CommandDescriptor(installpackage,   "build",   nully));
            AreEqual("uninstallpackage / build",   CommandDescriptor(uninstallpackage, "build",   nully));
            
            AreEqual("build / rebuild",            CommandDescriptor(build,            "rebuild", nully));
            AreEqual("rebuild / rebuild",          CommandDescriptor(rebuild,          "rebuild", nully));
            AreEqual("msbuild / rebuild",          CommandDescriptor(msbuild,          "rebuild", nully));
            AreEqual("msrebuild / rebuild",        CommandDescriptor(msrebuild,        "rebuild", nully));
            AreEqual("restore / rebuild",          CommandDescriptor(restore,          "rebuild", nully));
            AreEqual("installpackage / rebuild",   CommandDescriptor(installpackage,   "rebuild", nully));
            AreEqual("uninstallpackage / rebuild", CommandDescriptor(uninstallpackage, "rebuild", nully));
            
            AreEqual("build / msbuild",            CommandDescriptor(build,            "msbuild", nully));
            AreEqual("rebuild / msbuild",          CommandDescriptor(rebuild,          "msbuild", nully));
            AreEqual("msbuild",                    CommandDescriptor(msbuild,          "msbuild", nully));
            AreEqual("msrebuild / msbuild",        CommandDescriptor(msrebuild,        "msbuild", nully));
            AreEqual("restore / msbuild",          CommandDescriptor(restore,          "msbuild", nully));
            AreEqual("installpackage / msbuild",   CommandDescriptor(installpackage,   "msbuild", nully));
            AreEqual("uninstallpackage / msbuild", CommandDescriptor(uninstallpackage, "msbuild", nully));
            
            AreEqual("build / add",                CommandDescriptor(build,            "add",     nully));
            AreEqual("rebuild / add",              CommandDescriptor(rebuild,          "add",     nully));
            AreEqual("msbuild / add",              CommandDescriptor(msbuild,          "add",     nully));
            AreEqual("msrebuild / add",            CommandDescriptor(msrebuild,        "add",     nully));
            AreEqual("restore / add",              CommandDescriptor(restore,          "add",     nully));
            AreEqual("installpackage / add",       CommandDescriptor(installpackage,   "add",     nully));
            AreEqual("uninstallpackage / add",     CommandDescriptor(uninstallpackage, "add",     nully));
            
            AreEqual("build / restore",            CommandDescriptor(build,            "restore", nully));
            AreEqual("rebuild / restore",          CommandDescriptor(rebuild,          "restore", nully));
            AreEqual("msbuild / restore",          CommandDescriptor(msbuild,          "restore", nully));
            AreEqual("msrebuild / restore",        CommandDescriptor(msrebuild,        "restore", nully));
            AreEqual("restore",                    CommandDescriptor(restore,          "restore", nully));
            AreEqual("installpackage / restore",   CommandDescriptor(installpackage,   "restore", nully));
            AreEqual("uninstallpackage / restore", CommandDescriptor(uninstallpackage, "restore", nully));
            
            AreEqual("build / remove",             CommandDescriptor(build,            "remove",  nully));
            AreEqual("rebuild / remove",           CommandDescriptor(rebuild,          "remove",  nully));
            AreEqual("msbuild / remove",           CommandDescriptor(msbuild,          "remove",  nully));
            AreEqual("msrebuild / remove",         CommandDescriptor(msrebuild,        "remove",  nully));
            AreEqual("restore / remove",           CommandDescriptor(restore,          "remove",  nully));
            AreEqual("installpackage / remove",    CommandDescriptor(installpackage,   "remove",  nully));
            AreEqual("uninstallpackage / remove",  CommandDescriptor(uninstallpackage, "remove",  nully));
        }
    }
    
    [TestMethod]
    public void CommandDescriptor_CommandStringWithReFlag()
    {
        // All cases represent inconsistent data.
        // (Consistent case would have re flag only when enum also filled.)
        // That why it's meaningful to always show the redundant "(re)" flag
        foreach(var nully in _enumNullies)
        {
            AreEqual("(re)build",     CommandDescriptor(nully, "build",     re));
            AreEqual("(re)rebuild",   CommandDescriptor(nully, "rebuild",   re)); // Redundant re flag displayed correctly. (Command text "rebuild" does not exist: 2x re: text should have been "build".)
            AreEqual("(re)msbuild",   CommandDescriptor(nully, "msbuild",   re));
            AreEqual("(re)msrebuild", CommandDescriptor(nully, "msrebuild", re)); // Redundant re flag displayed correctly. (Command text "msrebuild" does not exist: 2x re: text should have been "msbuild".)
            AreEqual("(re)restore",   CommandDescriptor(nully, "restore",   re)); // Redundant re flag displayed correctly.
            AreEqual("(re)add",       CommandDescriptor(nully, "add",       re));
            AreEqual("(re)remove",    CommandDescriptor(nully, "remove",    re)); // Redundant re flag displayed correctly.
            AreEqual("(re)whatever",  CommandDescriptor(nully, "whatever",  re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_Enum_ReFlagAlreadyImplied()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("rebuild",   CommandDescriptor(rebuild,   nully, re));
            AreEqual("msrebuild", CommandDescriptor(msrebuild, nully, re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumShowsReFlag_WhenMisapplied()
    {
        foreach (var nully in _textNullies)
        {
            AreEqual("(re)build",            CommandDescriptor(build,            nully, re));
            AreEqual("(re)msbuild",          CommandDescriptor(msbuild,          nully, re));
            AreEqual("(re)restore",          CommandDescriptor(restore,          nully, re));
            AreEqual("(re)installpackage",   CommandDescriptor(installpackage,   nully, re));
            AreEqual("(re)uninstallpackage", CommandDescriptor(uninstallpackage, nully, re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumAndText_WithReFlag_NormalCases()
    {
        AreEqual("rebuild / build",                CommandDescriptor(rebuild,          "build",   re));
        AreEqual("msrebuild / msbuild",            CommandDescriptor(msrebuild,        "msbuild", re));
    }

    [TestMethod]
    public void CommandDescriptor_EnumAndText_WithReFlag_AllCombos()
    {
        AreEqual("build / (re)blah",               CommandDescriptor(build,            "blah",    re));
        AreEqual("rebuild / (re)blah",             CommandDescriptor(rebuild,          "blah",    re));
        AreEqual("msbuild / (re)blah",             CommandDescriptor(msbuild,          "blah",    re));
        AreEqual("msrebuild / (re)blah",           CommandDescriptor(msrebuild,        "blah",    re));
        AreEqual("restore / (re)blah",             CommandDescriptor(restore,          "blah",    re));
        AreEqual("installpackage / (re)blah",      CommandDescriptor(installpackage,   "blah",    re));
        AreEqual("uninstallpackage / (re)blah",    CommandDescriptor(uninstallpackage, "blah",    re));

        AreEqual("build / (re)build",              CommandDescriptor(build,            "build",   re));
        AreEqual("rebuild / build",                CommandDescriptor(rebuild,          "build",   re));
        AreEqual("msbuild / (re)build",            CommandDescriptor(msbuild,          "build",   re));
        AreEqual("msrebuild / (re)build",          CommandDescriptor(msrebuild,        "build",   re));
        AreEqual("restore / (re)build",            CommandDescriptor(restore,          "build",   re));
        AreEqual("installpackage / (re)build",     CommandDescriptor(installpackage,   "build",   re));
        AreEqual("uninstallpackage / (re)build",   CommandDescriptor(uninstallpackage, "build",   re));
        
        AreEqual("build / (re)rebuild",            CommandDescriptor(build,            "rebuild", re));
        AreEqual("rebuild / (re)rebuild",          CommandDescriptor(rebuild,          "rebuild", re));
        AreEqual("msbuild / (re)rebuild",          CommandDescriptor(msbuild,          "rebuild", re));
        AreEqual("msrebuild / (re)rebuild",        CommandDescriptor(msrebuild,        "rebuild", re));
        AreEqual("restore / (re)rebuild",          CommandDescriptor(restore,          "rebuild", re));
        AreEqual("installpackage / (re)rebuild",   CommandDescriptor(installpackage,   "rebuild", re));
        AreEqual("uninstallpackage / (re)rebuild", CommandDescriptor(uninstallpackage, "rebuild", re));
        
        AreEqual("build / (re)msbuild",            CommandDescriptor(build,            "msbuild", re));
        AreEqual("rebuild / (re)msbuild",          CommandDescriptor(rebuild,          "msbuild", re));
        AreEqual("msbuild / (re)msbuild",          CommandDescriptor(msbuild,          "msbuild", re));
        AreEqual("msrebuild / msbuild",            CommandDescriptor(msrebuild,        "msbuild", re));
        AreEqual("restore / (re)msbuild",          CommandDescriptor(restore,          "msbuild", re));
        AreEqual("installpackage / (re)msbuild",   CommandDescriptor(installpackage,   "msbuild", re));
        AreEqual("uninstallpackage / (re)msbuild", CommandDescriptor(uninstallpackage, "msbuild", re));
        
        AreEqual("build / (re)add",                CommandDescriptor(build,            "add",     re));
        AreEqual("rebuild / add",                  CommandDescriptor(rebuild,          "add",     re)); // TODO: Inconsistent data should show re-flag.
        AreEqual("msbuild / (re)add",              CommandDescriptor(msbuild,          "add",     re));
        AreEqual("msrebuild / (re)add",            CommandDescriptor(msrebuild,        "add",     re));
        AreEqual("restore / (re)add",              CommandDescriptor(restore,          "add",     re));
        AreEqual("installpackage / (re)add",       CommandDescriptor(installpackage,   "add",     re));
        AreEqual("uninstallpackage / (re)add",     CommandDescriptor(uninstallpackage, "add",     re));
        
        AreEqual("build / (re)restore",            CommandDescriptor(build,            "restore", re));
        AreEqual("rebuild / restore",              CommandDescriptor(rebuild,          "restore", re)); // TODO: Inconsistent data should show re-flag.
        AreEqual("msbuild / (re)restore",          CommandDescriptor(msbuild,          "restore", re));
        AreEqual("msrebuild / (re)restore",        CommandDescriptor(msrebuild,        "restore", re));
        AreEqual("restore / (re)restore",          CommandDescriptor(restore,          "restore", re));
        AreEqual("installpackage / (re)restore",   CommandDescriptor(installpackage,   "restore", re));
        AreEqual("uninstallpackage / (re)restore", CommandDescriptor(uninstallpackage, "restore", re));
        
        AreEqual("build / (re)remove",             CommandDescriptor(build,            "remove",  re));
        AreEqual("rebuild / remove",               CommandDescriptor(rebuild,          "remove",  re));  // TODO: Inconsistent data should show re-flag.
        AreEqual("msbuild / (re)remove",           CommandDescriptor(msbuild,          "remove",  re));
        AreEqual("msrebuild / (re)remove",         CommandDescriptor(msrebuild,        "remove",  re));
        AreEqual("restore / (re)remove",           CommandDescriptor(restore,          "remove",  re));
        AreEqual("installpackage / (re)remove",    CommandDescriptor(installpackage,   "remove",  re));
        AreEqual("uninstallpackage / (re)remove",  CommandDescriptor(uninstallpackage, "remove",  re));
    }

    [TestMethod]
    public void CommandDescriptor_WithReEnumAndReFlag()
    {
        AreEqual("rebuild",   CommandDescriptor(rebuild,   null, re));
        AreEqual("msrebuild", CommandDescriptor(msrebuild, null, re));
    }

    [TestMethod]
    public void CommandDescriptor_CommandSameAsEnum_OnlyShowsOnlyOne()
    {
        foreach (var nully in _boolNullies)
        {
            AreEqual("build",   CommandDescriptor(build,   "build",   nully));
            AreEqual("msbuild", CommandDescriptor(msbuild, "msbuild", nully));
            AreEqual("restore", CommandDescriptor(restore, "restore", nully));
        }
    }

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
