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


    [TestMethod]
    public void FormatArgs_Build_LogFile()
    {
        var args = new DotNetArgsAccessor(build) { Command = "build" }.Obj;
        var opt  = new DotNetOptions { LogFile = "build.log" };

        AreEqual("build --nodereuse:false --no-restore > \"build.log\"", FormatArgs(args, opt));
    }

        //string formattedLogFile         = TryFormatLogFile        (opt.LogFile,         args.CommandEnum);  

            //formattedLogFile // Add at the end to use cmd > operator


    /*
    // ReSharper disable once UnusedParameter.Local
    private static string TryFormatLogFile(string logFile, DotNetCommandEnum commandEnum)
    {
        if (logFile.IsNully()) 
        {
            return "";
        }

        //if (commandEnum is not (build or rebuild or msbuild or msrebuild)) 
        //{
        //    return "";
        //}
           
        return $"> \"{logFile}\"";
    }
    */

    /// <summary>
    /// TODO: Rename Log and NullLog to something more specific since there are more log options now to distinguish.
    ///  "Logger" as a name is in use by DotNetLogger, so that also doesn't work.
    /// </summary>
```