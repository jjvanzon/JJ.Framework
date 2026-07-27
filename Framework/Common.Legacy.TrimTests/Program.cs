
bool success = 
RunTests<CollectionExtensions_Recursive_IEnumerable_Tests_Ex>() &&
RunTests<CollectionExtensions_Recursive_IList_Tests_Ex>() &&
RunTests<CollectionExtensionsTestsEx>() &&
RunTests<CultureHelperTestsEx>() &&
RunTests<EmbeddedResourceHelperTestsEx>() &&
RunTests<ExceptionTypesTestsEx>() &&
RunTests<KeyValuePairHelperTestsEx>() &&
RunTests<StringExtensions_Casing_Tests_Ex>() &&
RunTests<StringExtensions_Split_Tests>() &&
RunTests<StringExtensions_Split_Tests_Ex>() &&
RunTests<StringExtensions_Split_Tests_Ex_WithQuotation>() &&
RunTests<StringExtensionsTests>() &&
RunTests<StringExtensionsTestsEx>() &&
RunTests<TrimAllTestsEx>();

WriteLine("Done.");
if (!success) Exit(1);
