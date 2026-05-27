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
            Output:
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

        const string expected =
            @"dotnet build --no-logo | MyProject.csproj | Dir = C:\repo | Output: Build succeeded.";

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
            Error:
            Compilation failed.
            """;

        AreEqual(expected, Stringify(result));
    }

    [TestMethod]
    public void DotNetResult_Stringify_ErrorInOutputFailure_UsesDotNetErrorHeader()
    {
        var args = new DotNetArgsAccessor(build)
        {
            Args = "--no-logo", 
            FullArgs = "build --no-logo" 
        }.Obj;

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
            Output:
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
            dotnet --no-logo timed out after 5s
            """;

        // TODO: Time-out messages do not quite work out yet.        
        //AreEqual(expected, Stringify(result));
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
            stdErr:
            Welcome banner
            Output:
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
    private static readonly DotNetResult? NullResult = null;
    private static readonly DotNetResult EmptyResult = new DotNetResultAccessor(DefaultOptions, DefaultArgs).Obj;

    // TODO: One method for Null, one method for Empty.

    [TestMethod]
    public void DotNetResult_Null()
    {
        AreEqual("DotNetResult null", NullResult);
        AreEqual("DotNetResult null", Descriptor(NullResult));
        AreEqual("DotNetResult null", Stringify(NullResult));
        AreEqual("DotNetResult null", ExceptionMessage(NullResult));
        AreEqual("DotNetResult null", DebuggerDisplay(NullResult));
    }

    [TestMethod] 
    public void DotNetResult_Empty()
    {
        AreEqual("DotNetResult empty", EmptyResult);
        AreEqual("DotNetResult empty", EmptyResult.Text);
        AreEqual("DotNetResult empty", EmptyResult.ToString());
        AreEqual("DotNetResult empty", Descriptor(EmptyResult));
        AreEqual("DotNetResult empty", Stringify(EmptyResult));
        AreEqual("DotNetResult empty", ExceptionMessage(EmptyResult));
        AreEqual("DotNetResult empty", DebuggerDisplay(EmptyResult));
    }

    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_HasTimeOut()
    {
        DotNetResult result = new DotNetResultAccessor(
            DefaultOptions, DefaultArgs, 
            timeOutMessage: "timed out after 120s").Obj;
        
        const string expected = "dotnet timed out after 120s";

        AreEqual(expected, result.Text);
        AreEqual(expected, result.ToString());
        AreEqual(expected, result);
        AreEqual(expected, Descriptor(result));
        AreEqual(expected, Stringify(result));
        AreEqual(expected, ExceptionMessage(result));
        AreEqual(expected, DebuggerDisplay(result));
    }

    [TestMethod] 
    public void Test_DotNetResult_Descriptor_Failure_HasErrorInOutput()
    {
        DotNetResult result = new DotNetResultAccessor(
            DefaultOptions, DefaultArgs, 
            outputText: "[error] Something went wrong during compilation.").Obj;

        string[] expectedElements = 
        [
            "dotnet ERROR!",
            "Output:",
            "[error] Something went wrong during compilation."
        ];

        string expectedSingleLine = Join(" | ", expectedElements);
        string expectedMultiLine = Join(NewLine, expectedElements);

        AreEqual(expectedMultiLine, result.Text);

         
    }

    //[TestMethod] public void Test_DotNetResult_Descriptor_Failure_HasExitCode() => throw new NotImplementedException();
    //[TestMethod] public void Test_DotNetResult_Descriptor_Failure_PriorityOrder() => throw new NotImplementedException();
    //[TestMethod] public void Test_DotNetResult_Descriptor_Failure_None() => throw new NotImplementedException();

    /*
    [TestMethod] public void Test_DotNetResult_Descriptor_Args() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_Opt() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_TimeOut() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_ExitCode() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_ErrorText_WithSuccess() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_ErrorText_WithFailure() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_Descriptor_OutputText() => throw new NotImplementedException();
    
    [TestMethod] public void Test_DotNetResult_Stringify_UsesNewLines() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResult_ExceptionMessage_UsesSpaceSeparator() => throw new NotImplementedException();
    */
}
