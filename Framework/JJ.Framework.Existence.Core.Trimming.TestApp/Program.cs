bool success = 
RunTests<Coalesce_1Arg_Tests>() &&
RunTests<Coalesce_2Args_Tests>() &&
RunTests<Coalesce_3Args_Objects>() &&
RunTests<Coalesce_3Args_ObjectsToText>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersNoExplicit>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersNoImplicit>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersNoExplicit>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersNoImplicit>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNo_Tests>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYes_Tests>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersNo_Tests>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersYes_Tests>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersNo>() &&
RunTests<Coalesce_3Args_SBToText_ExtensionsSpaceMattersYes>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersNo>() &&
RunTests<Coalesce_3Args_SBToText_StaticSpaceMattersYes>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersNo_Tests>() &&
RunTests<Coalesce_3Args_Text_ExtensionsSpaceMattersYes_Tests>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersNo_Tests>() &&
RunTests<Coalesce_3Args_Text_StaticSpaceMattersYes_Tests>() &&
RunTests<Coalesce_3Args_Values>() &&
RunTests<Coalesce_3Args_ValuesToText>() &&
RunTests<Coalesce_Collections_Tests>() &&
RunTests<Coalesce_Keywords_Tests>() &&
RunTests<Coalesce_Variadic_Tests>() &&
RunTests<Existence_BasicType_Tests>() &&
RunTests<Existence_NotNullWhen_Tests>() &&
RunTests<Existence_Regression>() &&
RunTests<Existence_Examples>() &&
RunTests<RegressionTest_CallToHas_FromGenericContext_TypeInfoLost>() &&
RunTests<Flex_Prototype>() &&
RunTests<Has_Collection_Misc>() &&
RunTests<Has_Collection_Yes>() &&
RunTests<Has_Collection_No>() &&
RunTests<Has_Object_Tests>() &&
RunTests<Has_StringBuilder_Tests>() &&
RunTests<Has_Text_Tests>() &&
RunTests<Has_Value_Tests>() &&
RunTests<In_Tests_CaseOrSpaceMattersNoNo>() &&
RunTests<In_Tests_CaseOrSpaceMattersNoYes>() &&
RunTests<In_Tests_CaseOrSpaceMattersYesNo>() &&
RunTests<In_Tests_CaseOrSpaceMattersYesYes>() &&
RunTests<In_Tests_CaseMatters>() &&
RunTests<In_Tests_SpaceMatters>() &&
RunTests<In_Tests_Other>() &&
RunTests<Is_Tests>() &&
RunTests<IsNully_Collection_No_Tests>();
RunTests<IsNully_Collection_Yes_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
