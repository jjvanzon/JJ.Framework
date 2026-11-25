bool success = 
RunTests<XmlHelperTestsEx>() &&
RunTests<XmlToObjectConverterTests_Basics>() &&
RunTests<XmlToObjectConverterTests_Collections>() &&
RunTests<XmlToObjectConverterTests_ComplicatedExample>() &&
RunTests<XmlToObjectConverterTests_EdgeCasesEx>() &&
RunTests<XmlToObjectConverterTests_ExplicitNames>() &&
RunTests<XmlToObjectConverterTests_NullableTypes>() &&
RunTests<XmlToObjectConverterTests_RecursiveElement>() &&
RunTests<XmlToObjectConverterTests_SimpleTypes>();

WriteLine("Done.");
if (!success) Exit(1);
