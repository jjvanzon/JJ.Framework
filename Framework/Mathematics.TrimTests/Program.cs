bool success = 
RunTests<Maths_CoreTests>() &&
RunTests<MathsTests>() &&
RunTests<NumberingSystems_CoreTests>() &&
RunTests<NumberingSystemsTests>() &&
RunTests<Randomizer_CoreTests>();
WriteLine("Done.");
if (!success) Exit(1);
