namespace JJ.Framework.Compilation.Core;

/// <inheritdoc cref="_exe" />
internal static class DotNetExecutor
{
    /// <inheritdoc cref="_exe" />
    internal static DotNetResult Exe(DotNetArgs args, DotNetOptions opt = default)
    {
        if (opt == default) 
        {
            opt = DefaultOptions;
        }

        Enrich(args);
        args.FullArgs = FormatArgs(args, opt);
        Log(args, opt);

        //string temp = args.ToString();

        const string fileName = "dotnet";

        using var process = Process.Start(new ProcessStartInfo
        {
            FileName               = fileName,
            Arguments              = args.FullArgs,
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
        var result = new DotNetResult(opt, args, process.ExitCode, error, output, timeOutMessage);

        result.Assert();

        if (opt.Verbosity.In(Diagnostic, Detailed))
        {
            if (Has(result.OutputText)) 
            {
                opt.Log(result.OutputText);
            }
        }

        return result;
    }
}