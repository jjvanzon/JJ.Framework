using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using System.Collections.Generic;
using JJ.Framework.Configuration;
using JJ.Framework.Soap.Tests.ServiceInterface;
using JJ.Framework.Soap.Tests.Helpers;
using System.Net;

namespace JJ.Framework.Soap.Tests
{
    [TestClass]
    public class WcfSoapClientTests
    {
        [TestMethod]
        public void Test_WcfSoapClient_SendAndGetComplicatedObject()
        {
            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            var client = new CustomWcfSoapClient<ITestService>(url);
            ComplicatedType obj1 = TestHelper.CreateComplicatedObject();

            try
            {
                ComplicatedType obj2 = client.Invoke(x => x.SendAndGetComplicatedObject(obj1));
            }
			catch (WebException ex)
			{
                TestHelper.AssertServiceConnectionFailed(ex);
            }
        }

        [TestMethod]
        public void Test_WcfSoapClient_SendAndGetCompositeObject()
        {
            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            var client = new CustomWcfSoapClient<ITestService>(url);
            CompositeType obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            try
            {
                CompositeType obj2 = client.Invoke(x => x.SendAndGetCompositeObject(obj1));
            }
			catch (WebException ex)
			{
                TestHelper.AssertServiceConnectionFailed(ex);
            }
        }

        [TestMethod]
        public void Test_WcfSoapClient_SendAndGetObjectWithCollection()
        {
            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            var client = new CustomWcfSoapClient<ITestService>(url);
            TypeWithCollection obj1 = new TypeWithCollection { StringList = new string[] { "Hi", "there", "!" } };

            try
            {
                TypeWithCollection obj2 = client.Invoke(x => x.SendAndGetObjectWithCollection(obj1));
            }
			catch (WebException ex)
			{
                TestHelper.AssertServiceConnectionFailed(ex);
            }
        }
    }
}
