bool success = 
RunTests<Coalesce_3Args_Text_Extensions_NoFlags>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_Text_Static_NoFlags>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront>();
WriteLine("Done.");
if (!success) Exit(1);
