bool success =
RunTests<DotNetArgsFormatterTests>() &&
RunTests<DotNetArgsTests>() &&
RunTests<DotNetCommandFormatterTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<DotNetOptionsFormatterTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<DotNetResultFormatterTests>() &&
RunTests<DotNetTests>() &&
RunTests<RunningTargetFrameworkTests>();
WriteLine("Done.");
if (!success) Exit(1);
