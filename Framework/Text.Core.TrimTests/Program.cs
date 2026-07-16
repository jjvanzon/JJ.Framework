bool success = 
RunTests<StringExtensionsCore_Tests>() &&
RunTests<StringHelperCore_Basics_Tests>() &&
RunTests<StringHelperCore_PrettyByteCount_Tests>() &&
RunTests<StringHelperCore_PrettyTime_Tests>() &&
RunTests<StringHelperCore_ShortGuids_Tests>() &&
RunTests<StringHelperCore_SpacingAndPunctuation_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
