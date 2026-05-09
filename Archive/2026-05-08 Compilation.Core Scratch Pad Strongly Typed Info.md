Transition to Info Object
=========================

`DotNet.cs`
-----------

```cs
// TODO: Variant that returns extended info (split Error and Output and ExitCode etc.)
// Maybe the returned info should just implicitly convert to string, for syntax sugar.

// Temporary for triansition to DTO-like structure.
string command = info.Command;
string args = info.Args;

ThrowIfNull(command);
ThrowIfNull(args);

string fullArgs = FormatArgs(command, args, opt);

RedirectStandardInput  = true,

// Close stdin immediately so the process never blocks waiting for user input.
process.StandardInput.Close();
```

`DotNetLogger.cs`
-----------------

```cs
public static void LogCommand(string command, string args, DotNetOptions opt)
{
    if (opt.Log == NullLog) return;
    if (opt.Verbosity == Quiet) return;
    string message = GetMessage(command, args);
    if (Has(message)) opt.Log(message);
}
```

`DotNetFormatter.cs`
--------------------

```cs
    // TODO: Sanitization

    public static string FormatCommandEnum(DotNetCommandEnum enumVal)
    {
        string text = TryFormatCommandEnum(enumVal);
    
        if (text.IsNully())
        {
            throw new Exception($"Cannot derive command text from {nameof(DotNetCommandEnum)} enum {enumVal}");
        }
    
        return text;
    }

    public static string FormatArgs(string command, string args, DotNetOptions opt)
    {
        ThrowIf(IsNullOrWhiteSpace(command));
        string formattedFile      = FormatFile(opt.File);
        string formattedRestore   = FormatAutoRestore(opt.AutoRestore, command);
        string formattedBuildConf = FormatBuildConf(opt.BuildConf, command);
        string formattedVerbosity = FormatVerbosity(opt.Verbosity, command);
        string[] elements = [ command, formattedFile, formattedBuildConf, formattedVerbosity, opt.Args, args, formattedRestore ]; // HACK: auto-restore put at the end makes `add package` work.
        string ret = Join(" ", elements.Where(FilledIn));
        return ret; 
    }

    public static DotNetCommandEnum GetCommandEnum(string command, string args)
    {
        DotNetCommandEnum commandEnum = TryGetCommandEnum(command, args);
        if (!Has(commandEnum))
        {
            throw new Exception($"Cannot derive DotNetCommand enum from {new { command, args }}");
        }
        return commandEnum;
    }

    private static string FormatAutoRestore(bool autoRestore, string command)
    {
        if (command.Is("add"))     return ""; // Needed?
        if (command.Is("restore")) return "";
        if (command.Is("remove"))  return ""; // Wouldn't this exclusion only apply to packages instead of removing other things?
        if (command.Is("msbuild")) return autoRestore ? "-restore" : "";
        return autoRestore ? "" : "--no-restore";
    }

    private static string FormatBuildConf(string buildConf, string command)
    {
        if (!Has(buildConf)) return "";
        if (command.Is("build")) return $"-c {buildConf}";
        if (command.Is("msbuild")) return $"/p:Configuration={buildConf}";
        return "";
    }

    private static string FormatVerbosity(DotNetVerbosity verbosity, string command)
    {
        if (verbosity == default) return "";
        if (command.Is("build")) return $"--verbosity {verbosity}";
        if (command.Is("msbuild")) return $"-verbosity:{verbosity}";
        return "";
    }
```

More
----

`DotNetEnricher.cs`

```cs

        //info.IsRebuild   = info.IsRebuild
        //                       .Coalesce(IsRebuild(info.CommandEnum))
        //                       .Coalesce(IsRebuild(info.Command, info.Args));

                               //.Coalesce(TryGetCommandEnum(info.Command, info.Args));
```

`DotNetFormatter`

```cs

    // Enum Helpers

    public static string ReArg(DotNetCommandEnum command)
    {
        if (command == rebuild  ) return REBUILD_ARG_DOT_NET;
        if (command == msrebuild) return REBUILD_ARG_MS_BUILD;
        return "";
    }

    //public static bool IsMSBuild(DotNetCommand command) 
    //    => command == msbuild || command == msrebuild;

    //public static string Re(bool re)
    //{
    //    if (re)
    //    if (command.Is("build")) return "--no-incremental";
    //    if (command.Is("msbuild")) return "/t:Rebuild";
    //    return "";
    //}

```