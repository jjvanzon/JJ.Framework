namespace JJ.Framework.Compilation.Core;

internal class DotNetEnricher
{
    public static void EnrichInfo(DotNetCommandInfo info)
    {
        info.Command     = Has(info.Command) ? info.Command : TryFormatCommandEnum(info.CommandEnum);

        info.CommandEnum = info.CommandEnum
                                .Coalesce(TryGetCommandEnum(info.Command, info.IsRebuild))
                                .Coalesce(TryGetCommandEnum(info.Command, info.Args));

        info.IsRebuild   = Has(info.IsRebuild) ? info.IsRebuild : IsRebuild(info.Command, info.Args);
    }
}
