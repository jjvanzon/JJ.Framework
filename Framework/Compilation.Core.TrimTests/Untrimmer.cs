// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Compilation.Core.TrimTests;

internal static class Untrimmer
{
    public const string MainAsm = "JJ.Framework.Compilation.Core";
    
    [NoTrim(AllCtors,                                typeof(DotNetArgs))]
    [NoTrim("set_" + nameof(DotNetArgs.CommandEnum), typeof(DotNetArgs))]
    [NoTrim("set_" + nameof(DotNetArgs.Command),     typeof(DotNetArgs))]
    [NoTrim("set_" + nameof(DotNetArgs.ID),          typeof(DotNetArgs))]
    [NoTrim("set_" + nameof(DotNetArgs.Ver),         typeof(DotNetArgs))]
    [NoTrim("set_" + nameof(DotNetArgs.Args),        typeof(DotNetArgs))]
    [NoTrim("set_" + nameof(DotNetArgs.IsRebuild),   typeof(DotNetArgs))]
    [NoTrim("set_" + nameof(DotNetArgs.FullArgs),    typeof(DotNetArgs))]
    [NoTrim("DEFAULT_TIME_OUT_SEC",               typeof(DotNetOptions))]
    [NoTrim("FormatArgs",        $"{MainAsm}.DotNetArgFormatter",   MainAsm)]
    [NoTrim("Enrich",            $"{MainAsm}.DotNetEnricher",       MainAsm)]
    [NoTrim("Log",               $"{MainAsm}.DotNetLogger",         MainAsm)]
    [NoTrim("Descriptor",        $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("CommandDescriptor", $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("IDVerDescriptor",   $"{MainAsm}.DiagnosticsFormatter", MainAsm)]
    [NoTrim("ArgsDescriptor",    $"{MainAsm}.DiagnosticsFormatter", MainAsm)]

    public static void Untrim() { }
}
