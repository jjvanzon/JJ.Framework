bool success = 
RunTests<AccessorTests_Indexers>() &&
RunTests<AccessorTests_UsingExpressions>() &&
RunTests<AccessorTests_UsingStrings>() &&
RunTests<ExpressionHelperExtensiveTests>() &&
RunTests<ExpressionHelperGetTextSimpleTests>() &&
RunTests<ExpressionHelperGetValueSimpleTests>() &&
RunTests<ExpressionHelperGetValuesTests>();
WriteLine("Done.");
if (!success) Exit(1);
