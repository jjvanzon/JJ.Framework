bool success = 
RunTests<BinaryWriterExtensionsTests>() &&
RunTests<CsvReaderTests>() &&
RunTests<StreamHelperTests>();
WriteLine("Done.");
if (!success) Exit(1);
