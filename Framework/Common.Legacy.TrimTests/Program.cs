
bool success = 
RunTests<StringExtensions_Split_Tests>() &&
RunTests<StringExtensionsTests>() &&
RunTests<StringExtensionsTestsEx>();
WriteLine("Done.");
if (!success) Exit(1);
