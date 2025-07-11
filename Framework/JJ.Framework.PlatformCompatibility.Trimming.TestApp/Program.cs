var result = new Result();

RunTests<CultureInfo_PlatformSafe_Tests>(result);
RunTests<Encoding_PlatformSafe_Tests>(result);
RunTests<MemberTypes_PlatformSafe_Tests>(result);
RunTests<PropertyInfo_GetValue_PlatformSafe_Tests>(result);
RunTests<Type_GetInterface_PlatformSafe_Tests>(result);
RunTests<XDocument_XElement_PlatformSafe_Tests>(result);

result.Messages.ForEach(WriteLine);

WriteLine("Done.");

if (!result.Success) Exit(1);
