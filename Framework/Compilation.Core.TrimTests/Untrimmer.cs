// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    
    // DotNetArgs

    [NoTrim(AllCtors,                       typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.CommandEnum), typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.Command),     typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.ID),          typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.Ver),         typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.Args),        typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.IsRebuild),   typeof(DotNetArgs))]
    [NoTrim(nameof(DotNetArgs.FullArgs),    typeof(DotNetArgs))]
    [NoTrim("DebuggerDisplay",              typeof(DotNetArgs))]

    // DotNetOptions

    [NoTrim("DebuggerDisplay",      typeof(DotNetOptions))]

    // DotNetResult

    [NoTrim("DebuggerDisplay", typeof(DotNetResult))]

    // DotNetArgsFormatter

    [NoTrim("Descriptor",                   $"{MainAsm}.Formatters.DotNetArgsFormatter", MainAsm)]
    [NoTrim("Stringify",                    $"{MainAsm}.Formatters.DotNetArgsFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",              $"{MainAsm}.Formatters.DotNetArgsFormatter", MainAsm)]
    [NoTrim("CommandDescriptor",            $"{MainAsm}.Formatters.DotNetArgsFormatter", MainAsm)]
    [NoTrim("IDVerDescriptor",              $"{MainAsm}.Formatters.DotNetArgsFormatter", MainAsm)]
    [NoTrim("ArgPropsDescriptor",           $"{MainAsm}.Formatters.DotNetArgsFormatter", MainAsm)]
    [NoTrim("DEFAULT_NO_COMMAND_INDICATOR", $"{MainAsm}.Formatters.DotNetArgsFormatter", MainAsm)]

    // DotNetArgsFormatterExtensions

    [NoTrim("Descriptor",         $"{MainAsm}.Formatters.DotNetArgsFormatterExtensions", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.Formatters.DotNetArgsFormatterExtensions", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.Formatters.DotNetArgsFormatterExtensions", MainAsm)]

    // DotNetOptionsFormatter

    [NoTrim("Descriptor",         $"{MainAsm}.Formatters.DotNetOptionsFormatter", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.Formatters.DotNetOptionsFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.Formatters.DotNetOptionsFormatter", MainAsm)]

    // DotNetOptionsExtensions

    [NoTrim("Descriptor",         $"{MainAsm}.Formatters.DotNetOptionsExtensions", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.Formatters.DotNetOptionsExtensions", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.Formatters.DotNetOptionsExtensions", MainAsm)]

    // DotNetResultFormatter

    [NoTrim("Descriptor",         $"{MainAsm}.Formatters.DotNetResultFormatter", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.Formatters.DotNetResultFormatter", MainAsm)]
    [NoTrim("DebuggerDisplay",    $"{MainAsm}.Formatters.DotNetResultFormatter", MainAsm)]
    [NoTrim("ExceptionMessage",   $"{MainAsm}.Formatters.DotNetResultFormatter", MainAsm)]

    // DotNetResultFormatterExtensions

    [NoTrim("Descriptor",         $"{MainAsm}.Formatters.DotNetResultFormatterExtensions", MainAsm)]
    [NoTrim("Stringify",          $"{MainAsm}.Formatters.DotNetResultFormatterExtensions", MainAsm)]
    [NoTrim("ExceptionMessage",   $"{MainAsm}.Formatters.DotNetResultFormatterExtensions", MainAsm)]

    // Services

    [NoTrim("FormatArgs",         $"{MainAsm}.Formatters.DotNetCmdFormatter", MainAsm)]
    [NoTrim("Enrich",             $"{MainAsm}.DotNetEnricher",                    MainAsm)]
    [NoTrim("LogAction",          $"{MainAsm}.DotNetLogger",                      MainAsm)]

    public static void Untrim() { }
}
