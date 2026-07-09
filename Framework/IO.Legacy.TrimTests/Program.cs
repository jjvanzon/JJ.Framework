bool success = 
RunTests<BinaryWriterExtensionsTests>() &&
RunTests<CsvReaderTests>() &&
RunTests<StreamHelperLegacyTestsEx>() &&
RunTests<StreamHelperTests>();
WriteLine("Done.");
if (!success) Exit(1);
