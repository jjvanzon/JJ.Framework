bool success = 
RunTests<CommonTitlesFormatterTestsEx>() &&
RunTests<CommonTitlesTestsEx>() &&
RunTests<MyResourceTests>() &&
RunTests<StringResourceTesterTestsEx>();

WriteLine("Done.");
if (!success) Exit(1);
