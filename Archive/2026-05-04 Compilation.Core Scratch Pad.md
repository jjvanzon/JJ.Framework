Compilation.Core Scratch Pad
============================

```cs
    // TODO: Options pattern

//private const int DefaultTimeOutSeconds = 180;

    //public record Options
    //{
    //    public const int DEFAULT_TIME_OUT_SECONDS = 180;
    
    //    public string Dir { get; init; } = "";
    //    public string Args { get; init; } = "";
    //    public int TimeOutSec { get; init; } = DEFAULT_TIME_OUT_SECONDS;
    //}

    //public static string Build(string dir) => Build(dir, "", DefaultTimeOutSeconds);
    //public static string Build(string dir, string args) => Build(dir, args, DefaultTimeOutSeconds);
    //public static string Build(string dir, int timeOutSeconds) => Build(dir, "", timeOutSeconds);
    //public static string Build(string dir, string args, int timeOutSeconds)

    //public static string MSBuild(string dir) => MSBuild(dir, "", DefaultTimeOutSeconds);
    //public static string MSBuild(string dir, string args) => MSBuild(dir, args, DefaultTimeOutSeconds);
    //public static string MSBuild(string dir, int timeOutSeconds) => MSBuild(dir, "", timeOutSeconds);
    //public static string MSBuild(string dir, string args, int timeOutSeconds)
```


```xml
    <!--<TargetFrameworks Condition="'$(IsNCrunch)'=='True'">net10.0;netstandard2.1;netstandard2.0</TargetFrameworks>-->
    <!--<TargetFrameworks>net10.0</TargetFrameworks>-->
```

```cs
        // HACK: auto-restore put at the end makes `add package` work.
        // Problem with that is that it sort of destroys the overriding possibility
        // with `opt.Args` and then `args`.
        // TODO: Make specific FormatArgs for package add/remove?
        //return Join(" ", command, formattedFile, formattedAutoRestore, opt.Args, args);
```


```cs
            //string ver = desc.CutLeft(".NET Framework ").CutRightUntil(".").CutRightUntil(".").Replace(".", "");
                //return "net" + ver;
```

```cs


            if (targetFrameworkAttr?.FrameworkName == null)
            {
            }

                //string ver = desc.CutLeft(".NET Framework ").CutRightUntil(".").CutRightUntil(".").Replace(".", "");
                //return "net" + ver;


                //var match = Match(tfm, @"Version=v(\d+)\.(\d+)(?:\.(\d+))?");
                //if (match.Success)
                //{
                //    string major = match.Groups[1].Value;
                //    string minor = match.Groups[2].Value;
                //    string patch = match.Groups[3].Value;
                //    string version = string.IsNullOrEmpty(patch) ? $"{major}{minor}" : $"{major}{minor}{patch}";
                //    return "net" + version;
                //}

            // ".NETCoreApp,Version=v8.0" → "net8.0"
            //else if (tfm.StartsWith(".NETCoreApp", OrdinalIgnoreCase) || tfm.StartsWith(".NET", OrdinalIgnoreCase))
            //{
            //    var match = Match(tfm, @"Version=v(\d+)\.(\d+)");
            //    if (match.Success)
            //    {
            //        string major = match.Groups[1].Value;
            //        string minor = match.Groups[2].Value;
            //        return $"net{major}.{minor}";
            //    }
            //}

            // Fallback: parse from runtime description
            //if (frameworkDescription.StartsWith(".NET Framework", OrdinalIgnoreCase))
            //{
            //    var match = Match(frameworkDescription, @"\.NET\s+Framework\s+(\d+)\.(\d+)(?:\.(\d+))?");
            //    if (match.Success)
            //    {
            //        string major = match.Groups[1].Value;
            //        string minor = match.Groups[2].Value;
            //        string patch = match.Groups[3].Value;
            //        string version = string.IsNullOrEmpty(patch) ? $"{major}{minor}" : $"{major}{minor}{patch}";
            //        return "net" + version;
            //    }
            //    return "net461";
            //}
```

```cs

    private static void LogCommand(string command, string args, DotNetOptions opt)
    {
        if (opt.Log == NullLog) return;
        if (opt.Verbosity == Quiet) return;
    
        if (command.Is("build") || command.Is("msbuild"))
        {
            var rebuildArg = ReArg(command);
            var isRebuild = args.Contains(rebuildArg, OrdinalIgnoreCase);
            string extraArgs = args.Replace(rebuildArg, "").Trim();
            string formattedExtraArgs = Has(extraArgs) ? " with " + extraArgs : "";
            
            if (isRebuild)
            {
                //opt.Log("Rebuild " + opt.BuildConf + formattedExtraArgs);
                opt.Log("Rebuild" + formattedExtraArgs);
            }
            else
            {
                //opt.Log("Build " + opt.BuildConf + formattedExtraArgs);
                opt.Log("Build" + formattedExtraArgs);
            }
        }
    
        if (command.Is("restore")) opt.Log("Restore");
        if (command.Is("add")) opt.Log("Install package");
        if (command.Is("remove")) opt.Log("Uninstall package");
    }


        DotNetCommand commandEnum = GetCommandEnum(command, args);
        switch (commandEnum)
        {
            case build: case msbuild:
                opt.Log("Build" + FormatArgsForLog(args));
                break;
            case rebuild: case msrebuild:
                opt.Log("Rebuild" + FormatArgsForLog(args));
                break;
            case restore:
                opt.Log("Restore");
                break;
            case installpackage:
                opt.Log("Install package");
                break;
            case uninstallpackage:
                opt.Log("Uninstall package");
                break;
            case undefined:
            default:
                throw new ArgumentOutOfRangeException();
        }
```