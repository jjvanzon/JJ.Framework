namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_Tuple_Core_Tests
{
    [TestMethod]
    public void PlatformCompatibility_Tuple2_Core_Test()
    {
        {
            (int, string) tuple = (1, "Hi!");
            AreEqual(1,     tuple.Item1);
            AreEqual("Hi!", tuple.Item2);
        }
        {
            Tuple_PlatformSupport<int, string> tuple = new(1, "Hi!");
            AreEqual(1,     tuple.Item1);
            AreEqual("Hi!", tuple.Item2);
        }
    }
    
    [TestMethod]
    public void PlatformCompatibility_Tuple3_Core_Test()
    {
        {
            (int, string, double) tuple = (1, "Hi!", 3.14);
            AreEqual(1,     tuple.Item1);
            AreEqual("Hi!", tuple.Item2);
            AreEqual(3.14,  tuple.Item3);
        }
        {
            Tuple_PlatformSupport<int, string, double> tuple = new(1, "Hi!", 3.14);
            AreEqual(1,     tuple.Item1);
            AreEqual("Hi!", tuple.Item2);
            AreEqual(3.14,  tuple.Item3);
        }
    }
}