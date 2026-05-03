
namespace JJ.Framework.Compilation.Core;

public static class DotNet
{
    private const int DefaultTimeOutSeconds = 180;

    // TODO: Dir could be optional, if you e.g. specify csproj in the arguments.
    // TODO: Args is a bit leaky, but not sure I want to abstract it so rigorously now.

    public static void Build(string dir) => Build(dir, "", DefaultTimeOutSeconds);
    public static void Build(string dir, string args) => Build(dir, args, DefaultTimeOutSeconds);
    public static void Build(string dir, int timeOutSeconds) => Build(dir, "", timeOutSeconds);
    public static void Build(string dir, string args, int timeOutSeconds)
    {
        ThrowIf(IsNullOrWhiteSpace(dir));

        const string fileName = "dotnet";
        // Seems to give time-outs in CI during/after restore. Execute restore first separately for all TFMs?
        //string arguments = $"build -p:TargetFramework={GetTargetFramework()}";
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
        // ncrunch: no coverage start
        {
            // TODO: Add Shim to JJ.Framework.
            #if !NET5_0_OR_GREATER
            process.Kill();
            #else
            process.Kill(entireProcessTree: true);
            #endif
            timeOutMessage = $"{fileName} {fullArgs} timed out after {timeOutSeconds}s";
        }
        // ncrunch: no coverage end

        // .NET may flush async after WaitForExit(int); call the parameterless overload.
        process.WaitForExit();

        var output = outputSB.ToString().TrimEnd();
        var error = errorSB.ToString().Trim();       

        bool hasExitCode = process.ExitCode != 0;
        bool hasErrorText = !IsNullOrWhiteSpace(error);
        bool hasErrorInOutput = output.Contains("[error]");
        bool hasTimeOut = !IsNullOrWhiteSpace(timeOutMessage);
        bool hasError = hasExitCode || hasErrorInOutput | hasTimeOut; // Don't consider error text, which has welcome messages and such in it these days.

        if (!hasError) return;

        // ncrunch: no coverage start
        throw new Exception(
            $"{fileName} {fullArgs} failed " +
            $"{new { hasExitCode, hasErrorText, hasErrorInOutput, hasTimeOut }}: " +
            $"{timeOutMessage} " +
            $"Exit code {process.ExitCode} {error} {output}");
        // ncrunch: no coverage end
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
