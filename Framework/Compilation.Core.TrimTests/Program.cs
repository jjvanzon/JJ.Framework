bool success =
RunTests<DotNetArgBuilderTests>() &&
RunTests<DotNetEnricherTests>() &&
RunTests<DotNetInfoTests>() &&
RunTests<DotNetLoggerTests>() &&
RunTests<DotNetOptionsTests>() &&
RunTests<DotNetTests>() &&
RunTests<RunningTargetFrameworkTests>();
WriteLine("Done.");
if (!success) Exit(1);
