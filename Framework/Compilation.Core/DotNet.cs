
#pragma warning disable IDE0002 // Simplify member access

namespace JJ.Framework.Compilation.Core;

/// <inheritdoc cref="_dotnet" />
public static class DotNet
{
    /// <inheritdoc cref="_build" />
    public static DotNetResult Build    (                              ) => DotNet.Exe(build               );
    /// <inheritdoc cref="_build" />
    public static DotNetResult Build    (             DotNetOptions opt) => DotNet.Exe(build,           opt);
    /// <inheritdoc cref="_build" />
    public static DotNetResult Build    (string args, DotNetOptions opt) => DotNet.Exe(build,     args, opt);
    /// <inheritdoc cref="_build" />
    public static DotNetResult Build    (string args                   ) => DotNet.Exe(build,     args     );

    /// <inheritdoc cref="_msbuild" />
    public static DotNetResult MSBuild  (                              ) => DotNet.Exe(msbuild             );
    /// <inheritdoc cref="_msbuild" />
    public static DotNetResult MSBuild  (             DotNetOptions opt) => DotNet.Exe(msbuild,         opt);
    /// <inheritdoc cref="_msbuild" />
    public static DotNetResult MSBuild  (string args, DotNetOptions opt) => DotNet.Exe(msbuild,   args, opt);
    /// <inheritdoc cref="_msbuild" />
    public static DotNetResult MSBuild  (string args                   ) => DotNet.Exe(msbuild,   args     );

    /// <inheritdoc cref="_rebuild" />
    public static DotNetResult Rebuild  (                              ) => DotNet.Exe(rebuild             );
    /// <inheritdoc cref="_rebuild" />
    public static DotNetResult Rebuild  (             DotNetOptions opt) => DotNet.Exe(rebuild,         opt);
    /// <inheritdoc cref="_rebuild" />
    public static DotNetResult Rebuild  (string args, DotNetOptions opt) => DotNet.Exe(rebuild,   args, opt);
    /// <inheritdoc cref="_rebuild" />
    public static DotNetResult Rebuild  (string args                   ) => DotNet.Exe(rebuild,   args     );

    /// <inheritdoc cref="_msrebuild" />
    public static DotNetResult MSRebuild(                              ) => DotNet.Exe(msrebuild           );
    /// <inheritdoc cref="_msrebuild" />
    public static DotNetResult MSRebuild(             DotNetOptions opt) => DotNet.Exe(msrebuild,       opt);
    /// <inheritdoc cref="_msrebuild" />
    public static DotNetResult MSRebuild(string args, DotNetOptions opt) => DotNet.Exe(msrebuild, args, opt);
    /// <inheritdoc cref="_msrebuild" />
    public static DotNetResult MSRebuild(string args                   ) => DotNet.Exe(msrebuild, args     );

    /// <inheritdoc cref="_restore" />
    public static DotNetResult Restore  (                              ) => DotNet.Exe(restore             );
    /// <inheritdoc cref="_restore" />
    public static DotNetResult Restore  (             DotNetOptions opt) => DotNet.Exe(restore,         opt);
    /// <inheritdoc cref="_restore" />
    public static DotNetResult Restore  (string args, DotNetOptions opt) => DotNet.Exe(restore,   args, opt);
    /// <inheritdoc cref="_restore" />
    public static DotNetResult Restore  (string args                   ) => DotNet.Exe(restore,   args     );

    /// <inheritdoc cref="_installpackage" />
    public static DotNetResult InstallPackage(string id, string ver)
        => DotNetExecutor.Exe(new DotNetArgs(installpackage) { ID = id, Ver = ver });

    /// <inheritdoc cref="_installpackage" />
    public static DotNetResult InstallPackage(string id, string ver, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetArgs(installpackage) { ID = id, Ver = ver }, opt);

    /// <inheritdoc cref="_installpackage" />
    public static DotNetResult InstallPackage(string id, string ver, string args) 
        => DotNetExecutor.Exe(new DotNetArgs(installpackage) { ID = id, Ver = ver, Args = args });

    /// <inheritdoc cref="_installpackage" />
    public static DotNetResult InstallPackage(string id, string ver, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetArgs(installpackage) { ID = id, Ver = ver, Args = args }, opt);

    /// <inheritdoc cref="_uninstallpackage" />
    public static DotNetResult UninstallPackage(string id) 
        => DotNetExecutor.Exe(new DotNetArgs(uninstallpackage) { ID = id });

    /// <inheritdoc cref="_uninstallpackage" />
    public static DotNetResult UninstallPackage(string id, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetArgs(uninstallpackage) { ID = id }, opt);

    /// <inheritdoc cref="_uninstallpackage" />
    public static DotNetResult UninstallPackage(string id, string args)
        => DotNetExecutor.Exe(new DotNetArgs(uninstallpackage) { ID = id, Args = args });

    /// <inheritdoc cref="_uninstallpackage" />
    public static DotNetResult UninstallPackage(string id, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetArgs(uninstallpackage) { ID = id, Args = args }, opt);

    // TODO: Full blown DotNetExe synonym method.

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(DotNetCommandEnum command) 
        => DotNetExecutor.Exe(new DotNetArgs(command));

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(DotNetCommandEnum command, DotNetOptions opt) 
        => DotNetExecutor.Exe(new DotNetArgs(command), opt);
    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(DotNetCommandEnum command, string args)
        => DotNetExecutor.Exe(new DotNetArgs(command) { Args = args });

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(DotNetCommandEnum command, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetArgs(command) { Args = args }, opt);

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(string command) 
        => DotNetExecutor.Exe(new DotNetArgs(command));

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(string command, DotNetOptions opt) 
        => DotNetExecutor.Exe(new DotNetArgs(command), opt);

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(string command, string args) 
        => DotNetExecutor.Exe(new DotNetArgs(command) { Args = args });

    /// <inheritdoc cref="_exe" />
    public static DotNetResult Exe(string command, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetArgs(command) { Args = args }, opt);

    // NOTE:
    // Coverage not measured for RunningTargetFramework.
    // Which code gets hit depends on the framework, 
    // thus can't cover all cover all code for all frameworks.

    // ncrunch: no coverage start

    /// <summary> Returns the TFM string matching the currently-executing assembly, e.g. "net8.0" or "net461". </summary>
    public static string RunningTargetFramework
    {
        get 
        {
            string frameworkDescription = RuntimeInformation.FrameworkDescription;
            if (!frameworkDescription.StartsWith(".NET Framework", Ordinal))
            {
                Version ver = Environment.Version;
                return $"net{ver.Major}.{ver.Minor}";
            }

            // GetCallingAssembly() returns the caller's assembly (e.g. the test project built for net461),
            // not this library's assembly (which targets netstandard2.0).
            var targetFrameworkAttribs = 
                GetCallingAssembly().GetCustomAttributes<TargetFrameworkAttribute>().ToArray();
            
            if (targetFrameworkAttribs.Length != 1) throw new Exception(TextOf(targetFrameworkAttribs.Length != 1));

            // ".NETFramework,Version=v4.6.1" => "net461"
            const string prefix = ".NETFramework,Version=v";
            string frameworkName = targetFrameworkAttribs[0].FrameworkName;
            if (frameworkName.StartsWith(prefix, Ordinal))
            {
                string ver = frameworkName.CutLeft(prefix.Length).Replace(".", "");
                return "net" + ver;
            }

            throw new Exception($"{nameof(RunningTargetFramework)} could not be resolved from {new {frameworkDescription, frameworkName}}."); // ncrunch: no coverage
        }
        // ncrunch: no coverage end
    }
}


