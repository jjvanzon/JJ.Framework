using static System.TimeSpan;
using static JJ.Framework.Reflection.Core.Tests.Helpers.ParseHelperCore;

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
            var number1 = accessor.MyMethod()!;
            AreEqual(1, () => number1);
        }
        {
            var text2 = accessor.MyMethod(2)!;
            AreEqual("2", () => text2);
        }
        {
            var number3 = accessor.Add(1, 2)!;
            AreEqual(3, () => number3);
        }
        {
            var dateTime = accessor.Add(FromYear(2000), FromDays(1), 10);
            AreEqual(DateTime.Parse("2000-01-02 10:00"), () => dateTime);
        }
        {
            var concat = accessor.Concat("A", 1, true, 2)!;
            AreEqual("A1True2", () => concat);
        }
        {
            var concat = accessor.Concat("A", "B", 12, 34)!;
            AreEqual("AB1234", () => concat);
        }
        {
            var concat = accessor.Concat(1, 2, true, "A")!;
            AreEqual("12TrueA", () => concat);
        }
        {
            var concat = accessor.Concat(1, 2, "A", "BC")!;

            AreEqual("12ABC", () => concat);
        }
    }

    private class MyAccessor(MyClass obj)
    {
        private readonly AccessorCore _accessor = new(obj);

        public int MyMethod() => (int)_accessor.Call()!;
        public string MyMethod(int arg1) => (string)_accessor.Call(arg1)!;
        public long Add(float arg1, float arg2) => (long)_accessor.Call(arg1, arg2)!;
        public DateTime Add(DateTime arg1, TimeSpan arg2, double hours) => (DateTime)_accessor.Call(arg1, arg2, hours)!;
        public string Concat(string arg1, float arg2, bool arg3, int arg4) => (string)_accessor.Call([arg1, arg2, arg3, arg4])!;
        public string Concat(string arg1, string arg2, int arg3, float arg4) => (string)_accessor.Call([arg1, arg2, arg3, arg4])!;
        public string Concat(int arg1, float arg2, bool arg3, string arg4) => (string)_accessor.Call(arg1, arg2, arg3, arg4)!;
        public string Concat(int arg1, float arg2, string arg3, string arg4) => (string)_accessor.Call([arg1, arg2, arg3, arg4])!;

    }
    
    private class MyClass
    {
        private int MyMethod() => 1;
        private string MyMethod(int arg1) => arg1.ToString();
        private long Add(float arg1, float arg2) => (long)(arg1 + arg2);
        private DateTime Add(DateTime arg1, TimeSpan arg2, double hours) => arg1.Add(arg2).AddHours(hours);
        private string Concat(string arg1, float arg2, bool arg3, int arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        private string Concat(string arg1, string arg2, int arg3, float arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        private string Concat(int arg1, float arg2, bool arg3, string arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        private string Concat(int arg1, float arg2, string arg3, string arg4) => $"{arg1}{arg2}{arg3}{arg4}";
        // TODO: 2 methods distinguish only by name, while parameter types are the same.


        // TODO: Generate different methods with successively more parameters (up to 10 parameters), with overlap in names and varying parameter/return types.
    }
}
