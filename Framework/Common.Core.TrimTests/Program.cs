bool success =
RunTests<CollectionExtensions_Recursive_IEnumerable_Legacy_Tests>() &&
RunTests<CollectionExtensions_Recursive_IList_Legacy_Tests>() &&
RunTests<CollectionExtensionsCoreTests>() &&
RunTests<CommonStringExtensionsCore_Obsolete_Tests>() &&
RunTests<ConfigurationHelperCoreTests>() &&
RunTests<CultureHelperCoreTests>() &&
RunTests<EmbeddedResourceHelperLegacyTests>() &&
RunTests<EnvironmentHelperCoreTests>() &&
RunTests<ExceptionTypesCoreTests>() &&
RunTests<FlaggingTests>() &&
RunTests<KeyValuePairHelperCoreTests>() &&
RunTests<TrimAllCoreTests>() &&
RunTests<OverloadByNameTests>();
WriteLine("Done.");
if (!success) Exit(1);
