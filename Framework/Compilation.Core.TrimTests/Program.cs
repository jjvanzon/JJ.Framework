//WriteLine( $"PID = {ProcessId}. Press a key to continue.");
//ReadKey();

bool success =
RunTests<DotNetArgsFormatterTests>() &&
RunTests<DotNetArgsTests>() &&
RunTests<BuildTests>() &&
RunTests<DotNetCommandFormatterTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<DotNetOptionsFormatterTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<DotNetResultFormatterTests>() &&
RunTests<DotNetTests>() &&
RunTests<InstallPackageTests>() &&
RunTests<RebuildTests>() &&
RunTests<RestoreTests>() &&
RunTests<RunningTargetFrameworkTests>();
WriteLine("Done.");

if (!success)
{
    WriteLine("There were errors.");
    Exit(1);
}
