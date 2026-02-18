bool success = 
RunTests<Coalesce_3Args_ValuesToText_Examples>() &&
RunTests<Coalesce_3Args_ValuesToText_Extensions>() &&
RunTests<Coalesce_3Args_ValuesToText_ExtensionsZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_ValuesToText_ExtensionsZeroMattersFlagsInFront>() &&
RunTests<Coalesce_3Args_ValuesToText_Static>() &&
RunTests<Coalesce_3Args_ValuesToText_StaticZeroMattersFlagsInBack>() &&
RunTests<Coalesce_3Args_ValuesToText_StaticZeroMattersFlagsInFront>();
WriteLine("Done.");
if (!success) Exit(1);
