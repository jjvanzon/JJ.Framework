//WriteLine( $"PID = {ProcessId}. Press a key to continue.");
//ReadKey();

bool success =
RunTests<BuildTests>() &&
RunTests<DotNetArgsFormatterTests>() &&
RunTests<DotNetArgsTests>() &&
RunTests<DotNetCmdFormatterTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<DotNetOptionsFormatterTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<DotNetResultFormatterTests>() &&
RunTests<DotNetTests>() &&
RunTests<InstallPackageTests>() &&
RunTests<MSBuildTests>() &&
RunTests<MSRebuildTests>() &&
RunTests<RebuildTests>() &&
RunTests<RestoreTests>() &&
RunTests<RunningTargetFrameworkTests>();
WriteLine("Done.");

if (!success)
{
    WriteLine("There were errors.");
    Exit(1);
}
