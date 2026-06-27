bool success = 
RunTests<MathsTests>() &&
RunTests<MathsTestsEx>() &&
RunTests<NumberingSystemsTests>() &&
RunTests<NumberingSystemsTestsEx>() &&
RunTests<RandomizerLegacyTests>() &&
RunTests<RandomizerLegacyTests_GetRandomItem>() &&
RunTests<RandomizerLegacyTests_TryGetRandomItem>() &&
RunTests<RandomizerTests>();
WriteLine("Done.");
if (!success) Exit(1);
