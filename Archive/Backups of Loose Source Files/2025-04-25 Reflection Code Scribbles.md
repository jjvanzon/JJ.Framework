
```cs
[TestMethod]
public void ExpressionHelper_ConvertCall_Implicit_ThroughExpressionType()
{
    // This expression has return type double, while the method returns int,
    // causing the expression tree to contain an implicit conversion to double,
    // which ExpressionHelper then needs to support internally.
    Expression<Func<double>> expression = () => IntMethod();
    
    string text = GetText(expression);
    double value = GetValue(expression);
    AreEqual("IntMethod()", () => text);
    AreEqual(1.0, () => value);
}

    {
        IsNotNull(() => expression);
        Type concreteType = expression.GetType();
        //AreEqual(typeof(), () => concreteType);
        
        return expression;
    }
```

```cs
        //int constant = 1;
        //double targetType = 2;
        
        // Compiler "helpfully" optimizes out our conversions. Trying different ways to get it to work.
        //var expression = CauseConvert(() => constant, targetType);
        //Expression<Func<double>> expression = () => (double)constant;
        //Expression<Func<double>> expression = () => constant;
        //Expression<Func<double>> expression = () => 1 + 1;
        //Expression<Func<double>> expression = ConstructConstConvert(constant);
    
    private static Expression<Func<double>> ConstructConstConvert(int value)
    {
        var intConst = Expression.Constant(value, typeof(int));
        var asDouble = Expression.Convert(intConst, typeof(double));
        return Expression.Lambda<Func<double>>(asDouble);
    }

        Expression<Func<object>> expression = () => (object)constant;

    
    private void AssertConvertConstant(LambdaExpression expression) 
        => AssertIsWrappedInConvert(expression, ExpressionType.Constant);

    private static void AssertIsWrappedInConvert(LambdaExpression expression, ExpressionType expectedInnerNodeType)
    {
        // TODO: Has weird failure message for AssertConvertConstant.
        // IsOfType<UnaryExpression>(() => expression.Body);
        Assert.IsInstanceOfType<UnaryExpression>(expression.Body);
    }
```

    /// <summary> Compiler-generated [DefaultMember("Item")] because of the indexer  </summary>
    /// <summary> Has Item property, but not DefaultMemberAttribute. Kinda kike an indexer. </summary>
    /// <summary> Has Item property, but not DefaultMemberAttribute. Kinda kike an indexer. </summary>
    /// <summary> Normal-ish class without an indexer </summary>

        //ThrowsException(() => IsStatic(GetType().GetEvents()[0]), "IsStatic cannot be obtained from member of type 'System.Reflection.EventInfo'.");
        //ThrowsException(() => IsStatic(GetType().GetProperties().Where(x => x.GetIndexParameters().Length > 0).First()), "IsStatic cannot be obtained from member of type 'System.Reflection.PropertyInfo'.");
