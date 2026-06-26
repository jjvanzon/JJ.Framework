bool success = 
RunTests<MathsTests>() &&
RunTests<MathsTestsEx>() &&
RunTests<NumberingSystems_CoreTests>() &&
RunTests<NumberingSystemsTests>() &&
RunTests<RandomizerTestsEx>() &&
RunTests<RandomizerLegacyTests>();
WriteLine("Done.");
if (!success) Exit(1);
