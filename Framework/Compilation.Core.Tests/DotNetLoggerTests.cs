namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetLoggerAccessor;

[TestClass]
public class DotNetLoggerTests
{
    // Verbosities

    [TestMethod]
    public void Test_Log_Quiet()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Quiet, Log = x => msg = x };

        Log(info, opt, "build --nologo");

        NullOrEmpty(msg);
    }

    [TestMethod]
    public void Test_Log_Minimal()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Minimal, Log = x => msg = x };

        Log(info, opt, fullArgs: "build --nologo");

        AreEqual("Build", msg);
    }

    [TestMethod]
    public void Test_Log_Minimal_WithArgs()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = build, Args = "--nologo" };
        var opt = new DotNetOptions { Verbosity = Minimal, Log = x => msg = x };

        Log(info, opt, fullArgs: "build --nologo");

        AreEqual("Build with --nologo", msg);
    }

    [TestMethod]
    public void Test_Log_Verbosity_Normal()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = restore};
        var opt = new DotNetOptions { Verbosity = Normal, Log = x => msg = x };

        Log(info, opt, fullArgs: "restore");

        const string expected = 
        """
        Restore:
        dotnet restore

        """;

        AreEqual(expected, msg);
    }

    [TestMethod]
    public void Test_Log_Detailed()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Detailed, Log = x => msg = x };

        Log(info, opt, fullArgs: "build");

        IsTrue(msg.StartsWith(
        """
        
        Build
        -----
        dotnet build
        
        """));

        // Note: Build output logged separately
    }

    [TestMethod]
    public void Test_Log_Diagnostic()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = restore };
        var opt = new DotNetOptions { Verbosity = Diagnostic, Log = x => msg = x };

        Log(info, opt, fullArgs: "restore");

        IsTrue(msg.StartsWith(
        """

        Restore
        -----
        dotnet restore

        """
        ));

        // Note: Build output logged separately.
    }

    // Various Commands

    [TestMethod]
    public void Test_Log_MSBuild_UsesCaptionBuild()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = msbuild };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "msbuild");

        IsTrue(msg.StartsWith("Build:"));
    }

    [TestMethod]
    public void Test_Log_MSRebuild_UsesCaptionRebuild()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = msrebuild };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "msbuild /t:Rebuild");

        IsTrue(msg.StartsWith("Rebuild:"));
    }

    [TestMethod]
    public void Test_Log_InstallPackage()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = installpackage };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "add package X");

        IsTrue(msg.StartsWith("Install package:"));
    }

    [TestMethod]
    public void Test_Log_UninstallPackage()
    {
        string msg = "";
        var info = new DotNetArgsAccessor { CommandEnum = uninstallpackage };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "remove package X");

        IsTrue(msg.StartsWith("Uninstall package:"));
    }

    // Edge-Cases

    // TODO: Make logging clean in edge cases

    /*
    [TestMethod]
    public void Test_Log_UnknownCommand_DoesNotLog_Cleanly()
    {
        string msg = "";
        var info = new DotNetInfo { Command = "MyCmd" };
        var opt = new DotNetInfoAccessor { Log = x => msg = x };

        Log(info, opt, fullArgs: "arg");

        AreEqual("", msg);
        //IsNullOrEmpty(msg);
    }
    */
}
