var result = new Result();

RunTests<PlatformCompatibility_Core_Tests>(result);
RunTests<PlatformCompatibility_CultureInfo_Core_Tests>(result);
RunTests<PlatformCompatibility_Encoding_Core_Tests>(result);
RunTests<PlatformCompatibility_MemberType_Core_Tests>(result);
RunTests<PlatformCompatibility_Stream_Core_Tests>(result);
RunTests<PlatformCompatibility_String_Core_Tests>(result);
RunTests<PlatformCompatibility_Tuple_Core_Tests>(result);
result.Messages.ForEach(WriteLine);

WriteLine("Done.");

if (!result.Success) Exit(1);

// Temporary test if CI fails upon error code
// TODO: Remove the following code line
Exit(1);