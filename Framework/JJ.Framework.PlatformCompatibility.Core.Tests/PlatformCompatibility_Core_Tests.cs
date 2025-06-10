using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JJ.Framework.Testing.Core;
using JJ.Framework.Testing.Core.docs;
using static System.Console;
using static System.TimeSpan;
using static JJ.Framework.Common.Core.NameHelper;
// ReSharper disable VariableCanBeNotNullable

namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_Core_Tests
{
    [TestMethod]
    public void Test_CallerArgumentExpression_PlatformCompatibility()
    {
        int i = 5;
        CallerArgumentExpressionDummy(i);
    }
    
    private void CallerArgumentExpressionDummy(int arg, [CallerArgumentExpression(nameof(arg))] string expr = "")
    {
        AreEqual("i", expr);
    }

    [TestMethod]
    public void Test_ExceptionSupport_PlatformCompatibility()
    {
        string? nullText = null;
        string? emptyText = "";
        string? spaceText = " \t \n ";
        ThrowsExceptionContaining<ArgumentNullException>(() => ThrowIfNull            (nullText ), "nullText",  "null");
        ThrowsExceptionContaining<ArgumentNullException>(() => ThrowIfNullOrWhiteSpace(nullText ), "nullText",  "null");
        ThrowsExceptionContaining<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(emptyText), "emptyText", "empty");
        ThrowsExceptionContaining<ArgumentException    >(() => ThrowIfNullOrWhiteSpace(spaceText), "spaceText", "space");
    }
    
    [TestMethod]
    public void Test_HashCode_PlatformCompatibility()
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
    
    [TestMethod]
    public void Test_NotNullWhen_PlatformCompatibility()
    {
        var attr = new NotNullWhenAttribute(true);
        IsTrue(attr.ReturnValue);
        
        // ReSharper disable once VariableCanBeNotNullable
        string? nullyFilled = "";
        string? @null = null;
        
        if (!NotNullDummy(nullyFilled))
        {
            string num = nullyFilled; // Compiles: Successfully promoted to non-null.
            NoNullRet(nullyFilled);
        }
        
        if (IsNullDummy(@null))
        {
            // Does not compile = correct = not promoted to non-null
            //string noNull = nullText;
        }
    }
    
    private bool NotNullDummy([NotNullWhen(true)] string? text)
    {
        return text != null;
    }
    
    private bool IsNullDummy([NotNullWhen(false)] string? text)
    {
        return text == null;
    }
}