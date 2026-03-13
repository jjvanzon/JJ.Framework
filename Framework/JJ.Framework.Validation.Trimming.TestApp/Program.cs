bool success = 
RunTests<ValidationMessageTests>() &&
RunTests<ValidationMessagesTests>() &&
RunTests<ValidatorBaseTests>() &&
RunTests<FluentValidatorTests>() &&
RunTests<TypicalValidatorUsageTests>();

WriteLine("Done.");
if (!success) Exit(1);
