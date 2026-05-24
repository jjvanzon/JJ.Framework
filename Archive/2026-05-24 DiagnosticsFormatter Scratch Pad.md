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