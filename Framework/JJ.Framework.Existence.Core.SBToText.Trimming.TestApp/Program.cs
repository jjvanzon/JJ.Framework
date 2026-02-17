bool success = 
RunTests<Coalesce_3Args_SBToText_Extensions_NoFlags>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersYesMagicBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBToText_Static_NoFlags>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersYesMagicBool_FlagsInFront>();
WriteLine("Done.");
if (!success) Exit(1);
