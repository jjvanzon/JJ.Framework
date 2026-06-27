bool success = 
RunTests<MathsTests>() &&
RunTests<MathsTestsEx>() &&
RunTests<NumberingSystemsTests>() &&
RunTests<NumberingSystemsTestsEx>() &&
RunTests<RandomizerTests>() &&
RunTests<RandomizerLegacyTests>();
WriteLine("Done.");
if (!success) Exit(1);
