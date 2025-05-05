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
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() })
        {
            int  arg;
            bool ret = accessor.MyMethod(out arg);
            
            AreEqual(1, () => arg);
            IsTrue(() => ret);
        }
    }
    
    // 2 Parameters Tests

    [TestMethod]
    public void AccessorCore_RefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        {
            float arg1 = 2;
            double arg2 = 4;

            long ret = accessor.MyMethod(ref arg1, arg2);

            AreEqual(3, () => arg1);
            AreEqual(4, () => arg2);
            AreEqual(5, () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        {
            TimeSpan arg1 = FromSeconds(06);
            string arg2;

            DateTime ret = accessor.MyMethod(arg1, out arg2);

            AreEqual(FromSeconds(06), () => arg1);
            AreEqual("7", () => arg2);
            AreEqual(FromYear(8), () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        {
            string arg1 = "9";
            TimeSpan arg2;

            Guid ret = accessor.MyMethod(ref arg1, out arg2);

            AreEqual("10", () => arg1);
            AreEqual(FromSeconds(11), () => arg2);
            AreEqual(ToGuid(12), () => ret);
        }
    }
    
    // 3 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_RefValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            double arg1 = 13;
            float  arg2 = 15;
            long   arg3 = 16;
            
            DateTime ret = accessor.MyMethod(ref arg1, arg2, arg3);
            
            AreEqual(14,           () => arg1);
            AreEqual(15,           () => arg2);
            AreEqual(16,           () => arg3);
            AreEqual(FromYear(17), () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            bool arg1 = true;
            long arg3 = 19;
            
            int ret = accessor.MyMethod(arg1, out int arg2, arg3);
            
            AreEqual(true, () => arg1);
            AreEqual(18,   () => arg2);
            AreEqual(19,   () => arg3);
            AreEqual(20,   () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            double   arg1 = 21;
            TimeSpan arg3 = FromSeconds(24);
            
            float ret = accessor.MyMethod(ref arg1, out DateTime arg2, arg3);
            
            AreEqual(22,              () => arg1);
            AreEqual(FromYear(23),    () => arg2);
            AreEqual(FromSeconds(24), () => arg3);
            AreEqual(25,              () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            Guid     arg1 = ToGuid(26);
            string   arg2 = "27";
            TimeSpan arg3 = FromSeconds(28);
            
            string ret = accessor.MyMethod(arg1, arg2, ref arg3);
            
            AreEqual(ToGuid(26),      () => arg1);
            AreEqual("27",            () => arg2);
            AreEqual(FromSeconds(29), () => arg3);
            AreEqual("30",            () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            float arg2 = 32;
            long  arg3 = 33;
            
            DateTime ret = accessor.MyMethod(out double arg1, arg2, ref arg3);
            
            AreEqual(31,           () => arg1);
            AreEqual(32,           () => arg2);
            AreEqual(34,           () => arg3);
            AreEqual(FromYear(35), () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            bool arg1 = true;
            long arg3 = 37;
            
            int ret = accessor.MyMethod(arg1, out int arg2, ref arg3);
            
            AreEqual(true, () => arg1);
            AreEqual(36,   () => arg2);
            AreEqual(38,   () => arg3);
            AreEqual(39,   () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            DateTime arg2 = FromYear(41);
            TimeSpan arg3;
            
            float ret = accessor.MyMethod(out double arg1, ref arg2, out arg3);
            
            AreEqual(40,              () => arg1);
            AreEqual(FromYear(42),    () => arg2);
            AreEqual(FromSeconds(43), () => arg3);
            AreEqual(44,              () => ret);
        }
    }
    
    // 4 Parameter Tests
    
    [TestMethod]
    public void AccessorCore_RefValValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = 45;
            var arg2 = 47;
            var arg3 = 48;
            var arg4 = 49;
            var ret  = accessor.MyMethod(ref arg1, arg2, arg3, arg4);
            
            AreEqual(46, () => arg1);
            AreEqual(50, () => ret);
        }
    }
        
    [TestMethod]
    public void AccessorCore_ValRefValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = true;
            var arg2 = "";
            var arg3 = FromYear(52);
            var arg4 = FromSeconds(53);
            var ret  = accessor.MyMethod(arg1, out arg2, arg3, arg4);
            
            AreEqual("51", () => arg2);
            AreEqual(54,   () => ret);
        }
    }
        
    [TestMethod]
    public void AccessorCore_RefRefValVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = (byte)55;
            var arg2 = 56;
            var arg3 = 58;
            var arg4 = 59;
            var ret  = accessor.MyMethod(ref arg1, out arg2, arg3, arg4);
            
            AreEqual(57,         () => arg2);
            AreEqual(ToGuid(60), () => ret);
        }
    }
        
    [TestMethod]
    public void AccessorCore_ValValRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = 61;
            var arg2 = true;
            var arg3 = "62";
            var arg4 = FromYear(64);
            var ret  = accessor.MyMethod(arg1, arg2, ref arg3, arg4);
            
            AreEqual("63", () => arg3);
            AreEqual(65,   () => ret);
        }
    }
        
    [TestMethod]
    public void AccessorCore_RefValRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = ToGuid(0);
            var arg2 = (byte)67;
            var arg3 = 68;
            var arg4 = 70;
            var ret  = accessor.MyMethod(out arg1, arg2, ref arg3, arg4);
            
            AreEqual(ToGuid(66),      () => arg1);
            AreEqual(69,              () => arg3);
            AreEqual(FromSeconds(71), () => ret);
        }
    }
    
    [TestMethod]
    public void AccessorCore_ValRefRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = 72;
            var arg2 = (decimal)0;
            var arg3 = true;
            var arg4 = "74";
            var ret  = accessor.MyMethod(arg1, out arg2, ref arg3, arg4);
            
            AreEqual(73,    () => arg2);
            AreEqual(false, () => arg3);
            AreEqual(75,    () => ret);
        }
    }
        
    [TestMethod]
    public void AccessorCore_RefRefRefVal()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = FromSeconds(0);
            var arg2 = ToGuid(77);
            var arg3 = (byte)0;
            var arg4 = 80;
            var ret  = accessor.MyMethod(out arg1, ref arg2, out arg3, arg4);
            
            AreEqual(FromSeconds(76), () => arg1);
            AreEqual(ToGuid(78),      () => arg2);
            AreEqual(79,              () => arg3);
            AreEqual(FromYear(81),    () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValValValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = 82;
            var arg2 = 83;
            var arg3 = 84;
            var arg4 = true;
            var ret  = accessor.MyMethod(arg1, arg2, arg3, ref arg4);
            
            AreEqual(false, () => arg4);
            AreEqual(85,    () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefValValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = default(DateTime);
            var arg2 = FromSeconds(87);
            var arg3 = ToGuid(88);
            var arg4 = (byte)89;
            var ret  = accessor.MyMethod(out arg1, arg2, arg3, ref arg4);
            
            AreEqual(FromYear(86), () => arg1);
            AreEqual(90,           () => arg4);
            AreEqual("91",         () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValRefValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = 92;
            var arg2 = (float)0;
            var arg3 = 94;
            var arg4 = (decimal)95;
            var ret  = accessor.MyMethod(arg1, out arg2, arg3, ref arg4);
            
            AreEqual(93, () => arg2);
            AreEqual(96, () => arg4);
            AreEqual(97, () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefRefValRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = "";
            var arg2 = FromYear(99);
            var arg3 = FromSeconds(101);
            var arg4 = ToGuid(0);
            var ret  = accessor.MyMethod(out arg1, ref arg2, arg3, out arg4);
            
            AreEqual("98",          () => arg1);
            AreEqual(FromYear(100), () => arg2);
            AreEqual(ToGuid(102),   () => arg4);
            AreEqual(true,          () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValValRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = 103;
            var arg2 = 104;
            var arg3 = (float)105;
            var arg4 = (double)0;
            var ret  = accessor.MyMethod(arg1, arg2, ref arg3, out arg4);
            
            AreEqual(106, () => arg3);
            AreEqual(107, () => arg4);
            AreEqual(108, () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefValRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = true;
            var arg2 = "109";
            var arg3 = default(DateTime);
            var arg4 = FromSeconds(111);
            var ret  = accessor.MyMethod(ref arg1, arg2, out arg3, ref arg4);
            
            AreEqual(false,            () => arg1);
            AreEqual(FromYear(110),    () => arg3);
            AreEqual(FromSeconds(112), () => arg4);
            AreEqual(113,              () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_ValRefRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = (byte)114;
            var arg2 = (int)0;
            var arg3 = (long)116;
            var arg4 = (float)0;
            var ret  = accessor.MyMethod(arg1, out arg2, ref arg3, out arg4);
            
            AreEqual(115,         () => arg2);
            AreEqual(117,         () => arg3);
            AreEqual(118,         () => arg4);
            AreEqual(ToGuid(119), () => ret);
        }
    }

    [TestMethod]
    public void AccessorCore_RefRefRefRef()
    {
        foreach (var accessor in new[] { new MyAccessor(), new MyAccessorByName() }) 
        
        {
            var arg1 = (decimal)120;
            var arg2 = default(bool);
            var arg3 = "122";
            var arg4 = default(DateTime);
            var ret  = accessor.MyMethod(ref arg1, out arg2, ref arg3, out arg4);
            
            AreEqual(121,           () => arg1);
            AreEqual(true,          () => arg2);
            AreEqual("123",         () => arg3);
            AreEqual(FromYear(124), () => arg4);
            AreEqual(125,           () => ret);
        }
    }
    
    // Accessor Classes
    
    private class MyAccessor() : AccessorCore(new MyClass())
    {
        // 1 Parameter
        
        public bool MyMethod(out int arg)
        {
            arg = default;
            return (bool)Call(Name(), ref arg)!;
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
    }
    
    private class MyAccessorByName : MyAccessor
    {
        // 1 Parameter
        
        public new bool MyMethod(out int arg)
        {
            arg = default;
            return (bool)Call(Name(), ref arg)!;
        }

        // 2 Parameters (+ explicit names syntax variants)

        public new long MyMethod(ref float arg1, double arg2) 
            => (long)Call(Name(), ref arg1, arg2)!;

        public new DateTime MyMethod(TimeSpan arg1, out string arg2)
        {
            arg2 = default;
            return (DateTime)Call(nameof(MyMethod), arg1, ref arg2)!;
        }

        public new Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            arg2 = default;
            return (Guid)Call("MyMethod", ref arg1, ref arg2)!;
        }

        // 3 Parameters (+ inline out parameters)

        public new DateTime MyMethod(ref double arg1, float arg2, long arg3)
            => (DateTime)Call(Name(), ref arg1, arg2, arg3)!;

        public new int MyMethod(bool arg1, out int arg2, long arg3)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, arg3)!;
        }

        public new float MyMethod(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            arg2 = default;
            return (float)Call(Name(), ref arg1, ref arg2, arg3)!;
        }

        public new string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
            => (string)Call(Name(), arg1, arg2, ref arg3)!;

        public new DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = default;
            return (DateTime)Call(Name(), ref arg1, arg2, ref arg3)!;
        }

        public new int MyMethod(bool arg1, out int arg2, ref long arg3)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, ref arg3)!;
        }

        public new float MyMethod(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = default;
            arg3 = default;
            return (float)Call(Name(), ref arg1, ref arg2, ref arg3)!;
        }
        
        // 4 Parameters
        
        public new byte MyMethod(ref int arg1, long arg2, float arg3, double arg4) 
            => (byte)Call(Name(), ref arg1, arg2, arg3, arg4)!;
        
        public new decimal MyMethod(bool arg1, out string arg2, DateTime arg3, TimeSpan arg4)
        {
            arg2 = default;
            return (decimal)Call(Name(), arg1, ref arg2, arg3, arg4)!;
        }
        
        public new Guid MyMethod(ref byte arg1, out int arg2, long arg3, float arg4)
        {
            arg2 = default;
            return (Guid)Call(Name(), ref arg1, ref arg2, arg3, arg4)!;
        }

        public new double MyMethod(decimal arg1, bool arg2, ref string arg3, DateTime arg4) 
            => (double)Call(Name(), arg1, arg2, ref arg3, arg4)!;

        public new TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, long arg4)
        {
            arg1 = default;
            return (TimeSpan)Call(Name(), ref arg1, arg2, ref arg3, arg4)!;
        }
        
        public new float MyMethod(double arg1, out decimal arg2, ref bool arg3, string arg4)
        {
            arg2 = default;
            return (float)Call(Name(), arg1, ref arg2, ref arg3, arg4)!;
        }

        public new DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, int arg4)
        {
            arg1 = default;
            arg3 = default;
            return (DateTime)Call(Name(), ref arg1, ref arg2, ref arg3, arg4)!;
        }

        public new long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4) 
            => (long)Call(Name(), arg1, arg2, arg3, ref arg4)!;

        public new string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = default;
            return (string)Call(Name(), ref arg1, arg2, arg3, ref arg4)!;
        }
        
        public new int MyMethod(long arg1, out float arg2, double arg3, ref decimal arg4)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public new bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = default;
            arg4 = default;
            return (bool)Call(Name(), ref arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public new byte MyMethod(int arg1, long arg2, ref float arg3, out double arg4)
        {
            arg4 = default;
            return (byte)Call(Name(), arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public new decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref TimeSpan arg4)
        {
            arg3 = default;
            return (decimal)Call(Name(), ref arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public new Guid MyMethod(byte arg1, out int arg2, ref long arg3, out float arg4)
        {
            arg2 = default;
            arg4 = default;
            return (Guid)Call(Name(), arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public new double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out DateTime arg4)
        {
            arg2 = default;
            arg4 = default;
            return (double)Call(Name(), ref arg1, ref arg2, ref arg3, ref arg4)!;
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
            AreEqual(FromSeconds(6), () => arg1);
            arg2 = "7";
            return FromYear(8);
        }

        private Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            AreEqual("9", arg1, nameof(arg1));
            arg1 = "10";
            arg2 = FromSeconds(11);
            return ToGuid(12);
        }

        // 3 Parameters

        private DateTime MyMethod(ref double arg1, float arg2, long arg3)
        {
            AreEqual(13d, arg1, nameof(arg1));
            arg1 = 14;
            AreEqual(15f, () => arg2);
            AreEqual(16, () => arg3);
            return FromYear(17);
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
            arg2 = FromYear(23);
            AreEqual(FromSeconds(24), () => arg3);
            return 25;
        }

        private string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
        {
            AreEqual(ToGuid(26), () => arg1);
            AreEqual("27", () => arg2);
            AreEqual(FromSeconds(28), arg3, nameof(arg3));
            arg3 = FromSeconds(29);
            return "30";
        }

        private DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = 31;
            AreEqual(32f, () => arg2);
            AreEqual(33l, arg3, nameof(arg3));
            arg3 = 34;
            return FromYear(35);
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
            AreEqual(FromYear(41), arg2, nameof(arg2));
            arg2 = FromYear(42);
            arg3 = FromSeconds(43);
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
            AreEqual(FromYear(52), () => arg3);
            AreEqual(FromSeconds(53), () => arg4);
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
            AreEqual(FromYear(64), () => arg4);
            return 65;
        }

        private TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, long arg4)
        {
            arg1 = ToGuid(66);
            AreEqual(67, () => arg2);
            AreEqual(68, arg3, nameof(arg3));
            arg3 = 69;
            AreEqual(70, () => arg4);
            return FromSeconds(71);
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
            arg1 = FromSeconds(76);
            AreEqual(ToGuid(77), arg2, nameof(arg2));
            arg2 = ToGuid(78);
            arg3 = 79;
            AreEqual(80, () => arg4);
            return FromYear(81);
        }

        private long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4)
        {
            AreEqual(82, () => arg1);
            AreEqual(83, () => arg2);
            AreEqual(84, () => arg3);
            AreEqual(true, arg4, nameof(arg4));
            arg4 = false;
            return 85;
        }

        private string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = FromYear(86);
            AreEqual(FromSeconds(87), () => arg2);
            AreEqual(ToGuid(88), () => arg3);
            AreEqual(89, arg4, nameof(arg4));
            arg4 = 90;
            return "91";
        }
        
        private int MyMethod(long arg1, out float arg2, double arg3, ref decimal arg4)
        {
            AreEqual(92, () => arg1);
            arg2 = 93;
            AreEqual(94, () => arg3);
            AreEqual(95, arg4, nameof(arg4));
            arg4 = 96;
            return 97;
        }
        
        private bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = "98";
            AreEqual(FromYear(99), arg2, nameof(arg2));
            arg2 = FromYear(100);
            AreEqual(FromSeconds(101),  () => arg3);
            arg4 = ToGuid(102);
            return true;
        }
        
        private byte MyMethod(int arg1, long arg2, ref float arg3, out double arg4)
        {
            AreEqual(103, () => arg1);
            AreEqual(104, () => arg2);
            AreEqual(105, arg3, nameof(arg3));
            arg3 = 106;
            arg4 = 107;
            return 108;
        }
        
        private decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref TimeSpan arg4)
        {
            AreEqual(true, arg1, nameof(arg1));
            arg1 = false;
            AreEqual("109", () => arg2);
            arg3 = FromYear(110);
            AreEqual(FromSeconds(111), arg4, nameof(arg4));
            arg4 = FromSeconds(112);
            return 113;
        }
        
        private Guid MyMethod(byte arg1, out int arg2, ref long arg3, out float arg4)
        {
            AreEqual(114, () => arg1);
            arg2 = 115;
            AreEqual(116, arg3, nameof(arg3));
            arg3 = 117;
            arg4 = 118;
            return ToGuid(119);
        }
        
        private double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out DateTime arg4)
        {
            AreEqual(120, arg1, nameof(arg1));
            arg1 = 121;
            arg2 = true;
            AreEqual("122", arg3, nameof(arg3));
            arg3 = "123";
            arg4 = FromYear(124);
            return 125;
        }
    }
}