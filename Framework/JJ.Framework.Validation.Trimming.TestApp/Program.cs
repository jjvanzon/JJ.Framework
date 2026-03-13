bool success = 
RunTests<ValidationMessageTests>() &&
RunTests<ValidationMessagesTests>() &&
RunTests<ValidatorBaseTests>() &&
RunTests<FluentValidatorTests>() &&
RunTests<TypicalUsageTests>();

WriteLine("Done.");
if (!success) Exit(1);
