using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using System.Collections.Generic;
using JJ.Framework.Testing;
using System.Net;
using JJ.Framework.Configuration;
using JJ.Framework.Soap.Tests.ServiceInterface;
using JJ.Framework.Soap.Tests.Helpers;

namespace JJ.Framework.Soap.Tests
{
    [TestClass]
    public class SoapClientTests
    {
        [TestMethod]
        public void Test_SoapClient()
        {
            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            string methodName = "SendAndGetCompositeObject";
            string soapAction = String.Format("http://tempuri.org/{0}/{1}", typeof(ITestService).Name, methodName);
            var client = new SoapClient(url, Encoding.UTF8);
            CompositeType obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            CompositeType obj2 = null;
            TestHelper.WithInconclusiveConnectionAssertion(() =>
            {
                obj2 = client.Invoke<CompositeType>(soapAction, methodName, new SoapParameter("compositeObject", obj1));
            });

            AssertHelper.IsNotNull(() => obj2);
            AssertHelper.IsTrue(() => obj2.BoolValue);
            AssertHelper.AreEqual(obj1.StringValue + " to you too!", () => obj2.StringValue);
        }

        [TestMethod]
        public void Test_SoapClient_WithNamespaceMappings()
        {
            var namespaceMappings = new List<SoapNamespaceMapping>
            {
                new SoapNamespaceMapping(SoapNamespaceMapping.WCF_SOAP_NAMESPACE_HEADER + typeof(CompositeType).Namespace, "http://blahblahblah.com"),
            };

            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            string methodName = "SendAndGetCompositeObject";
            string soapAction = String.Format("http://tempuri.org/{0}/{1}", typeof(ITestService).Name, methodName);
            var client = new SoapClient(url, Encoding.UTF8, namespaceMappings);
            CompositeType obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            CompositeType obj2 = null;

            TestHelper.WithInconclusiveConnectionAssertion(() =>
            {
                obj2 = client.Invoke<CompositeType>(soapAction, methodName, new SoapParameter("compositeObject", obj1));
            });

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
                new SoapNamespaceMapping("http://tempuri.org/", "http://blahblahblah.org"),
            };

            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            string methodName = "SendAndGetCompositeObject";
            string soapAction = String.Format("http://tempuri.org/{0}/{1}", typeof(ITestService).Name, methodName);
            var client = new SoapClient(url, Encoding.UTF8, namespaceMappings);
            CompositeType obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            CompositeType obj2;

            TestHelper.WithInconclusiveConnectionAssertion(() =>
            {
                obj2 = client.Invoke<CompositeType>(soapAction, methodName, new SoapParameter("compositeObject", obj1));
            });
        }
    }
}
