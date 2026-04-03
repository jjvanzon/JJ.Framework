using JJ.Framework.Testing.Core;
using static System.Console;

bool success =
RunTests<CallerArgumentExpression_Tests>() &&
RunTests<ExceptionSupport_Tests>() &&
RunTests<HashCode_Tests>() &&
RunTests<Lock_Tests>() &&
RunTests<NotNullWhen_Tests>() &&
RunTests<OverloadResolutionPriority_Tests>() &&
RunTests<TrimShimCreation_Tests>() &&
RunTests<TrimShimUsage_Tests>();
WriteLine("Done.");
if (!success) Exit(1);