using static System.TimeSpan;
using static JJ.Framework.Common.Core.NameHelper;
using static JJ.Framework.Reflection.Core.Tests.Helpers.ParseHelperCore;
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
    public void AccessorCore_RefVal()
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
    public void AccessorCore_ValRef()
    {
        var accessor = new MyAccessor();

        TimeSpan arg1 = FromMinutes(06);
        string arg2;

        DateTime ret = accessor.MyMethod(arg1, out arg2);

        AreEqual(FromMinutes(06), () => arg1);
        AreEqual("7", () => arg2);
        AreEqual(FromYear(2008), () => ret);
    }

    [TestMethod]
    public void AccessorCore_RefRef()
    {
        var accessor = new MyAccessor();
        
        string arg1 = "9";
        TimeSpan arg2;

        Guid ret = accessor.MyMethod(ref arg1, out arg2);

        AreEqual("10", () => arg1);
        AreEqual(FromMinutes(11), () => arg2);
        AreEqual(ToGuid(12), () => ret);
    }
    
    // 3 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_RefValVal()
    {
        var accessor = new MyAccessor();

        double arg1 = 13;
        float arg2 = 15;
        long arg3 = 16;

        DateTime ret = accessor.MyMethod(ref arg1, arg2, arg3);

        AreEqual(14, () => arg1);
        AreEqual(15, () => arg2);
        AreEqual(16, () => arg3);
        AreEqual(FromYear(2017), () => ret);
    }

    [TestMethod]
    public void AccessorCore_ValRefVal()
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
    public void AccessorCore_RefRefVal()
    {
        var accessor = new MyAccessor();

        double arg1 = 21;
        TimeSpan arg3 = FromMinutes(24);

        float ret = accessor.MyMethod(ref arg1, out DateTime arg2, arg3);

        AreEqual(22, () => arg1);
        AreEqual(FromYear(2023), () => arg2);
        AreEqual(FromMinutes(24), () => arg3);
        AreEqual(25, () => ret);
    }

    [TestMethod]
    public void AccessorCore_ValValRef()
    {
        var accessor = new MyAccessor();

        Guid arg1 = ToGuid(26);
        string arg2 = "27";
        TimeSpan arg3 = FromMinutes(28);

        string ret = accessor.MyMethod(arg1, arg2, ref arg3);

        AreEqual(ToGuid(26), () => arg1);
        AreEqual("27", () => arg2);
        AreEqual(FromMinutes(29), () => arg3);
        AreEqual("30", () => ret);
    }

    [TestMethod]
    public void AccessorCore_RefValRef()
    {
        var accessor = new MyAccessor();
        
        float arg2 = 32;
        long arg3 = 33;

        DateTime ret = accessor.MyMethod(out double arg1, arg2, ref arg3);

        AreEqual(31, () => arg1);
        AreEqual(32, () => arg2);
        AreEqual(34, () => arg3);
        AreEqual(FromYear(2035), () => ret);
    }

    [TestMethod]
    public void AccessorCore_ValRefRef()
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
    public void AccessorCore_RefRefRef()
    {
        var accessor = new MyAccessor();
        
        DateTime arg2 = FromYear(2041);
        TimeSpan arg3;

        float ret = accessor.MyMethod(out double arg1, ref arg2, out arg3);

        AreEqual(40, () => arg1);
        AreEqual(FromYear(2042), () => arg2);
        AreEqual(FromMinutes(43), () => arg3);
        AreEqual(44, () => ret);
    }
    
    // 4 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_RefValValVal()
    {
        var accessor = new MyAccessor();
        
        var arg1 = 45;
        var arg2 = 47;
        var arg3 = 48;
        var arg4 = 49;
        var ret = accessor.MyMethod(ref arg1, arg2, arg3, arg4);
        
        AreEqual(46, () => arg1);
        AreEqual(50, () => ret);
    }
        
    [TestMethod]
    public void AccessorCore_ValRefValVal()
    {
        var accessor = new MyAccessor();
        
        var arg1 = true;
        var arg2 = "";
        var arg3 = FromYear(2052);
        var arg4 = FromMinutes(53);
        var ret = accessor.MyMethod(arg1, out arg2, arg3, arg4);
        
        AreEqual("51", () => arg2);
        AreEqual(54, () => ret);
    }
        
    [TestMethod]
    public void AccessorCore_RefRefValVal()
    {
        var accessor = new MyAccessor();
        
        var arg1 = (byte)55;
        var arg2 = 56;
        var arg3 = 58;
        var arg4 = 59;
        var ret = accessor.MyMethod(ref arg1, out arg2, arg3, arg4);
        
        AreEqual(57, () => arg2);
        AreEqual(ToGuid(60), () => ret);
    }
        
    [TestMethod]
    public void AccessorCore_ValValRefVal()
    {
        var accessor = new MyAccessor();
        
        var arg1 = 61;
        var arg2 = true;
        var arg3 = "62";
        var arg4 = FromYear(2064);
        var ret = accessor.MyMethod(arg1, arg2, ref arg3, arg4);
        
        AreEqual("63", arg3, nameof(arg2));
        AreEqual(65, () => ret);
    }
        
    [TestMethod]
    public void AccessorCore_RefValRefVal()
    {
        var accessor = new MyAccessor();
        
        var arg1 = ToGuid(0);
        var arg2 = (byte)67;
        var arg3 = 68;
        var arg4 = 70;
        var ret = accessor.MyMethod(out arg1, arg2, ref arg3, arg4);

        AreEqual(ToGuid(66), () => arg1);
        AreEqual(69, arg3, nameof(arg3));
        AreEqual(FromMinutes(71), () => ret);
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRefVal()
    {
        var accessor = new MyAccessor();
        
        var arg1 = 72;
        var arg2 = (decimal)0;
        var arg3 = true;
        var arg4 = "74";
        var ret = accessor.MyMethod(arg1, out arg2, ref arg3, arg4);
        
        AreEqual(73, arg2, nameof(arg2));
        AreEqual(false, arg3, nameof(arg3));
        AreEqual(75, () => ret);
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
            => (byte)Call(ref arg1, arg2, arg3, arg4)!;
        
        public decimal MyMethod(bool arg1, out string arg2, DateTime arg3, TimeSpan arg4)
        {
            arg2 = default;
            return (decimal)Call(arg1, ref arg2, arg3, arg4)!;
        }
        
        public Guid MyMethod(ref byte arg1, out int arg2, long arg3, float arg4)
        {
            arg2 = default;
            return (Guid)Call(ref arg1, ref arg2, arg3, arg4)!;
        }

        public double MyMethod(decimal arg1, bool arg2, ref string arg3, DateTime arg4) 
            => (double)Call(arg1, arg2, ref arg3, arg4)!;

        public TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, long arg4)
        {
            arg1 = default;
            return (TimeSpan)Call(ref arg1, arg2, ref arg3, arg4)!;
        }
        
        public float MyMethod(double arg1, out decimal arg2, ref bool arg3, string arg4)
        {
            arg2 = default;
            return (float)Call(arg1, ref arg2, ref arg3, arg4)!;
        }

        public DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, int arg4)
        {
            arg1 = default;
            arg3 = default;
            return (DateTime)Call(ref arg1, ref arg2, ref arg3, arg4)!;
        }

        public long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4) 
            => (long)Call(arg1, arg2, arg3, ref arg4)!;

        public string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = default;
            return (string)Call(ref arg1, arg2, arg3, ref arg4)!;
        }
        
        public int MyMethod(long arg1, out float arg2, double arg3, ref decimal arg4)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = default;
            arg4 = default;
            return (bool)Call(ref arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public byte MyMethod(int arg1, long arg2, ref float arg3, out double arg4)
        {
            arg4 = default;
            return (byte)Call(arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref TimeSpan arg4)
        {
            arg3 = default;
            return (decimal)Call(ref arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public Guid MyMethod(byte arg1, out int arg2, ref long arg3, out float arg4)
        {
            arg2 = default;
            arg4 = default;
            return (Guid)Call(arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out DateTime arg4)
        {
            arg2 = default;
            arg4 = default;
            return (double)Call(ref arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public TimeSpan MyMethod(ref Guid arg1, out byte arg2, ref int arg3, out long arg4)
        {
            arg2 = default;
            arg4 = default;
            return (TimeSpan)Call(ref arg1, ref arg2, ref arg3, ref arg4)!;
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
            AreEqual(FromMinutes(6), () => arg1);
            arg2 = "7";
            return FromYear(2008);
        }

        private Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            AreEqual("9", arg1, nameof(arg1));
            arg1 = "10";
            arg2 = FromMinutes(11);
            return ToGuid(12);
        }

        // 3 Parameters

        private DateTime MyMethod(ref double arg1, float arg2, long arg3)
        {
            AreEqual(13d, arg1, nameof(arg1));
            arg1 = 14;
            AreEqual(15f, () => arg2);
            AreEqual(16, () => arg3);
            return FromYear(2017);
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
            arg2 = FromYear(2023);
            AreEqual(FromMinutes(24), () => arg3);
            return 25;
        }

        private string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
        {
            AreEqual(ToGuid(26), () => arg1);
            AreEqual("27", () => arg2);
            AreEqual(FromMinutes(28), arg3, nameof(arg3));
            arg3 = FromMinutes(29);
            return "30";
        }

        private DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = 31;
            AreEqual(32f, () => arg2);
            AreEqual(33l, arg3, nameof(arg3));
            arg3 = 34;
            return FromYear(2035);
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
            AreEqual(FromYear(2041), arg2, nameof(arg2));
            arg2 = FromYear(2042);
            arg3 = FromMinutes(43);
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
            arg2 = "51";
            AreEqual(FromYear(2052), () => arg3);
            AreEqual(FromMinutes(53), () => arg4);
            return 54;
        }
        
        private Guid MyMethod(ref byte arg1, out int arg2, long arg3, float arg4)
        {
            AreEqual(55, arg1, nameof(arg1));
            arg1 = 56;
            arg2 = 57;
            AreEqual(58, () => arg3);
            AreEqual(59, () => arg4);
            return ToGuid(60);
        }

        private double MyMethod(decimal arg1, bool arg2, ref string arg3, DateTime arg4)
        {
            AreEqual(61, () => arg1);
            AreEqual(true, () => arg2);
            AreEqual("62", arg3, nameof(arg3));
            arg3 = "63";
            AreEqual(FromYear(2064), () => arg4);
            return 65;
        }

        private TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, long arg4)
        {
            arg1 = ToGuid(66);
            AreEqual(67, () => arg2);
            AreEqual(68, arg3, nameof(arg3));
            arg3 = 69;
            AreEqual(70, () => arg4);
            return FromMinutes(71);
        }

        private float MyMethod(double arg1, out decimal arg2, ref bool arg3, string arg4)
        {
            AreEqual(72, arg1, nameof(arg2));
            arg2 = 73;
            AreEqual(true, arg3, nameof(arg3));
            arg3 = false;
            AreEqual("74", () => arg4);
            return 75;
        }

        private DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, int arg4)
        {
            arg1 = FromMinutes(77);
            AreEqual(ToGuid(78), arg2, nameof(arg2));
            arg2 = ToGuid(79);
            arg3 = 80;
            AreEqual(81, () => arg4);
            return FromYear(2082);
        }

        private long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4)
        {
            AreEqual(83, () => arg1);
            AreEqual(84, () => arg2);
            AreEqual(85, () => arg3);
            AreEqual(true, arg4, nameof(arg4));
            arg4 = false;
            return 86;
        }

        private string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = FromYear(2087);
            AreEqual(FromMinutes(88), () => arg2);
            AreEqual(ToGuid(89), () => arg3);
            AreEqual(90, arg4, nameof(arg4));
            arg4 = 91;
            return "92";
        }
        
        private int MyMethod(long arg1, out float arg2, double arg3, ref decimal arg4)
        {
            AreEqual(93, () => arg1);
            arg2 = 94;
            AreEqual(95, () => arg3);
            AreEqual(96, arg4, nameof(arg4));
            arg4 = 97;
            return 98;
        }
        
        private bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = "99";
            AreEqual(FromYear(2100), arg2, nameof(arg2));
            arg2 = FromYear(2101);
            AreEqual(FromMinutes(102),  () => arg3);
            arg4 = new Guid("00000000-0000-0000-0000-000000000103");
            return true;
        }
        
        private byte MyMethod(int arg1, long arg2, ref float arg3, out double arg4)
        {
            AreEqual(104, () => arg1);
            AreEqual(105, () => arg2);
            AreEqual(106, arg3, nameof(arg3));
            arg3 = 107;
            arg4 = 108;
            return 109;
        }
        
        private decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref TimeSpan arg4)
        {
            AreEqual(true, arg1, nameof(arg1));
            arg1 = false;
            AreEqual("110", () => arg2);
            arg3 = FromYear(2111);
            AreEqual(FromMinutes(112), arg4, nameof(arg4));
            arg4 = FromMinutes(113);
            return 114;
        }
        
        private Guid MyMethod(byte arg1, out int arg2, ref long arg3, out float arg4)
        {
            AreEqual(115, () => arg1);
            arg2 = 116;
            AreEqual(117, arg3, nameof(arg3));
            arg3 = 118;
            arg4 = 119;
            return new Guid("00000000-0000-0000-0000-000000000120");
        }
        
        private double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out DateTime arg4)
        {
            AreEqual(121, arg1, nameof(arg1));
            arg1 = 122;
            arg2 = true;
            AreEqual("123", arg3, nameof(arg3));
            arg3 = "124";
            arg4 = FromYear(2125);
            return 126;
        }
        
        private TimeSpan MyMethod(ref Guid arg1, out byte arg2, ref int arg3, out long arg4)
        {
            AreEqual(new Guid("00000000-0000-0000-0000-000000000127"), arg1, nameof(arg1));
            arg1 = new Guid("00000000-0000-0000-0000-000000000128");
            arg2 = 129;
            AreEqual(130, arg3, nameof(arg3));
            arg3 = 131;
            arg4 = 132; 
            return FromMinutes(133);
        }
    }
}