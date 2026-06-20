namespace JJ.Framework.Compilation.Core.Formatters;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
internal static class DotNetResultFormatterExtensions
{
    extension(DotNetResult? result)
    {
        public string Stringify() => DotNetResultFormatter.Stringify(result);
        public string DebuggerDisplay() => DotNetResultFormatter.DebuggerDisplay(result);
        public string ExceptionMessage() => DotNetResultFormatter.ExceptionMessage(result);
        public string Descriptor(bool singleLine = false) => DotNetResultFormatter.Descriptor(result, singleLine);
    }
}
// ReSharper restore UnusedType.Global
// ReSharper restore UnusedMember.Global

internal static class DotNetResultFormatter
{
    public static string Stringify(DotNetResult? result) => Has(result?.Text) ? result.Text : Descriptor(result);
    public static string DebuggerDisplay(DotNetResult? result)
    {
        var text = Descriptor(result, singleLine: true);
        text = PrettifySeparators(text); 
        return text;
    }

    public static string ExceptionMessage(DotNetResult? result) => Descriptor(result, singleLine: true);
    public static string Descriptor(DotNetResult? result, bool singleLine = false)
    {
        string sep = singleLine ? " | " : NewLine;

        if (result == null) return nameof(DotNetResult) + " null";
        if (!Has(result)) return nameof(DotNetResult) + " empty";

        string failurePart = "";
        if (result.HasTimeOut)
        {
            failurePart = $"TIME OUT after {result.Opt.TimeOutSec}s";
        }
        else if (result.HasErrorInOutput)
        {
            failurePart = "ERROR";
        }
        else if (result.HasExitCode)
        {
            failurePart = "EXIT CODE " + result.ExitCode + "";
        }

        string dotNetPart = "dotnet ";

        string argsPart = "";
        if (result.Args.FilledIn())
        {
            argsPart = dotNetPart + result.Args.Descriptor();
            dotNetPart = "";
        }

        string optPart = "";
        if (result.Opt.FilledIn())
        {
            optPart = dotNetPart + result.Opt.Descriptor();
            dotNetPart = "";
        }

        // Remove redundancies from opt
        if (Has(optPart))
        {
            if (argsPart.Has(result.Opt.Dir))
            {
                string dirDescriptor = DirDescriptor(result.Opt.Dir);
                if (Has(dirDescriptor)) optPart = optPart.Replace(dirDescriptor, "");
            }

            if (argsPart.Has(result.Opt.File))
            {
                string fileDescriptor = FileDescriptor(result.Opt.File);
                if (Has(fileDescriptor)) optPart = optPart.Replace(fileDescriptor, "");
            }

            if (argsPart.Has(result.Opt.BuildConf))
            {
                string buildConfDescriptor = BuildConfDescriptor(result.Opt);
                if (Has(buildConfDescriptor)) optPart = optPart.Replace(buildConfDescriptor, "");

            }

            if (result.HasTimeOut)
            {
                string timeOutDescriptor = TimeOutDescriptor(result.Opt.TimeOutSec);
                if (Has(timeOutDescriptor)) optPart = optPart.Replace(timeOutDescriptor, "");
            }

            //if (argsPart.Has(result.Opt.Verbosity))
            //{
            //}

            // TODO: This does not seem enough. I think I need my string.Trim(string) overload back.
            const string optSep = " | ";
            optPart = optPart.CutLeft(optSep);
        }

        string sep2 = singleLine ? " " : NewLine;

        string errorTextPart = "";
        if (result.HasErrorText)
        {
            if (result.Successful)
            {
                errorTextPart =  $"{dotNetPart}stdErr:{sep2}{result.ErrorText}";
            }
            else
            {
                errorTextPart =  $"{dotNetPart}Error:{sep2}{result.ErrorText}";
            }
            dotNetPart = "";
        }
        
        string outputTextPart = "";
        if (result.HasOutputText)
        {
            outputTextPart = $"{dotNetPart}Output:{sep2}{result.OutputText}";
            dotNetPart = "";
        }

        failurePart = dotNetPart + failurePart;

        string[] elements = 
        [
            failurePart,
            argsPart,
            optPart,
            errorTextPart,
            outputTextPart
        ];

        var descriptor = Join(sep, elements.Where(FilledIn));
        return descriptor;
    }
}
