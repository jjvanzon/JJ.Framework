
bool success = 
RunTests<StringExtensions_Split_Tests>() &&
RunTests<StringExtensions_Split_Tests_Ex>() &&
RunTests<StringExtensions_Casing_Tests_Ex>() &&
RunTests<StringExtensionsTests>() &&
RunTests<StringExtensionsTestsEx>();
WriteLine("Done.");
if (!success) Exit(1);
