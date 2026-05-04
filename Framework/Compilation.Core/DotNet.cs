using static JJ.Framework.Existence.Core.FilledInHelper;

#pragma warning disable IDE0002

namespace JJ.Framework.Compilation.Core;

public static class DotNet
{
    public static string Build  (DotNetOptions options) => DotNet.Exe(options with { Command = "build"   });
    public static string MSBuild(DotNetOptions options) => DotNet.Exe(options with { Command = "msbuild" });

    // TODO: Variant that returns extended info (split Error and Output and ExitCode etc.)
    // Maybe the returned info should just implicitly convert to string, for syntax sugar.
    public static string Exe(DotNetOptions options)
    {
        const string fileName = "dotnet";

        string args = FormatArgs(options);

        using var process = Process.Start(new ProcessStartInfo
        {
            FileName               = fileName,
            Arguments              = args,
            WorkingDirectory       = options.Dir,
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
        if (!process.WaitForExit(options.TimeOutSec * 1000))
        {
            // TODO: Add Shim to JJ.Framework.
            #if !NET5_0_OR_GREATER
            process.Kill();
            #else
            process.Kill(entireProcessTree: true);
            #endif
            timeOutMessage = $"{fileName} {options.Args} timed out after {options.TimeOutSec}s";
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
            $"{fileName} {options.Args} failed " +
            $"{new { hasExitCode, hasErrorText, hasErrorInOutput, hasTimeOut }}: " +
            $"{timeOutMessage} " +
            $"Exit code {process.ExitCode} {error} {output}");
    }

    private static string FormatArgs(DotNetOptions options)
    {
       var formattedFile = Has(options.File) ? @"""" + options.File + @"""" : "";
       return options.Command + " " + formattedFile + " " + options.Args;
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
