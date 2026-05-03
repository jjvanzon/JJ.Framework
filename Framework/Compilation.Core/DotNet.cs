namespace JJ.Framework.Compilation.Core;

public static class DotNet
{
    private const int DefaultTimeOutSeconds = 180;

    // TODO: Dir could be optional, if you e.g. specify csproj in the arguments.
    // TODO: Args is a bit leaky, but not sure I want to abstract it so rigorously now.

    public static string Build(string dir) => Build(dir, "", DefaultTimeOutSeconds);
    public static string Build(string dir, string args) => Build(dir, args, DefaultTimeOutSeconds);
    public static string Build(string dir, int timeOutSeconds) => Build(dir, "", timeOutSeconds);
    public static string Build(string dir, string args, int timeOutSeconds)
    {
        ThrowIf(IsNullOrWhiteSpace(dir));

        const string fileName = "dotnet";
        string fullArgs = "build " + args;

        using var process = Process.Start(new ProcessStartInfo
        {
            FileName               = fileName,
            Arguments              = fullArgs,
            WorkingDirectory       = dir,
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
        if (!process.WaitForExit(timeOutSeconds * 1000))
        {
            // TODO: Add Shim to JJ.Framework.
            #if !NET5_0_OR_GREATER
            process.Kill();
            #else
            process.Kill(entireProcessTree: true);
            #endif
            timeOutMessage = $"{fileName} {fullArgs} timed out after {timeOutSeconds}s";
        }

        // .NET may flush async after WaitForExit(int); call the parameterless overload.
        process.WaitForExit();

        var output = outputSB.ToString().TrimEnd();
        var error = errorSB.ToString().Trim();       

        bool hasExitCode = process.ExitCode != 0;
        bool hasErrorText = !IsNullOrWhiteSpace(error);
        bool hasOutput = !IsNullOrWhiteSpace(output);
        bool hasErrorInOutput = output.Contains("[error]");
        bool hasTimeOut = !IsNullOrWhiteSpace(timeOutMessage);
        bool hasError = hasExitCode || hasErrorInOutput | hasTimeOut; // Don't consider error text, which has welcome messages and such in it these days.

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
            $"{fileName} {fullArgs} failed " +
            $"{new { hasExitCode, hasErrorText, hasErrorInOutput, hasTimeOut }}: " +
            $"{timeOutMessage} " +
            $"Exit code {process.ExitCode} {error} {output}");
    }
    
    /// <summary> Returns the TFM string matching the currently-executing runtime, e.g. "net8.0" or "net461". </summary>
    public static string RunningTargetFramework
    {
        get 
        {
            // TODO: This is not reusable; limited to .NET 4.6.1
            if (RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework", OrdinalIgnoreCase))
                return "net461";

            Version v = Environment.Version;
            return $"net{v.Major}.{v.Minor}";
        }
    }

}
