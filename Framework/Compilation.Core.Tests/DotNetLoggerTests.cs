namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetLoggerAccessor;

[TestClass]
public class DotNetLoggerTests
{
    // Verbosities

    [TestMethod]
    public void Test_LogAction_Quiet()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(build) { FullArgs = "build --nologo" }.Obj;
        var opt = new DotNetOptions { Verbosity = Quiet, LogAction = x => msg = x };

        Log(args, opt);

        NullOrEmpty(msg);
    }

    [TestMethod]
    public void Test_LogAction_Minimal()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(build) { FullArgs = "build --nologo" }.Obj;
        var opt = new DotNetOptions { Verbosity = Minimal, LogAction = x => msg = x };

        Log(args, opt);

        AreEqual("Build", msg);
    }

    [TestMethod]
    public void Test_LogAction_Minimal_WithArgs()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(build) { Args = "--nologo", FullArgs = "build --nologo" }.Obj;
        var opt = new DotNetOptions { Verbosity = Minimal, LogAction = x => msg = x };

        Log(args, opt);

        AreEqual("Build with --nologo", msg);
    }

    [TestMethod]
    public void Test_LogAction_Verbosity_Normal()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(restore) { FullArgs = "restore"}.Obj;
        var opt = new DotNetOptions { Verbosity = Normal, LogAction = x => msg = x };

        Log(args, opt);

        const string expected = 
        """
        Restore:
        dotnet restore

        """;

        AreEqual(expected, msg);
    }

    [TestMethod]
    public void Test_LogAction_Detailed()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(build) { FullArgs = "build" }.Obj;
        var opt = new DotNetOptions { Verbosity = Detailed, LogAction = x => msg = x };

        Log(args, opt);

        IsTrue(msg.StartsWith(
        """
        
        Build
        -----
        dotnet build
        
        """));

        // Note: Build output logged separately
    }

    [TestMethod]
    public void Test_LogAction_Diagnostic()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(restore) { FullArgs = "restore" }.Obj;
        var opt = new DotNetOptions { Verbosity = Diagnostic, LogAction = x => msg = x };

        Log(args, opt);

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
    public void Test_LogAction_MSBuild_UsesCaptionBuild()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(msbuild) { FullArgs = "msbuild" }.Obj;
        var opt = new DotNetOptions { LogAction = x => msg = x };

        Log(args, opt);

        IsTrue(msg.StartsWith("Build:"));
    }

    [TestMethod]
    public void Test_LogAction_MSRebuild_UsesCaptionRebuild()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(msrebuild) { FullArgs = "msbuild /t:Rebuild" }.Obj;
        var opt = new DotNetOptions { LogAction = x => msg = x };

        Log(args, opt);

        IsTrue(msg.StartsWith("Rebuild:"));
    }

    [TestMethod]
    public void Test_LogAction_InstallPackage()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(installpackage) { FullArgs = "add package X" }.Obj;
        var opt = new DotNetOptions { LogAction = x => msg = x };

        Log(args, opt);

        IsTrue(msg.StartsWith("Install package:"));
    }

    [TestMethod]
    public void Test_LogAction_UninstallPackage()
    {
        string msg = "";
        var args = new DotNetArgsAccessor(uninstallpackage) { FullArgs = "remove package X" }.Obj;
        var opt = new DotNetOptions { LogAction = x => msg = x };

        Log(args, opt);

        IsTrue(msg.StartsWith("Uninstall package:"));
    }

    // Edge-Cases

    // TODO: Make logging clean in edge cases

    /*
    [TestMethod]
    public void Test_LogAction_UnknownCommand_DoesNotLog_Cleanly()
    {
        string msg = "";
        var info = new DotNetInfo { Command = "MyCmd" };
        var opt = new DotNetInfoAccessor { LogAction = x => msg = x };

        Log(info, opt, fullArgs: "arg");

        AreEqual("", msg);
        //IsNullOrEmpty(msg);
    }
    */
}
