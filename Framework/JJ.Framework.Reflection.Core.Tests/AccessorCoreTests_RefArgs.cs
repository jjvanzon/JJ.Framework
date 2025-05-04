// ReSharper disable InlineOutVariableDeclaration

using static JJ.Framework.Reflection.Core.Tests.Helpers.ParseHelperLegacy;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_RefArgs
{
    // Test Methods
    
    // 1 Parameter
    
    [TestMethod]
    public void AccessorCore_1Out()
    {
        var accessor = new MyAccessor();
        
        int arg;
        bool ret = accessor.MyMethod(out arg);
        
        AreEqual(1, () => arg);
        IsTrue(() => ret);
    }
    
    // 2 Parameters

    [TestMethod]
    public void AccessorCore_ByRef_ByVal()
    {
        var accessor = new MyAccessor();
     
        float arg1 = 2;
        double arg2 = 4;

        long ret = accessor.MyMethod(ref arg1, arg2);

        AreEqual(3, () => arg1);
        AreEqual(4, () => arg2);
        AreEqual(5, () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByVal_ByRef()
    {
        var accessor = new MyAccessor();

        TimeSpan arg1 = ParseTimeSpan("00:06");
        string arg2;

        DateTime ret = accessor.MyMethod(arg1, out arg2);

        AreEqual(ParseTimeSpan("00:06"), () => arg1);
        AreEqual("7", () => arg2);
        AreEqual(ParseDateTime("2008-01-01"), () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByRef_ByRef()
    {
        var accessor = new MyAccessor();
        
        string arg1 = "9";
        TimeSpan arg2;

        Guid ret = accessor.MyMethod(ref arg1, out arg2);

        AreEqual("10", () => arg1);
        AreEqual(ParseTimeSpan("00:11"), () => arg2);
        AreEqual(new Guid("00000000-0000-0000-0000-000000000012"), () => ret);
    }
    
    
    // Accessor Class
    
    private class MyAccessor() : AccessorCore(new MyClass())
    {
        // 1 Parameter
        
        public bool MyMethod(out int arg)
        {
            arg = default;
            return (bool)Call(ref arg)!;
        }

        // 2 Parameters

        public long MyMethod(ref float arg1, double arg2) 
            => (long)Call(ref arg1, arg2)!;

        public DateTime MyMethod(TimeSpan arg1, out string arg2)
        {
            arg2 = default;
            return (DateTime)Call(arg1, ref arg2)!;
        }

        public Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            arg2 = default;
            return (Guid)Call(ref arg1, ref arg2)!;
        }
    }
    
    // Target Class
    
    private class MyClass
    {
        // 1 Parameter

        private bool MyMethod(out int arg)
        {
            arg = 1;
            return true;
        }

        // 2 Parameters
        
        private long MyMethod(ref float arg1, double arg2)
        {
            AreEqual(2f, arg1, nameof(arg1));
            arg1 = 3;
            AreEqual(4d, () => arg2);
            return 5;
        }

        private DateTime MyMethod(TimeSpan arg1, out string arg2)
        {
            AreEqual(ParseTimeSpan("00:06"), () => arg1);
            arg2 = "7";
            return ParseDateTime("2008-01-01");
        }

        private Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            AreEqual("9", arg1, nameof(arg1));
            arg1 = "10";
            arg2 = ParseTimeSpan("00:11");
            return new Guid("00000000-0000-0000-0000-000000000012");
        }
    }
}