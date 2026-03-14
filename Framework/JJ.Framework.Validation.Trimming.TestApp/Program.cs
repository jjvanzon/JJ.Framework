bool success = 
RunTests<FluentValidatorTests>() &&
RunTests<TypicalValidatorUsageTests>() &&
RunTests<ValidationGlobalizationTests>() &&
RunTests<ValidationMessagesTests>() &&
RunTests<ValidationMessageTests>() &&
RunTests<ValidatorBaseTests>();

WriteLine("Done.");
if (!success) Exit(1);
