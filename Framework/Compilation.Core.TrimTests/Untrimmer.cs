// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    
    [NoTrim(AllCtors,                       typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.CommandEnum), typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.Command),     typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.ID),          typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.Ver),         typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.Args),        typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.IsRebuild),   typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.FullArgs),    typeof(DotNetArgs   ))]
    [NoTrim("DebuggerDisplay",              typeof(DotNetArgs   ))]
    [NoTrim("DebuggerDisplay",              typeof(DotNetResult ))]
    [NoTrim("DebuggerDisplay",              typeof(DotNetOptions))]
    [NoTrim("DEFAULT_TIME_OUT_SEC",         typeof(DotNetOptions))]
    [NoTrim("FormatArgs",        $"{MainAsm}.DotNetCommandFormatter", MainAsm)]
    [NoTrim("Enrich",            $"{MainAsm}.DotNetEnricher",         MainAsm)]
    [NoTrim("Log",               $"{MainAsm}.DotNetLogger",           MainAsm)]
    [NoTrim("Descriptor",        $"{MainAsm}.DotNetArgsFormatter",    MainAsm)]
    [NoTrim("Descriptor",        $"{MainAsm}.DotNetOptionsFormatter", MainAsm)]
    [NoTrim("Descriptor",        $"{MainAsm}.DotNetResultFormatter",  MainAsm)]
    [NoTrim("Stringify",         $"{MainAsm}.DotNetArgsFormatter",    MainAsm)]
    [NoTrim("Stringify",         $"{MainAsm}.DotNetOptionsFormatter", MainAsm)]
    [NoTrim("Stringify",         $"{MainAsm}.DotNetResultFormatter",  MainAsm)]
    [NoTrim("DebuggerDisplay",   $"{MainAsm}.DotNetArgsFormatter",    MainAsm)]
    [NoTrim("DebuggerDisplay",   $"{MainAsm}.DotNetOptionsFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",   $"{MainAsm}.DotNetResultFormatter",  MainAsm)]
    [NoTrim("ExceptionMessage",  $"{MainAsm}.DotNetResultFormatter",  MainAsm)]
    [NoTrim("CommandDescriptor", $"{MainAsm}.DotNetArgsFormatter",    MainAsm)]
    [NoTrim("IDVerDescriptor",   $"{MainAsm}.DotNetArgsFormatter",    MainAsm)]
    [NoTrim("ArgsDescriptor",    $"{MainAsm}.DotNetArgsFormatter",    MainAsm)]

    public static void Untrim() { }
}
