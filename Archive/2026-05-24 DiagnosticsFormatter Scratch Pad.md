FormatLogOptions:

```cs
        if (verbosity == Quiet) return "";
        string callbackFlag = HasLog(log) ? " (callback)": "";
        return $"log {verbosity}" + callbackFlag;

        string formattedVerbosity = Coalesce(verbosity, "");
        string[] elements = [ formattedVerbosity, callbackFlag ];
        return Join(" ", elements.Where(FilledIn));
```

More:

```cs
        string?[] elements;
        string formattedDir = Has(dir) ? $"({dir})" : "";
        elements = [ args, file, dir ];
        elements = [ file, args, dir ];
        return Join(" " , elements.Where(FilledIn));
```


```cs
        if (opt == default       ) return "Default";
        ff (opt == DefaultOptions) return "Default";
        if (!Has(descriptor))
        {
            descriptor = "<no descriptor>";
        }
```

```cs
    public static string DebuggerDisplay(DotNetArgs? args) 
        => nameof(DotNetArgs) + " " + Descriptor(args);
```

`DotNet` utiity:

```cs
    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(DotNetArgs args) 
        => DotNetExecutor.Exe(args.NotNull());

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(DotNetArgs args, DotNetOptions opt) 
        => DotNetExecutor.Exe(args.NotNull(), opt);
```