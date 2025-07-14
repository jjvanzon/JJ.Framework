var result = new Result();

//RunTests<PlatformCompatibility_Core_Tests>(result);
//RunTests<PlatformCompatibility_CultureInfo_Core_Tests>(result);
result.Messages.ForEach(WriteLine);

WriteLine("Done.");

if (!result.Success) Exit(1);
