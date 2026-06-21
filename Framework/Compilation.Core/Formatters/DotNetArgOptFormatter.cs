namespace JJ.Framework.Compilation.Core.Formatters;

internal static class DotNetArgOptFormatter
{
    public static string Descriptor(DotNetArgs? args, DotNetOptions opt, bool singleLine = false, int? maxPathChars = null)
    {
        string commandDescriptor   = "";
        string idVerDescriptor     = "";
        string argPropsDescriptor  = "";
        string buildConfDescriptor = "";
        string restoreDescriptor   = "";
        string logDescriptor       = "";
        string timeOutDescriptor   = "";
        string fileDescriptor      = "";
        string dirDescriptor       = "";
        string optArgsDescriptor   = "";

        if (args != null)
        {
            commandDescriptor = CommandDescriptor(args, noCommandIndicator: "");
            idVerDescriptor = IDVerDescriptor(args);
            argPropsDescriptor = ArgPropsDescriptor(args);

            commandDescriptor = StripCommandDescriptor(commandDescriptor, args);
            idVerDescriptor = StripIDVerDescriptor(idVerDescriptor, args);
        }

        if (opt != default && opt != DefaultOptions)
        {
            if (!args.Has(opt.BuildConf)) 
                buildConfDescriptor = BuildConfDescriptor(opt);

            restoreDescriptor = RestoreDescriptor(opt);
            logDescriptor = LogDescriptor(opt);
            timeOutDescriptor = TimeOutDescriptor(opt);
            
            if (!args.Has(opt.File))
                fileDescriptor = FileDescriptor(opt, maxPathChars);

            if (!args.Has(opt.Dir)) 
                dirDescriptor = DirDescriptor(opt, maxPathChars);

            optArgsDescriptor = opt.Args;
        }


        //if (args.Has(   opt.Dir        )) dirDescriptor       = "";
        //if (args.Has(   opt.File       )) fileDescriptor      = "";
        //if (args.Has(   opt.BuildConf  )) buildConfDescriptor = "";
        if (args.Has(   opt.Args       )) optArgsDescriptor   = "";
        if (args.Has($"{opt.Verbosity}")) logDescriptor = logDescriptor.Replace($"{opt.Verbosity}", "").Trim();

        string[] argElements = 
        [
            commandDescriptor, 
            idVerDescriptor, 
            argPropsDescriptor
        ];

        var argDescriptor = Join(" | ", argElements.Where(FilledIn));

        string[] optElements =
        [
            buildConfDescriptor,
            restoreDescriptor,  
            logDescriptor,      
            timeOutDescriptor,  
            fileDescriptor,
            optArgsDescriptor,
            dirDescriptor
        ];

        var optDescriptor = Join(" | ", optElements.Where(FilledIn));

        string sep = "";

        if (Has(argDescriptor) && 
            Has(optDescriptor))
        {
            sep = singleLine ? " | " : NewLine;
        }

        var descriptor = argDescriptor + sep + optDescriptor;
        return descriptor;
    }
}

