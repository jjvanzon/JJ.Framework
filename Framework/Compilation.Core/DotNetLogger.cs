// ReSharper disable MergeIntoPattern

namespace JJ.Framework.Compilation.Core;

internal static class DotNetLogger
{
    private static readonly string e = NewLine;

    public static void LogAction(DotNetArgs args, DotNetOptions opt)
    {
        if (opt.LogAction == NullAction) return;
        string message = GetMessage(opt.Verbosity, args);
        if (Has(message)) opt.LogAction(message);
    }

    public static void LogOutputWithActionIfNeeded(DotNetResult result)
    {
        if (!result.Opt.Verbosity.In(Diagnostic, Detailed)) return;
        if (!Has(result.OutputText)) return;
        if (IsAzurePipelines) return; // HACK: This blows up my CI if I enable Dianostics or Detailed logging (but I need that for binlogs).
        result.Opt.LogAction(result.OutputText);
    }

    public static void WriteLogFileIfNeeded(DotNetResult result)
    {
        if (!Has(result.Opt.LogFile)) return;
        if (!result.HasOutputText && !result.HasErrorText) return;

        if (result.Opt.Verbosity is Normal or Detailed or Diagnostic)
        {
            result.Opt.LogAction("LogFile = " + result.Opt.LogFile);
        }

        using FileStream stream = File.Create(result.Opt.LogFile);
        using StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

        bool bothFilled = result.HasOutputText && result.HasErrorText;

        if (bothFilled)
        {
            writer.WriteLine("Error:");
            writer.WriteLine();
        }

        if (result.HasErrorText)
        {
            writer.Write(result.ErrorText);
        }

        if (bothFilled)
        {
            writer.WriteLine("Output:");
            writer.WriteLine();
        }

        if (result.HasOutputText)
        {
            writer.Write(result.OutputText);
        }
    }

    private static string GetMessage(DotNetVerbosity verbosity, DotNetArgs args) => verbosity switch
    {
        Quiet   => "",
        Minimal => GetMessageMinimal(args),
        Normal  => GetMessageNormal(args),
        _       => GetMessageDetailed(args)
    };

    private static string GetMessageMinimal(DotNetArgs args)
        => FormatCommand(args.CommandEnum) + FormatArgs(args.Args);

    private static string GetMessageNormal(DotNetArgs args) 
        => $"{FormatCommand(args.CommandEnum)}:" + e +
           $"dotnet {args.FullArgs}" + e
           ;

    private static string GetMessageDetailed(DotNetArgs args) 
        => e + 
           FormatCommand(args.CommandEnum) + e + 
           "-----" + e + 
           $"dotnet {args.FullArgs}" + e
           ;

    private static string FormatCommand(DotNetCommandEnum command) => command switch
    {
        build   or msbuild   => "Build",
        rebuild or msrebuild => "Rebuild",
        restore              => "Restore",
        installpackage       => "Install package",
        uninstallpackage     => "Uninstall package",
        _ => ""
    };

    private static string FormatArgs(string args) => Has(args) ? $" with {args}" : "";
}
