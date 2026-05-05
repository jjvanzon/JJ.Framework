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