bool success = 
RunTests<IsAssignableTo_CoreTests>() &&
RunTests<IsStatic_CoreTests>() &&
RunTests<AccessorTests_Indexers>() &&
RunTests<AccessorTests_UsingExpressions>() &&
RunTests<AccessorTests_UsingStrings>() &&
RunTests<ExpressionHelperExtensiveTests>() &&
RunTests<ExpressionHelperGetTextSimpleTests>() &&
RunTests<ExpressionHelperGetValueSimpleTests>() &&
RunTests<ExpressionHelperGetValuesTests>();
WriteLine("Done.");
if (!success) Exit(1);
