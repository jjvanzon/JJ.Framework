using JJ.Framework.Reflection.Core.Tests.Helpers;
using static System.TimeSpan;
using static JJ.Framework.Reflection.Core.Tests.Helpers.FormatHelper;

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_Call
{
    [TestMethod]
    public void AccessorCore_Call_ByName()
    {
        var myClass  = new MyClass();
        var accessor = new AccessorCore(myClass);
        
        var number = (int)accessor.Call("MyMethod")!;
        AreEqual(1, () => number);
        
        var text = (string)accessor.Call("MyMethod", 2)!;
        AreEqual("2", () => text);
    }
    
    [TestMethod]
    public void AccessorCore_Call_ByCallerMemberName()
    {
        var myClass  = new MyClass();
        var accessor = new MyAccessor(myClass);

        {
            var number = accessor.MyMethod()!;
            AreEqual(1, () => number);
        }
        {
            var text = accessor.MyMethod(2)!;
            AreEqual("2", () => text);
        }
        {
            var number = accessor.Add(1, 2)!;
            AreEqual(3, () => number);
        }



        {
            var dateTime = accessor.Add(FromYear(2000), FromDays(1), 10);
            AreEqual(DateTime.Parse("2000-01-02 10:00"), () => dateTime);
        }
        {
            var concat = accessor.Concat(1, 2, 'A', 3, 4);
            AreEqual("12A34", () => concat);
        }
        {
            var number = accessor.Add(1, 2, 3, 4, true, 5);
            AreEqual(16, () => number);
        }
        {
            var number = accessor.AddLongs(1, 2, 3, 4, 5, 6, 7);
            AreEqual(28, () => number);
        }
        {
            var formattedDateTime = accessor.FormatDateTime(1, 2, 3, 4, 5, 6, 7, 'A');
            AreEqual("0001-02-03 04:05:06.007A", () => formattedDateTime);
        }

    }
        
    [TestMethod]
    public void AccessorCore_Call_StringConfusedWithName_SolvedWithCollectionExpression()
    {
        var myClass  = new MyClass();
        var accessor = new MyAccessor(myClass);
        {
            var concat = accessor.Concat("A", 1, true, 2);
            AreEqual("A1True2", () => concat);
        }
        {
            var concat = accessor.Concat("A", "B", 12, 34);
            AreEqual("AB1234", () => concat);
        }
        {
            var concat = accessor.Concat(1, 2, true, "A");
            AreEqual("12TrueA", () => concat);
        }
        {
            var concat = accessor.Concat(1, 2, "A", "BC");

            AreEqual("12ABC", () => concat);
        }
    }

    private class MyAccessor(MyClass obj)
    {
        private readonly AccessorCore _accessor = new(obj);

        public int MyMethod() 
            => (int)_accessor.Call()!;

        public string MyMethod(int arg1) 
            => (string)_accessor.Call(arg1)!;

        public long Add(float arg1, float arg2)
            => (long)_accessor.Call(arg1, arg2)!;

        public DateTime Add(DateTime arg1, TimeSpan arg2, double hours) 
            => (DateTime)_accessor.Call(arg1, arg2, hours)!;

        public string FourArgs(int a, bool b, float c, string d) 
            => (string)_accessor.Call(a, b, c, d)!;

        public string Concat(decimal arg1, long arg2, char arg3, short arg4, byte arg5) 
            => (string)_accessor.Call(arg1, arg2, arg3, arg4, arg5)!;

        public double Add(float a, int b, double c, long d, bool e, ushort f) 
            => (double)_accessor.Call(a, b, c, d, e, f)!;

        public long AddLongs(long a1, long a2, long a3, long a4, long a5, long a6, long a7) 
            => (long)_accessor.Call(a1, a2, a3, a4, a5, a6, a7)!;

        public string FormatDateTime(byte a, short b, int c, long d, float e, double f, decimal g, char h)
            => (string)_accessor.Call(a, b, c, d, e, f, g, h)!;

        public void NineArgs(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) 
            => _accessor.Call(a1, a2, a3, a4, a5, a6, a7, a8, a9);

        public bool TenArgs(bool a1, bool a2, bool a3, bool a4, bool a5, bool a6, bool a7, bool a8, bool a9, bool a10)
            => (bool)_accessor.Call(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10)!;


        // String Confused with Name: Solved With Collection Expression
        public string Concat(string arg1, float  arg2, bool   arg3, int    arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;
        public string Concat(string arg1, string arg2, int    arg3, float  arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;
        public string Concat(int    arg1, float  arg2, bool   arg3, string arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;
        public string Concat(int    arg1, float  arg2, string arg3, string arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;

    }
    
    private class MyClass
    {
        private int      MyMethod      ()                                                                                                                    => 1;
        private string   MyMethod      (int      arg1)                                                                                                       => arg1.ToString();
        private long     Add           (float    arg1, float    arg2)                                                                                        => (long)(arg1 + arg2);
        private DateTime Add           (DateTime arg1, TimeSpan arg2, double hours)                                                                          => arg1.Add(arg2).AddHours(hours);
        private string   FourArgs      (int      a,    bool     b,    float  c,    string d)                                                                 => $"{a}{b}{c}{d}";
        private string   Concat        (decimal  arg1, long     arg2, char   arg3, short  arg4, byte  arg5)                                                  => $"{arg1}{arg2}{arg3}{arg4}{arg5}";
        private double   Add           (float    a,    int      b,    double c,    long   d,    bool  e,  ushort f)                                          => a  + b  + c  + d  + (e ? 1 : 0) + f;
        private long     AddLongs      (long     a1,   long     a2,   long   a3,   long   a4,   long  a5, long   a6, long    a7)                             => a1 + a2 + a3 + a4 + a5 + a6 + a7;
        private string   FormatDateTime(byte     a,    short    b,    int    c,    long   d,    float e,  double f,  decimal g,  char h)                     => FormatHelper.FormatDateTime(new DateTime(a, b, c, (int)d, (int)e, (int)f, (int)g)) + h;
        private void     NineArgs      (int      a1,   int      a2,   int    a3,   int    a4,   int   a5, int    a6, int     a7, int  a8, int  a9)           => Console.WriteLine($"Sum: {a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9}");
        private bool     TenArgs       (bool     a1,   bool     a2,   bool   a3,   bool   a4,   bool  a5, bool   a6, bool    a7, bool a8, bool a9, bool a10) => new[] { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 }.Count(x => x) >= 5;
        
        // String Confused with Name: Solved With Collection Expression
        private string Concat(string arg1, float  arg2, bool   arg3, int    arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        private string Concat(string arg1, string arg2, int    arg3, float  arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        private string Concat(int    arg1, float  arg2, bool   arg3, string arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        private string Concat(int    arg1, float  arg2, string arg3, string arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        
        // TODO: 2 methods distinguish only by name, while parameter types are the same.
    }
}
