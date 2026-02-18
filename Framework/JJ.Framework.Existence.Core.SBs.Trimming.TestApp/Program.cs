bool success = 
RunTests<Coalesce_3Args_SBs_Extensions_NoFlags>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBs_Static_NoFlags>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront>() &&
RunTests<Coalesce_NArgs_SB_Tests>() &&
RunTests<FilledIn_StringBuilder_Tests>() &&
RunTests<Has_StringBuilder_Tests>() &&
RunTests<IsNully_StringBuilder_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
