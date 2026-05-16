namespace JJ.Framework.Compilation.Core;

// TODO: Rename to CommandEnum? Or just Command?

/// <inheritdoc cref="_dotnetcommandenum" />
public enum DotNetCommandEnum
{
    // ReSharper disable once UnusedMember.Global
    undefined,
    build,
    rebuild,
    msbuild,
    msrebuild,
    restore,
    installpackage,
    uninstallpackage
}
