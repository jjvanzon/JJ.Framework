Compilation.Core Logging Scratch Pad

```cs
        //string logDir = AppContext.BaseDirectory; // Put in running process dir, not csproj dir.
        //string logFile = file;
        //if (logFile.IsNully()) 
        //{
        //    logFile = $"{commandEnum}";
        //}
        //logFile = Path.GetFileNameWithoutExtension(logFile);
        //logFile += ".binlog"; 
        //logFile = Path.Combine(logDir, logFile);

    //private readonly DotNetOptions _optNoFile; // with dir only (restore / package commands)

            //Args    = GetBinLogArg(testName) 
            //Args    = GetBinLogArg(testName)

    /*
    /// <summary>
    /// HACK: Add binlogs (temporarily) for dotnet.exe performance degredation test.
    /// </summary>
    private string GetBinLogArg(string testName)
    {
        var filePath = GetBinLogFile(testName);
        return $"-bl:\"{filePath}\"" ;
    }
    */

    //private static string TryFormatBinLogEnabled(DotNetOptions opt, DotNetCommandEnum commandEnum) => TryFormatBinLogEnabled(opt.BinLogEnabled, opt.File, commandEnum);
```