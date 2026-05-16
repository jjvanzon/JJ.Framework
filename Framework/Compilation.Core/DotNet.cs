#pragma warning disable IDE0002 // Simplify member access

namespace JJ.Framework.Compilation.Core;

public static class DotNet
{
    public static string Build    (                              ) => DotNet.Exe(build               );
    public static string Build    (             DotNetOptions opt) => DotNet.Exe(build,           opt);
    public static string Build    (string args, DotNetOptions opt) => DotNet.Exe(build,     args, opt);
    public static string Build    (string args                   ) => DotNet.Exe(build,     args     );

    public static string MSBuild  (                              ) => DotNet.Exe(msbuild             );
    public static string MSBuild  (             DotNetOptions opt) => DotNet.Exe(msbuild,         opt);
    public static string MSBuild  (string args, DotNetOptions opt) => DotNet.Exe(msbuild,   args, opt);
    public static string MSBuild  (string args                   ) => DotNet.Exe(msbuild,   args     );

    public static string Rebuild  (                              ) => DotNet.Exe(rebuild             );
    public static string Rebuild  (             DotNetOptions opt) => DotNet.Exe(rebuild,         opt);
    public static string Rebuild  (string args, DotNetOptions opt) => DotNet.Exe(rebuild,   args, opt);
    public static string Rebuild  (string args                   ) => DotNet.Exe(rebuild,   args     );

    public static string MSRebuild(                              ) => DotNet.Exe(msrebuild           );
    public static string MSRebuild(             DotNetOptions opt) => DotNet.Exe(msrebuild,       opt);
    public static string MSRebuild(string args, DotNetOptions opt) => DotNet.Exe(msrebuild, args, opt);
    public static string MSRebuild(string args                   ) => DotNet.Exe(msrebuild, args     );

    public static string Restore  (                              ) => DotNet.Exe(restore             );
    public static string Restore  (             DotNetOptions opt) => DotNet.Exe(restore,         opt);
    public static string Restore  (string args, DotNetOptions opt) => DotNet.Exe(restore,   args, opt);
    public static string Restore  (string args                   ) => DotNet.Exe(restore,   args     );

    public static string InstallPackage(string id, string ver)
        => DotNetExecutor.Exe(new DotNetInfo(installpackage) { ID = id, Ver = ver });

    public static string InstallPackage(string id, string ver, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetInfo(installpackage) { ID = id, Ver = ver }, opt);

    public static string InstallPackage(string id, string ver, string args) 
        => DotNetExecutor.Exe(new DotNetInfo(installpackage) { ID = id, Ver = ver, Args = args });

    public static string InstallPackage(string id, string ver, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetInfo(installpackage) { ID = id, Ver = ver, Args = args }, opt);

    public static string UninstallPackage(string id) 
        => DotNetExecutor.Exe(new DotNetInfo(uninstallpackage) { ID = id });

    public static string UninstallPackage(string id, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetInfo(uninstallpackage) { ID = id }, opt);

    public static string UninstallPackage(string id, string args)
        => DotNetExecutor.Exe(new DotNetInfo(uninstallpackage) { ID = id, Args = args });

    public static string UninstallPackage(string id, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetInfo(uninstallpackage) { ID = id, Args = args }, opt);

    // TODO: Full blown DotNetExe synonym method.

    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command) 
        => DotNetExecutor.Exe(new DotNetInfo(command));

    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command, DotNetOptions opt) 
        => DotNetExecutor.Exe(new DotNetInfo(command), opt);
    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command, string args)
        => DotNetExecutor.Exe(new DotNetInfo(command) { Args = args });

    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetInfo(command) { Args = args }, opt);

    /// <inheritdoc cref="_exe" />
    public static string Exe(string command) 
        => DotNetExecutor.Exe(new DotNetInfo(command));

    /// <inheritdoc cref="_exe" />
    public static string Exe(string command, DotNetOptions opt) 
        => DotNetExecutor.Exe(new DotNetInfo(command), opt);

    /// <inheritdoc cref="_exe" />
    public static string Exe(string command, string args) 
        => DotNetExecutor.Exe(new DotNetInfo(command) { Args = args });

    /// <inheritdoc cref="_exe" />
    public static string Exe(string command, string args, DotNetOptions opt)
        => DotNetExecutor.Exe(new DotNetInfo(command) { Args = args }, opt);

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
            
            ThrowIf(targetFrameworkAttribs.Length != 1);

            // ".NETFramework,Version=v4.6.1" => "net461"
            const string prefix = ".NETFramework,Version=v";
            string frameworkName = targetFrameworkAttribs[0].FrameworkName;
            if (frameworkName.StartsWith(prefix, Ordinal))
            {
                string ver = frameworkName.CutLeft(prefix.Length).Replace(".", "");
                return "net" + ver;
            }

            throw new Exception($"{nameof(RunningTargetFramework)} could not be resolved from {new {frameworkDescription, frameworkName}}.");
        }
    }
}