// ReSharper disable UnusedParameter.Local
// ReSharper disable RedundantCast
// ReSharper disable ExpressionIsAlwaysNull

using System.Linq.Expressions;
using static JJ.Framework.Reflection.ExpressionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ExpressionHelperCoreTests
{
    private void VoidMethod() { } // ncrunch: no coverage
    private int IntMethod() => 1; // ncrunch: no coverage
    
    // Overloads
    
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
    
    // Exceptions
    
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
        
        ThrowsExceptionContaining(
            () => GetText(() => number1 == 1), 
            "Name cannot be obtained from", "Equal.");
    }

    [TestMethod]
    public void GetText_NodeType_NotSupportedException_WrappedInConversion()
    {
        int number1 = 1;
        
        ThrowsExceptionContaining(
            () => GetText(() => (object)(number1 == 1)), 
            "Name cannot be obtained from", "Equal.");
    }
    
    // Expression Node Constructions
    
    [TestMethod]
    public void ExpressionHelper_ConvertCall_Explicit()
    {
        string text = GetText(() => (double)IntMethod());
        double value = GetValue(() => (double)IntMethod());
        AreEqual("IntMethod()", () => text);
        AreEqual(1, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertsCall_Implicit()
    {
        double targetType = 2.0;
        var    expression = CauseConvert(() => IntMethod(), targetType);
        string text       = GetText(expression);
        double value      = GetValue(expression);
        AssertConvertCall(expression);
        AreEqual("IntMethod()", () => text);
        AreEqual(1, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertsArrayIndex_Implicit()
    {
        int[]  array      = [ 1, 2, 3 ];
        double targetType = 2.0;
        var    expression = CauseConvert(() => array[0], targetType);
        string text       = GetText(expression);
        double value      = GetValue(expression);
        AssertConvertArrayIndex(expression);
        AreEqual("array[0]", () => text);
        AreEqual(1, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertsConstant_Implicit()
    {
        const int constant = 1;
        // Cast to object forces boxing, keeping the compiler from optimizing away
        // the convert expression tree node we're trying to test.
        object? targetType = null;
        var expression = CauseConvert(() => constant, targetType);
        string text  = GetText(expression);
        object value = GetValue(expression);
        AssertConvertConstant(expression);
        AreEqual("1", () => text);
        AreEqual(1, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_NestedConversions()
    {
        object? targetType = null;
        var expression = CauseConvert(() => (decimal)(double)IntMethod(), targetType);
        string text = GetText(expression);
        object value = GetValue(expression);
        AssertNestedConvert(expression);
        AreEqual("IntMethod()", () => text);
        AreEqual(1m, () => value); 
    }
    
    /// <summary>
    /// This helper stimulates the construction of a Convert node.
    /// Using expressions with a generic method,
    /// can easily cause an implicit conversion
    /// that leaks into the expression tree.
    /// </summary>
    private Expression<Func<T>> CauseConvert<T>(Expression<Func<T>> expression, T target) => expression;
    
    private void AssertConvertCall(LambdaExpression expression) 
        => AssertIsWrappedInConvert(expression, ExpressionType.Call);
    
    private void AssertConvertArrayIndex(LambdaExpression expression) 
        => AssertIsWrappedInConvert(expression, ExpressionType.ArrayIndex);
    
    private void AssertConvertConstant(LambdaExpression expression) 
        => AssertIsWrappedInConvert(expression, ExpressionType.Constant);
    
    private void AssertNestedConvert(LambdaExpression expression) 
        => AssertIsWrappedInConvert(expression, ExpressionType.Convert);
    
    private static void AssertIsWrappedInConvert(LambdaExpression expression, ExpressionType expectedInnerNodeType)
    {
        IsNotNull(() => expression);
        IsNotNull(() => expression.Body);
        // TODO: Has weird failure message for AssertConvertConstant.
        //IsOfType<UnaryExpression>(() => expression.Body);
        Assert.IsInstanceOfType<UnaryExpression>(expression.Body);
        AreEqual(ExpressionType.Convert, () => expression.Body.NodeType);
        
        UnaryExpression unaryExpression = (UnaryExpression)expression.Body;
        IsNotNull(() => unaryExpression.Operand);
        AreEqual(expectedInnerNodeType, () => unaryExpression.Operand.NodeType);
    }
}