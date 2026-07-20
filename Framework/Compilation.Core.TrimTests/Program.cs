//WriteLine( $"PID = {ProcessId}. Press a key to continue.");
//ReadKey(true);

bool success =
RunTests<DotNetArgsFilledInTests>() &&
RunTests<DotNetOptionsFilledInTests>() &&
RunTests<DotNetResultFilledInTests>() &&
RunTests<DotNetArgsFormatterTests>() &&
RunTests<DotNetCmdFormatterTests>() &&
RunTests<DotNetOptionsFormatterTests>() &&
RunTests<DotNetResultFormatterTests>() &&
RunTests<DotNetArgsTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<BuildTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<InstallPackageTests>() &&
RunTests<MSBuildTests>() &&
RunTests<MSRebuildTests>() &&
RunTests<RebuildTests>() &&
RunTests<RestoreTests>() &&
RunTests<RunningTargetFrameworkTests>() &&
RunTests<UninstallPackageTests>();

WriteLine("Done.");

if (!success)
{
    WriteLine("There were errors.");
    Exit(1);
}
