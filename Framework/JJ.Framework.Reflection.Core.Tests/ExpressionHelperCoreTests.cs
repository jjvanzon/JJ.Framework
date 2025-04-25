// ReSharper disable UnusedParameter.Local

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
    public void ExpressionHelper_ConvertCall_Explicit()
    {
        string text = GetText(() => (double)IntMethod());
        double value = GetValue(() => (double)IntMethod());
        AreEqual("IntMethod()", () => text);
        AreEqual(1.0, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertsCall_Implicit()
    {
        double input = 2.0;
        var expression = CauseConvert(input, () => IntMethod());
        string text = GetText(expression);
        double value = GetValue(expression);
        AssertConvertCall(expression);
        AreEqual("IntMethod()", () => text);
        AreEqual(1.0, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertsArrayIndex_Implicit()
    {
        int[] array = [ 1, 2, 3 ];
        double comparison = 2.0;
        var expression = CauseConvert(comparison, () => array[1]);
        string text = GetText(expression);
        double value = GetValue(expression);
        AssertConvertArrayIndex(expression);
        AreEqual("array[1]", () => text);
        AreEqual(2,          () => value);
    }
    
    /// <summary>
    /// Using expressions with a generic method,
    /// can easily cause an implicit conversion
    /// that leaks into the expression tree,
    /// which can happen frequently enough that
    /// ExpressionHelper has to support that internally.
    /// </summary>
    private Expression<Func<T>> CauseConvert<T>(T value, Expression<Func<T>> expression) => expression;
    
    private void AssertConvertCall(LambdaExpression expression) => AssertIsWrappedInConvert(expression, ExpressionType.Call);
    private void AssertConvertArrayIndex(LambdaExpression expression) => AssertIsWrappedInConvert(expression, ExpressionType.ArrayIndex);
    
    private static void AssertIsWrappedInConvert(LambdaExpression expression, ExpressionType expectedInnerNodeType)
    {
        IsNotNull(() => expression);
        IsNotNull(() => expression.Body);
        IsOfType<UnaryExpression>(() => expression.Body);
        AreEqual(ExpressionType.Convert, () => expression.Body.NodeType);
        
        UnaryExpression unaryExpression = (UnaryExpression)expression.Body;
        IsNotNull(() => unaryExpression.Operand);
        AreEqual(expectedInnerNodeType, () => unaryExpression.Operand.NodeType);
    }
}