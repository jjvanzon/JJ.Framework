bool success =
RunTests<CollectionExtensions_Recursive_IEnumerable_Legacy_Tests>() &&
RunTests<CollectionExtensions_Recursive_IList_Legacy_Tests>() &&
RunTests<CollectionExtensionsCoreTests>() &&
RunTests<ConfigurationHelperCoreTests>() &&
RunTests<CultureHelperCoreTests>() &&
RunTests<EmbeddedResourceHelperLegacyTests>() &&
RunTests<EnvironmentHelperCoreTests>() &&
RunTests<ExceptionTypesCoreTests>() &&
RunTests<FlaggingTests>() &&
RunTests<KeyValuePairHelperCoreTests>() &&
RunTests<SplitCoreTests>() &&
RunTests<SplitWithQuotationCoreTests>() &&
RunTests<StringExtensionsCasingCoreTests>() &&
RunTests<StringExtensionsCoreTests>() &&
RunTests<TrimAllCoreTests>();
WriteLine("Done.");
if (!success) Exit(1);
