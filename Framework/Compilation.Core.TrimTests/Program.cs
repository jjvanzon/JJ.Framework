bool success =
RunTests<DiagnosticsFormatter_DotNetArgs_Tests>() &&
RunTests<DiagnosticsFormatter_DotNetOptions_Tests>() &&
RunTests<DiagnosticsFormatter_DotNetResult_Tests>() &&
RunTests<DotNetArgFormatterTests>() &&
RunTests<DotNetArgsTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<DotNetTests>() &&
RunTests<RunningTargetFrameworkTests>();
WriteLine("Done.");
if (!success) Exit(1);
