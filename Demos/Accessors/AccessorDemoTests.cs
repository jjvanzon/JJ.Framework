using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Demos.Accessors
{
    [TestClass]
    public class AccessorDemoTests
    {
        [TestMethod]
        public void Debug_AccessorDemo_AccessorCaller()
        {
            var accessorCaller = new AccessorCaller();
            accessorCaller.Demo();
        }

        [TestMethod]
        public void Debug_AccessorDemo_MyAccessorCaller()
        {
            var myAccessorCaller = new MyAccessorCaller();
            myAccessorCaller.Demo();
        }
    }
}