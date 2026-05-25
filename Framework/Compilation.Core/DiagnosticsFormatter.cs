namespace JJ.Framework.Compilation.Core;

internal static partial class DiagnosticsFormatter
{
    public static string Descriptor(DotNetArgs? args, DotNetOptions opt, string sep = " | ")
    {
        // TODO: Remove redundancies from opt when already in args.
        string descriptor = $"{Descriptor(args)}{sep}{Descriptor(opt)}";
        return descriptor;
    }
}
