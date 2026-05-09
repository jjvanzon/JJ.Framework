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
}
