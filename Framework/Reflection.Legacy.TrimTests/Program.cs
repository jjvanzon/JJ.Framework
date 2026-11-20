/*
#if DEBUG && !NCRUNCH
WriteLine($"PID: {ProcessId} - Attach debugger if needed and/or press any key to continue.");
ReadKey(true);
#endif
*/

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
RunTests<ExpressionHelper_TestsEx>() &&
RunTests<GetImplementations_TestsEx>() &&
RunTests<IsAssignableTo_TestsEx>() &&
RunTests<IsIndexer_TestsEx>() &&
RunTests<IsStatic_TestsEx>() &&
RunTests<ItemType_TestsEx>() &&
RunTests<NullException_TestsEx>() &&
RunTests<ReflectionCache_Constructor_TestsEx>() &&
RunTests<ReflectionCache_Field_TestsEx>() &&
RunTests<ReflectionCache_Indexer_TestsEx>() &&
RunTests<ReflectionCache_Indexer_TestsEx_GenericOverload>() &&
RunTests<ReflectionCache_Method_TestsEx>() &&
RunTests<ReflectionCache_Method_TestsEx_GenericOverload>() &&
RunTests<ReflectionCache_Property_TestsEx>() &&
RunTests<ReflectionCache_Type_TestsEx>() &&
RunTests<TypeExtensions_TestsEx>();

WriteLine("Done.");

if (!success) Exit(1);