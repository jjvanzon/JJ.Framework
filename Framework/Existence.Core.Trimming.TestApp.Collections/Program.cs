bool success = 
RunTests<Coalesce_Collections_Misc_Tests>() &&
RunTests<Coalesce_Collections_Extensions_Tests>() &&
RunTests<Coalesce_Collections_Static_Tests>() &&
RunTests<FilledIn_Collection_No>() &&
RunTests<FilledIn_Collection_NotNullWhen>() &&
RunTests<FilledIn_Collection_Yes>() &&
RunTests<Has_Collection_Misc>() &&
RunTests<Has_Collection_NotNullWhen>() &&
RunTests<Has_Collection_No>() &&
RunTests<Has_Collection_Yes>() &&
RunTests<IsNully_Collection_No_Tests>() &&
RunTests<IsNully_Collection_NotNullWhen>() &&
RunTests<IsNully_Collection_Yes_Tests>();
WriteLine("Done.");
if (!success) Exit(1);
