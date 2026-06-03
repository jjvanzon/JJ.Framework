// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    
    // DotNetArgs

    [NoTrim(AllCtors,                       typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.CommandEnum), typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.Command),     typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.ID),          typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.Ver),         typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.Args),        typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.IsRebuild),   typeof(DotNetArgs   ))]
    [NoTrim(nameof(DotNetArgs.FullArgs),    typeof(DotNetArgs   ))]
    [NoTrim("DebuggerDisplay",              typeof(DotNetArgs   ))]

    // DotNetOptions

    [NoTrim("DebuggerDisplay",              typeof(DotNetOptions))]
    [NoTrim("DEFAULT_TIME_OUT_SEC",         typeof(DotNetOptions))]

    // DotNetResult

    [NoTrim("DebuggerDisplay",              typeof(DotNetResult ))]

    // DotNetArgsFormatter

    [NoTrim("Descriptor",         $"{MainAsm}.DotNetArgsFormatter", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.DotNetArgsFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.DotNetArgsFormatter", MainAsm)]
    [NoTrim("CommandDescriptor",  $"{MainAsm}.DotNetArgsFormatter", MainAsm)]
    [NoTrim("IDVerDescriptor",    $"{MainAsm}.DotNetArgsFormatter", MainAsm)]
    [NoTrim("ArgPropsDescriptor", $"{MainAsm}.DotNetArgsFormatter", MainAsm)]

    // DotNetArgsFormatterExtensions

    [NoTrim("Descriptor",         $"{MainAsm}.DotNetArgsFormatterExtensions", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.DotNetArgsFormatterExtensions", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.DotNetArgsFormatterExtensions", MainAsm)]

    // DotNetOptionsFormatter

    [NoTrim("Descriptor",         $"{MainAsm}.DotNetOptionsFormatter", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.DotNetOptionsFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.DotNetOptionsFormatter", MainAsm)]

    // DotNetOptionsExtensions

    [NoTrim("Descriptor",         $"{MainAsm}.DotNetOptionsExtensions", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.DotNetOptionsExtensions", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.DotNetOptionsExtensions", MainAsm)]

    // DotNetResultFormatter

    [NoTrim("Descriptor",         $"{MainAsm}.DotNetResultFormatter", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.DotNetResultFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.DotNetResultFormatter", MainAsm)]
    [NoTrim("ExceptionMessage",   $"{MainAsm}.DotNetResultFormatter", MainAsm)]

    // DotNetResultFormatterExtensions

    [NoTrim("Descriptor",         $"{MainAsm}.DotNetResultFormatterExtensions", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.DotNetResultFormatterExtensions", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.DotNetResultFormatterExtensions", MainAsm)]
    [NoTrim("ExceptionMessage",   $"{MainAsm}.DotNetResultFormatterExtensions", MainAsm)]

    // Services

    [NoTrim("FormatArgs",         $"{MainAsm}.DotNetCommandFormatter", MainAsm)]
    [NoTrim("Enrich",             $"{MainAsm}.DotNetEnricher",         MainAsm)]
    [NoTrim("LogAction",          $"{MainAsm}.DotNetLogger",           MainAsm)]

    public static void Untrim() { }
}
