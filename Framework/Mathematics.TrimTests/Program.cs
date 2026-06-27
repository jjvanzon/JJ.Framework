bool success = 
RunTests<MathsTests>() &&
RunTests<MathsTestsEx>() &&
RunTests<NumberingSystemsTests>() &&
RunTests<NumberingSystemsTestsEx>() &&
RunTests<RandomizerTests>() &&
RunTests<RandomizerTestsEx>();
WriteLine("Done.");
if (!success) Exit(1);
