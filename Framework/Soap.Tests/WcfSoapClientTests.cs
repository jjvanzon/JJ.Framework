﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Configuration;
using JJ.Framework.Soap.Tests.ServiceInterface;
using JJ.Framework.Soap.Tests.Helpers;

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

            TestHelper.WithInconclusiveConnectionAssertion(() =>
            {
                ComplicatedType obj2 = client.Invoke(x => x.SendAndGetComplicatedObject(obj1));
            });
        }

        [TestMethod]
        public void Test_WcfSoapClient_SendAndGetCompositeObject()
        {
            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            var client = new CustomWcfSoapClient<ITestService>(url);
            CompositeType obj1 = new CompositeType { BoolValue = true, StringValue = "Hi!" };

            TestHelper.WithInconclusiveConnectionAssertion(() =>
            {
                CompositeType obj2 = client.Invoke(x => x.SendAndGetCompositeObject(obj1));
            });
        }

        [TestMethod]
        public void Test_WcfSoapClient_SendAndGetObjectWithCollection()
        {
            string url = AppSettings<IAppSettings>.Get(x => x.Url);
            var client = new CustomWcfSoapClient<ITestService>(url);
            TypeWithCollection obj1 = new TypeWithCollection { StringList = new string[] { "Hi", "there", "!" } };

            TestHelper.WithInconclusiveConnectionAssertion(() =>
            {
                TypeWithCollection obj2 = client.Invoke(x => x.SendAndGetObjectWithCollection(obj1));
            });
        }
    }
}