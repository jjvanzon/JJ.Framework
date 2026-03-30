namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class OverloadResolutionPriority_Shim_Tests_Base
{
    // OverloadResolutionPriority
    
    public void Test_PlatformStub_OverloadResolutionPriority_Create()
    {
        var prio1Attribute = new OverloadResolutionPriorityAttribute(1);
        AreEqual(1, prio1Attribute.Priority);

        var prio0Attribute = new OverloadResolutionPriorityAttribute(0);
        AreEqual(0, prio0Attribute.Priority);
    }
    
    public void Test_PlatformStub_OverloadResolutionPriority_Implicit()
    {
        AreEqual("Overload(A,B)", Overload("A", "B"));
        AreEqual("Overload(A)", Overload("A"));
    }
    
    private string Overload(string text) => $"Overload({text})";
    // ReSharper disable once MethodOverloadWithOptionalParameter
    private string Overload(string text1, string text2 = "C") => $"Overload({text1},{text2})";
    
    public void Test_PlatformStub_OverloadResolutionPriority_Explicit()
    {
        AreEqual("WithPrios(A,B)", WithPrios("A", "B"));
        // Here, OverloadResolutionPriority(1) leads the single-arg call to the two-arg method instead.
        AreEqual("WithPrios(A,C)", WithPrios("A"));
    }
    
    private string WithPrios(string text) => $"WithPrios({text})"; // ncrunch: no coverage
    [OverloadResolutionPriority(1)]
    private string WithPrios(string text1, string text2 = "C") => $"WithPrios({text1},{text2})";
}