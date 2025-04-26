namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class NullExceptionTests
{
    // ncrunch: no coverage start
    
    private int Property { get; set; }

    private class Item
    {
        public int ItemProperty { get; set; }
    }

    // ncrunch: no coverage end
    
    [TestMethod]
    public void Test_Null_Throws_NullException()
    {
        {
            int localVariable = 1;
            var exception = new NullException(() => localVariable);
            AreEqual("localVariable cannot be null.", exception.Message);
        }
        {
            var exception = new NullException(() => Property);
            AreEqual("Property cannot be null.", exception.Message);
        }
        {
            var item = new Item();
            var exception = new NullException(() => item.ItemProperty);
            AreEqual("item.ItemProperty cannot be null.", exception.Message);
        }
    }
}
