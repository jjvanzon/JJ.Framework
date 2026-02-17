bool success = 
RunTests<Coalesce_3Args_SBTextCombos_Extensions_NoFlags>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYesMagicBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBTextCombos_Static_NoFlags>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersNoExplicit_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesExplicitBool_FlagsInFront>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInBack>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersYesMagicBool_FlagsInFront>();
WriteLine("Done.");
if (!success) Exit(1);
