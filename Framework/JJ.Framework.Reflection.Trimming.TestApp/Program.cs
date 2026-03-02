#if DEBUG
WriteLine($"PID: {ProcessId} - Attach debugger if needed and/or press any key to continue.");
ReadKey(true);
#endif

bool success = 
RunTests<AccessorTests_Indexers>() &&
RunTests<AccessorTests_UsingExpressions>() &&
RunTests<AccessorTests_UsingStrings>() &&
RunTests<ExpressionHelperExtensiveTests>() &&
RunTests<ExpressionHelperGetTextSimpleTests>() &&
RunTests<ExpressionHelperGetValueSimpleTests>() &&
RunTests<ExpressionHelperGetValuesTests>() &&
RunTests<ReflectionCacheLegacyExampleTests>() &&
RunTests<ReflectionCacheLegacyTests>() &&
RunTests<GetImplementations_CoreTests>() &&
RunTests<IsAssignableTo_CoreTests>() &&
RunTests<IsIndexer_CoreTests>() &&
RunTests<IsStatic_CoreTests>();

WriteLine("Done.");

if (!success) Exit(1);