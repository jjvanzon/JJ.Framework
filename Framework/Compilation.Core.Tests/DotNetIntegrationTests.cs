namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetIntegrationTests
{
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
}
