DotNet Diagnostics Scratch Pad
==============================

```cs
           bool exitCodeWasAdded = false;

     // ReSharper disable once ConvertToConstant.Local
        string timeOutPart = "";
        //if (result.HasTimeOut)
        //{
        //    timeOutPart = $"after {result.Opt.TimeOutSec}s";
        //}
        
        string exitCodePart = "";
        if (result.HasExitCode && !exitCodeWasAdded)
        {
            exitCodePart = "ExitCode = " + result.ExitCode;
        }
            timeOutPart,
            exitCodePart,


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

    [Prio(1)]
    public static DotNetResult NewResult(
        DotNetArgsAccessor args,
        int exitCode = 0,
        string errorText = "",
        string outputText = "",
        bool hasTimeOut = false) => NewResult(default, args, exitCode, errorText, outputText, hasTimeOut);
```