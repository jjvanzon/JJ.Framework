// Not worth untrimming, refecerenced here
// to avpod ReSharper unused type error.
using JJ.Framework.PlatformCompatibility.Tests.Obsolete;
var excludedTests = new[]
{
    typeof(CultureInfo_PlatformSafe_Obsolete_Tests),
    typeof(Encoding_PlatformSafe_Obsolete_Tests),
    typeof(PlatformExtensions_Obsolete_Tests),
    typeof(PlatformHelper_Obsolete_Tests)
};

bool success = 
RunTests<CultureInfo_PlatformSafe_Tests>() &&
RunTests<Encoding_PlatformSafe_Tests>() &&
RunTests<MemberTypes_PlatformSafe_Tests>() &&
RunTests<PropertyInfo_GetValue_PlatformSafe_Tests>() &&
RunTests<Type_GetInterface_PlatformSafe_Tests>() &&
RunTests<XDocument_XElement_PlatformSafe_Tests>() &&
RunTests<PropertyInfo_PlatformSafe_TestsEx>() &&
RunTests<PlatformCompatibility_CultureInfo_TestsEx>() &&
RunTests<PlatformCompatibility_Encoding_TestsEx>() &&
RunTests<PlatformCompatibility_MemberType_TestsEx>() &&
RunTests<PlatformCompatibility_Stream_TestsEx>() &&
RunTests<PlatformCompatibility_String_TestsEx>() &&
RunTests<PlatformCompatibility_Tuple_TestsEx>();

WriteLine("Done.");
if (!success) Exit(1);
