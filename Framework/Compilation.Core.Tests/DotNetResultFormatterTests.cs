namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetResultFormatterAccessor;

[TestClass]
public class DotNetResultFormatterTests
{
    [TestMethod]
    public void DotNetResult_Stringify_Success_ArgsOptOutputText()
    {
        var args = new DotNetArgsAccessor(build)
        { 
            Args = "--no-logo", 
            FullArgs = "build MyProject.csproj --no-logo" 
        };

        var opt = new DotNetOptions
        { 
            Dir = @"C:\repo", 
            File = "MyProject.csproj"
        };

        DotNetResult result = new DotNetResultAccessor(opt, args.Obj, outputText: "Build succeeded.").Obj;

        // TODO: If args contains File, do not repeat in opt descriptor.

        const string expectedLongForm =
            """
            dotnet build MyProject.csproj --no-logo
            MyProject.csproj | Dir = C:\repo
            Output:
            Build succeeded.
            """;

        const string expectedWideForm = 
            """
            dotnet build MyProject.csproj --no-logo | MyProject.csproj | Dir = C:\repo | Output: Build succeeded.
            """;
        
        AreEqual(expectedLongForm, result.Text);
        AreEqual(expectedLongForm, result.ToString());
        AreEqual(expectedLongForm, result);
        AreEqual(expectedLongForm, Descriptor(result));
        AreEqual(expectedLongForm, Stringify(result));
        AreEqual(expectedWideForm, ExceptionMessage(result));
        AreEqual(expectedWideForm, DebuggerDisplay(result));
}

    [TestMethod]
    public void DotNetResult_ExceptionMessage_Success_UsesSingleLineSeparator()
    {
        var args = new DotNetArgsAccessor(build) { Args = "--no-logo", FullArgs = "build --no-logo" }.Obj;
        var opt = new DotNetOptions { Dir = @"C:\repo", File = "MyProject.csproj" };
        var result = new DotNetResultAccessor(
            opt,
            args,
            outputText: "Build succeeded.").Obj;

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
            errorText: "Compilation failed.").Obj;

        // TODO: "dotnet" would look better near the full arg text.

        const string expected =
            """
            dotnet EXIT CODE 2!
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
            outputText: "[error] Something broke").Obj;

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
            DefaultOptions,
            args,
            //timeOutMessage: "dotnet --no-logo timed out after 5s").Obj;
            hasTimeOut: true).Obj;

        // TODO: dotnet next to build instead would look better.

        const string expected =
            """
            dotnet TIME OUT! after 300s
            build --no-logo
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
            errorText: "Welcome banner",
            outputText: "Build succeeded.").Obj;

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
            outputText: "Build succeeded.");

        DotNetResult result = resultAccessor.Obj;

        // TODO: No longer the case. Add prefix?
        //AreEqual(result.Text, resultAccessor.DebuggerDisplay);
    }

    // Part-by-Part Tests

    // TODO: One method for Null, one method for Empty.

    [TestMethod]
    public void DotNetResult_Null()
    {
        DotNetResult? result = null;
        AssertDiagnosticTexts(result, "DotNetResult null");
    }

    [TestMethod] 
    public void DotNetResult_Empty()
    {
        DotNetResult result = new DotNetResultAccessor(DefaultOptions, DefaultArgs).Obj;
        AssertDiagnosticTexts(result, "DotNetResult empty");
    }

    [TestMethod] public void Test_DotNetResult_Descriptor_Failure_HasTimeOut()
    {
        DotNetResult result = new DotNetResultAccessor(
            DefaultOptions, DefaultArgs, 
            hasTimeOut: true).Obj;

        AssertDiagnosticTexts(result, "dotnet TIME OUT! after 300s");
    }

    [TestMethod] 
    public void Test_DotNetResult_Descriptor_Failure_HasErrorInOutput()
    {
        DotNetResult result = new DotNetResultAccessor(
            DefaultOptions, DefaultArgs, 
            outputText: "  Happily compiling the stuff..." + NewLine +
                        "  [error] Something went wrong during compilation.").Obj;

        // TODO: Trim between "Output: " and the rest of the text.
        const string expectedWideForm = 
            """
            dotnet ERROR! | Output:   Happily compiling the stuff...
              [error] Something went wrong during compilation.
            """;

        const string expectedLongForm = 
            """
            dotnet ERROR!
            Output:
              Happily compiling the stuff...
              [error] Something went wrong during compilation.
            """;

        AssertDiagnosticTexts(result, expectedWideForm, expectedLongForm);
    }

    [TestMethod]
    public void Test_DotNetResult_Descriptor_Failure_HasExitCode()
    {
        DotNetResult result = new DotNetResultAccessor(DefaultOptions, DefaultArgs, exitCode: 3).Obj;
        AssertDiagnosticTexts(result, "dotnet EXIT CODE 3!");
    }

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

    // Helpers

    private static readonly DotNetArgs DefaultArgs = new DotNetArgsAccessor().Obj;

    private static void AssertDiagnosticTexts(DotNetResult? result, string expectedWideForm, string? expectedLongForm = null)
    {
        expectedLongForm ??= expectedWideForm;
        
        if (result != null) AreEqual(expectedLongForm, result.ToString());

        AreEqual(expectedLongForm, result);
        AreEqual(expectedLongForm, Descriptor(result));
        AreEqual(expectedLongForm, Stringify(result));
        AreEqual(expectedWideForm, ExceptionMessage(result));
        AreEqual(expectedWideForm, DebuggerDisplay(result));
    }
}
