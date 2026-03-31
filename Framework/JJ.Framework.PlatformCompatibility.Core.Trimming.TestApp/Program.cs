bool success = 
RunTests<AotShims_Tests>() &&
RunTests<CallerArgumentExpression_Tests>() &&
RunTests<ExceptionSupport_Tests>() &&
RunTests<HashCode_Tests>() &&
RunTests<NotNullWhen_Tests>() &&
RunTests<OverloadResolutionPriority_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
