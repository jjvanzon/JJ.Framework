global using System.Diagnostics.CodeAnalysis;
// ReSharper disable RedundantNullableFlowAttribute

namespace JJ.Framework.Compilation.Core;

internal static class DotNetFilledInUtil
{
    public static bool FilledIn([NotNullWhen(true)] DotNetArgs? args)
    {
        if (args == null) 
            return false;

        if (Has(args.IsRebuild))
            return true;

        if (Has(args.CommandEnum))
            return true;

        if (Has(args.Command))
            return true;

        if (Has(args.ID))
            return true;

        if (Has(args.Ver))
            return true;

        if (Has(args.Args))
            return true;

        if (Has(args.FullArgs))
            return true;

        return false;
    }

    public static bool FilledIn(DotNetOptions? opt)
    {
        if (!opt.HasValue) 
            return false;

        return FilledIn(opt.Value);
    }

    public static bool FilledIn(DotNetOptions opt)
    {
        if (opt == default)
            return false;

        if (opt == DefaultOptions)
            return false;

        if (Has(opt.Dir))
            return true;

        if (Has(opt.File))
            return true;

        if (Has(opt.BuildConf))
            return true;

        if (Has(opt.Args))
            return true;

        if (Has(opt.AutoRestore))
            return true;

        if (Has(opt.ParallelRestore))
            return true;

        if (Has(opt.NodeReuse))
            return true;

        if (Has(opt.LogFile))
            return true;

        if (Has(opt.BinLog))
            return true;

        if (Has(opt.TimeOutSec) && opt.TimeOutSec != DefaultOptions.TimeOutSec)
            return true;

        if (Has(opt.Verbosity) && opt.Verbosity != DefaultOptions.Verbosity)
            return true;

        if (Has(opt.LogAction) && opt.LogAction != DefaultOptions.LogAction)
            return true;

        return false;
    }

    public static bool FilledIn(DotNetResult? result)
    {
        if (result == null)
            return false;

        if (Has(result.HasExitCode) || Has(result.ExitCode))
            return true;

        if (Has(result.HasErrorText) || Has(result.ErrorText))
            return true;

        if (Has(result.HasOutputText) || Has(result.OutputText))
            return true;
       
        if (Has(result.HasErrorInOutput))
            return true;

        if (Has(result.HasTimeOut))
            return true;

        if (Has(result.Opt))
            return true;

        if (Has(result.Args))
            return true;

        // Outcommented: These mess with things.

        //if (Has(result.Successful)) 
        //    return true; 
       
        //if (Has(result.Text)) 
        //    return true; 

        return false;
    }
}

public static class DotNetFilledInHelper
{
    public static bool FilledIn([NotNullWhen(true )]      DotNetArgs?    args  ) =>  DotNetFilledInUtil.FilledIn(args);
    public static bool FilledIn([NotNullWhen(true )]      DotNetOptions  opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn([NotNullWhen(true )]      DotNetOptions? opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn([NotNullWhen(true )]      DotNetResult?  result) =>  DotNetFilledInUtil.FilledIn(result);
    public static bool Has     ([NotNullWhen(true )]      DotNetArgs?    args  ) =>  DotNetFilledInUtil.FilledIn(args);
    public static bool Has     ([NotNullWhen(true )]      DotNetOptions  opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool Has     ([NotNullWhen(true )]      DotNetOptions? opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool Has     ([NotNullWhen(true )]      DotNetResult?  result) =>  DotNetFilledInUtil.FilledIn(result);
    public static bool IsNully ([NotNullWhen(false)]      DotNetArgs?    args  ) => !DotNetFilledInUtil.FilledIn(args);
    public static bool IsNully ([NotNullWhen(false)]      DotNetOptions  opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully ([NotNullWhen(false)]      DotNetOptions? opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully ([NotNullWhen(false)]      DotNetResult?  result) => !DotNetFilledInUtil.FilledIn(result);
}

public static class DotNetFilledInExtensions
{
    public static bool FilledIn([NotNullWhen(true )] this DotNetArgs?    args  ) =>  DotNetFilledInUtil.FilledIn(args);
    public static bool FilledIn([NotNullWhen(true )] this DotNetOptions  opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn([NotNullWhen(true )] this DotNetOptions? opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn([NotNullWhen(true )] this DotNetResult?  result) =>  DotNetFilledInUtil.FilledIn(result);
    public static bool IsNully ([NotNullWhen(false)] this DotNetArgs?    args  ) => !DotNetFilledInUtil.FilledIn(args);
    public static bool IsNully ([NotNullWhen(false)] this DotNetOptions  opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully ([NotNullWhen(false)] this DotNetOptions? opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully ([NotNullWhen(false)] this DotNetResult?  result) => !DotNetFilledInUtil.FilledIn(result);
}
