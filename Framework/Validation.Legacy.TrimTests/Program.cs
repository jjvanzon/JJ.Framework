bool success = 
RunTests<FluentValidatorTests>() &&
RunTests<TypicalValidatorUsageTests>() &&
RunTests<ValidationMessagesTests>() &&
RunTests<ValidationMessageTests>() &&
RunTests<ValidatorBaseTests>() &&
RunTests<ValidatorGlobalizationTests>();

WriteLine("Done.");
if (!success) Exit(1);
