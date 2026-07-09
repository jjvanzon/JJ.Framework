bool success = 
RunTests<CommonTitlesFormatterTests>() &&
RunTests<CommonTitlesTests>() &&
RunTests<MyResourceTests>() &&
RunTests<StringResourceTesterTests>();

WriteLine("Done.");
if (!success) Exit(1);
