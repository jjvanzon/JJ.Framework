bool success = 
RunTests<EntityStatusManagerByIDCoreTests>() &&
RunTests<EntityStatusManagerCoreTests>() &&
RunTests<ListIsDirtyTests>() &&
RunTests<SideEffectTests>();
WriteLine("Done.");
if (!success) Exit(1);
