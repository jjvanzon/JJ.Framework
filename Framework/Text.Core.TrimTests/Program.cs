bool success = 
RunTests<TextCore_Basics_Tests>() &&
RunTests<TextCore_PrettyByteCount_Tests>() &&
RunTests<TextCore_PrettyTime_Tests>() &&
RunTests<TextCore_ShortGuids_Tests>() &&
RunTests<TextCore_SpacingAndPunctuation_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
