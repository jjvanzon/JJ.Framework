var result = new Result();

RunTests<StringExtensions_Split_Tests>(result);
RunTests<StringExtensionsTests>(result);
result.Messages.ForEach(WriteLine);

WriteLine("Done.");

if (!result.Success) Exit(1);
