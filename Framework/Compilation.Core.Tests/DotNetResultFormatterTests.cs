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

        var result = new DotNetResultAccessor(args: args, exitCode: 2, errorText: "Project not found!").Obj;

        // TODO: "dotnet" would look better near the full arg text.

        const string expectedWideForm =
            "dotnet EXIT CODE 2! | build --no-logo | Error: Project not found!";

        const string expectedLongForm =
            """
            dotnet EXIT CODE 2!
            build --no-logo
            Error:
            Project not found!
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

        var result = new DotNetResultAccessor(args: args, outputText: "[error] Something broke").Obj;

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

        var result = new DotNetResultAccessor(args: args, hasTimeOut: true).Obj;

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
            args: args,
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

    // Error States

    [TestMethod]
    public void DotNetResult_Null() => AssertDiagnosticTexts(null, "DotNetResult null");

    [TestMethod] 
    public void DotNetResult_Empty() 
        => AssertDiagnosticTexts(new DotNetResultAccessor().Obj, "DotNetResult empty");

    [TestMethod] 
    public void Test_DotNetResultFormatter_TimeOut()
    {
        AssertDiagnosticTexts(new DotNetResultAccessor(hasTimeOut: true).Obj, "dotnet TIME OUT! after 300s");
    }

    [TestMethod] 
    public void Test_DotNetResultFormatter_Failure_HasErrorInOutput()
    {
        DotNetResult result = new DotNetResultAccessor(
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
    public void Test_DotNetResultFormatter_ExitCode() 
        => AssertDiagnosticTexts(new DotNetResultAccessor(exitCode: 3).Obj, "dotnet EXIT CODE 3!");

    //[TestMethod] public void Test_DotNetResultFormatter_Failure_PriorityOrder() => throw new NotImplementedException();
    //[TestMethod] public void Test_DotNetResultFormatter_Failure_None() => throw new NotImplementedException();

    //[TestMethod] public void Test_DotNetResultFormatter_ErrorText_WithSuccess() => throw new NotImplementedException();
    //[TestMethod] public void Test_DotNetResultFormatter_ErrorText_WithFailure() => throw new NotImplementedException();

    // Part-by-Part Tests

    [TestMethod]
    public void Test_DotNetResultFormatter_OutputText()
    {
        var result = new DotNetResultAccessor(outputText: "I am happy to inform you of this output text.").Obj;

        const string expectedWideForm = 
            "dotnet Output: I am happy to inform you of this output text.";

        const string expectedLongForm = 
            """
            dotnet Output:
            I am happy to inform you of this output text.
            """;

        AssertDiagnosticTexts(result, expectedWideForm, expectedLongForm);
    }

    [TestMethod]
    public void Test_DotNetResultFormatter_Opt_Dir()
    {
        AssertDiagnosticTexts(NewResult(opt: new() { 
            Dir = @"C:\Repositories\FunProject" }), 
            @"dotnet Dir = C:\Repositories\FunProject");
        // TODO: Test a longer path too.
    }

    [TestMethod] 
    public void Test_DotNetResultFormatter_Opt_File()
    {
        AssertDiagnosticTexts(NewResult(opt: new() { 
            File = "FunProject.csproj" }), 
            "dotnet FunProject.csproj");
        // TODO: Test a longer path too.
    }

    [TestMethod] 
    public void Test_DotNetResultFormatter_Opt_BuildConf() 
        => AssertDiagnosticTexts(NewResult(opt: new() { 
            BuildConf = "Release" }), 
            """
            dotnet "Release"
            """);

    [TestMethod] 
    public void Test_DotNetResultFormatter_Opt_Args() 
        => AssertDiagnosticTexts(NewResult(opt: new() { 
            Args = "--help" }), 
            "dotnet --help");

    // TODO: Fails: result ToString says "dotnet default". Problem: verbosity without Log method.
    /*
    [TestMethod] 
    public void Test_DotNetResultFormatter_Opt_Verbosity() 
        => AssertDiagnosticTexts(NewResult(opt: new() { 
            Verbosity = Quiet }), 
            "dotnet | Log Quiet");
    */        

    // TODO: Maybe a pipeline after dotnet would be nice? Not sure
    //   Pipeline character between command line parts and property parts?

    [TestMethod]
    public void Test_DotNetResultFormatter_Opt_AutoRestore() 
        => AssertDiagnosticTexts(NewResult(opt: new() { 
            AutoRestore = true }), 
            "dotnet Restore: Auto");
    
    [TestMethod] 
    public void Test_DotNetResultFormatter_Opt_ParallelRestore() 
        => AssertDiagnosticTexts(NewResult(opt: new() { 
            ParallelRestore = true }), 
            "dotnet Restore: Parallel");

    [TestMethod]
    public void Test_DotNetResultFormatter_Opt_TimeOutSec()
        => AssertDiagnosticTexts(NewResult(opt: new() { 
            TimeOutSec = 123 }), 
            "dotnet Timeout: 123s");
    
    [TestMethod] 
    public void Test_DotNetResultFormatter_Opt_Log() 
        => AssertDiagnosticTexts(NewResult(opt: new() { 
            Log = WriteLine }), 
            "dotnet Log");
    
    [TestMethod] public void Test_DotNetResultFormatter_Arg_CommandEnum() 
        => AssertDiagnosticTexts(NewResult(arg: new() { 
            CommandEnum = build }), 
            "dotnet build");

    [TestMethod] 
    public void Test_DotNetResultFormatter_Arg_Command() 
        => AssertDiagnosticTexts(NewResult(arg: new() { 
            Command = "nuget" }), 
            "dotnet nuget");

    // TODO: <no command> didn't show up in the other incomplete results.
    [TestMethod] 
    public void Test_DotNetResultFormatter_Arg_ID() 
        => AssertDiagnosticTexts(NewResult(arg: new() { 
            ID = "JJ.Framework.Common" }), 
            "dotnet <no command> JJ.Framework.Common");

    [TestMethod] 
    public void Test_DotNetResultFormatter_Arg_Ver() 
        => AssertDiagnosticTexts(NewResult(arg: new() { 
            Ver = "1.0.0" }), 
            "dotnet <no command> 1.0.0");

    // TODO: Turns out "co command" isn't even a big problem per se,
    //  because if args specify the command anyway, it wouldn't matter.
    // TODO: Pipeline might work well, to signal there are Args but not yet FullArgs.
    //  But it probably got there because of a hard `opt + sep + args`.

    [TestMethod] 
    public void Test_DotNetResultFormatter_Arg_Args()
        => AssertDiagnosticTexts(NewResult(arg: new() { 
            Args = "--p:BuildNum=1234" }), 
            "dotnet <no command> | --p:BuildNum=1234");

    [TestMethod] public void Test_DotNetResultFormatter_Arg_IsRebuild()
        => AssertDiagnosticTexts(NewResult(arg: new() { 
            IsRebuild = true }), 
            "dotnet (re-)<no command>");

    // TODO: "dotnet --p:BuildNum=1234" would be better. "<no commmand>" and " | " are irrenevant
    [TestMethod] 
    public void Test_DotNetResultFormatter_Arg_FullArgs()
        => AssertDiagnosticTexts(NewResult(arg: new() { 
            FullArgs = "--p:BuildNum=1234" }), 
            "dotnet <no command> | --p:BuildNum=1234");

    // Helpers

    private static DotNetResult NewResult(DotNetOptions opt) => new DotNetResultAccessor(opt).Obj;
    private static DotNetResult NewResult(DotNetArgsAccessor arg) => new DotNetResultAccessor(args: arg.Obj).Obj;

    private static void AssertDiagnosticTexts(DotNetResult? result, string expectedWideForm, string? expectedLongForm = null)
    {
        expectedLongForm ??= expectedWideForm;
        
        if (result != null) AreEqual(expectedLongForm, result.ToString());

        AreEqual(expectedLongForm, result);
        AreEqual(expectedLongForm, Descriptor(result));
        AreEqual(expectedLongForm, Stringify(result));
        AreEqual(expectedWideForm, ExceptionMessage(result));

        // TODO: Should the debugger display even contain the entire output?
        // ... TODO: This one should have no double quotes or backslashes, just single quotes and foreward ones.
        string expectedDebuggerDisplay = expectedWideForm;
        //expectedDebuggerDisplay = expectedDebuggerDisplay.Replace('\\', '/')
        //                                                 .Replace('"', '\'');
        AreEqual(expectedDebuggerDisplay, DebuggerDisplay(result));
    }
}
