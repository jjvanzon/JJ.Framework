bool success = 
RunTests<AddRangeTestsEx>() &&
RunTests<AddTestsEx>() &&
RunTests<CollectionExtensions_Recursive_Ancestors_Tests_Legacy>() &&
RunTests<ConcatTestsEx>() &&
RunTests<DistinctTestsEx>() &&
RunTests<ExceptTestsEx>() &&
RunTests<ForEachTestsEx>() &&
RunTests<OfTypeTestsEx>() &&
RunTests<OneBecomesTwoTestsEx>() &&
RunTests<ProductTestsEx>() &&
RunTests<RemoveRangeTestsEx>() &&
RunTests<SumTestsEx>() &&
RunTests<UnionTestsEx>();

WriteLine("Done.");
if (!success) Exit(1);
