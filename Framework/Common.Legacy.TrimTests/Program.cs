
bool success = 
RunTests<StringExtensions_Split_Tests>() &&
RunTests<StringExtensions_Casing_Tests_Legacy>() &&
RunTests<StringExtensionsTests>() &&
RunTests<StringExtensionsTestsEx>();
WriteLine("Done.");
if (!success) Exit(1);
