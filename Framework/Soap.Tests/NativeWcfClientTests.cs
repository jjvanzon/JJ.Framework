using JJ.Framework.Configuration;
using JJ.Framework.Soap.Tests.Helpers;
using JJ.Framework.Soap.Tests.ServiceInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Soap.Tests
{
    [TestClass]
    public class NativeWcfClientTests
    {
        [TestMethod]
        public void Test_NativeWcfClient_SendAndGetComplicatedObject()
        { 
            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            var client = new NativeWcfClient(url);
            ComplicatedType obj1 = TestHelper.CreateComplicatedObject();

            TestHelper.WithInconclusiveConnectionAssertion(() =>
            {
                ComplicatedType obj2 = client.SendAndGetComplicatedObject(obj1);
            });
        }
    }
}
