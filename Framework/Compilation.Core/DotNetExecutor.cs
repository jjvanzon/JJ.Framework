namespace JJ.Framework.Compilation.Core;

internal static class DotNetExecutor
{
    /// <inheritdoc cref="_exe" />
    internal static string Exe(DotNetInfo info, DotNetOptions opt = default)
    {
        if (opt == default) 
        {
            opt = DefaultOptions;
        }

        Enrich(info);
        string fullArgs = FormatArgs(info, opt);
        Log(info, opt, fullArgs);

        const string fileName = "dotnet";

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

}