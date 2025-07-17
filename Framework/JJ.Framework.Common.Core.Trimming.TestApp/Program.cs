var result = new Result();

RunTests<CollectionExtensions_Recursive_IEnumerable_Legacy_Tests>(result);
RunTests<CollectionExtensions_Recursive_IList_Legacy_Tests>(result);
RunTests<CollectionExtensionsCoreTests>(result);
RunTests<ConfigurationHelperCoreTests>(result);
RunTests<CultureHelperCoreTests>(result);
RunTests<EmbeddedResourceHelperLegacyTests>(result);
RunTests<EnvironmentHelperCoreTests>(result);
RunTests<ExceptionTypesCoreTests>(result);
RunTests<FlaggingTests>(result);
RunTests<KeyValuePairHelperCoreTests>(result);
RunTests<SplitCoreTests>(result);
RunTests<SplitWithQuotationCoreTests>(result);
RunTests<StringExtensionsCasingCoreTests>(result);
RunTests<StringExtensionsCoreTests>(result);
RunTests<TrimAllCoreTests>(result);

result.Messages.ForEach(WriteLine);

WriteLine("Done.");

if (!result.Success) Exit(1);
