bool success = 
RunTests<BinaryWriterExtensionsTests>() &&
RunTests<CsvReaderTests>() &&
RunTests<StreamHelperTestsEx>() &&
RunTests<StreamHelperTests>();
WriteLine("Done.");
if (!success) Exit(1);
