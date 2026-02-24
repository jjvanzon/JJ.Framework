bool success =
    RunTests<SplitCoreTests>() &&
    RunTests<StringExtensionsCoreTests>() &&
    RunTests<StringExtensionsCasingCoreTests>() &&
    RunTests<SplitWithQuotationCoreTests>() &&
    RunTests<TrimAllCoreTests>() &&
    RunTests<CollectionExtensionsCoreTests>() &&
    RunTests<ConfigurationHelperCoreTests>() &&
    RunTests<EnvironmentHelperCoreTests>() &&
    RunTests<CultureHelperCoreTests>();

WriteLine("Done.");
if (!success) Exit(1);
