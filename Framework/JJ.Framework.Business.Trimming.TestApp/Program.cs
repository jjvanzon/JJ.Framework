bool success = 
RunTests<EntityStatusManagerTests>() &&
RunTests<EntityStatusManagerByIDCoreTests>() &&
RunTests<EntityStatusManagerCoreTests>() &&
RunTests<ListIsDirtyCoreTests>() &&
RunTests<SideEffectCoreTests>();
WriteLine("Done.");
if (!success) Exit(1);
