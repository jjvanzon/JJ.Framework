bool success = 
RunTests<Coalesce_1Arg_Tests>() &&
RunTests<Coalesce_2Args_Tests>() &&
RunTests<Coalesce_3Args_Objects>() &&
RunTests<Coalesce_3Args_ObjectsToText>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersNo>() &&
RunTests<Coalesce_3Args_SBs_ExtensionsSpaceMattersYes>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersNo>() &&
RunTests<Coalesce_3Args_SBs_StaticSpaceMattersYes>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersNo_Tests>() &&
RunTests<Coalesce_3Args_SBTextCombos_ExtensionsSpaceMattersYes_Tests>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersNo_Tests>() &&
RunTests<Coalesce_3Args_SBTextCombos_StaticSpaceMattersYes_Tests>() &&
RunTests<Coalesce_3Args_SBToText>() &&
RunTests<Coalesce_3Args_Text>() &&
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
RunTests<In_Tests>() &&
RunTests<Is_Tests>() &&
RunTests<IsNully_Collection_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
