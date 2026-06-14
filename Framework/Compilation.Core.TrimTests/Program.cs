//WriteLine( $"PID = {ProcessId}. Press a key to continue.");
//ReadKey();

bool success =
RunTests<BuildTests>() &&
RunTests<DotNetArgsFilledInTests>() &&
RunTests<DotNetArgsFormatterTests>() &&
RunTests<DotNetArgsTests>() &&
RunTests<DotNetCmdFormatterTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<DotNetOptionsFilledInTests>() &&
RunTests<DotNetOptionsFormatterTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<DotNetResultFormatterTests>() &&
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
