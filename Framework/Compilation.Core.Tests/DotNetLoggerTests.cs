namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetLoggerTests
{
    // TODO: This tests 2 thing: minimallogging and how the args get logged.
    [TestMethod]
    public void Tes_Log_Minimal()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = build, Args = "--nologo" };
        var opt = new DotNetOptions { Verbosity = Minimal, Log = x => msg = x };

        Log(info, "build --nologo", opt);

        AreEqual("Build with --nologo", msg);
    }

    [TestMethod]
    public void Test_Log_NormalVerbosity()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = restore};
        var opt = new DotNetOptions { Verbosity = Normal, Log = x => msg = x };

        Log(info, "restore", opt);

        IsTrue(msg.StartsWith("Restore:"));
        IsTrue(msg.Contains("dotnet restore"));
    }

    [TestMethod]
    public void Test_Log_Quiet()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Quiet, Log = x => msg = x };

        Log(info, "arg", opt);

        NullOrEmpty(msg);
    }

    [TestMethod]
    public void Test_Log_Detailed()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = build };
        var opt = new DotNetOptions { Verbosity = Detailed, Log = x => msg = x };

        Log(info, "build", opt);

        IsTrue(msg.StartsWith(NewLine));
        IsTrue(msg.Contains("Build"));
        IsTrue(msg.Contains("dotnet build"));
    }

    [TestMethod]
    public void Test_Log_Diagnostic()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = restore };
        var opt = new DotNetOptions { Verbosity = Diagnostic, Log = x => msg = x };

        Log(info, "restore", opt);

        IsTrue(msg.Contains("Restore"));
        IsTrue(msg.Contains("dotnet restore"));
    }

    [TestMethod]
    public void Test_Log_UnknownCommand_DoesNotLog()
    {
        string msg = "";
        var info = new DotNetInfo { Command = "MyCmd" };
        var opt = new DotNetOptions { Verbosity = Minimal, Log = x => msg = x };

        Log(info, "arg", opt);
        IsNullOrEmpty(msg);
    }

    [TestMethod]
    public void Test_Log_MSBuild_UsesBuildCaption()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = msbuild };
        var opt = new DotNetOptions { Verbosity = Normal, Log = x => msg = x };

        Log(info, "msbuild", opt);

        IsTrue(msg.StartsWith("Build:"));
    }

    [TestMethod]
    public void Test_Log_MSRebuild_UsesRebuildCaption()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = msrebuild };
        var opt = new DotNetOptions { Verbosity = Normal, Log = x => msg = x };

        Log(info, "msbuild /t:Rebuild", opt);

        IsTrue(msg.StartsWith("Rebuild:"));
    }

    [TestMethod]
    public void Test_Log_InstallPackage()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = installpackage };
        var opt = new DotNetOptions { Verbosity = Normal, Log = x => msg = x };

        Log(info, "add package X", opt);

        IsTrue(msg.StartsWith("Install package:"));
    }

    [TestMethod]
    public void Test_Log_UninstallPackage()
    {
        string msg = "";
        var info = new DotNetInfo { CommandEnum = uninstallpackage };
        var opt = new DotNetOptions { Verbosity = Normal, Log = x => msg = x };

        Log(info, "remove package X", opt);

        IsTrue(msg.StartsWith("Uninstall package:"));
    }
}
