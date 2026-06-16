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
```