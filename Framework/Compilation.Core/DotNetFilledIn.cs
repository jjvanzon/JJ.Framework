namespace JJ.Framework.Compilation.Core;

internal static class DotNetFilledInUtil
{
    public static bool FilledIn(DotNetArgs? args)
    {
        if (args == null) return false;

        if (Has(args.IsRebuild  )) return true;
        if (Has(args.CommandEnum)) return true;
        if (Has(args.Command    )) return true;
        if (Has(args.ID         )) return true;
        if (Has(args.Ver        )) return true;
        if (Has(args.Args       )) return true;
        if (Has(args.FullArgs   )) return true;

        return false;
    }

    public static bool FilledIn(DotNetOptions? opt)
    {
        return opt.HasValue && opt.Value != default && opt.Value != DefaultOptions;
    }

    public static bool FilledIn(DotNetResult? result)
    {
        if (result == null) return false;
        //if (Has(result.Successful       )) return true; // Messes with things
        if (Has(result.HasExitCode      )) return true;
        if (Has(result.HasErrorText     )) return true;
        if (Has(result.HasOutputText    )) return true;
        if (Has(result.HasErrorInOutput )) return true;
        if (Has(result.HasTimeOut       )) return true;
        if (Has(result.ExitCode         )) return true;
        if (Has(result.Opt              )) return true;
        if (Has(result.Args             )) return true;
        //if (Has(result.Text             )) return true; // Messes with things
        if (Has(result.ErrorText        )) return true;
        if (Has(result.OutputText       )) return true;
        if (Has(result.TimeOutMessage   )) return true;
        return false;
    }
}

public static class DotNetFilledInHelper
{
    public static bool FilledIn(     DotNetArgs?    args  ) =>  DotNetFilledInUtil.FilledIn(args);
    public static bool FilledIn(     DotNetOptions  opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn(     DotNetOptions? opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn(     DotNetResult?  result) =>  DotNetFilledInUtil.FilledIn(result);
    public static bool Has     (     DotNetArgs?    args  ) =>  DotNetFilledInUtil.FilledIn(args);
    public static bool Has     (     DotNetOptions  opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool Has     (     DotNetOptions? opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool Has     (     DotNetResult?  result) =>  DotNetFilledInUtil.FilledIn(result);
    public static bool IsNully (     DotNetArgs?    args  ) => !DotNetFilledInUtil.FilledIn(args);
    public static bool IsNully (     DotNetOptions  opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully (     DotNetOptions? opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully (     DotNetResult?  result) => !DotNetFilledInUtil.FilledIn(result);
}

public static class DotNetFilledInExtensions
{
    public static bool FilledIn(this DotNetArgs?    args  ) =>  DotNetFilledInUtil.FilledIn(args);
    public static bool FilledIn(this DotNetOptions  opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn(this DotNetOptions? opt   ) =>  DotNetFilledInUtil.FilledIn(opt);
    public static bool FilledIn(this DotNetResult?  result) =>  DotNetFilledInUtil.FilledIn(result);
    public static bool IsNully (this DotNetArgs?    args  ) => !DotNetFilledInUtil.FilledIn(args);
    public static bool IsNully (this DotNetOptions  opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully (this DotNetOptions? opt   ) => !DotNetFilledInUtil.FilledIn(opt);
    public static bool IsNully (this DotNetResult?  result) => !DotNetFilledInUtil.FilledIn(result);
}
