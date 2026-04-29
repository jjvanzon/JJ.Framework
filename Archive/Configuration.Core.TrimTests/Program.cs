bool success = 
RunTests<CopyConfigTargetsTests>() &&
RunTests<CustomConfigurationManagerCoreTests>();

WriteLine("Done.");
if (!success) Exit(1);
