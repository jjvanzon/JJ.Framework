#if DEBUG && !NCRUNCH
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
RunTests<ExpressionHelper_CoreTests>() &&
RunTests<GetImplementations_CoreTests>() &&
RunTests<IsAssignableTo_CoreTests>() &&
RunTests<IsIndexer_CoreTests>() &&
RunTests<IsStatic_CoreTests>() &&
RunTests<ItemType_CoreTests>() &&
RunTests<NullException_CoreTests>() &&
RunTests<ReflectionCache_Constructor_CoreTests>() &&
RunTests<ReflectionCache_Field_CoreTests>() &&
RunTests<ReflectionCache_Indexer_CoreTests>() &&
RunTests<ReflectionCache_Indexer_CoreTests_GenericOverload>() &&
RunTests<ReflectionCache_Method_CoreTests>() &&
RunTests<ReflectionCache_Method_CoreTests_GenericOverload>() &&
RunTests<ReflectionCache_Property_CoreTests>() &&
RunTests<ReflectionCache_Type_CoreTests>() &&
RunTests<TypeExtensions_CoreTests>();

WriteLine("Done.");

if (!success) Exit(1);