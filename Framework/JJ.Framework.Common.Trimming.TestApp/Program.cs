bool success = 
RunTests<StringExtensions_Split_Tests>() &&
RunTests<StringExtensionsTests>();
WriteLine("Done.");
if (!success) Exit(1);
