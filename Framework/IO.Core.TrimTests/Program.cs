bool success = true;
success &= RunTests<FileHelperCoreTests_NumberedFilePath>();
success &= RunTests<FileHelperCoreTests_SafeFileStream>();
WriteLine("Done.");
if (!success) Exit(1);
