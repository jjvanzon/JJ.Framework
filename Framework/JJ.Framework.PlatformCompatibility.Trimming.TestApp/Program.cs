bool success = 
RunTests<CultureInfo_PlatformSafe_Tests>() &&
RunTests<Encoding_PlatformSafe_Tests>() &&
RunTests<MemberTypes_PlatformSafe_Tests>() &&
RunTests<PropertyInfo_GetValue_PlatformSafe_Tests>() &&
RunTests<Type_GetInterface_PlatformSafe_Tests>() &&
RunTests<XDocument_XElement_PlatformSafe_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
