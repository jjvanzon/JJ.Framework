namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetIntegrationTests
{
    private static readonly DotNetOptions _safeOptions = new()
    {
        Log = _ => { },
        Verbosity = Minimal
    };

    [TestMethod]
    public void DotNetExe_WithCommandOnlyAndOptions_ReturnsOutput()
    {
        string result = DotNet.Exe("--version", _safeOptions);

        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetExe_WhenVersionCommand_ReturnsOutput()
    {
        string logMessage = "";

        string result = DotNet.Exe("--version", new DotNetOptions
        {
            Log = x => logMessage = x,
            Verbosity = Normal
        });

        IsTrue(result.Contains("Output ="));
        IsTrue(logMessage.Contains("dotnet --version"));
    }

    [TestMethod]
    public void DotNetExe_WithCommandAndEmptyArgs_ReturnsOutput()
    {
        string result = DotNet.Exe("--version", "", _safeOptions);

        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetExe_WithCommandAndEmptyArgsWithoutOptions_ReturnsOutput()
    {
        string result = DotNet.Exe("--version", "");
        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetExe_WithCommandOnlyWithoutOptions_ReturnsOutput()
    {
        string result = DotNet.Exe("--version");
        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetRestore_WithHelpArgs_ReturnsOutput()
    {
        string result = Restore("--help", _safeOptions);

        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetRestore_WithHelpArgsWithoutOptions_ReturnsOutput()
    {
        string result = Restore("--help");
        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetBuild_WithHelpArgs_ReturnsOutput()
    {
        string result = Build("--help", _safeOptions);

        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetBuild_WithHelpArgsWithoutOptions_ReturnsOutput()
    {
        string result = Build("--help");
        IsTrue(result.Contains("Output ="));
    }
}
