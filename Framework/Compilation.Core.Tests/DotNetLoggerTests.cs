namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetLoggerTests
{
    [TestMethod]
    public void Log_WithMinimalVerbosity_LogsShortMessage()
    {
        string message = "";
        var info = new DotNetInfo(build) { Args = "--nologo" };
        var options = new DotNetOptions { Verbosity = Minimal, Log = x => message = x };

        Log(info, "build --nologo", options);

        AreEqual("Build with --nologo", message);
    }

    [TestMethod]
    public void Log_WithNormalVerbosity_LogsCommandLine()
    {
        string message = "";
        var info = new DotNetInfo(restore);
        var options = new DotNetOptions { Verbosity = Normal, Log = x => message = x };

        Log(info, "restore", options);

        IsTrue(message.StartsWith("Restore:"));
        IsTrue(message.Contains("dotnet restore"));
    }

    [TestMethod]
    public void Log_WithQuietVerbosity_DoesNotLog()
    {
        bool invoked = false;
        var info = new DotNetInfo(build);
        var options = new DotNetOptions { Verbosity = Quiet, Log = _ => invoked = true };

        Log(info, "build", options);

        IsFalse(invoked);
    }

    [TestMethod]
    public void Log_WithDetailedVerbosity_LogsDetailedLayout()
    {
        string message = "";
        var info = new DotNetInfo(build);
        var options = new DotNetOptions { Verbosity = Detailed, Log = x => message = x };

        Log(info, "build", options);

        IsTrue(message.StartsWith(NewLine));
        IsTrue(message.Contains("Build"));
        IsTrue(message.Contains("dotnet build"));
    }

    [TestMethod]
    public void Log_WithDiagnosticVerbosity_UsesDetailedLayout()
    {
        string message = "";
        var info = new DotNetInfo(restore);
        var options = new DotNetOptions { Verbosity = Diagnostic, Log = x => message = x };

        Log(info, "restore", options);

        IsTrue(message.Contains("Restore"));
        IsTrue(message.Contains("dotnet restore"));
    }

    [TestMethod]
    public void Log_WithNullLog_DoesNotThrow()
    {
        var info = new DotNetInfo(build);
        var options = new DotNetOptions { Verbosity = Normal };

        Log(info, "build", options);
    }

    [TestMethod]
    public void Log_WithUnknownCommandAndNoArgs_DoesNotInvokeLogger()
    {
        bool invoked = false;
        var info = new DotNetInfo(undefined);
        var options = new DotNetOptions { Verbosity = Minimal, Log = _ => invoked = true };

        Log(info, "", options);

        IsFalse(invoked);
    }

    [TestMethod]
    public void Log_WithMSBuildCommand_UsesBuildCaption()
    {
        string message = "";
        var info = new DotNetInfo(msbuild);
        var options = new DotNetOptions { Verbosity = Normal, Log = x => message = x };

        Log(info, "msbuild", options);

        IsTrue(message.StartsWith("Build:"));
    }

    [TestMethod]
    public void Log_WithMSRebuildCommand_UsesRebuildCaption()
    {
        string message = "";
        var info = new DotNetInfo(msrebuild);
        var options = new DotNetOptions { Verbosity = Normal, Log = x => message = x };

        Log(info, "msbuild /t:Rebuild", options);

        IsTrue(message.StartsWith("Rebuild:"));
    }

    [TestMethod]
    public void Log_WithInstallPackageCommand_UsesInstallCaption()
    {
        string message = "";
        var info = new DotNetInfo(installpackage);
        var options = new DotNetOptions { Verbosity = Normal, Log = x => message = x };

        Log(info, "add package X", options);

        IsTrue(message.StartsWith("Install package:"));
    }

    [TestMethod]
    public void Log_WithUninstallPackageCommand_UsesUninstallCaption()
    {
        string message = "";
        var info = new DotNetInfo(uninstallpackage);
        var options = new DotNetOptions { Verbosity = Normal, Log = x => message = x };

        Log(info, "remove package X", options);

        IsTrue(message.StartsWith("Uninstall package:"));
    }
}
