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

```xml
<!--!$(IsAzurePipelines) And--> <!-- Include TrimTest in Azure Pipelines Build step again -->
```

```cs

        // TODO: Replace double quotes and backslashes by single quotes and forward slashes for pretty display.

    //[MethodImpl(NoInlining)] // Visual Studio Test client doesn't find type DotNetArgsFormatter.
//using System.Runtime.CompilerServices;
//using static System.Runtime.CompilerServices.MethodImplOptions;

        //if (Has(result.Text)) return result.Text;

        //if (result.Opt.Dir.FilledIn() && argsPart.Contains(result.Opt.Dir, OrdinalIgnoreCase))
        //if (result.Opt.File.FilledIn() && argsPart.Contains(result.Opt.File, OrdinalIgnoreCase))

        string emptyDescriptor = EmptyDescriptor(args);
        if (Has(emptyDescriptor)) return emptyDescriptor;

        args = args!;

    public static string EmptyDescriptor(DotNetArgs? args)
    {
        if (args == null) return "<null>";
        return null;
    }

    // TODO: Turns out "co command" isn't even a big problem per se,
    //  because if args specify the command anyway, it wouldn't matter.
```