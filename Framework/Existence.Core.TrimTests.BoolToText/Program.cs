bool success = 
RunTests<Coalesce_3Args_BoolToText_Examples>() &&
RunTests<Coalesce_3Args_BoolToText_Extensions>() &&
RunTests<Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_BoolToText_ExtensionsZeroMattersFlagsInFront>() &&
RunTests<Coalesce_3Args_BoolToText_Static>() &&
RunTests<Coalesce_3Args_BoolToText_StaticZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_BoolToText_StaticZeroMattersFlagsInFront>() &&
RunTests<Coalesce_4Args_BoolToText_Extensions>() &&
RunTests<Coalesce_4Args_BoolToText_Static>();
WriteLine("Done.");
if (!success) Exit(1);
