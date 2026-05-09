namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetIntegrationTests
{
    private static readonly DotNetOptions _safeOptions = new()
    {
        Log = _ => { },
        Verbosity = DotNetVerbosity.Minimal
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
            Verbosity = DotNetVerbosity.Normal
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
    public void DotNetExe_WithCommandAndEmptyArgsWithoutOptions_ThrowsNullReferenceException()
    {
        Throws<NullReferenceException>(() => DotNet.Exe("--version", ""));
    }

    [TestMethod]
    public void DotNetExe_WithCommandOnlyWithoutOptions_ThrowsNullReferenceException()
        => Throws<NullReferenceException>(() => DotNet.Exe("--version"));

    [TestMethod]
    public void DotNetRestore_WithHelpArgs_ReturnsOutput()
    {
        string result = DotNet.Restore("--help", _safeOptions);

        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetRestore_WithHelpArgsWithoutOptions_ThrowsNullReferenceException()
        => Throws<NullReferenceException>(() => DotNet.Restore("--help"));

    [TestMethod]
    public void DotNetBuild_WithHelpArgs_ReturnsOutput()
    {
        string result = DotNet.Build("--help", _safeOptions);

        IsTrue(result.Contains("Output ="));
    }

    [TestMethod]
    public void DotNetBuild_WithHelpArgsWithoutOptions_ThrowsNullReferenceException()
        => Throws<NullReferenceException>(() => DotNet.Build("--help"));
}
