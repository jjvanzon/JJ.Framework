
bool success = 
RunTests<CollectionExtensions_Recursive_IEnumerable_Legacy_Tests>() &&
RunTests<CollectionExtensions_Recursive_IList_Legacy_Tests>() &&
RunTests<CollectionExtensionsCoreTests>() &&
RunTests<KeyValuePairHelperCoreTests>() &&
RunTests<StringExtensions_Casing_Tests_Ex>() &&
RunTests<StringExtensions_Split_Tests>() &&
RunTests<StringExtensions_Split_Tests_Ex>() &&
RunTests<StringExtensions_Split_Tests_Ex_WithQuotation>() &&
RunTests<StringExtensionsTests>() &&
RunTests<StringExtensionsTestsEx>();
WriteLine("Done.");
if (!success) Exit(1);
