bool success =
RunTests<ExpressionHelperExtensiveTests>() &&
RunTests<AccessorTests_Indexers>();
WriteLine("Done.");
if (!success) Exit(1);
