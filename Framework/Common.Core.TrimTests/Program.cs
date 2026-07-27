//WriteLine( $"PID = {ProcessId}. Press a key to continue.");
//ReadKey(true);

bool success =
RunTests<CommonStringExtensionsCore_Obsolete_Tests>() &&
RunTests<ConfigurationHelperCoreTests>() &&
RunTests<CultureHelperCoreTests>() &&
RunTests<EmbeddedResourceHelperLegacyTests>() &&
RunTests<EnvironmentHelperCoreTests>() &&
RunTests<ExceptionTypesCoreTests>() &&
RunTests<FlaggingTests>() &&
RunTests<TrimAllCoreTests>() &&
RunTests<OverloadByNameTests>();
WriteLine("Done.");
if (!success) Exit(1);
