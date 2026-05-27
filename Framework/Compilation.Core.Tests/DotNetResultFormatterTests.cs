namespace JJ.Framework.Compilation.Core.Tests;

using static DotNetResultFormatterAccessor;

[TestClass]
public class DotNetResultFormatterTests
{
    [TestMethod]
    public void DotNetResultFormatter_Success_WithArgsOptOutputText()
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
        
        AssertDiagnosticTexts(result, expectedWideForm, expectedLongForm);
    }

    [TestMethod]
    public void DotNetResultFormatter_Failure_ExitCode_WithArgsErrorText()
    {
        var args = new DotNetArgsAccessor(build)
        { 
            Args = "--no-logo", 
            FullArgs = "build --no-logo"
        }.Obj;

        var result = new DotNetResultAccessor(
            default,
            args,
            exitCode: 2,
            errorText: "Project or solution not found!").Obj;

        // TODO: "dotnet" would look better near the full arg text.

        const string expectedWideForm =
            "dotnet EXIT CODE 2! | build --no-logo | Error: Project or solution not found!";

        const string expectedLongForm =
            """
            dotnet EXIT CODE 2!
            build --no-logo
            Error:
            Project or solution not found!
            """;

        AssertDiagnosticTexts(result, expectedWideForm, expectedLongForm);
    }

    [TestMethod]
    public void DotNetResultFormatter_Failure_ErrorInOutput_WithArgs()
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

        const string expectedWideForm =
            "dotnet ERROR! | build --no-logo | Output: [error] Something broke";

        const string expectedLongForm =
            """
            dotnet ERROR!
            build --no-logo
            Output:
            [error] Something broke
            """;

        AssertDiagnosticTexts(result, expectedWideForm, expectedLongForm);
    }

    [TestMethod]
    public void DotNetResultFormatter_Failure_TimeOut_WithArgs()
    {
        var args = new DotNetArgsAccessor(build)
        {
            Args = "--no-logo", 
            FullArgs = "build --no-logo"
        }.Obj;

        var result = new DotNetResultAccessor(
            DefaultOptions,
            args,
            hasTimeOut: true).Obj;

        // TODO: dotnet next to build instead would look better.

        const string expectedWideForm =
            "dotnet TIME OUT! after 300s | build --no-logo";

        const string expectedLongForm =
            """
            dotnet TIME OUT! after 300s
            build --no-logo
            """;

        AssertDiagnosticTexts(result, expectedWideForm, expectedLongForm);
    }

    [TestMethod]
    public void DotNetResultFormatter_Success_WithStdErr_WithArgs()
    {
        var args = new DotNetArgsAccessor(build)
        { 
            Args = "--no-logo", 
            FullArgs = "build --no-logo"
        }.Obj;

        var result = new DotNetResultAccessor(
            default,
            args,
            errorText: "Welcome banner",
            outputText: "Build succeeded.").Obj;

        const string expectedWideForm =
            "dotnet build --no-logo | stdErr: Welcome banner | Output: Build succeeded.";

        const string expectedLongForm =
            """
            dotnet build --no-logo
            stdErr:
            Welcome banner
            Output:
            Build succeeded.
            """;

        AssertDiagnosticTexts(result, expectedWideForm, expectedLongForm);
    }

    // Part-by-Part Tests

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

    [TestMethod] public void Test_DotNetResultFormatter_Failure_HasTimeOut()
    {
        DotNetResult result = new DotNetResultAccessor(
            DefaultOptions, DefaultArgs, 
            hasTimeOut: true).Obj;

        AssertDiagnosticTexts(result, "dotnet TIME OUT! after 300s");
    }

    [TestMethod] 
    public void Test_DotNetResultFormatter_Failure_HasErrorInOutput()
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
    public void Test_DotNetResultFormatter_Failure_HasExitCode()
    {
        DotNetResult result = new DotNetResultAccessor(DefaultOptions, DefaultArgs, exitCode: 3).Obj;
        AssertDiagnosticTexts(result, "dotnet EXIT CODE 3!");
    }

    //[TestMethod] public void Test_DotNetResultFormatter_Failure_PriorityOrder() => throw new NotImplementedException();
    //[TestMethod] public void Test_DotNetResultFormatter_Failure_None() => throw new NotImplementedException();

    /*
    [TestMethod] public void Test_DotNetResultFormatter_Args() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResultFormatter_Opt() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResultFormatter_TimeOut() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResultFormatter_ExitCode() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResultFormatter_ErrorText_WithSuccess() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResultFormatter_ErrorText_WithFailure() => throw new NotImplementedException();
    [TestMethod] public void Test_DotNetResultFormatter_OutputText() => throw new NotImplementedException();
    
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
