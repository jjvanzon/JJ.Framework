using System.Linq.Expressions;
using static JJ.Framework.Reflection.ExpressionHelper;
namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ExpressionHelperCoreTests
{
    // ncrunch: no coverage start
    
    private void VoidMethod() { }
    private int IntMethod() => 1;
    
    // ncrunch: no coverage end
    
    [TestMethod]
    public void GetName_WithAction() 
        => AreEqual(nameof(VoidMethod), GetName(() => VoidMethod()));

    [TestMethod]
    public void GetMember_WithFunc()
    {
        var memberInfo = GetMember(() => IntMethod());
        IsNotNull(() => memberInfo);
        AreEqual(nameof(IntMethod), memberInfo.Name);
    }
    
    [TestMethod]
    public void GetMember_NodeType_NotSupportedException() 
        => ThrowsException
            <NotSupportedException>(
            () => GetMember(() => 1), 
            "Member cannot be retrieved from NodeType Constant.");
    
    [TestMethod]
    public void GetMethodCallInfo_NodeType_NotSupportedException() 
        => ThrowsException
            <NotSupportedException>(
            () => GetMethodCallInfo(() => 1),
            "MethodCallInfo cannot be retrieved from NodeType Constant.");

    [TestMethod]
    public void GetText_NodeType_NotSupportedException()
    {
        int number1 = 1;
        
        ThrowsException(
            () => GetText(() => number1 == 1), 
            "Name cannot be obtained from Equal.");
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertCall()
    {
        string text = GetText(() => (double)IntMethod());
        double value = GetValue(() => (double)IntMethod());
        AreEqual("IntMethod()", () => text);
        AreEqual(1.0, () => value);
    }
    
    //private double CauseConvert(Expression<Func<double>> expression)
    //{
    //}
}