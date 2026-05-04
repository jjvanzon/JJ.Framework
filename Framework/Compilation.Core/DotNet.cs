using static JJ.Framework.Existence.Core.FilledInHelper;

#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core;

public static class DotNet
{
    public static string Build    (DotNetOptions opt) => DotNet.Exe("build",   opt);
    public static string Restore  (DotNetOptions opt) => DotNet.Exe("restore", opt);
    public static string MSBuild  (DotNetOptions opt) => DotNet.Exe("msbuild", opt);
    public static string MSRebuild(DotNetOptions opt) => DotNet.Exe("msbuild", opt with { Args = opt.Args + " /t:Rebuild" });

    // TODO: Variant that returns extended info (split Error and Output and ExitCode etc.)
    // Maybe the returned info should just implicitly convert to string, for syntax sugar.

    /// <param name="command">E.g., "build", "add", "msbuild"</param>
    /// <param name="opt"></param>
    public static string Exe(string command, DotNetOptions opt)
    {
        const string fileName = "dotnet";

        string args = FormatArgs(command, opt);

        using var process = Process.Start(new ProcessStartInfo
        {
            FileName               = fileName,
            Arguments              = args,
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
            // TODO: Add Shim to JJ.Framework.
            #if !NET5_0_OR_GREATER
            process.Kill();
            #else
            process.Kill(entireProcessTree: true);
            #endif
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

            return result;
        }

        throw new Exception(
            $"{fileName} {opt.Args} failed " +
            $"{new { hasExitCode, hasErrorText, hasErrorInOutput, hasTimeOut, args }}: " +
            $"{timeOutMessage} " +
            $"Exit code {process.ExitCode} {error} {output}");
    }

    public static string FormatArgs(string command, DotNetOptions opt)
    {
       ThrowIf(IsNullOrWhiteSpace(command));
       string formattedFile = Has(opt.File) ? @"""" + opt.File + @"""" : "";
       return Join(" ", command, formattedFile, opt.Args);
    }
    
    /// <summary> Returns the TFM string matching the currently-executing runtime, e.g. "net8.0" or "net461". </summary>
    public static string RunningTargetFramework
    {
        get 
        {
            // TODO: This is not reusable; limited to .NET 4.6.1
            if (RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework", OrdinalIgnoreCase))
                return "net461";

            Version ver = Environment.Version;
            return $"net{ver.Major}.{ver.Minor}";
        }
    }

}
