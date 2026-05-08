Transition to Info Object
=========================

`DotNet.cs`:

```cs
    // TODO: Variant that returns extended info (split Error and Output and ExitCode etc.)
    // Maybe the returned info should just implicitly convert to string, for syntax sugar.


        // Temporary for triansition to DTO-like structure.
        //string command = info.Command;
        //string args = info.Args;

        //ThrowIfNull(command);
        //ThrowIfNull(args);

        //string fullArgs = FormatArgs(command, args, opt);

            //RedirectStandardInput  = true,

        // Close stdin immediately so the process never blocks waiting for user input.
        //process.StandardInput.Close();
```

`DotNetLogger.cs`:

```cs
    //public static void LogCommand(string command, string args, DotNetOptions opt)
    //{
    //    if (opt.Log == NullLog) return;
    //    if (opt.Verbosity == Quiet) return;
    //    string message = GetMessage(command, args);
    //    if (Has(message)) opt.Log(message);
    //}
```

`DotNetFormatter.cs`

```cs
    // TODO: Sanitization

    //public static string FormatCommandEnum(DotNetCommandEnum enumVal)
    //{
    //    string text = TryFormatCommandEnum(enumVal);
    //
    //    if (text.IsNully())
    //    {
    //        throw new Exception($"Cannot derive command text from {nameof(DotNetCommandEnum)} enum {enumVal}");
    //    }
    //
    //    return text;
    //}

    //public static string FormatArgs(string command, string args, DotNetOptions opt)
    //{
    //    ThrowIf(IsNullOrWhiteSpace(command));
    //    string formattedFile      = FormatFile(opt.File);
    //    string formattedRestore   = FormatAutoRestore(opt.AutoRestore, command);
    //    string formattedBuildConf = FormatBuildConf(opt.BuildConf, command);
    //    string formattedVerbosity = FormatVerbosity(opt.Verbosity, command);
    //    string[] elements = [ command, formattedFile, formattedBuildConf, formattedVerbosity, opt.Args, args, formattedRestore ]; // HACK: auto-restore put at the end makes `add package` work.
    //    string ret = Join(" ", elements.Where(FilledIn));
    //    return ret; 
    //}

    //public static DotNetCommandEnum GetCommandEnum(string command, string args)
    //{
    //    DotNetCommandEnum commandEnum = TryGetCommandEnum(command, args);
    //    if (!Has(commandEnum))
    //    {
    //        throw new Exception($"Cannot derive DotNetCommand enum from {new { command, args }}");
    //    }
    //    return commandEnum;
    //}
```

