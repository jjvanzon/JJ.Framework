bool success =
    RunTests<BasicType_Char_Tests>() &&
    RunTests<BasicType_DateTime_Tests>() &&
    RunTests<BasicType_Double_Tests>() &&
    RunTests<BasicType_Enum_Tests>() &&
    RunTests<BasicType_Guid_Tests>() &&
    RunTests<BasicType_Other_Tests>();

WriteLine("Done.");
if (!success) Exit(1);
