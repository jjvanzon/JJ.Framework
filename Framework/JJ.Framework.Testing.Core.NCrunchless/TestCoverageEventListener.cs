namespace nCrunch.TestRuntime.DotNetCore;

/// <summary>
/// Shim 
/// </summary>
public class TestCoverageEventListener
{
    public static void NCrunchMarkClassInstanceConstructed(int a, int b) { }
    public static void NCrunchEnsureStackSpaceExists() { }
    public static void NCrunchMarkCodeCoverage(int a, int b) { }
}
