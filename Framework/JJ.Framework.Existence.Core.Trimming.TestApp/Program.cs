var result = new Result();

RunTests<Coalesce_1Arg_Tests>(result);
RunTests<Coalesce_2Args_Tests>(result);
RunTests<Coalesce_3Args_Objects>(result);
RunTests<Coalesce_3Args_ObjectsToText>(result);
RunTests<Coalesce_3Args_SBTextCombos>(result);
RunTests<Coalesce_3Args_StringBuilder>(result);
RunTests<Coalesce_3Args_Text>(result);
RunTests<Coalesce_3Args_Values>(result);
RunTests<Coalesce_3Args_ValuesToText>(result);
RunTests<Coalesce_Collections_Tests>(result);
RunTests<Coalesce_Keywords_Tests>(result);
RunTests<Coalesce_Variadic_Tests>(result);
RunTests<Existence_BasicType_Tests>(result);
RunTests<Existence_NotNullWhen_Tests>(result);
RunTests<Existence_Regression>(result);
RunTests<Existence_Examples>(result);
RunTests<RegressionTest_CallToHas_FromGenericContext_TypeInfoLost>(result);
RunTests<Flex_Prototype>(result);
RunTests<Has_Collection_Tests>(result);
RunTests<Has_Object_Tests>(result);
RunTests<Has_StringBuilder_Tests>(result);
RunTests<Has_Text_Tests>(result);
RunTests<Has_Value_Tests>(result);
RunTests<In_Tests>(result);
RunTests<Is_Tests>(result);

result.Messages.ForEach(WriteLine);

WriteLine("Done.");

if (!result.Success) Exit(1);
