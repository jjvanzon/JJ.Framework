//WriteLine( $"PID = {ProcessId}. Press a key to continue.");
//ReadKey(true);

bool success =
RunTests<CommonStringExtensionsCore_Obsolete_Tests>() &&
RunTests<ConfigurationHelperCoreTests>() &&
RunTests<EnvironmentHelperCoreTests>() &&
RunTests<FlaggingTests>() &&
RunTests<OverloadByNameTests>();
WriteLine("Done.");
if (!success) Exit(1);
