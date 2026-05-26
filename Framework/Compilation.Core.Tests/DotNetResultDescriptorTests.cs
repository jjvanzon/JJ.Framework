namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DotNetResultDescriptorTests
{
    [TestMethod]
    public void DotNetResult_Stringify_Success_ContainsDotNetArgsAndOutput()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var opt = new DotNetOptions { Dir = @"C:\repo", File = "MyProject.csproj" };
        var result = new DotNetResultAccessor(
            opt,
            args,
            exitCode: 0,
            errorText: "",
            outputText: "Build succeeded.",
            timeOutMessage: "").Obj;

        const string expected =
            """
            dotnet build --no-logo
            MyProject.csproj | Dir = C:\repo
            Output =
            Build succeeded.
            """;

        AreEqual(expected, Stringify(result));
        AreEqual(expected, result.ToString());
    }

    [TestMethod]
    public void DotNetResult_ExceptionMessage_Success_UsesSingleLineSeparator()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var opt = new DotNetOptions { Dir = @"C:\repo", File = "MyProject.csproj" };
        var result = new DotNetResultAccessor(
            opt,
            args,
            exitCode: 0,
            errorText: "",
            outputText: "Build succeeded.",
            timeOutMessage: "").Obj;

        const string expected = "dotnet build --no-logo MyProject.csproj | Dir = C:\\repo Output = Build succeeded.";

        AreEqual(expected, ExceptionMessage(result));
    }

    [TestMethod]
    public void DotNetResult_Stringify_ExitCodeFailure_IncludesExitCodeAndErrorLabel()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var result = new DotNetResultAccessor(
            default,
            args,
            exitCode: 2,
            errorText: "Compilation failed.",
            outputText: "",
            timeOutMessage: "").Obj;

        const string expected =
            """
            dotnet EXIT CODE = 2!
            build --no-logo
            default
            Error =
            Compilation failed.
            """;

        AreEqual(expected, Stringify(result));
    }

    [TestMethod]
    public void DotNetResult_Stringify_ErrorInOutputFailure_UsesDotNetErrorHeader()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var result = new DotNetResultAccessor(
            default,
            args,
            exitCode: 0,
            errorText: "",
            outputText: "[error] Something broke",
            timeOutMessage: "").Obj;

        const string expected =
            """
            dotnet ERROR!
            build --no-logo
            default
            Output =
            [error] Something broke
            """;

        AreEqual(expected, Stringify(result));
    }

    [TestMethod]
    public void DotNetResult_Stringify_TimeOutFailure_IncludesTimeOutMessage()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var result = new DotNetResultAccessor(
            default,
            args,
            exitCode: 0,
            errorText: "",
            outputText: "",
            timeOutMessage: "dotnet --no-logo timed out after 5s").Obj;

        const string expected =
            """
            dotnet TIME OUT!
            build --no-logo
            default
            dotnet --no-logo timed out after 5s
            """;

        AreEqual(expected, Stringify(result));
    }

    [TestMethod]
    public void DotNetResult_Stringify_Success_WithErrorText_UsesStdErrLabel()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var result = new DotNetResultAccessor(
            default,
            args,
            exitCode: 0,
            errorText: "Welcome banner",
            outputText: "Build succeeded.",
            timeOutMessage: "").Obj;

        const string expected =
            """
            dotnet build --no-logo
            default
            stdErr =
            Welcome banner
            Output =
            Build succeeded.
            """;

        AreEqual(expected, Stringify(result));
    }

    [TestMethod]
    public void DotNetResult_DebuggerDisplay_EqualsText()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var resultAccessor = new DotNetResultAccessor(
            default,
            args,
            exitCode: 0,
            errorText: "",
            outputText: "Build succeeded.",
            timeOutMessage: "");

        DotNetResult result = resultAccessor.Obj;

        AreEqual(result.Text, resultAccessor.DebuggerDisplay);
    }
}
