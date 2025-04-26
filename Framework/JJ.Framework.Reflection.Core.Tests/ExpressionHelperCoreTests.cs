// ReSharper disable UnusedParameter.Local
// ReSharper disable RedundantCast
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable EventNeverSubscribedTo.Local
// ReSharper disable ValueParameterNotUsed

using System.Linq.Expressions;
using static JJ.Framework.Reflection.ExpressionHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class ExpressionHelperCoreTests
{
    // ncrunch: no coverage start
    
    private void VoidMethod() { }
    private int GetInt() => 1;
    private int MethodWith2Parameters(int a, int b) => 1;
    private int[] GetArray() => [1, 2, 3];
    private event EventHandler Event { add { } remove { } }
    
    // ncrunch: no coverage end

    private class TestIndexer
    {
        public int this[int x, int y] => 1;
    }
    
    // Overloads
    
    [TestMethod]
    public void GetName_WithAction() 
        => AreEqual("VoidMethod", GetName(() => VoidMethod()));

    [TestMethod]
    public void GetMember_WithFunc()
    {
        var memberInfo = GetMember(() => GetInt());
        IsNotNull(() => memberInfo);
        AreEqual("GetInt", memberInfo.Name);
    }
    
    // Exceptions

    [TestMethod]
    public void ExpressionHelper_NodeType_NotSupported()
    {
        int number1 = 1;
        
        ThrowsExceptionContaining(
            () => GetText(() => number1 == 1), 
            "cannot be", "from", "Equal");
        
        ThrowsExceptionContaining(
            () => GetValue(() => number1 == 1), 
            "cannot be", "from", "Equal");
    }

    [TestMethod]
    public void ExpressionHelper_NodeType_NotSupported_WrappedInConversion()
    {
        int number1 = 1;
        
        ThrowsExceptionContaining(
            () => GetText(() => (object)(number1 == 1)), 
            "cannot be", "from", "Equal");
        
        ThrowsExceptionContaining(
            () => GetValue(() => (object)(number1 == 1)), 
            "cannot be", "from", "Equal");
    }
        
    [TestMethod]
    public void GetValue_ArrayIndex_NodeType_NotSupported()
    {
        int[] array = [ 1, 2, 3 ];
        ThrowsExceptionContaining(
            () => GetValue(() => array[GetInt()]),
            "Call", "not supported");
    }
        
    // NOTE: The exception we are trying to test is unreachable.
    //[TestMethod]
    //public void GetValue_Member_NodeType_NotSupported()
    //{
    //    ThrowsExceptionContaining(
    //        () => GetValue(() => Event),
    //        "Event", "not supported");
    //}
    
    [TestMethod]
    public void ExpressionHelper_ArrayLength_NodeType_NotSupported()
    {
        ThrowsExceptionContaining(
            () => GetText(() => GetArray().Length),
            "cannot be", "from", "Call");

        ThrowsExceptionContaining(
            () => GetValue(() => GetArray().Length),
            "cannot be", "from", "Call");
    }
    
    [TestMethod]
    public void GetMember_NodeType_NotSupportedException() 
        => ThrowsExceptionContaining(
            () => GetMember(() => 1), 
            "cannot be", "from", "Constant");
    
    [TestMethod]
    public void GetMethodCallInfo_NodeType_NotSupportedException() 
        => ThrowsExceptionContaining(
            () => GetMethodCallInfo(() => 1),
            "cannot be", "from", "Constant.");
    
    // Expression Node Constructions
    
    [TestMethod]
    public void ExpressionHelper_Indexer_WithMultipleArguments()
    {
        var indexer = new TestIndexer();
        string text = GetText(() => indexer[1, 2]);
        int value = GetValue(() => indexer[1, 2]);
        AreEqual("indexer[1, 2]", () => text);
        AreEqual(1, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_Method_WithMultipleArguments()
    {
        string text = GetText(() => MethodWith2Parameters(1, 2));
        int value = GetValue(() => MethodWith2Parameters(1, 2));
        AreEqual("MethodWith2Parameters(1, 2)", () => text);
        AreEqual(1, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertCall_Explicit()
    {
        string text = GetText(() => (double)GetInt());
        double value = GetValue(() => (double)GetInt());
        AreEqual("GetInt()", () => text);
        AreEqual(1, () => value);
    }
    
    [TestMethod]
    public void ExpressionHelper_ConvertsCall_Implicit()
    {
        double targetType = 2.0;
        var    expression = CauseConvert(() => GetInt(), targetType);
        string text       = GetText(expression);
        double value      = GetValue(expression);
        AssertConvertCall(expression);
        AreEqual("GetInt()", () => text);
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
        var expression = CauseConvert(() => (decimal)(double)GetInt(), targetType);
        string text = GetText(expression);
        object value = GetValue(expression);
        AssertNestedConvert(expression);
        AreEqual("GetInt()", () => text);
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
    
    private static void AssertIsWrappedInConvert(LambdaExpression expression, ExpressionType innerNodeType)
    {
        IsNotNull(() => expression);
        IsNotNull(() => expression.Body);
        IsOfType<UnaryExpression>(() => expression.Body);
        AreEqual(ExpressionType.Convert, () => expression.Body.NodeType);
        
        UnaryExpression unaryExpression = (UnaryExpression)expression.Body;
        IsNotNull(() => unaryExpression.Operand);
        AreEqual(innerNodeType, () => unaryExpression.Operand.NodeType);
    }
}