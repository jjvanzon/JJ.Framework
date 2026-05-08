namespace JJ.Framework.Compilation.Core;

/// <inheritdoc cref="_dotnetcommand" />
public enum DotNetCommand
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
