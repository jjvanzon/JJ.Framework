using System.Collections.Generic;
using System.Net;
using System.Text;
using JJ.Framework.Configuration;
using JJ.Framework.Soap.Tests.Helpers;
using JJ.Framework.Soap.Tests.ServiceInterface;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable NotAccessedVariable

namespace JJ.Framework.Soap.Tests
{
    [TestClass]
    public class SoapClientTests
    {
        [TestMethod]
        public void Test_SoapClient()
        {
            string url = AppSettingsReader<IAppSettings>.Get(x => x.Url);
            var methodName = "SendAndGetCompositeObject";
            string soapAction = "http://tempuri.org/{typeof(ITestService).Name}/{methodName}";
            var client = new SoapClient(url, Encoding.UTF8);
            var obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            CompositeType obj2 = null;

            TestHelper.WithInconclusiveConnectionAssertion(
                () => obj2 = client.Invoke<CompositeType>(soapAction, methodName, new SoapParameter("compositeObject", obj1)));

            AssertHelper.IsNotNull(() => obj2);
            AssertHelper.IsTrue(() => obj2.BoolValue);
            AssertHelper.AreEqual(obj1.StringValue + " to you too!", () => obj2.StringValue);
        }

        [TestMethod]
        public void Test_SoapClient_WithNamespaceMappings()
        {
            var namespaceMappings = new List<SoapNamespaceMapping>
            {
                new SoapNamespaceMapping(
                    SoapNamespaceMapping.WCF_SOAP_NAMESPACE_HEADER + typeof(CompositeType).Namespace,
                    "http://blahblahblah.com")
            };

            string url = AppSettingsReader<IAppSettings>.Get(x => x.Url);
            var methodName = "SendAndGetCompositeObject";
            string soapAction = $"http://tempuri.org/{typeof(ITestService).Name}/{methodName}";
            var client = new SoapClient(url, Encoding.UTF8, namespaceMappings);
            var obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            CompositeType obj2 = null;

            TestHelper.WithInconclusiveConnectionAssertion(
                () => obj2 = client.Invoke<CompositeType>(soapAction, methodName, new SoapParameter("compositeObject", obj1)));

            // WCF will accept the message, just will not bind the data sent to the server.
            AssertHelper.IsNotNull(() => obj2);
            AssertHelper.IsTrue(() => obj2.BoolValue);
            AssertHelper.AreEqual("Hello world!", () => obj2.StringValue);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Test_SoapClient_WithNamespaceMapping_ThatReplacesDefaultNamespace()
        {
            var namespaceMappings = new List<SoapNamespaceMapping>
            {
                new SoapNamespaceMapping("http://tempuri.org/", "http://blahblahblah.org")
            };

            string url = AppSettingsReader<IAppSettings>.Get(x => x.Url);
            var methodName = "SendAndGetCompositeObject";
            string soapAction = $"http://tempuri.org/{typeof(ITestService).Name}/{methodName}";
            var client = new SoapClient(url, Encoding.UTF8, namespaceMappings);
            var obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            CompositeType obj2;

            TestHelper.WithInconclusiveConnectionAssertion(
                () => obj2 = client.Invoke<CompositeType>(soapAction, methodName, new SoapParameter("compositeObject", obj1)));
        }
    }
}