#pragma warning disable IDE0017
// ReSharper disable InvertIf
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Compilation.Core.Tests.FormatterTests;

using static DotNetArgsFormatterAccessor;
using static DotNetArgsFormatterExtensionsAccessor;

[TestClass]
public class DotNetArgsFormatterTests
{
    // DotNetArgs

    [TestMethod]
    public void DotNetArgsFormatter_NullArgs()
    {
        AssertDiagnosticTexts(null, "<null>");
    }

    [TestMethod]
    public void DotNetArgsFormatter_CommandEnumAndArgs()
    {
        var args = new DotNetArgsAccessor(build)
        {
            Args = 
            """
            --o "C:\Temp\out"
            """
        };

        AssertDiagnosticTexts(
            args.Obj,
            """
            build | --o "C:\Temp\out"
            """);
    }

    // With Commands

    [TestMethod]
    public void DotNetArgs_Descriptor_EnumAndCommandText_MSRebuild()
    {
        var args = new DotNetArgsAccessor(msrebuild) { Command = "msbuild" }.Obj;
        AssertDiagnosticTexts(args, "msrebuild / msbuild");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_EnumAndFullArgs_Build()
    {
        var args = new DotNetArgsAccessor(build) { FullArgs = "build --no-restore" }.Obj;
        AssertDiagnosticTexts(args, "build --no-restore");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_EnumAndFullArgs_Rebuild()
    {
        var args = new DotNetArgsAccessor(rebuild) { FullArgs = "build --no-incremental" }.Obj;
        AssertDiagnosticTexts(args, "rebuild | build --no-incremental");
    }

    // With Args

    [TestMethod]
    public void DotNetArgs_Descriptor_Build_Enum_CommandText_FullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = build, 
            Command = "build", 
            FullArgs = "build --no-incremental" 
        }.Obj;
        AssertDiagnosticTexts(args, "build --no-incremental");
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
        }.Obj;
        AssertDiagnosticTexts(args, "rebuild | build --no-incremental");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_CommandEnum_FullArgsAndArgs()
    {
        var args = new DotNetArgsAccessor
        {
            CommandEnum = restore,
            Args = "--bogus-arg",
            FullArgs = "--dummy-arg"
        }.Obj;
        AssertDiagnosticTexts(args, "restore | --bogus-arg | --dummy-arg");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_CommandEnum_FullContainsArgs()
    {
        var args = new DotNetArgsAccessor
        {
            CommandEnum = restore,
            Args = "--no-cache",
            FullArgs = "--no-cache --no-logo"
        }.Obj;
        AssertDiagnosticTexts(args, "restore | --no-cache --no-logo");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_ArgsAndFullArgs()
    {
        var args = new DotNetArgsAccessor
        {
            Args = "--no-cache",
            FullArgs = "--no-cache --no-logo"
        }.Obj;
        AssertDiagnosticTexts(args, "<no command> | --no-cache --no-logo");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_NoCommandNoIDVerNoArgs_OnlyNoCommandText()
    {
        var args = new DotNetArgsAccessor().Obj;
        AssertDiagnosticTexts(args, "<no command>");
    }

    // InstallPackage

    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandEnumAndIDVer()
    {
        var args = new DotNetArgsAccessor
        {
            CommandEnum = installpackage,
            ID = "JJ.Framework.Common", 
            Ver = "1.0.0" 
        }.Obj;
        AssertDiagnosticTexts(args, "installpackage JJ.Framework.Common 1.0.0");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandTextAndIDVer()
    {
        var args = new DotNetArgsAccessor
        { 
            Command = "add",
            ID = "JJ.Framework.Common", 
            Ver = "1.0.0" 
        }.Obj;
        AssertDiagnosticTexts(args, "add JJ.Framework.Common 1.0.0");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandEnumTextAndIDVer()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = installpackage,
            Command = "add",
            ID = "JJ.Framework.Common", 
            Ver = "1.0.0"
        }.Obj;
        AssertDiagnosticTexts(args, "installpackage / add JJ.Framework.Common 1.0.0");
    }
    
    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandEnumIDVerAndFullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = installpackage,
            ID = "JJ.Framework.Common", 
            Ver = "1.0.0",
            FullArgs = "add package JJ.Framework.Common --version 1.0.0"
        }.Obj;
        AssertDiagnosticTexts(args, "installpackage | add package JJ.Framework.Common --version 1.0.0");
    }
    
    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandTextIDVerAndFullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            Command = "add",
            ID = "JJ.Framework.Common", 
            Ver = "1.0.0",
            FullArgs = "add package JJ.Framework.Common --version 1.0.0"
        }.Obj;
        AssertDiagnosticTexts(args, "add package JJ.Framework.Common --version 1.0.0");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_InstallPackage_CommandEnumTextIDVerAndFullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = installpackage,
            Command = "add",
            ID = "JJ.Framework.Common", 
            Ver = "1.0.0",
            FullArgs = "add package JJ.Framework.Common --version 1.0.0"
        }.Obj;
        AssertDiagnosticTexts(args, "installpackage | add package JJ.Framework.Common --version 1.0.0");
    }

    // UninstallPackage

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandTextAndID()
    {
        var args = new DotNetArgsAccessor
        { 
            Command = "remove",
            ID = "JJ.Framework.Common" 
        }.Obj;
        AssertDiagnosticTexts(args, "remove JJ.Framework.Common");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandEnumAndID()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = uninstallpackage,
            ID = "JJ.Framework.Common" 
        }.Obj;
        AssertDiagnosticTexts(args, "uninstallpackage JJ.Framework.Common");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandTextEnumAndID()
    {
        var args = new DotNetArgsAccessor
        { 
            Command = "remove",
            CommandEnum = uninstallpackage,
            ID = "JJ.Framework.Common" 
        }.Obj;
        AssertDiagnosticTexts(args, "uninstallpackage / remove JJ.Framework.Common");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandEnumTextIDAndArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = uninstallpackage, 
            Command = "remove", 
            ID = "JJ.Framework.Common", 
            Args = "--help"
        }.Obj;
        AssertDiagnosticTexts(args, "uninstallpackage / remove JJ.Framework.Common | --help");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandTextIDAndFullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            Command = "remove",
            ID = "JJ.Framework.Common", 
            FullArgs = "remove package JJ.Framework.Common"
        }.Obj;
        AssertDiagnosticTexts(args, "remove package JJ.Framework.Common");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandEnumTextIDAndFullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = uninstallpackage,
            Command = "remove",
            ID = "JJ.Framework.Common", 
            FullArgs = "remove package JJ.Framework.Common"
        }.Obj;
        AssertDiagnosticTexts(args, "uninstallpackage | remove package JJ.Framework.Common");
    }

    [TestMethod]
    public void DotNetArgs_Descriptor_UninstallPackage_CommandEnumTextIDAnd_ArgsInFullArgs()
    {
        var args = new DotNetArgsAccessor
        { 
            CommandEnum = uninstallpackage,
            Command = "remove",
            ID = "JJ.Framework.Common", 
            FullArgs = "remove package JJ.Framework.Common --help",
            Args = "--help"
        }.Obj;
        AssertDiagnosticTexts(args, "uninstallpackage | remove package JJ.Framework.Common --help");
    }

    // TODO: Tests with both Args and FullArgs (realistic non-error case ones).

    // CommandDescriptor

    [TestMethod]
    public void CommandDescriptor_EnumOnly()
    {
        foreach (var nully1 in NullyTexts)
        foreach (var nully2 in NullyBools)
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
        foreach(var nully1 in NullyCommandEnums)
        foreach(var nully2 in NullyBools)
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
        foreach (var nully in NullyBools)
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
        foreach(var nully in NullyCommandEnums)
        {
            AreEqual("(re)build",     CommandDescriptor(nully, "build",     Re));
            AreEqual("(re)rebuild",   CommandDescriptor(nully, "rebuild",   Re)); // Redundant re flag displayed correctly. (Command text "rebuild" does not exist: 2x re: text should have been "build".)
            AreEqual("(re)msbuild",   CommandDescriptor(nully, "msbuild",   Re));
            AreEqual("(re)msrebuild", CommandDescriptor(nully, "msrebuild", Re)); // Redundant re flag displayed correctly. (Command text "msrebuild" does not exist: 2x re: text should have been "msbuild".)
            AreEqual("(re)restore",   CommandDescriptor(nully, "restore",   Re)); // Redundant re flag displayed correctly.
            AreEqual("(re)add",       CommandDescriptor(nully, "add",       Re));
            AreEqual("(re)remove",    CommandDescriptor(nully, "remove",    Re)); // Redundant re flag displayed correctly.
            AreEqual("(re)whatever",  CommandDescriptor(nully, "whatever",  Re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_Enum_ReFlagAlreadyImplied()
    {
        foreach (var nully in NullyTexts)
        {
            AreEqual("rebuild",   CommandDescriptor(rebuild,   nully, Re));
            AreEqual("msrebuild", CommandDescriptor(msrebuild, nully, Re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumShowsReFlag_WhenMisapplied()
    {
        foreach (var nully in NullyTexts)
        {
            AreEqual("(re)build",            CommandDescriptor(build,            nully, Re));
            AreEqual("(re)msbuild",          CommandDescriptor(msbuild,          nully, Re));
            AreEqual("(re)restore",          CommandDescriptor(restore,          nully, Re));
            AreEqual("(re)installpackage",   CommandDescriptor(installpackage,   nully, Re));
            AreEqual("(re)uninstallpackage", CommandDescriptor(uninstallpackage, nully, Re));
        }
    }

    [TestMethod]
    public void CommandDescriptor_EnumAndText_WithReFlag_NormalCases()
    {
        AreEqual("rebuild / build",                CommandDescriptor(rebuild,          "build",   Re));
        AreEqual("msrebuild / msbuild",            CommandDescriptor(msrebuild,        "msbuild", Re));
    }

    [TestMethod]
    public void CommandDescriptor_EnumAndText_WithReFlag_AllCombos()
    {
        AreEqual("build / (re)blah",               CommandDescriptor(build,            "blah",    Re));
        AreEqual("rebuild / (re)blah",             CommandDescriptor(rebuild,          "blah",    Re));
        AreEqual("msbuild / (re)blah",             CommandDescriptor(msbuild,          "blah",    Re));
        AreEqual("msrebuild / (re)blah",           CommandDescriptor(msrebuild,        "blah",    Re));
        AreEqual("restore / (re)blah",             CommandDescriptor(restore,          "blah",    Re));
        AreEqual("installpackage / (re)blah",      CommandDescriptor(installpackage,   "blah",    Re));
        AreEqual("uninstallpackage / (re)blah",    CommandDescriptor(uninstallpackage, "blah",    Re));

        AreEqual("build / (re)build",              CommandDescriptor(build,            "build",   Re));
        AreEqual("rebuild / build",                CommandDescriptor(rebuild,          "build",   Re));
        AreEqual("msbuild / (re)build",            CommandDescriptor(msbuild,          "build",   Re));
        AreEqual("msrebuild / (re)build",          CommandDescriptor(msrebuild,        "build",   Re));
        AreEqual("restore / (re)build",            CommandDescriptor(restore,          "build",   Re));
        AreEqual("installpackage / (re)build",     CommandDescriptor(installpackage,   "build",   Re));
        AreEqual("uninstallpackage / (re)build",   CommandDescriptor(uninstallpackage, "build",   Re));
        
        AreEqual("build / (re)rebuild",            CommandDescriptor(build,            "rebuild", Re));
        AreEqual("rebuild / (re)rebuild",          CommandDescriptor(rebuild,          "rebuild", Re));
        AreEqual("msbuild / (re)rebuild",          CommandDescriptor(msbuild,          "rebuild", Re));
        AreEqual("msrebuild / (re)rebuild",        CommandDescriptor(msrebuild,        "rebuild", Re));
        AreEqual("restore / (re)rebuild",          CommandDescriptor(restore,          "rebuild", Re));
        AreEqual("installpackage / (re)rebuild",   CommandDescriptor(installpackage,   "rebuild", Re));
        AreEqual("uninstallpackage / (re)rebuild", CommandDescriptor(uninstallpackage, "rebuild", Re));
        
        AreEqual("build / (re)msbuild",            CommandDescriptor(build,            "msbuild", Re));
        AreEqual("rebuild / (re)msbuild",          CommandDescriptor(rebuild,          "msbuild", Re));
        AreEqual("msbuild / (re)msbuild",          CommandDescriptor(msbuild,          "msbuild", Re));
        AreEqual("msrebuild / msbuild",            CommandDescriptor(msrebuild,        "msbuild", Re));
        AreEqual("restore / (re)msbuild",          CommandDescriptor(restore,          "msbuild", Re));
        AreEqual("installpackage / (re)msbuild",   CommandDescriptor(installpackage,   "msbuild", Re));
        AreEqual("uninstallpackage / (re)msbuild", CommandDescriptor(uninstallpackage, "msbuild", Re));
        
        AreEqual("build / (re)add",                CommandDescriptor(build,            "add",     Re));
        AreEqual("rebuild / (re)add",              CommandDescriptor(rebuild,          "add",     Re));
        AreEqual("msbuild / (re)add",              CommandDescriptor(msbuild,          "add",     Re));
        AreEqual("msrebuild / (re)add",            CommandDescriptor(msrebuild,        "add",     Re));
        AreEqual("restore / (re)add",              CommandDescriptor(restore,          "add",     Re));
        AreEqual("installpackage / (re)add",       CommandDescriptor(installpackage,   "add",     Re));
        AreEqual("uninstallpackage / (re)add",     CommandDescriptor(uninstallpackage, "add",     Re));
        
        AreEqual("build / (re)restore",            CommandDescriptor(build,            "restore", Re));
        AreEqual("rebuild / (re)restore",          CommandDescriptor(rebuild,          "restore", Re));
        AreEqual("msbuild / (re)restore",          CommandDescriptor(msbuild,          "restore", Re));
        AreEqual("msrebuild / (re)restore",        CommandDescriptor(msrebuild,        "restore", Re));
        AreEqual("restore / (re)restore",          CommandDescriptor(restore,          "restore", Re));
        AreEqual("installpackage / (re)restore",   CommandDescriptor(installpackage,   "restore", Re));
        AreEqual("uninstallpackage / (re)restore", CommandDescriptor(uninstallpackage, "restore", Re));
        
        AreEqual("build / (re)remove",             CommandDescriptor(build,            "remove",  Re));
        AreEqual("rebuild / (re)remove",           CommandDescriptor(rebuild,          "remove",  Re));
        AreEqual("msbuild / (re)remove",           CommandDescriptor(msbuild,          "remove",  Re));
        AreEqual("msrebuild / (re)remove",         CommandDescriptor(msrebuild,        "remove",  Re));
        AreEqual("restore / (re)remove",           CommandDescriptor(restore,          "remove",  Re));
        AreEqual("installpackage / (re)remove",    CommandDescriptor(installpackage,   "remove",  Re));
        AreEqual("uninstallpackage / (re)remove",  CommandDescriptor(uninstallpackage, "remove",  Re));
    }

    [TestMethod]
    public void CommandDescriptor_WithReEnumAndReFlag()
    {
        AreEqual("rebuild",   CommandDescriptor(rebuild,   null, Re));
        AreEqual("msrebuild", CommandDescriptor(msrebuild, null, Re));
    }

    [TestMethod]
    public void CommandDescriptor_CommandSameAsEnum_OnlyShowsOnlyOne()
    {
        foreach (var nully in NullyBools)
        {
            AreEqual("build",   CommandDescriptor(build,   "build",   nully));
            AreEqual("msbuild", CommandDescriptor(msbuild, "msbuild", nully));
            AreEqual("restore", CommandDescriptor(restore, "restore", nully));
        }
    }

    [TestMethod]
    public void CommandDescriptor_Nullies_ShowAsNoCommand()
    {
        foreach (var nully1 in NullyCommandEnums)
        foreach (var nully2 in NullyTexts)
        foreach (var nully3 in NullyBools)
        {
            AreEqual("<no command>", CommandDescriptor(nully1, nully2, nully3));
        }
    }

    [TestMethod]
    public void CommandDescriptor_IsRebuildAndNullies_ShowsAsReWithNoCommand()
    {
        foreach (var nully1 in NullyCommandEnums)
        foreach (var nully2 in NullyTexts)
        {
            AreEqual("(re-)<no command>", CommandDescriptor(nully1, nully2, Re));
        }
    }

    // IDVerDescriptor

    [TestMethod]
    public void IDVerDescriptor_IDAndVer()
        => AreEqual("MyPkg 1.0.0", IDVerDescriptor("MyPkg", "1.0.0"));

    [TestMethod]
    public void IDVerDescriptor_OnlyID()
    {
        foreach (var nully in NullyTexts)
        {
            AreEqual("MyPkg", IDVerDescriptor("MyPkg", nully));
        }
    }

    [TestMethod]
    public void IDVerDescriptor_OnlyVer()
    {
        foreach (var nully in NullyTexts)
        {
            AreEqual("1.0.0", IDVerDescriptor(nully, "1.0.0"));
        }
    }

    [TestMethod]
    public void IDVerDescriptor_NullyCases()
    {
        foreach (var nully1 in NullyTexts)
        foreach (var nully2 in NullyTexts)
        {
            AreEqual("", IDVerDescriptor(nully1, nully2));
        }
    }

    // ArgPropsDescriptor

    [TestMethod]
    public void ArgPropsDescriptor_FullArgsDoesNotContainArgs_ReturnsBothWithPipe()
        => AreEqual("--output ./out | --no-restore", ArgPropsDescriptor("--output ./out", "--no-restore"));

    [TestMethod]
    public void ArgPropsDescriptor_NullyArgs()
    {
        foreach (var nully in NullyTexts)
        {
            AreEqual("build --output ./out", ArgPropsDescriptor(nully, "build --output ./out"));
        }
    }

    [TestMethod]
    public void ArgPropsDescriptor_NullyFullArgs()
    {
        foreach (var nully in NullyTexts)
        {
            AreEqual("--output ./out", ArgPropsDescriptor("--output ./out", nully));
        }
    }

    [TestMethod]
    public void ArgPropsDescriptor_ArgsInFullArgs_ReturnsOnlyFullArgs()
        => AreEqual(
            "-f net8.0 --output ./out  --no-restore", 
            ArgPropsDescriptor("--output ./out", "  -f net8.0 --output ./out  --no-restore"));

    [TestMethod]
    public void ArgPropsDescriptor_NullyCases()
    {
        foreach (var nully1 in NullyTexts)
        foreach (var nully2 in NullyTexts)
        {
            AreEqual("", ArgPropsDescriptor(nully1, nully2));
        }
    }

    private void AssertDiagnosticTexts(DotNetArgs? args, string expectedDescriptor)
    {

        string expectedStringify = "DotNetArgs " + expectedDescriptor;
        string expectedDebuggerDisplay = "{DotNetArgs " + expectedDescriptor.Replace('"', '\'').Replace('\\', '/') + "}";

        // Descriptor
        {
            AreEqual(expectedDescriptor, Descriptor(args));
            AreEqual(expectedDescriptor, args.Descriptor());
        }
        // Stringify
        {
            AreEqual(expectedStringify, Stringify(args));
            AreEqual(expectedStringify, args.Stringify());
            if (args != null) AreEqual(expectedStringify, args.ToString());
        }
        // DebuggerDisplay
        {
            AreEqual(expectedDebuggerDisplay, DebuggerDisplay(args));
            AreEqual(expectedDebuggerDisplay, args.DebuggerDisplay());
            
            if (args != null)
            {
                var accessor = new DotNetArgsAccessor(args);
                AreEqual(expectedDebuggerDisplay, accessor.DebuggerDisplay);
            }
        }
    }
}
