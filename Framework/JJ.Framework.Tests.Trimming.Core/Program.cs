RunTests<CultureInfo_PlatformSafe_Tests          >().ForEach(WriteLine); WriteLine();
RunTests<Encoding_PlatformSafe_Tests             >().ForEach(WriteLine); WriteLine();
RunTests<MemberTypes_PlatformSafe_Tests          >().ForEach(WriteLine); WriteLine();
RunTests<PropertyInfo_GetValue_PlatformSafe_Tests>().ForEach(WriteLine); WriteLine();
WriteLine("Done.");
ReadKey();