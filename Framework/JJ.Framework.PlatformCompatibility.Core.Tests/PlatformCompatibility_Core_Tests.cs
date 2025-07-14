using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static System.Console;
using static System.TimeSpan;
// ReSharper disable VariableCanBeNotNullable
// ReSharper disable UseSymbolAlias

namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_Core_Tests
{
    // CallerArgumentExpression
    
    [TestMethod]
    public void Test_CallerArgumentExpression_PlatformStub()
    {
        var attribute = new CallerArgumentExpressionAttribute("name");
        AreEqual("name", attribute.ParameterName);

        int i = 5;
        CallerArgumentExpressionDummy(i);
    }
    
    private void CallerArgumentExpressionDummy(int arg, [CallerArgumentExpression(nameof(arg))] string expr = "")
    {
        AreEqual("i", expr);
    }

    // ExceptionSupport
    
    [TestMethod]
    public void Test_ExceptionSupport_PlatformStub()
    {
        string? nullText = null;
        string? emptyText = "";
        string? spaceText = " \t \n ";
        ThrowsExceptionContaining<ArgumentNullException>(() => ThrowIfNull            (nullText ), "nullText",  "null");
        ThrowsExceptionContaining<ArgumentNullException>(() => ThrowIfNullOrWhiteSpace(nullText ), "nullText",  "null");
        ThrowsExceptionContaining<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(emptyText), "emptyText", "empty");
        ThrowsExceptionContaining<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(spaceText), "spaceText", "space");
    }
    
    // HashCode
    
    [TestMethod]
    public void Test_HashCode_PlatformStub()
    {
        int hashCode1 =  HashCode.Combine(1);
        int hashCode2 =  HashCode.Combine(1, 2l);
        int hashCode3 =  HashCode.Combine(1, 2l, 3f);
        int hashCode4 =  HashCode.Combine(1, 2l, 3f, 4d);
        int hashCode5 =  HashCode.Combine(1, 2l, 3f, 4d, 5m);
        int hashCode6 =  HashCode.Combine(1, 2l, 3f, 4d, 5m, "6");
        int hashCode7 =  HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7);
        int hashCode8 =  HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7, FromMinutes(8));
        WriteLine(TextOf(HashCode.Combine(1)) + " = " + hashCode1);
        WriteLine(TextOf(HashCode.Combine(1, 2l)) + " = " + hashCode2);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f)) + " = " + hashCode3);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d)) + " = " + hashCode4);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m)) + " = " + hashCode5);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m, "6")) + " = " + hashCode6);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7)) + " = " + hashCode7);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7, FromMinutes(8))) + " = " + hashCode8);
        IsTrue(hashCode1 != 0);
        IsTrue(hashCode2 != 0);
        IsTrue(hashCode3 != 0);
        IsTrue(hashCode4 != 0);
        IsTrue(hashCode5 != 0);
        IsTrue(hashCode6 != 0);
        IsTrue(hashCode7 != 0);
        IsTrue(hashCode8 != 0);
    }
    
    // NotNullWhen
    
    [TestMethod]
    public void Test_NotNullWhen_PlatformStub()
    {
        var attr = new NotNullWhenAttribute(true);
        IsTrue(attr.ReturnValue);
        
        // ReSharper disable once VariableCanBeNotNullable
        string? nullyFilled = "";
        string? @null = null;
        
        if (!CheckNotNull(nullyFilled))
        // ncrunch: no coverage start
        {
            string num = nullyFilled; // Compiles: Successfully promoted to non-null.
            NoNullRet(nullyFilled);
        }
        // ncrunch: no coverage end
        
        if (CheckIsNull(@null))
        {
            // Does not compile = correct = not promoted to non-null
            //string noNull = nullText;
        }
    }
    
    private bool CheckNotNull([NotNullWhen(true)] string? text) => text != null;
    private bool CheckIsNull([NotNullWhen(false)] string? text) => text == null;
    
    // OverloadResolutionPriority
    
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Create()
    {
        var prio1Attribute = new OverloadResolutionPriorityAttribute(1);
        AreEqual(1, prio1Attribute.Priority);

        var prio0Attribute = new OverloadResolutionPriorityAttribute(0);
        AreEqual(0, prio0Attribute.Priority);
    }
    
    [TestMethod]
    public void Test_PlatformStub_OverloadResolutionPriority_Implicit()
    {
        AreEqual("Overload(A,B)", Overload("A", "B"));
        AreEqual("Overload(A)", Overload("A"));
    }
    
    private string Overload(string text) => $"Overload({text})";
    // ReSharper disable once MethodOverloadWithOptionalParameter
    private string Overload(string text1, string text2 = "C") => $"Overload({text1},{text2})";
    
    [TestMethod]
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