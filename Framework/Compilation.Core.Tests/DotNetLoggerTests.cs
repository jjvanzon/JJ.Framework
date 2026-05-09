namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetLoggerTests
{
    [TestMethod]
    public void Log_WithMinimalVerbosity_LogsShortMessage()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.build) { Args = "--nologo" };
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Minimal, Log = x => message = x };

        DotNetLogger.Log(info, "build --nologo", options);

        AreEqual("Build with --nologo", message);
    }

    [TestMethod]
    public void Log_WithNormalVerbosity_LogsCommandLine()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.restore);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Normal, Log = x => message = x };

        DotNetLogger.Log(info, "restore", options);

        IsTrue(message.StartsWith("Restore:"));
        IsTrue(message.Contains("dotnet restore"));
    }

    [TestMethod]
    public void Log_WithQuietVerbosity_DoesNotLog()
    {
        bool invoked = false;
        var info = new DotNetInfo(DotNetCommandEnum.build);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Quiet, Log = _ => invoked = true };

        DotNetLogger.Log(info, "build", options);

        IsFalse(invoked);
    }

    [TestMethod]
    public void Log_WithDetailedVerbosity_LogsDetailedLayout()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.build);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Detailed, Log = x => message = x };

        DotNetLogger.Log(info, "build", options);

        IsTrue(message.StartsWith(Environment.NewLine));
        IsTrue(message.Contains("Build"));
        IsTrue(message.Contains("dotnet build"));
    }

    [TestMethod]
    public void Log_WithDiagnosticVerbosity_UsesDetailedLayout()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.restore);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Diagnostic, Log = x => message = x };

        DotNetLogger.Log(info, "restore", options);

        IsTrue(message.Contains("Restore"));
        IsTrue(message.Contains("dotnet restore"));
    }

    [TestMethod]
    public void Log_WithNullLog_DoesNotThrow()
    {
        var info = new DotNetInfo(DotNetCommandEnum.build);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Normal };

        DotNetLogger.Log(info, "build", options);
    }

    [TestMethod]
    public void Log_WithUnknownCommandAndNoArgs_DoesNotInvokeLogger()
    {
        bool invoked = false;
        var info = new DotNetInfo(DotNetCommandEnum.undefined);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Minimal, Log = _ => invoked = true };

        DotNetLogger.Log(info, "", options);

        IsFalse(invoked);
    }

    [TestMethod]
    public void Log_WithMSBuildCommand_UsesBuildCaption()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.msbuild);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Normal, Log = x => message = x };

        DotNetLogger.Log(info, "msbuild", options);

        IsTrue(message.StartsWith("Build:"));
    }

    [TestMethod]
    public void Log_WithMSRebuildCommand_UsesRebuildCaption()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.msrebuild);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Normal, Log = x => message = x };

        DotNetLogger.Log(info, "msbuild /t:Rebuild", options);

        IsTrue(message.StartsWith("Rebuild:"));
    }

    [TestMethod]
    public void Log_WithInstallPackageCommand_UsesInstallCaption()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.installpackage);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Normal, Log = x => message = x };

        DotNetLogger.Log(info, "add package X", options);

        IsTrue(message.StartsWith("Install package:"));
    }

    [TestMethod]
    public void Log_WithUninstallPackageCommand_UsesUninstallCaption()
    {
        string message = "";
        var info = new DotNetInfo(DotNetCommandEnum.uninstallpackage);
        var options = new DotNetOptions { Verbosity = DotNetVerbosity.Normal, Log = x => message = x };

        DotNetLogger.Log(info, "remove package X", options);

        IsTrue(message.StartsWith("Uninstall package:"));
    }
}
