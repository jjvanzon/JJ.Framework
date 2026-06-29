bool success = 
RunTests<CallerArgumentExpression_Tests>() &&
RunTests<ExceptionSupport_Tests>() &&
RunTests<HashCode_Tests>() &&
RunTests<NotNullWhen_Tests>() &&
RunTests<OverloadResolutionPriority_Tests>() &&
RunTests<TrimShimCreation_Tests>() &&
RunTests<TrimShimUsage_Tests>() &&
RunTests<NotNullIfNotNull_Tests>() &&
RunTests<OperatingSystemSupport_Tests>();

WriteLine("Done.");
if (!success) Exit(1);
