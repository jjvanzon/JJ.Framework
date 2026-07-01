bool success = 
RunTests<FileHelperCoreTests_NumberedFilePath>() &&
RunTests<FileHelperCoreTests_SafeFileStream>();
WriteLine("Done.");
if (!success) Exit(1);
