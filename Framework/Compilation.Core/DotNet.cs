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

    public static string InstallPackage  (string id, string ver                                ) => DotNet.Exe(installpackage, PackArg(id, ver));
    public static string InstallPackage  (string id, string ver,              DotNetOptions opt) => DotNet.Exe(installpackage, PackArg(id, ver), opt);
    public static string InstallPackage  (string id, string ver, string args                   ) => DotNet.Exe(installpackage, PackArg(id, ver) + " " + args);
    public static string InstallPackage  (string id, string ver, string args, DotNetOptions opt) => DotNet.Exe(installpackage, PackArg(id, ver) + " " + args, opt);

    public static string UninstallPackage(string id                                            ) => DotNet.Exe(new DotNetInfo(uninstallpackage) { PackageID = id }, DefaultOptions);
    public static string UninstallPackage(string id,                          DotNetOptions opt) => DotNet.Exe(new DotNetInfo(uninstallpackage) { PackageID = id }, opt);
    public static string UninstallPackage(string id,             string args                   ) => DotNet.Exe(new DotNetInfo(uninstallpackage) { PackageID = id, Args = args }, DefaultOptions);
    public static string UninstallPackage(string id,             string args, DotNetOptions opt) => DotNet.Exe(new DotNetInfo(uninstallpackage) { PackageID = id, Args = args }, opt);

    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command                                ) => DotNet.Exe(new DotNetInfo(command), DefaultOptions);
    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command,              DotNetOptions opt) => DotNet.Exe(new DotNetInfo(command), opt);
    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command, string args                   ) => DotNet.Exe(new DotNetInfo(command) { Args = args }, DefaultOptions);
    /// <inheritdoc cref="_exe" />
    public static string Exe(DotNetCommandEnum command, string args, DotNetOptions opt) => DotNet.Exe(new DotNetInfo(command) { Args = args }, opt);
    /// <inheritdoc cref="_exe" />
    public static string Exe(string            command                                ) => DotNet.Exe(new DotNetInfo(command), DefaultOptions);
    /// <inheritdoc cref="_exe" />
    public static string Exe(string            command,              DotNetOptions opt) => DotNet.Exe(new DotNetInfo(command), opt);
    /// <inheritdoc cref="_exe" />
    public static string Exe(string            command, string args                   ) => DotNet.Exe(new DotNetInfo(command) { Args = args }, DefaultOptions);
    /// <inheritdoc cref="_exe" />
    public static string Exe(string            command, string args, DotNetOptions opt) => DotNet.Exe(new DotNetInfo(command) { Args = args }, opt);
    /// <inheritdoc cref="_exe" />
    internal static string Exe(DotNetInfo info, DotNetOptions opt)
    {
        Enrich(info);
        Log(info, opt);

        const string fileName = "dotnet";
        string fullArgs = FormatArgs(info, opt);

        using var process = Process.Start(new ProcessStartInfo
        {
            FileName               = fileName,
            Arguments              = fullArgs,
            WorkingDirectory       = opt.Dir,
            RedirectStandardOutput = true,
            RedirectStandardError  = true,
            UseShellExecute        = false,
            CreateNoWindow         = true
        })!;


        var outputSB = new StringBuilder();
        var errorSB = new StringBuilder();
        process.OutputDataReceived += (_, e) => outputSB.AppendLine(e.Data ?? "");
        process.ErrorDataReceived += (_, e) => errorSB.AppendLine(e.Data ?? "");
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
       
        string timeOutMessage = "";
        if (!process.WaitForExit(opt.TimeOutSec * 1000))
        {
            process.Kill(entireProcessTree: true);
            timeOutMessage = $"{fileName} {opt.Args} timed out after {opt.TimeOutSec}s";
        }
        
        // .NET may flush async after WaitForExit(int); call the parameterless overload.
        process.WaitForExit();

        var output = outputSB.ToString().TrimEnd();
        var error  = errorSB .ToString().Trim();       

        bool hasTimeOut       = Has(timeOutMessage);
        bool hasExitCode      = Has(process.ExitCode);
        bool hasErrorText     = Has(error);
        bool hasOutput        = Has(output);
        bool hasErrorInOutput = output.Contains("[error]");
        bool hasError         = hasExitCode || hasErrorInOutput | hasTimeOut; // Don't consider error text, which has welcome messages and such in it these days.

        if (!hasError) 
        {
            string result = 
                Join(NewLine,
                     hasExitCode  ? $"Exit Code = {process.ExitCode}" : "",
                     hasErrorText ? $"Error = {error}" : "",
                     hasOutput    ? $"Output = {output}" : "");

            if (opt.Verbosity.In(Diagnostic, Detailed))
            {
                opt.Log(output);
            }

            return result;
        }

        throw new Exception(
            $"{fileName} {opt.Args} failed " +
            $"{new { hasExitCode, hasErrorText, hasErrorInOutput, hasTimeOut, fullArgs }}: " +
            $"{timeOutMessage} " +
            $"Exit code {process.ExitCode} {error} {output}");
    }

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
