namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetLoggerTests
{
    // Verbosities

    [TestMethod]
    public void Test_Log_Quiet()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Quiet, Log = x => msg = x };

        Log(info, opt, fullArgs: "arg");

        NullOrEmpty(msg);
    }

    [TestMethod]
    public void Tes_Log_Minimal()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Minimal, Log = x => msg = x };

        Log(info, opt, fullArgs: "build --nologo");

        AreEqual("Build", msg);
    }

    [TestMethod]
    public void Tes_Log_Minimal_WithArgs()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = build, Args = "--nologo" };
        var opt = new DotNetOptions { Verbosity = Minimal, Log = x => msg = x };

        Log(info, opt, fullArgs: "build --nologo");

        AreEqual("Build with --nologo", msg);
    }

    [TestMethod]
    public void Test_Log_Verbosity_Normal()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = restore};
        var opt = new DotNetOptions { Verbosity = Normal, Log = x => msg = x };

        Log(info, opt, fullArgs: "restore");

        AreEqual("Restore:" + NewLine + "dotnet restore" + NewLine, msg);
    }

    [TestMethod]
    public void Test_Log_Detailed()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Detailed, Log = x => msg = x };

        Log(info, opt, fullArgs: "build");

        // TODO: Might as well assert the entire message (start) instead of just parts of it.
        IsTrue(msg.StartsWith(NewLine));
        IsTrue(msg.Contains("Build"));
        IsTrue(msg.Contains("dotnet build"));

        // Note: Build output logged separately in DotNet.Exe method.
    }

    [TestMethod]
    public void Test_Log_Diagnostic()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = restore };
        var opt = new DotNetOptions { Verbosity = Diagnostic, Log = x => msg = x };

        Log(info, opt, fullArgs: "restore");

        // TODO: Might as well assert the entire message (start) instead of just parts of it.
        IsTrue(msg.Contains("Restore"));
        IsTrue(msg.Contains("dotnet restore"));

        // Note: Build output logged separately in DotNet.Exe method.
    }

    // Various Commands

    [TestMethod]
    public void Test_Log_MSBuild_UsesCaptionBuild()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = msbuild };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "msbuild");

        IsTrue(msg.StartsWith("Build:"));
    }

    [TestMethod]
    public void Test_Log_MSRebuild_UsesCaptionRebuild()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = msrebuild };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "msbuild /t:Rebuild");

        IsTrue(msg.StartsWith("Rebuild:"));
    }

    [TestMethod]
    public void Test_Log_InstallPackage()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = installpackage };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "add package X");

        IsTrue(msg.StartsWith("Install package:"));
    }

    [TestMethod]
    public void Test_Log_UninstallPackage()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = uninstallpackage };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "remove package X");

        IsTrue(msg.StartsWith("Uninstall package:"));
    }

    // Edge-Cases

    [TestMethod]
    public void Test_Log_UnknownCommand_DoesNotLog()
    {
        string msg = "";
        var info = new DotNetInfo { Command = "MyCmd" };
        var opt = new DotNetOptions { Log = x => msg = x };

        Log(info, opt, fullArgs: "arg");
        IsNullOrEmpty(msg);
    }
}
