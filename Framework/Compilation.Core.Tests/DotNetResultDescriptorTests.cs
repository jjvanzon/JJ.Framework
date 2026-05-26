namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class DiagnosticsFormatter_DotNetResult_Tests
{
    [TestMethod]
    public void DotNetResult_Stringify_Success_ArgsOptOutputText()
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

        // TODO: No longer the case. Add prefix?
        //AreEqual(result.Text, resultAccessor.DebuggerDisplay);
    }

    // Part-by-Part Tests

    private static readonly DotNetArgs DefaultArgs = new DotNetArgsAccessor().Obj;
    private static readonly DotNetResult EmptyResult = new DotNetResultAccessor(DefaultOptions, DefaultArgs).Obj;
    private static readonly DotNetResult? NullResult = null;

    [TestMethod] public void DotNetResult_Empty_Text()               => AreEqual("DotNetResult empty", EmptyResult.Text);
    [TestMethod] public void DotNetResult_Empty_ToString()           => AreEqual("DotNetResult empty", EmptyResult.ToString());
    [TestMethod] public void DotNetResult_Empty_ConversionOpString() => AreEqual("DotNetResult empty", EmptyResult);
    [TestMethod] public void DotNetResult_Empty_Descriptor()         => AreEqual("empty", Descriptor(EmptyResult, " "));
    [TestMethod] public void DotNetResult_Empty_Stringify()          => AreEqual("DotNetResult empty", Stringify(EmptyResult));
    [TestMethod] public void DotNetResult_Empty_ExceptionMessage()   => AreEqual("DotNetResult empty", ExceptionMessage(EmptyResult));
    //[TestMethod] public void DotNetResult_Empty_DebuggerDisplay()    => AreEqual("DotNetResult empty", DebuggerDisplay(EmptyResult));

    //[TestMethod] public void DotNetResult_Null_ConversionOpString() => AreEqual("null", NullResult);
    //[TestMethod] public void DotNetResult_Null_Descriptor()         => AreEqual("null", Descriptor(NullResult, " "));
    [TestMethod] public void DotNetResult_Null_Stringify()          => AreEqual("null", Stringify(NullResult));
    [TestMethod] public void DotNetResult_Null_ExceptionMessage()   => AreEqual("DotNetResult null", ExceptionMessage(NullResult));
    [TestMethod] public void DotNetResult_Null_DebuggerDisplay()    => AreEqual("DotNetResult null", DebuggerDisplay(NullResult));

    /*
    [TestMethod] public void Test_DotNetResult_Stringify_UsesNewLines() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_ExceptionMessage_UsesSpaceSeparator() => throw new NotImplementedException();

    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_None() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_HasTimeOut() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_HasErrorInOutput() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_HasExitCode() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_PriorityOrder() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_PreferenceOrder() => throw new NotImplementedException();

    [TestMethod] public void Test_DotNetResult_Descriptor_Args() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_Opt() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_TimeOut() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_ExitCode() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_ErrorText_WithSuccess() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_ErrorText_WithFailure() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_OutputText() => throw new NotImplementedException();
    */
}
