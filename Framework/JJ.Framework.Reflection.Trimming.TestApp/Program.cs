
var result = new Result();

RunTests<AccessorTests_Indexers>(result);
result.Messages.ForEach(WriteLine);

WriteLine("Done.");

if (!result.Success) Exit(1);
