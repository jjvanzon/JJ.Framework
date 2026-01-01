using static System.TimeSpan;

#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace JJ.Framework.Reflection.Core.Tests;

public partial class AccessorCoreTests_RefArgs
{
    // Accessor Classes
    
    private class MyAccessor() : AccessorCore(new MyClass())
    {
        // 1 Parameter
        
        public virtual bool MyMethod(out int arg)
        {
            arg = default;
            return (bool)Call(ref arg)!;
        }
        
        public virtual bool MyMethod(out string arg)
        {
            arg = "";
            return (bool)Call(ref arg)!;
        }
        
        // 2 Parameters
        
        public virtual long MyMethod(ref float arg1, double arg2)
            => (long)Call(ref arg1, arg2)!;
        
        public virtual long MyMethod(ref float arg1, string arg2)
            => (long)Call(ref arg1, arg2)!;
        
        public virtual DateTime MyMethod(TimeSpan arg1, out char arg2)
        {
            arg2 = default;
            return (DateTime)Call(arg1, ref arg2)!;
        }
        
        public virtual DateTime MyMethod(TimeSpan arg1, out string arg2)
        {
            arg2 = "";
            return (DateTime)Call(arg1, ref arg2)!;
        }
        
        public virtual Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            arg2 = default;
            return (Guid)Call(ref arg1, ref arg2)!;
        }
        
        public virtual Guid MyMethod(ref string arg1, out string arg2)
        {
            arg2 = "";
            return (Guid)Call(ref arg1, ref arg2)!;
        }
        
        // 3 Parameters (+ inline out parameters)
        
        public virtual DateTime MyMethod(ref double arg1, float arg2, long arg3)
            => (DateTime)Call(ref arg1, arg2, arg3)!;
        
        public virtual DateTime MyMethod(ref double arg1, float arg2, string arg3)
            => (DateTime)Call(ref arg1, arg2, arg3)!;
        
        public virtual int MyMethod(bool arg1, out int arg2, long arg3)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, arg3)!;
        }
        
        public virtual int MyMethod(bool arg1, out int arg2, string arg3)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, arg3)!;
        }
        
        public virtual float MyMethod(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            arg2 = default;
            return (float)Call(ref arg1, ref arg2, arg3)!;
        }
        
        public virtual float MyMethod(ref double arg1, out DateTime arg2, string arg3)
        {
            arg2 = default;
            return (float)Call(ref arg1, ref arg2, arg3)!;
        }
        
        public virtual string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
            => (string)Call(arg1, arg2, ref arg3)!;
        
        public virtual string MyMethod(Guid arg1, string arg2, ref string arg3)
            => (string)Call(arg1, arg2, ref arg3)!;
        
        public virtual DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = default;
            return (DateTime)Call(ref arg1, arg2, ref arg3)!;
        }
        
        public virtual DateTime MyMethod(out double arg1, float arg2, ref string arg3)
        {
            arg1 = default;
            return (DateTime)Call(ref arg1, arg2, ref arg3)!;
        }
        
        public virtual int MyMethod(bool arg1, out int arg2, ref long arg3)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, ref arg3)!;
        }
        
        public virtual int MyMethod(bool arg1, out int arg2, ref string arg3)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, ref arg3)!;
        }
        
        public virtual float MyMethod(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = default;
            arg3 = default;
            return (float)Call(ref arg1, ref arg2, ref arg3)!;
        }
        
        public virtual float MyMethod(out double arg1, ref DateTime arg2, out string arg3)
        {
            arg1 = default;
            arg3 = "";
            return (float)Call(ref arg1, ref arg2, ref arg3)!;
        }
        
        // 4 Parameters
        
        public virtual byte MyMethod(ref int arg1, long arg2, float arg3, double arg4)
            => (byte)Call(ref arg1, arg2, arg3, arg4)!;
        
        public virtual byte MyMethod(ref int arg1, long arg2, float arg3, string arg4)
            => (byte)Call(ref arg1, arg2, arg3, arg4)!;
        
        public virtual decimal MyMethod(bool arg1, out string arg2, DateTime arg3, TimeSpan arg4)
        {
            arg2 = "";
            return (decimal)Call(arg1, ref arg2, arg3, arg4)!;
        }
        
        public virtual decimal MyMethod(bool arg1, out string arg2, DateTime arg3, string arg4)
        {
            arg2 = "";
            return (decimal)Call(arg1, ref arg2, arg3, arg4)!;
        }
        
        public virtual Guid MyMethod(ref byte arg1, out int arg2, long arg3, float arg4)
        {
            arg2 = default;
            return (Guid)Call(ref arg1, ref arg2, arg3, arg4)!;
        }
        
        public virtual Guid MyMethod(ref byte arg1, out int arg2, long arg3, string arg4)
        {
            arg2 = default;
            return (Guid)Call(ref arg1, ref arg2, arg3, arg4)!;
        }
        
        public virtual double MyMethod(decimal arg1, bool arg2, ref string arg3, DateTime arg4)
            => (double)Call(arg1, arg2, ref arg3, arg4)!;
        
        public virtual double MyMethod(decimal arg1, bool arg2, ref string arg3, string arg4)
            => (double)Call(arg1, arg2, ref arg3, arg4)!;
        
        public virtual TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, long arg4)
        {
            arg1 = default;
            return (TimeSpan)Call(ref arg1, arg2, ref arg3, arg4)!;
        }
        
        public virtual TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, string arg4)
        {
            arg1 = default;
            return (TimeSpan)Call(ref arg1, arg2, ref arg3, arg4)!;
        }
        
        public virtual float MyMethod(double arg1, out decimal arg2, ref bool arg3, char arg4)
        {
            arg2 = default;
            return (float)Call(arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public virtual float MyMethod(double arg1, out decimal arg2, ref bool arg3, string arg4)
        {
            arg2 = default;
            return (float)Call(arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public virtual DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, int arg4)
        {
            arg1 = default;
            arg3 = default;
            return (DateTime)Call(ref arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public virtual DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, string arg4)
        {
            arg1 = default;
            arg3 = default;
            return (DateTime)Call(ref arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public virtual long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4)
            => (long)Call(arg1, arg2, arg3, ref arg4)!;
        
        public virtual long MyMethod(float arg1, double arg2, decimal arg3, ref string arg4)
            => (long)Call(arg1, arg2, arg3, ref arg4)!;
        
        public virtual string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = default;
            return (string)Call(ref arg1, arg2, arg3, ref arg4)!;
        }
        
        public virtual string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref string arg4)
        {
            arg1 = default;
            return (string)Call(ref arg1, arg2, arg3, ref arg4)!;
        }
        
        public virtual int MyMethod(long arg1, out float arg2, double arg3, ref decimal arg4)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public virtual int MyMethod(long arg1, out float arg2, double arg3, ref string arg4)
        {
            arg2 = default;
            return (int)Call(arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public virtual bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = "";
            arg4 = default;
            return (bool)Call(ref arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public virtual bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out string arg4)
        {
            arg1 = "";
            arg4 = "";
            return (bool)Call(ref arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public virtual byte MyMethod(int arg1, long arg2, ref float arg3, out double arg4)
        {
            arg4 = default;
            return (byte)Call(arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public virtual byte MyMethod(int arg1, long arg2, ref float arg3, out string arg4)
        {
            arg4 = "";
            return (byte)Call(arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public virtual decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref TimeSpan arg4)
        {
            arg3 = default;
            return (decimal)Call(ref arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public virtual decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref string arg4)
        {
            arg3 = default;
            return (decimal)Call(ref arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public virtual Guid MyMethod(byte arg1, out int arg2, ref long arg3, out float arg4)
        {
            arg2 = default;
            arg4 = default;
            return (Guid)Call(arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public virtual Guid MyMethod(byte arg1, out int arg2, ref long arg3, out string arg4)
        {
            arg2 = default;
            arg4 = "";
            return (Guid)Call(arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public virtual double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out DateTime arg4)
        {
            arg2 = default;
            arg4 = default;
            return (double)Call(ref arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public virtual double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out string arg4)
        {
            arg2 = default;
            arg4 = "";
            return (double)Call(ref arg1, ref arg2, ref arg3, ref arg4)!;
        }
    }
    
    private class MyAccessorByName : MyAccessor
    {
        // 1 Parameter
        
        public override bool MyMethod(out int arg)
        {
            arg = default;
            return (bool)Call(Name(), ref arg)!;
        }
        
        public override bool MyMethod(out string arg)
        {
            arg = "";
            return (bool)Call(Name(), ref arg)!;
        }
        
        // 2 Parameters (+ explicit names syntax variants)
        
        public override long MyMethod(ref float arg1, double arg2)
            => (long)Call(Name(), ref arg1, arg2)!;
        
        public override long MyMethod(ref float arg1, string arg2)
            => (long)Call(Name(), ref arg1, arg2)!;
        
        public override DateTime MyMethod(TimeSpan arg1, out char arg2)
        {
            arg2 = default;
            return (DateTime)Call(nameof(MyMethod), arg1, ref arg2)!;
        }
        
        public override DateTime MyMethod(TimeSpan arg1, out string arg2)
        {
            arg2 = "";
            return (DateTime)Call(nameof(MyMethod), arg1, ref arg2)!;
        }
        
        public override Guid MyMethod(ref string arg1, out TimeSpan arg2)
        {
            arg2 = default;
            return (Guid)Call("MyMethod", ref arg1, ref arg2)!;
        }
        
        public override Guid MyMethod(ref string arg1, out string arg2)
        {
            arg2 = "";
            return (Guid)Call("MyMethod", ref arg1, ref arg2)!;
        }
        
        // 3 Parameters (+ inline out parameters)
        
        public override DateTime MyMethod(ref double arg1, float arg2, long arg3)
            => (DateTime)Call(Name(), ref arg1, arg2, arg3)!;
        
        public override DateTime MyMethod(ref double arg1, float arg2, string arg3)
            => (DateTime)Call(Name(), ref arg1, arg2, arg3)!;
        
        public override int MyMethod(bool arg1, out int arg2, long arg3)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, arg3)!;
        }
        
        public override int MyMethod(bool arg1, out int arg2, string arg3)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, arg3)!;
        }
        
        public override float MyMethod(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            arg2 = default;
            return (float)Call(Name(), ref arg1, ref arg2, arg3)!;
        }
        
        public override float MyMethod(ref double arg1, out DateTime arg2, string arg3)
        {
            arg2 = default;
            return (float)Call(Name(), ref arg1, ref arg2, arg3)!;
        }
        
        public override string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
            => (string)Call(Name(), arg1, arg2, ref arg3)!;
        
        public override string MyMethod(Guid arg1, string arg2, ref string arg3)
            => (string)Call(Name(), arg1, arg2, ref arg3)!;
        
        public override DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = default;
            return (DateTime)Call(Name(), ref arg1, arg2, ref arg3)!;
        }
        
        public override DateTime MyMethod(out double arg1, float arg2, ref string arg3)
        {
            arg1 = default;
            return (DateTime)Call(Name(), ref arg1, arg2, ref arg3)!;
        }
        
        public override int MyMethod(bool arg1, out int arg2, ref long arg3)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, ref arg3)!;
        }
        
        public override int MyMethod(bool arg1, out int arg2, ref string arg3)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, ref arg3)!;
        }
        
        public override float MyMethod(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = default;
            arg3 = default;
            return (float)Call(Name(), ref arg1, ref arg2, ref arg3)!;
        }
        
        public override float MyMethod(out double arg1, ref DateTime arg2, out string arg3)
        {
            arg1 = default;
            arg3 = "";
            return (float)Call(Name(), ref arg1, ref arg2, ref arg3)!;
        }
        
        // 4 Parameters
        
        public override byte MyMethod(ref int arg1, long arg2, float arg3, double arg4)
            => (byte)Call(Name(), ref arg1, arg2, arg3, arg4)!;
        
        public override byte MyMethod(ref int arg1, long arg2, float arg3, string arg4)
            => (byte)Call(Name(), ref arg1, arg2, arg3, arg4)!;
        
        public override decimal MyMethod(bool arg1, out string arg2, DateTime arg3, TimeSpan arg4)
        {
            arg2 = "";
            return (decimal)Call(Name(), arg1, ref arg2, arg3, arg4)!;
        }
        
        public override decimal MyMethod(bool arg1, out string arg2, DateTime arg3, string arg4)
        {
            arg2 = "";
            return (decimal)Call(Name(), arg1, ref arg2, arg3, arg4)!;
        }
        
        public override Guid MyMethod(ref byte arg1, out int arg2, long arg3, float arg4)
        {
            arg2 = default;
            return (Guid)Call(Name(), ref arg1, ref arg2, arg3, arg4)!;
        }
        
        public override Guid MyMethod(ref byte arg1, out int arg2, long arg3, string arg4)
        {
            arg2 = default;
            return (Guid)Call(Name(), ref arg1, ref arg2, arg3, arg4)!;
        }
        
        public override double MyMethod(decimal arg1, bool arg2, ref string arg3, DateTime arg4)
            => (double)Call(Name(), arg1, arg2, ref arg3, arg4)!;
        
        public override double MyMethod(decimal arg1, bool arg2, ref string arg3, string arg4)
            => (double)Call(Name(), arg1, arg2, ref arg3, arg4)!;
        
        public override TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, long arg4)
        {
            arg1 = default;
            return (TimeSpan)Call(Name(), ref arg1, arg2, ref arg3, arg4)!;
        }
        
        public override TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, string arg4)
        {
            arg1 = default;
            return (TimeSpan)Call(Name(), ref arg1, arg2, ref arg3, arg4)!;
        }
        
        public override float MyMethod(double arg1, out decimal arg2, ref bool arg3, char arg4)
        {
            arg2 = default;
            return (float)Call(Name(), arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public override float MyMethod(double arg1, out decimal arg2, ref bool arg3, string arg4)
        {
            arg2 = default;
            return (float)Call(Name(), arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public override DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, int arg4)
        {
            arg1 = default;
            arg3 = default;
            return (DateTime)Call(Name(), ref arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public override DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, string arg4)
        {
            arg1 = default;
            arg3 = default;
            return (DateTime)Call(Name(), ref arg1, ref arg2, ref arg3, arg4)!;
        }
        
        public override long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4)
            => (long)Call(Name(), arg1, arg2, arg3, ref arg4)!;
        
        public override long MyMethod(float arg1, double arg2, decimal arg3, ref string arg4)
            => (long)Call(Name(), arg1, arg2, arg3, ref arg4)!;
        
        public override string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = default;
            return (string)Call(Name(), ref arg1, arg2, arg3, ref arg4)!;
        }
        
        public override string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref string arg4)
        {
            arg1 = default;
            return (string)Call(Name(), ref arg1, arg2, arg3, ref arg4)!;
        }
        
        public override int MyMethod(long arg1, out float arg2, double arg3, ref decimal arg4)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public override int MyMethod(long arg1, out float arg2, double arg3, ref string arg4)
        {
            arg2 = default;
            return (int)Call(Name(), arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public override bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = "";
            arg4 = default;
            return (bool)Call(Name(), ref arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public override bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out string arg4)
        {
            arg1 = "";
            arg4 = "";
            return (bool)Call(Name(), ref arg1, ref arg2, arg3, ref arg4)!;
        }
        
        public override byte MyMethod(int arg1, long arg2, ref float arg3, out double arg4)
        {
            arg4 = default;
            return (byte)Call(Name(), arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public override byte MyMethod(int arg1, long arg2, ref float arg3, out string arg4)
        {
            arg4 = "";
            return (byte)Call(Name(), arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public override decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref TimeSpan arg4)
        {
            arg3 = default;
            return (decimal)Call(Name(), ref arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public override decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref string arg4)
        {
            arg3 = default;
            return (decimal)Call(Name(), ref arg1, arg2, ref arg3, ref arg4)!;
        }
        
        public override Guid MyMethod(byte arg1, out int arg2, ref long arg3, out float arg4)
        {
            arg2 = default;
            arg4 = default;
            return (Guid)Call(Name(), arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public override Guid MyMethod(byte arg1, out int arg2, ref long arg3, out string arg4)
        {
            arg2 = default;
            arg4 = "";
            return (Guid)Call(Name(), arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public override double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out DateTime arg4)
        {
            arg2 = default;
            arg4 = default;
            return (double)Call(Name(), ref arg1, ref arg2, ref arg3, ref arg4)!;
        }
        
        public override double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out string arg4)
        {
            arg2 = default;
            arg4 = "";
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
        
        private bool MyMethod(out string arg)
        {
            arg = "1";
            return true;
        }
        
        // 2 Parameters
        
        private long MyMethod(ref float arg1, double arg2)
        {
            AreEqual(2, arg1, nameof(arg1));
            arg1 = 3;
            AreEqual(4, () => arg2);
            return 5;
        }
        
        private long MyMethod(ref float arg1, string arg2)
        {
            AreEqual(2, arg1, nameof(arg1));
            arg1 = 3;
            AreEqual("4", () => arg2);
            return 5;
        }
        
        private DateTime MyMethod(TimeSpan arg1, out char arg2)
        {
            AreEqual(FromSeconds(6), () => arg1);
            arg2 = (char)7;
            return FromYear(8);
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
        
        private Guid MyMethod(ref string arg1, out string arg2)
        {
            AreEqual("9", arg1, nameof(arg1));
            arg1 = "10";
            arg2 = "11";
            return ToGuid(12);
        }
        
        // 3 Parameters
        
        private DateTime MyMethod(ref double arg1, float arg2, long arg3)
        {
            AreEqual(13, arg1, nameof(arg1));
            arg1 = 14;
            AreEqual(15, () => arg2);
            AreEqual(16, () => arg3);
            return FromYear(17);
        }
        
        private DateTime MyMethod(ref double arg1, float arg2, string arg3)
        {
            AreEqual(13, arg1, nameof(arg1));
            arg1 = 14;
            AreEqual(15,   () => arg2);
            AreEqual("16", () => arg3);
            return FromYear(17);
        }
        
        private int MyMethod(bool arg1, out int arg2, long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 18;
            AreEqual(19, () => arg3);
            return 20;
        }
        
        private int MyMethod(bool arg1, out int arg2, string arg3)
        {
            IsTrue(() => arg1);
            arg2 = 18;
            AreEqual("19", () => arg3);
            return 20;
        }
        
        private float MyMethod(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            AreEqual(21, arg1, nameof(arg1));
            arg1 = 22;
            arg2 = FromYear(23);
            AreEqual(FromSeconds(24), () => arg3);
            return 25;
        }
        
        private float MyMethod(ref double arg1, out DateTime arg2, string arg3)
        {
            AreEqual(21, arg1, nameof(arg1));
            arg1 = 22;
            arg2 = FromYear(23);
            AreEqual("24", () => arg3);
            return 25;
        }
        
        private string MyMethod(Guid arg1, string arg2, ref TimeSpan arg3)
        {
            AreEqual(ToGuid(26),      () => arg1);
            AreEqual("27",            () => arg2);
            AreEqual(FromSeconds(28), arg3, nameof(arg3));
            arg3 = FromSeconds(29);
            return "30";
        }
        
        private string MyMethod(Guid arg1, string arg2, ref string arg3)
        {
            AreEqual(ToGuid(26), () => arg1);
            AreEqual("27",       () => arg2);
            AreEqual("28",       arg3, nameof(arg3));
            arg3 = "29";
            return "30";
        }
        
        private DateTime MyMethod(out double arg1, float arg2, ref long arg3)
        {
            arg1 = 31;
            AreEqual(32, () => arg2);
            AreEqual(33, arg3, nameof(arg3));
            arg3 = 34;
            return FromYear(35);
        }
        
        private DateTime MyMethod(out double arg1, float arg2, ref string arg3)
        {
            arg1 = 31;
            AreEqual(32,   () => arg2);
            AreEqual("33", arg3, nameof(arg3));
            arg3 = "34";
            return FromYear(35);
        }
        
        private int MyMethod(bool arg1, out int arg2, ref long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 36;
            AreEqual(37, arg3, nameof(arg3));
            arg3 = 38;
            return 39;
        }
        
        private int MyMethod(bool arg1, out int arg2, ref string arg3)
        {
            IsTrue(() => arg1);
            arg2 = 36;
            AreEqual("37", arg3, nameof(arg3));
            arg3 = "38";
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
        
        private float MyMethod(out double arg1, ref DateTime arg2, out string arg3)
        {
            arg1 = 40;
            AreEqual(FromYear(41), arg2, nameof(arg2));
            arg2 = FromYear(42);
            arg3 = "43";
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
        
        private byte MyMethod(ref int arg1, long arg2, float arg3, string arg4)
        {
            AreEqual(45, arg1, nameof(arg1));
            arg1 = 46;
            AreEqual(47,   () => arg2);
            AreEqual(48,   () => arg3);
            AreEqual("49", () => arg4);
            return 50;
        }
        
        private decimal MyMethod(bool arg1, out string arg2, DateTime arg3, TimeSpan arg4)
        {
            AreEqual(true, () => arg1);
            arg2 = "51";
            AreEqual(FromYear(52),    () => arg3);
            AreEqual(FromSeconds(53), () => arg4);
            return 54;
        }
        
        private decimal MyMethod(bool arg1, out string arg2, DateTime arg3, string arg4)
        {
            AreEqual(true, () => arg1);
            arg2 = "51";
            AreEqual(FromYear(52), () => arg3);
            AreEqual("53",         () => arg4);
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
        
        private Guid MyMethod(ref byte arg1, out int arg2, long arg3, string arg4)
        {
            AreEqual(55, arg1, nameof(arg1));
            arg1 = 56;
            arg2 = 57;
            AreEqual(58,   () => arg3);
            AreEqual("59", () => arg4);
            return ToGuid(60);
        }
        
        private double MyMethod(decimal arg1, bool arg2, ref string arg3, DateTime arg4)
        {
            AreEqual(61,   () => arg1);
            AreEqual(true, () => arg2);
            AreEqual("62", arg3, nameof(arg3));
            arg3 = "63";
            AreEqual(FromYear(64), () => arg4);
            return 65;
        }
        
        private double MyMethod(decimal arg1, bool arg2, ref string arg3, string arg4)
        {
            AreEqual(61,   () => arg1);
            AreEqual(true, () => arg2);
            AreEqual("62", arg3, nameof(arg3));
            arg3 = "63";
            AreEqual("64", () => arg4);
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
        
        private TimeSpan MyMethod(out Guid arg1, byte arg2, ref int arg3, string arg4)
        {
            arg1 = ToGuid(66);
            AreEqual(67, () => arg2);
            AreEqual(68, arg3, nameof(arg3));
            arg3 = 69;
            AreEqual("70", () => arg4);
            return FromSeconds(71);
        }
        
        private float MyMethod(double arg1, out decimal arg2, ref bool arg3, char arg4)
        {
            AreEqual(72, arg1, nameof(arg2));
            arg2 = 73;
            AreEqual(true, arg3, nameof(arg3));
            arg3 = false;
            AreEqual((char)74, () => arg4);
            return 75;
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
        
        private DateTime MyMethod(out TimeSpan arg1, ref Guid arg2, out byte arg3, string arg4)
        {
            arg1 = FromSeconds(76);
            AreEqual(ToGuid(77), arg2, nameof(arg2));
            arg2 = ToGuid(78);
            arg3 = 79;
            AreEqual("80", () => arg4);
            return FromYear(81);
        }
        
        private long MyMethod(float arg1, double arg2, decimal arg3, ref bool arg4)
        {
            AreEqual(82,   () => arg1);
            AreEqual(83,   () => arg2);
            AreEqual(84,   () => arg3);
            AreEqual(true, arg4, nameof(arg4));
            arg4 = false;
            return 85;
        }
        
        private long MyMethod(float arg1, double arg2, decimal arg3, ref string arg4)
        {
            AreEqual(82,     () => arg1);
            AreEqual(83,     () => arg2);
            AreEqual(84,     () => arg3);
            AreEqual("true", arg4, nameof(arg4));
            arg4 = "false";
            return 85;
        }
        
        private string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref byte arg4)
        {
            arg1 = FromYear(86);
            AreEqual(FromSeconds(87), () => arg2);
            AreEqual(ToGuid(88),      () => arg3);
            AreEqual(89,              arg4, nameof(arg4));
            arg4 = 90;
            return "91";
        }
        
        private string MyMethod(out DateTime arg1, TimeSpan arg2, Guid arg3, ref string arg4)
        {
            arg1 = FromYear(86);
            AreEqual(FromSeconds(87), () => arg2);
            AreEqual(ToGuid(88),      () => arg3);
            AreEqual("89",            arg4, nameof(arg4));
            arg4 = "90";
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
        
        private int MyMethod(long arg1, out float arg2, double arg3, ref string arg4)
        {
            AreEqual(92, () => arg1);
            arg2 = 93;
            AreEqual(94,   () => arg3);
            AreEqual("95", arg4, nameof(arg4));
            arg4 = "96";
            return 97;
        }
        
        private bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out Guid arg4)
        {
            arg1 = "98";
            AreEqual(FromYear(99), arg2, nameof(arg2));
            arg2 = FromYear(100);
            AreEqual(FromSeconds(101), () => arg3);
            arg4 = ToGuid(102);
            return true;
        }
        
        private bool MyMethod(out string arg1, ref DateTime arg2, TimeSpan arg3, out string arg4)
        {
            arg1 = "98";
            AreEqual(FromYear(99), arg2, nameof(arg2));
            arg2 = FromYear(100);
            AreEqual(FromSeconds(101), () => arg3);
            arg4 = "102";
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
        
        private byte MyMethod(int arg1, long arg2, ref float arg3, out string arg4)
        {
            AreEqual(103, () => arg1);
            AreEqual(104, () => arg2);
            AreEqual(105, arg3, nameof(arg3));
            arg3 = 106;
            arg4 = "107";
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
        
        private decimal MyMethod(ref bool arg1, string arg2, out DateTime arg3, ref string arg4)
        {
            AreEqual(true, arg1, nameof(arg1));
            arg1 = false;
            AreEqual("109", () => arg2);
            arg3 = FromYear(110);
            AreEqual("111", arg4, nameof(arg4));
            arg4 = "112";
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
        
        private Guid MyMethod(byte arg1, out int arg2, ref long arg3, out string arg4)
        {
            AreEqual(114, () => arg1);
            arg2 = 115;
            AreEqual(116, arg3, nameof(arg3));
            arg3 = 117;
            arg4 = "118";
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
        
        private double MyMethod(ref decimal arg1, out bool arg2, ref string arg3, out string arg4)
        {
            AreEqual(120, arg1, nameof(arg1));
            arg1 = 121;
            arg2 = true;
            AreEqual("122", arg3, nameof(arg3));
            arg3 = "123";
            arg4 = "124";
            return 125;
        }
    }
}