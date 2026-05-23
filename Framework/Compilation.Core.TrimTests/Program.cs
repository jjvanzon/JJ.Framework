bool success =
RunTests<DotNetArgFormatterTests>() &&
RunTests<DotNetArgsDescriptorTests>() &&
RunTests<DotNetArgsTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<DotNetTests>() &&
RunTests<RunningTargetFrameworkTests>();
WriteLine("Done.");
if (!success) Exit(1);
