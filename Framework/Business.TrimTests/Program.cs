bool success = 
RunTests<EntityStatusManagerTests>() &&
RunTests<EntityStatusManagerByIDTestsEx>() &&
RunTests<EntityStatusManagerTestsEx>() &&
RunTests<ListIsDirtyTestsEx>() &&
RunTests<ResultOfTTestsEx>() &&
RunTests<SideEffectTestsEx>();
WriteLine("Done.");
if (!success) Exit(1);
