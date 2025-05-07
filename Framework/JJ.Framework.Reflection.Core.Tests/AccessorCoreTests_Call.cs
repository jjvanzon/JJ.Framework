using static System.TimeSpan;
// ReSharper disable ReplaceWithSingleCallToCount
// ReSharper disable RedundantBoolCompare

namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class AccessorCoreTests_Call
{
    [TestMethod]
    public void AccessorCore_Call_ByName()
    {
        var obj  = new MyClass();
        var accessor = new AccessorCore(obj);
        
        var number = (int)accessor.Call("MyMethod")!;
        AreEqual(1, () => number);
        
        var text = (string)accessor.Call("MyMethod", 2)!;
        AreEqual("2", () => text);
    }
    
    [TestMethod]
    public void AccessorCore_Call_WithCallerMemberName()
    {
        var obj  = new MyClass();
        var accessor = new MyAccessor(obj);

        // 0 Args
        {
            int number = accessor.MyMethod()!;
            AreEqual(1, () => number);
        }
        // 1 Args
        {
            string text = accessor.MyMethod(2)!;
            AreEqual("2", () => text);
        }
        // 2 Args
        {
            long number = accessor.Add(1, 2)!;
            AreEqual(3, () => number);
        }
        // 3 Args
        {
            DateTime ret = accessor.AddDate(FromYear(2000), FromDays(1), 10);
            AreEqual(ToDateTime("2000-01-02 10:00"), () => ret);
        }
        // 4 Args
        {
            string concat = accessor.Concat(1, true, 2.0f, 'A');
            AreEqual("1True2A", () => concat);
        }
        // 5 Args
        {
            string concat = accessor.Concat(1, 2, "A", 3, 4);
            AreEqual("12A34", () => concat);
        }
        // 6 Args
        {
            double number = accessor.Add(1, 2, 3, 4, true, 5);
            AreEqual(16, () => number);
        }
        // 7 Args
        {
            long number = accessor.AddLongs(1, 2, 3, 4, 5, 6, 7);
            AreEqual(28, () => number);
        }
        // 8 Args
        {
            string formattedDateTime = accessor.ConcatDateTime(1, 2, 3, 4, 5, 6, 7, 'A');
            AreEqual("0001-02-03 04:05:06.007A", () => formattedDateTime);
        }
        // 9 Args
        {
            string text = accessor.FormatSum(1, 2, 3, 4, 5, 6, 7, 8, 9);
            AreEqual("Sum: 45", () => text);
        }
        // 9 Args with Void Return
        {
            accessor.LogSum(1, 2, 3, 4, 5, 6, 7, 8, 9); 
        }
        // 10 Args
        {
            int count = accessor.CountWhereTrue(true, false, true, true, true, false, true, false, true, false);
            AreEqual(6, () => count);
        }
    }

    [TestMethod]
    public void AccessorCore_Call_WithTypeArguments()   
    {
        var obj = new MyClass();
        var accessor = new MyAccessor(obj);

        // 1 Type Argument
        {
            var concat = accessor.Concat<int>(1);
            AreEqual("<Int32>(1)", () => concat);
        }
        // 2 Type Arguments
        {
            var concat = accessor.Concat<int, string>(1, 2);
            AreEqual("<Int32, String>(1, 2)", () => concat);
        }
        // 3 Type Arguments
        {
            var concat = accessor.Concat<int, string, float>(1, 2, 3);
            AreEqual("<Int32, String, Single>(1, 2, 3)", () => concat);
        }
        // 4 Type Arguments
        {
            var concat = accessor.Concat<int, string, float, bool>(1, true, "3", '4');
            AreEqual("<Int32, String, Single, Boolean>(1, True, 3, 4)", () => concat);
        }
        // 5 Type Arguments
        {
            var concat = accessor.Concat<int, string, float, bool, DateTime>(FromYear(1), FromSeconds(2), ToGuid(3), GetCultureInfo("nl-NL"), Tuesday);
            AreEqual("<Int32, String, Single, Boolean, DateTime>(0001-01-01 00:00:00.000, 00:00:02, 00000000-0000-0000-0000-000000000003, nl-NL, Tuesday)", () => concat);
        }
        // 6 Type Arguments
        //{
        //    var concat = accessor.Concatenate<int, string, float, bool, DateTime, TimeSpan>(1, 2, 3, 4, FromYear(5), 6);
        //    AreEqual("<Int32, String, Single, Boolean, DateTime, TimeSpan>(1, 2, 3, 4, 0005-01-01 00:00:00, 6)", () => concat);
        //}
        // 7 Type Arguments
        //{
        //    var concat = accessor.Concatenate<int, string, float, bool, DateTime, TimeSpan, Guid>(1, "2", 3, true, 5, FromSeconds(6), 7);
        //    AreEqual("<Int32, String, Single, Boolean, DateTime, TimeSpan, Guid>(1, 2, 3, true, 5, 00:06:00, 7)", () => concat);
        //}
    }
            
    [TestMethod]
    public void AccessorCore_Call_StringConfusedWithName_SolvedWithCollectionExpression()
    {
        var obj  = new MyClass();
        var accessor = new MyAccessor(obj);

        // Start with String
        {
            var concat = accessor.Concat("A", 1, true, 2);
            AreEqual("A1True2", () => concat);
        }

        // Start with 2 Strings
        {
            var concat = accessor.Concat("A", "B", 12, 34);
            AreEqual("AB1234", () => concat);
        }

        // End with String
        {
            var concat = accessor.Concat(1, 2, true, "A");
            AreEqual("12TrueA", () => concat);
        }
        
        // End with 2 Strings
        {
            var concat = accessor.Concat(1, 2, "A", "BC");
            AreEqual("12ABC", () => concat);
        }
    }

    private class MyAccessor(MyClass obj)
    {
        private readonly AccessorCore _accessor = new(obj);

        // 0 Args
        public int MyMethod() 
            => (int)_accessor.Call()!;

        // 1 Arg
        public string MyMethod(int arg1) 
            => (string)_accessor.Call(arg1)!;

        // 2 Args
        public long Add(float arg1, float arg2)
            => (long)_accessor.Call(arg1, arg2)!;

        // 3 Args
        public DateTime AddDate(DateTime arg1, TimeSpan arg2, double hours) 
            => (DateTime)_accessor.Call(arg1, arg2, hours)!;

        // 4 Args
        public string Concat(int a, bool b, float c, char d) 
            => (string)_accessor.Call(a, b, c, d)!;

        // 5 Args
        public string Concat(decimal arg1, long arg2, string arg3, short arg4, byte arg5) 
            => (string)_accessor.Call(arg1, arg2, arg3, arg4, arg5)!;

        // 6 Args
        public double Add(float a, int b, double c, long d, bool e, ushort f) 
            => (double)_accessor.Call(a, b, c, d, e, f)!;

        // 7 Args
        public long AddLongs(long a1, long a2, long a3, long a4, long a5, long a6, long a7) 
            => (long)_accessor.Call(a1, a2, a3, a4, a5, a6, a7)!;

        // 8 Args
        public string ConcatDateTime(byte a, short b, int c, long d, float e, double f, decimal g, char h)
            => (string)_accessor.Call(a, b, c, d, e, f, g, h)!;

        // 9 Args
        public string FormatSum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) 
            => (string)_accessor.Call(a1, a2, a3, a4, a5, a6, a7, a8, a9);

        // Void Return
        public void LogSum(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9) 
            => _accessor.Call(a1, a2, a3, a4, a5, a6, a7, a8, a9);

        // 10 Args
        public int CountWhereTrue(bool a1, bool a2, bool a3, bool a4, bool a5, bool a6, bool a7, bool a8, bool a9, bool a10)
            => (int)_accessor.Call(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10)!;


        // Strings at start or end:

        // Interpreted as names. Distinguish them from parameters using square bracket [collection expressions].

        // Start with String
        public string Concat(string arg1, float  arg2, bool   arg3, int    arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;

        // Start with 2 Strings
        public string Concat(string arg1, string arg2, int    arg3, float  arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;

        // End with String
        public string Concat(int    arg1, float  arg2, bool   arg3, string arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;

        // End with 2 Strings
        public string Concat(int    arg1, float  arg2, string arg3, string arg4) => (string)_accessor.Call([ arg1, arg2, arg3, arg4 ])!;

        // With Type Arguments

        public string Concat
            <T1>
            (byte arg1) 
            => (string)_accessor.Call<T1>(Name(), arg1);

        public string Concat
            <T1, T2>
            (short arg1, int arg2)
            => (string)_accessor.Call<T1, T2>(Name(), arg1, arg2);

        public string 
            Concat<T1, T2, T3>
            (long arg1, float arg2, double arg3)
            => (string)_accessor.Call<T1, T2, T3>(Name(), arg1, arg2, arg3);

        public string 
            Concat<T1, T2, T3, T4>
            (decimal arg1, bool arg2, string arg3, char arg4)
            => (string)_accessor.Call<T1, T2, T3, T4>(Name(), arg1, arg2, arg3, arg4);

        public string 
            Concat<T1, T2, T3, T4, T5>
            (DateTime arg1, TimeSpan arg2, Guid arg3, CultureInfo arg4, DayOfWeek arg5)
            => (string)_accessor.Call<T1, T2, T3, T4, T5>(Name(), arg1, arg2, arg3, arg4, arg5);

        public string 
            Concatenate<T1, T2, T3, T4, T5, T6>
            (T1 arg1, byte arg2, T3 arg3, short arg4, T5 arg5, int arg6)
            => (string)_accessor.Call<T1, T2, T3, T4, T5, T6>(Name(), arg1, arg2, arg3, arg4, arg5, arg6);

        public string Concatenate
            <T1, T2, T3, T4, T5, T6, T7>
            (long arg1, T2 arg2, float arg3, T4 arg4, double arg5, T6 arg6, decimal arg7)
            => (string)_accessor.Call<T1, T2, T3, T4, T5, T6, T7>(Name(), arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        public string Concatenate
            <T1, T2, T3, T4, T5, T6, T7, T8>
            (T1 arg1, bool arg2, T3 arg3, string arg4, T5 arg5, char arg6, T7 arg7, DateTime arg8)
            => (string)_accessor.Call<T1, T2, T3, T4, T5, T6, T7, T8>(Name(), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        public string Concatenate
            <T1, T2, T3, T4, T5, T6, T7, T8, T9>
            (TimeSpan arg1, T2 arg2, Guid arg3, T4 arg4, CultureInfo arg5, T6 arg6, DayOfWeek arg7, T8 arg8, byte arg9)
            => (string)_accessor.Call<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Name(), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        public string Concatenate
            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
            (T1 arg1, short arg2, int arg3, long arg4, float arg5, double arg6, decimal arg7, bool arg8, string arg9, T10 arg10)
            => (string)_accessor.Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Name(), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
    }
    
    private class MyClass
    {
        // 0 Args
        private int      MyMethod      ()                                                                                                                   => 1;
        
        // 1 Arg
        private string   MyMethod      (int      arg1)                                                                                                      => arg1.ToString();
        
        // 2 Args
        private long     Add           (float    arg1, float    arg2)                                                                                       => (long)(arg1 + arg2);
        
        // 3 Args
        private DateTime AddDate       (DateTime arg1, TimeSpan arg2, double hours)                                                                         => arg1.Add(arg2).AddHours(hours);
        
        // 4 Args
        private string   Concat        (int      a,    bool     b,    float  c,    char  d)                                                                 => $"{a}{b}{c}{d}";
        
        // 5 Args
        private string   Concat        (decimal  arg1, long     arg2, string arg3, short arg4, byte  arg5)                                                  => $"{arg1}{arg2}{arg3}{arg4}{arg5}";
        
        // 6 Args
        private double   Add           (float    a,    int      b,    double c,    long  d,    bool  e,  ushort f)                                          => a  + b  + c  + d  + (e ? 1 : 0) + f;
        
        // 7 Args
        private long     AddLongs      (long     a1,   long     a2,   long   a3,   long  a4,   long  a5, long   a6, long    a7)                             => a1 + a2 + a3 + a4 + a5 + a6 + a7;
        
        // 8 Args
        private string   ConcatDateTime(byte     a,    short    b,    int    c,    long  d,    float e,  double f,  decimal g,  char h)                     => FormatDateTime(new DateTime(a, b, c, (int)d, (int)e, (int)f, (int)g)) + h;
        

        // 2 methods distinguished by name, while parameter types are same:

        // 9 Args 
        private string   FormatSum     (int      a1,   int      a2,   int    a3,   int   a4,   int   a5, int    a6, int     a7, int  a8, int  a9)           => $"Sum: {a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9}";
        
        // 8 Args with Void Return
        private void     LogSum        (int      a1,   int      a2,   int    a3,   int   a4,   int   a5, int    a6, int     a7, int  a8, int  a9)           => Console.WriteLine(FormatSum(a1, a2, a3, a4, a5, a6, a7, a8, a9));
        
        // 10 Args
        private int      CountWhereTrue(bool     a1,   bool     a2,   bool   a3,   bool  a4,   bool  a5, bool   a6, bool    a7, bool a8, bool a9, bool a10) => new[] { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 }.Where(x => x == true).Count();
        
        // Strings at start or end:

        // Start with String
        private string Concat(string arg1, float  arg2, bool   arg3, int    arg4) => $"{arg1}{arg2}{arg3}{arg4}";

        // Start with 2 Strings
        private string Concat(string arg1, string arg2, int    arg3, float  arg4) => $"{arg1}{arg2}{arg3}{arg4}";

        // End with String
        private string Concat(int    arg1, float  arg2, bool   arg3, string arg4) => $"{arg1}{arg2}{arg3}{arg4}";

        // End with 2 Strings
        private string Concat(int    arg1, float  arg2, string arg3, string arg4) => $"{arg1}{arg2}{arg3}{arg4}";

        // With Type Arguments

        private string Concat
            <T1>
            (byte arg1) 
            => $"<{typeof(T1).Name}>" +
               $"({arg1})";

        private string Concat
            <T1, T2>
            (short arg1, int arg2)
            => $"<{typeof(T1).Name}, {typeof(T2).Name}>" +
               $"({arg1}, {arg2})";

        private string 
            Concat<T1, T2, T3>
            (long arg1, float arg2, double arg3)
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}>" +
               $"({arg1}, {arg2}, {arg3})";

        private string 
            Concat<T1, T2, T3, T4>
            (decimal arg1, bool arg2, string arg3, char arg4) 
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}, {typeof(T4).Name}>" +
               $"({arg1}, {arg2}, {arg3}, {arg4})";

        private string 
            Concat<T1, T2, T3, T4, T5>
            (DateTime arg1, TimeSpan arg2, Guid arg3, CultureInfo arg4, DayOfWeek arg5) 
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}, {typeof(T4).Name}, {typeof(T5).Name}>" +
               $"({FormatDateTime(arg1)}, {arg2}, {arg3}, {arg4}, {arg5})";

        private string 
            Concatenate<T1, T2, T3, T4, T5, T6>
            (T1 arg1, byte arg2, T3 arg3, short arg4, T5 arg5, int arg6)
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}, {typeof(T4).Name}, {typeof(T5).Name}, {typeof(T6).Name}>" +
               $"({arg1}, {arg2}, {arg3}, {arg4}, {arg5}, {arg6})";

        private string Concatenate
            <T1, T2, T3, T4, T5, T6, T7>
            (long arg1, T2 arg2, float arg3, T4 arg4, double arg5, T6 arg6, decimal arg7)
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}, {typeof(T4).Name}, {typeof(T5).Name}, {typeof(T6).Name}, {typeof(T7).Name}>" +
               $"({arg1}, {arg2}, {arg3}, {arg4}, {arg5}, {arg6}, {arg7})";

        private string Concatenate
            <T1, T2, T3, T4, T5, T6, T7, T8>
            (T1 arg1, bool arg2, T3 arg3, string arg4, T5 arg5, char arg6, T7 arg7, DateTime arg8) 
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}, {typeof(T4).Name}, {typeof(T5).Name}, {typeof(T6).Name}, {typeof(T7).Name}, {typeof(T8).Name}>" +
               $"({arg1}, {arg2}, {arg3}, {arg4}, {arg5}, {arg6}, {arg7}, {FormatDateTime(arg8)})";

        private string Concatenate
            <T1, T2, T3, T4, T5, T6, T7, T8, T9>
            (TimeSpan arg1, T2 arg2, Guid arg3, T4 arg4, CultureInfo arg5, T6 arg6, DayOfWeek arg7, T8 arg8, byte arg9)
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}, {typeof(T4).Name}, {typeof(T5).Name}, {typeof(T6).Name}, {typeof(T7).Name}, {typeof(T8).Name}, {typeof(T9).Name}>" +
               $"({arg1}, {arg2}, {arg3}, {arg4}, {arg5}, {arg6}, {arg7}, {arg8}, {arg9})";

        private string Concatenate
            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
            (T1 arg1, short arg2, int arg3, long arg4, float arg5, double arg6, decimal arg7, bool arg8, string arg9, T10 arg10) 
            => $"<{typeof(T1).Name}, {typeof(T2).Name}, {typeof(T3).Name}, {typeof(T4).Name}, {typeof(T5).Name}, {typeof(T6).Name}, {typeof(T7).Name}, {typeof(T8).Name}, {typeof(T9).Name}, {typeof(T10).Name}>" +
               $"({arg1}, {arg2}, {arg3}, {arg4}, {arg5}, {arg6}, {arg7}, {arg8}, {arg9}, {arg10})";
    }
}
