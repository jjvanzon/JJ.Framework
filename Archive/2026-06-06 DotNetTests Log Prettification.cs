    // TODO: Make test console output look better.

    public DotNetOptions TestOpt([Caller] string testName = "")
    {
        return Opt(testName);// with { Verbosity = Detailed };
    }


    // ReSharper disable once UnusedParameter.Global
    internal DotNetOptions OptRelease([Caller] string testName = "") 
        => GetOpt() with
        {
            BuildConf = "Release"
        };


    internal static DotNetOptions NormalToMinimal(DotNetOptions opt)
    {
        if (opt.Verbosity == Normal) return opt with { Verbosity = Minimal };
        return opt;
    }


    /// <summary>
    /// Downgrade verbosity if not very detailed already.
    /// </summary>
    internal static DotNetVerbosity DowngradeNormalTo(DotNetVerbosity to)
    {
        if (Verbosity == Normal) return to;
        // ReSharper disable once HeuristicUnreachableCode
        return Verbosity;
    }


    private static int LogSize(DotNetVerbosity verbosity)
    {
        switch (verbosity)
        {
            case Quiet:
                return 1;
            case Minimal:
                return 2;
            case Normal:
                return 3;
            case Detailed:
                return 4;
            case Diagnostic:
                return 5;
            default:
                return 0;
        }
    }
