bool success = 
RunTests<Coalesce_3Args_Values_Extensions>() &&
RunTests<Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_Values_ExtensionsZeroMattersFlagsInFront>() &&
RunTests<Coalesce_3Args_Values_Static>() &&
RunTests<Coalesce_3Args_Values_StaticZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_Values_StaticZeroMattersFlagsInFront>();
WriteLine("Done.");
if (!success) Exit(1);
