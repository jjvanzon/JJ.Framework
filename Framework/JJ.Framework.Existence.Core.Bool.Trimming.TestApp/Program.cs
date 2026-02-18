bool success = 
RunTests<Coalesce_2Args_Bool_Examples>() &&
RunTests<Coalesce_2Args_Bool_FlagsInBack>() &&
RunTests<Coalesce_2Args_Bool_FlagsInFront>() &&
RunTests<Coalesce_2Args_Bool_NoFlags>() &&
RunTests<Coalesce_3Args_Bool_Examples>() &&
RunTests<Coalesce_3Args_Bool_Extensions>() &&
RunTests<Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_Bool_ExtensionsZeroMattersFlagsInFront>() &&
RunTests<Coalesce_3Args_Bool_Static>() &&
RunTests<Coalesce_3Args_Bool_StaticZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_Bool_StaticZeroMattersFlagsInFront>() &&
RunTests<Coalesce_4Args_Bool_Extensions>() &&
RunTests<Coalesce_4Args_Bool_Static>() &&
RunTests<Coalesce_NArg_Bool_Tests>() &&
RunTests<FilledIn_Bool_Tests>() &&
RunTests<Has_Bool_Tests>() &&
RunTests<IsNully_Bool_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
