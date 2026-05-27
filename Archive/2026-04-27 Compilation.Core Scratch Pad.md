
```cs
    public static implicit operator DotNetArgs?([NotNullIfNotNull(nameof(accessor))] DotNetArgsAccessor? accessor) => accessor?.Obj;

    //public static implicit operator DotNetResult?([System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute(nameof(accessor))] DotNetResultAccessor? accessor) => accessor?.Obj;
    public static implicit operator DotNetResult?([NotNullIfNotNull(nameof(accessor))] DotNetResultAccessor? accessor) => accessor?.Obj;

    //public static bool Has     (     DotNetArgs?    args) => FilledIn(args);
    //public static bool Has     (     DotNetOptions? opt ) => FilledIn(opt);
    //public static bool IsNully (     DotNetArgs?    args) => !FilledIn(args);
    //public static bool IsNully (     DotNetOptions? opt ) => !FilledIn(opt);

    //private const string DotNetArgsNull = "<null>";

        //string argsPart = $"{Descriptor(result.Args)}{sep}{Descriptor(result.Opt)}";

```
