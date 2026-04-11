bool success = 
RunTests<CommonTitlesFormatterTests>() &&
RunTests<CommonTitlesTests>() &&
RunTests<StringResourceTesterTests>();

WriteLine("Done.");
if (!success) Exit(1);
