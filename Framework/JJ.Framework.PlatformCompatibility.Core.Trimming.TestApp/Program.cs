bool success = 
RunTests<CallerArgumentExpression_Shim_Tests>() &&
RunTests<ExceptionSupport_Shim_Tests>() &&
RunTests<HashCode_Shim_Tests>() &&
RunTests<NotNullWhen_Shim_Tests>() &&
RunTests<OverloadResolutionPriority_Shim_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
