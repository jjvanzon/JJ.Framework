// ReSharper disable ReplaceAutoPropertyWithComputedProperty
namespace JJ.Framework.Compilation.Core.Tests;

internal static class Mocks
{
    public const bool Re = true;

    public static DotNetCommandEnum[] FilledCommandEnums { get; } = [ build, rebuild, msbuild, msrebuild, restore, installpackage, uninstallpackage ];
    public static string           [] FilledTexts        { get; } = [ "something", "anything ", "---" ];
    public static string           [] FilledCommands     { get; } = [ "build", "test", "whatevs" ];
    public static string           [] FilledIDs          { get; } = [ ID, "NoID!" ];
    public static string           [] FilledVers         { get; } = [ Ver, "Not a ver" ];
    public static bool             [] FilledBools        { get; } = [ true ];
    public static int              [] FilledTimeOuts     { get; } = [ 123 ];
    public static DotNetVerbosity  [] FilledVerbosities  { get; } = [ Quiet, Minimal, Detailed, Diagnostic ];
    public static Action<string>   [] FilledLogActions   { get; } = [ _ => { }, WriteLine ];
    
    public static bool             [] NullyBools         { get; } = [ false, default ];
    public static DotNetCommandEnum[] NullyCommandEnums  { get; } = [ undefined, default, 0 ];
    public static string?          [] NullyTexts         { get; } = [ " ", "", default, null ];
    public static int              [] NullyTimeOuts      { get; } = [ DefaultOptions.TimeOutSec, default, 0 ];
    public static DotNetVerbosity  [] NullyVerbosities   { get; } = [ DefaultOptions.Verbosity, Undefined, default, 0 ];
    public static Action<string>?  [] NullyLogActions    { get; } = [ DefaultOptions.LogAction, default, null ];

    public const int    FilledExitCode   = 1;
    public const string FilledErrorText  = "Welcome to the .NET CLI!"; // Yes, this is a realistic error text #nosarcasm
    public const string FilledOutputText = "Build successful";
    public const bool   FilledHasTimeOut = true;

    public const int    NullyExitCode    = 0;
    public const string NullyErrorText   = " ";
    public const string NullyOutputText  = " ";
    public const bool   NullyHasTimeOut  = false;


    public static DotNetOptions FilledOpt { get; } = new()
    {
        Dir = FilledTexts[0],
        File = FilledTexts[0],
        BuildConf = FilledTexts[0],
        Args = FilledTexts[0],
        AutoRestore = true,
        ParallelRestore = true,
        NodeReuse = true,
        TimeOutSec = FilledTimeOuts[0],
        Verbosity = FilledVerbosities[0],
        LogFile = FilledTexts[0],
        BinLog = FilledTexts[0],
        LogAction = FilledLogActions[0]
    };
    
    public static readonly DotNetArgs DefaultArgs = new DotNetArgsAccessor();

    public static DotNetArgsAccessor FilledArgs() => new()
    {
        CommandEnum = FilledCommandEnums[0],
        Command = FilledCommands[0],
        ID = FilledIDs[0],
        Ver = FilledVers[0],
        Args = FilledTexts[0],
        FullArgs = FilledTexts[0],
        IsRebuild = true,
    };

    public static DotNetResultAccessor FilledResult(DotNetOptions opt) => new
    (
        opt,
        FilledArgs(),
        FilledExitCode,
        FilledErrorText,
        FilledOutputText,
        FilledHasTimeOut
    );

    public static DotNetResultAccessor FilledResult(DotNetArgs args) => new
    (
        FilledOpt,
        args,
        FilledExitCode,
        FilledErrorText,
        FilledOutputText,
        FilledHasTimeOut
    );
    
    /*
    public static DotNetResultAccessor FilledResult() => new
    (
        FilledOpt,
        FilledArgs(),
        FilledExitCode,
        FilledErrorText,
        FilledOutputText,
        FilledTimeOut
    );
    */

    public static DotNetResult FilledResult(
        int    exitCode   = FilledExitCode,
        string errorText  = FilledErrorText,
        string outputText = FilledOutputText,
        bool   hasTimeOut = FilledHasTimeOut)
        => new DotNetResultAccessor(FilledOpt, FilledArgs(), exitCode, errorText, outputText, hasTimeOut);


    [Prio(1)]
    public static DotNetResult NewResult(
        DotNetArgsAccessor args,
        int exitCode = 0,
        string errorText = "",
        string outputText = "",
        bool hasTimeOut = false) => NewResult(default, args, exitCode, errorText, outputText, hasTimeOut);

    public static DotNetResult NewResult(
        DotNetOptions opt = default,
        DotNetArgsAccessor? args = null,
        int exitCode = 0,
        string errorText = "",
        string outputText = "",
        bool hasTimeOut = false)
        => new DotNetResultAccessor(Coalesce(opt, DefaultOptions), args ?? DefaultArgs, exitCode, errorText, outputText, hasTimeOut);
}
