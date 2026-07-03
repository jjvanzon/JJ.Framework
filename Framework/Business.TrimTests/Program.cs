bool success = 
RunTests<EntityStatusManagerTests>() &&
RunTests<EntityStatusManagerByIDTestsEx>() &&
RunTests<EntityStatusManagerTestsEx>() &&
RunTests<ListIsDirtyTestsEx>() &&
RunTests<ResultTestsEx>() &&
RunTests<SideEffectTestsEx>();
WriteLine("Done.");
if (!success) Exit(1);
