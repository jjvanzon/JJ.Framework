using static JJ.Framework.Common.Core.NameHelper;
using static JJ.Framework.Reflection.Core.Tests.Helpers.ParseHelperLegacy;
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local

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
        long arg3 = 19;

        int ret = accessor.MyMethod(arg1, out int arg2, arg3);

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
        TimeSpan arg3 = ParseTimeSpan("00:24");

        float ret = accessor.MyMethod(ref arg1, out DateTime arg2, arg3);

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
        
        float arg2 = 32;
        long arg3 = 33;

        DateTime ret = accessor.MyMethod(out double arg1, arg2, ref arg3);

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
        long arg3 = 37;

        int ret = accessor.MyMethod(arg1, out int arg2, ref arg3);

        AreEqual(true, () => arg1);
        AreEqual(36, () => arg2);
        AreEqual(38, () => arg3);
        AreEqual(39, () => ret);
    }

    [TestMethod]
    public void AccessorCore_ByRef_ByRef_ByRef()
    {
        var accessor = new MyAccessor();
        
        DateTime arg2 = ParseDateTime("2041-01-01");
        TimeSpan arg3;

        float ret = accessor.MyMethod(out double arg1, ref arg2, out arg3);

        AreEqual(40, () => arg1);
        AreEqual(ParseDateTime("2042-01-01"), () => arg2);
        AreEqual(ParseTimeSpan("00:43"), () => arg3);
        AreEqual(44, () => ret);
    }
    
    // 4 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_ByRef_ByVal_ByVal_ByVal()
    {
        var accessor = new MyAccessor();
        
        int arg1 = 45;
        long arg2 = 47;
        float arg3 = 48;
        double arg4 = 49;
        byte ret = accessor.MyMethod(ref arg1, arg2, arg3, arg4);
        
        AreEqual(46, () => arg1);
        AreEqual(50, () => ret);
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

        // 2 Parameters (+ explicit names)

        public long MyMethod(ref float arg1, double arg2) 
            => (long)Call(Name(), ref arg1, arg2)!;

        public DateTime MyMethod(TimeSpan arg1, out string arg2)
        {
            arg2 = default;
            return (DateTime)Call(nameof(MyMethod), arg1, ref arg2)!;
        }

        public Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            arg2 = default;
            return (Guid)Call("MyMethod", ref arg1, ref arg2)!;
        }

        // 3 Parameters (+ inline out parameters)

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
        
        // 4 Parameters
        
        public byte MyMethod(ref int arg1, long arg2, float arg3, double arg4)
        {
            return (byte)Call(ref arg1, arg2, arg3, arg4)!;
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
            arg3 = TimeSpan.FromMinutes(43);
            return 44;
        }
        
        // 4 Parameters
        
        private byte MyMethod(ref int arg1, long arg2, float arg3, double arg4)
        {
            AreEqual(45, arg1, nameof(arg1));
            arg1 = 46;
            AreEqual(47, () => arg2);
            AreEqual(48, () => arg3);
            AreEqual(49, () => arg4);
            return 50;
        }
        
        private decimal MyMethod(bool arg1, out string arg2, DateTime arg3, TimeSpan arg4)
        {
            AreEqual(true, () => arg1);
            arg2 = "52";
            AreEqual(ParseDateTime("2053-01-01"), () => arg3);
            AreEqual(TimeSpan.FromMinutes(54), () => arg4);
            return 55;
        }
        
        private Guid MyMethod(ref byte arg1, out int arg2, long arg3, float arg4)
        {
            AreEqual(56, arg1, nameof(arg1));
            arg1 = 57;
            arg2 = 58;
            AreEqual(59, () => arg3);
            AreEqual(60, () => arg4);
            return new Guid("00000000-0000-0000-0000-000000000061");
        }

        private double MyMethod(decimal arg1, bool arg2, ref string arg3, DateTime arg4)
        {
            AreEqual(62, () => arg1);
            AreEqual(true, () => arg2);
            AreEqual("63", arg3, nameof(arg3));
            arg3 = "64";
            AreEqual(ParseDateTime("2065-01-01"), () => arg4);
            return 66;
        }

        private TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, long arg4)
        {
            arg1 =  new Guid("00000000-0000-0000-0000-000000000067");
            AreEqual(68, () => arg2);
            AreEqual(69, arg3, nameof(arg3));
            arg3 = 70;
            AreEqual(71, () => arg4);
            return TimeSpan.FromMinutes(72);
        }

        private float MyMethod(out double arg1, ref decimal arg2, bool arg3, string arg4)
        {
            arg1 = 73;
            AreEqual(74, arg2, nameof(arg2));
            arg2 = 75;
            AreEqual(true, () => arg3);
            AreEqual("76", () => arg4);
            return 77;
        }

        private DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, int arg4)
        {
            arg1 = TimeSpan.FromMinutes(78);
            AreEqual(new Guid("00000000-0000-0000-0000-000000000079"), arg2, nameof(arg2));
            arg2 = new Guid("00000000-0000-0000-0000-000000000080");
            arg3 = 81;
            AreEqual(82, () => arg4);
            return ParseDateTime("2083-01-01");
        }

        private long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4)
        {
            AreEqual(84, () => arg1);
            AreEqual(85, () => arg2);
            AreEqual(86, () => arg3);
            AreEqual(true, arg4, nameof(arg4));
            arg4 = false;
            return 87;
        }

        private string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = ParseDateTime("2088-01-01");
            AreEqual(TimeSpan.FromMinutes(89), () => arg2);
            AreEqual(new Guid("00000000-0000-0000-0000-000000000090"), () => arg3);
            AreEqual(91, arg4, nameof(arg4));
            arg4 = 92;
            return "93";
        }
        
        private int MyMethod(long arg1, out float arg2, double arg3, ref decimal arg4)
        {
            AreEqual(94, () => arg1);
            arg2 = 95;
            AreEqual(96, () => arg3);
            AreEqual(97, arg4, nameof(arg4));
            arg4 = 98;
            return 99;
        }
        
        private bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = "100";
            AreEqual(ParseDateTime("2101-01-01"), arg2, nameof(arg2));
            arg2 = ParseDateTime("2102-01-01");
            AreEqual(TimeSpan.FromMinutes(103),  () => arg3);
            arg4 = new Guid("00000000-0000-0000-0000-000000000104");
            return true;
        }
        
        private byte MyMethod(int arg1, long arg2, ref float arg3, out double arg4)
        {
            AreEqual(105, () => arg1);
            AreEqual(106, () => arg2);
            AreEqual(107, arg3, nameof(arg3));
            arg3 = 108;
            arg4 = 109;
            return 110;
        }
        
        private decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref TimeSpan arg4)
        {
            AreEqual(true, arg1, nameof(arg1));
            arg1 = false;
            AreEqual("111", () => arg2);
            arg3 = ParseDateTime("2112-01-01");
            AreEqual(TimeSpan.FromMinutes(113), arg4, nameof(arg4));
            arg4 = TimeSpan.FromMinutes(114);
            return 115;
        }
        
        private Guid MyMethod(byte arg1, out int arg2, ref long arg3, out float arg4)
        {
            AreEqual(116, () => arg1);
            arg2 = 117;
            AreEqual(118, arg3, nameof(arg3));
            arg3 = 119;
            arg4 = 120;
            return new Guid("00000000-0000-0000-0000-000000000121");
        }
        
        private double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out DateTime arg4)
        {
            AreEqual(122, arg1, nameof(arg1));
            arg1 = 123;
            arg2 = true;
            AreEqual("124", arg3, nameof(arg3));
            arg3 = "125";
            arg4 = ParseDateTime("2126-01-01");
            return 127;
        }
        
        private TimeSpan MyMethod(ref Guid arg1, out byte arg2, ref int arg3, out long arg4)
        {
            AreEqual(new Guid("00000000-0000-0000-0000-000000000128"), arg1, nameof(arg1));
            arg1 = new Guid("00000000-0000-0000-0000-000000000129");
            arg2 = 130;
            AreEqual(131, arg3, nameof(arg3));
            arg3 = 132;
            arg4 = 133; 
            return TimeSpan.FromMinutes(134);
        }
    }
}