bool success = 
RunTests<Coalesce_1Arg_Object_Tests>() &&
RunTests<Coalesce_2Args_Objects_NoFlags>() &&
RunTests<Coalesce_2Args_SBText_FlagsInBack>() &&
RunTests<Coalesce_2Args_SBText_FlagsInFront>() &&
RunTests<Coalesce_2Args_SBText_NoFlags>() &&
RunTests<Coalesce_3Args_Objects>() &&
RunTests<Coalesce_3Args_ObjectsToText>() &&
RunTests<Coalesce_Keywords_Tests>() &&
RunTests<Coalesce_NArg_Objects_Tests>() &&
RunTests<Contains_Nullable_Tests>() &&
RunTests<Contains_Tests>() &&
RunTests<BasicType_Other_Tests>() &&
RunTests<Existence_Bugs>() &&
RunTests<BasicType_Char_Tests>() &&
RunTests<BasicType_DateTime_Tests>() &&
RunTests<BasicType_Double_Tests>() &&
RunTests<BasicType_Enum_Tests>() &&
RunTests<Existence_Examples>() &&
RunTests<BasicType_Guid_Tests>() &&
RunTests<RegressionTest_CallToHas_FromGenericContext_TypeInfoLost>() &&
RunTests<FilledIn_Objects_Tests>() &&
RunTests<Flex_Prototype>() &&
RunTests<Has_Object_Tests>() &&
RunTests<In_Tests_ExtensionsCaseOrSpaceMattersNoNo>() &&
RunTests<In_Tests_StaticCaseOrSpaceMattersNoNo>() &&
RunTests<In_Tests_ExtensionsCaseOrSpaceMattersNoYes>() &&
RunTests<In_Tests_StaticCaseOrSpaceMattersNoYes>() &&
RunTests<In_Tests_ExtensionsCaseOrSpaceMattersYesNo>() &&
RunTests<In_Tests_StaticCaseOrSpaceMattersYesNo>() &&
RunTests<In_Tests_ExtensionsCaseOrSpaceMattersYesYes>() &&
RunTests<In_Tests_StaticCaseOrSpaceMattersYesYes>() &&
RunTests<In_Tests_CaseMatters>() &&
RunTests<In_Tests_SpaceMatters>() &&
RunTests<In_Tests_Other>() &&
RunTests<Is_Tests_Examples>() &&
RunTests<Is_Tests_ExtensionsFlagsInBack>() &&
RunTests<Is_Tests_ExtensionsFlagsInFront>() &&
RunTests<Is_Tests_StaticFlagsInBack>() &&
RunTests<Is_Tests_StaticFlagsInFront>() &&
RunTests<IsNully_Object_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
