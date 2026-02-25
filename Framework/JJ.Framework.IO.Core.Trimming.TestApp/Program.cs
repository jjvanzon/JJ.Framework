bool success = 
RunTests<BinaryWriterExtensionsTests>() &&
RunTests<CsvReaderTests>() &&
RunTests<DummyTests>() &&
RunTests<StreamHelperLegacyTests>() &&
RunTests<StreamHelperTests>();
WriteLine("Done.");
if (!success) Exit(1);
