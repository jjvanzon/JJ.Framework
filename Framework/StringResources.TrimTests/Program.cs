bool success = 
RunTests<CommonTitlesFormatterTests>() &&
RunTests<CommonTitlesTests>() &&
RunTests<ResourceStringTesterTests>();

WriteLine("Done.");
if (!success) Exit(1);
