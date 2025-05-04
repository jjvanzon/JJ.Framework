using static JJ.Framework.Reflection.Core.Tests.Helpers.ParseHelperLegacy;
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_RefArgs
{
    // Test Methods
    
    // 1 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_1Out()
    {
        var accessor = new MyAccessor();
        
        int arg;
        bool ret = accessor.MyMethod(out arg);
        
        AreEqual(1, () => arg);
        IsTrue(() => ret);
    }
    
    // 2 Parameters Tests

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
    
    // 3 Parameter Tests
    
    // TODO: Inline out variables for variation and terseness
    
    [TestMethod]
    public void AccessorCore_ByRef_ByVal_ByVal()
    {
        var accessor = new MyAccessor();

        double arg1 = 13;
        float arg2 = 15;
        long arg3 = 16;

        DateTime ret = accessor.MyMethod(ref arg1, arg2, arg3);

        AreEqual(14, () => arg1);
        AreEqual(15, () => arg2);
        AreEqual(16, () => arg3);
        AreEqual(ParseDateTime("2017-01-01"), () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByVal_ByRef_ByVal()
    {
        var accessor = new MyAccessor();

        bool arg1 = true;
        int arg2;
        long arg3 = 19;

        int ret = accessor.MyMethod(arg1, out arg2, arg3);

        AreEqual(true, () => arg1);
        AreEqual(18, () => arg2);
        AreEqual(19, () => arg3);
        AreEqual(20, () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByRef_ByRef_ByVal()
    {
        var accessor = new MyAccessor();

        double arg1 = 21;
        DateTime arg2;
        TimeSpan arg3 = ParseTimeSpan("00:24");

        float ret = accessor.MyMethod(ref arg1, out arg2, arg3);

        AreEqual(22, () => arg1);
        AreEqual(ParseDateTime("2023-01-01"), () => arg2);
        AreEqual(ParseTimeSpan("00:24"), () => arg3);
        AreEqual(25, () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByVal_ByVal_ByRef()
    {
        var accessor = new MyAccessor();

        Guid arg1 = new Guid("00000000-0000-0000-0000-000000000026");
        string arg2 = "27";
        TimeSpan arg3 = ParseTimeSpan("00:28");

        string ret = accessor.MyMethod(arg1, arg2, ref arg3);

        AreEqual(new Guid("00000000-0000-0000-0000-000000000026"), () => arg1);
        AreEqual("27", () => arg2);
        AreEqual(ParseTimeSpan("00:29"), () => arg3);
        AreEqual("30", () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByRef_ByVal_ByRef()
    {
        var accessor = new MyAccessor();

        double arg1;
        float arg2 = 32;
        long arg3 = 33;

        DateTime ret = accessor.MyMethod(out arg1, arg2, ref arg3);

        AreEqual(31, () => arg1);
        AreEqual(32, () => arg2);
        AreEqual(34, () => arg3);
        AreEqual(ParseDateTime("2035-01-01"), () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByVal_ByRef_ByRef()
    {
        var accessor = new MyAccessor();

        bool arg1 = true;
        int arg2;
        long arg3 = 37;

        int ret = accessor.MyMethod(arg1, out arg2, ref arg3);

        AreEqual(true, () => arg1);
        AreEqual(36, () => arg2);
        AreEqual(38, () => arg3);
        AreEqual(39, () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByRef_ByRef_ByRef()
    {
        var accessor = new MyAccessor();

        double arg1;
        DateTime arg2 = ParseDateTime("2041-01-01");
        TimeSpan arg3;

        float ret = accessor.MyMethod(out arg1, ref arg2, out arg3);

        AreEqual(40, () => arg1);
        AreEqual(ParseDateTime("2042-01-01"), () => arg2);
        AreEqual(ParseTimeSpan("00:43"), () => arg3);
        AreEqual(44, () => ret);
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

        // TODO: Use overload with explicit name at the front for variance.
        
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

        // 3 Parameters

        public DateTime MyMethod(ref double arg1, float arg2, long arg3)
            => (DateTime)Call(ref arg1, arg2, arg3)!;

        public int MyMethod(bool arg1, out int arg2, long arg3)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, arg3)!;
        }

        public float MyMethod(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            arg2 = default;
            return (float)Call(ref arg1, ref arg2, arg3)!;
        }

        public string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
            => (string)Call(arg1, arg2, ref arg3)!;

        public DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = default;
            return (DateTime)Call(ref arg1, arg2, ref arg3)!;
        }

        public int MyMethod(bool arg1, out int arg2, ref long arg3)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, ref arg3)!;
        }

        public float MyMethod(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = default;
            arg3 = default;
            return (float)Call(ref arg1, ref arg2, ref arg3)!;
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

        // 3 Parameters

        private DateTime MyMethod(ref double arg1, float arg2, long arg3)
        {
            AreEqual(13d, arg1, nameof(arg1));
            arg1 = 14;
            AreEqual(15f, () => arg2);
            AreEqual(16, () => arg3);
            return ParseDateTime("2017-01-01");
        }

        private int MyMethod(bool arg1, out int arg2, long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 18;
            AreEqual(19, () => arg3);
            return 20;
        }

        private float MyMethod(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            AreEqual(21d, arg1, nameof(arg1));
            arg1 = 22;
            arg2 = ParseDateTime("2023-01-01");
            AreEqual(ParseTimeSpan("00:24"), () => arg3);
            return 25;
        }

        private string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
        {
            AreEqual(new Guid("00000000-0000-0000-0000-000000000026"), () => arg1);
            AreEqual("27", () => arg2);
            AreEqual(ParseTimeSpan("00:28"), arg3, nameof(arg3));
            arg3 = ParseTimeSpan("00:29");
            return "30";
        }

        private DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = 31;
            AreEqual(32f, () => arg2);
            AreEqual(33l, arg3, nameof(arg3));
            arg3 = 34;
            return ParseDateTime("2035-01-01");
        }

        private int MyMethod(bool arg1, out int arg2, ref long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 36;
            AreEqual(37l, arg3, nameof(arg3));
            arg3 = 38;
            return 39;
        }

        private float MyMethod(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = 40;
            AreEqual(ParseDateTime("2041-01-01"), arg2, nameof(arg2));
            arg2 = ParseDateTime("2042-01-01");
            arg3 = ParseTimeSpan("00:43");
            return 44;
        }
    }
}