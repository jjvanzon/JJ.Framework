bool success = 
RunTests<PlatformCompatibility_Core_Tests>() &&
RunTests<PlatformCompatibility_CultureInfo_Core_Tests>() &&
RunTests<PlatformCompatibility_Encoding_Core_Tests>() &&
RunTests<PlatformCompatibility_MemberType_Core_Tests>() &&
RunTests<PlatformCompatibility_Stream_Core_Tests>() &&
RunTests<PlatformCompatibility_String_Core_Tests>() &&
RunTests<PlatformCompatibility_Tuple_Core_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
