bool success = 
RunTests<Coalesce_3Args_Bool_Examples>() &&
RunTests<Coalesce_3Args_Bool_Extensions>() &&
RunTests<Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront>() &&
RunTests<Coalesce_3Args_Bool_Static>() &&
RunTests<Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront>() &&
RunTests<Coalesce_4Args_Bool_Extensions>() &&
RunTests<Coalesce_4Args_Bool_Static>();
WriteLine("Done.");
if (!success) Exit(1);
