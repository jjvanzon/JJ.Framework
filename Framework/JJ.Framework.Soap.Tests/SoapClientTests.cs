using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using JJ.Apps.SetText.ViewModels;
using System.Collections.Generic;
using JJ.Framework.Testing;

namespace JJ.Framework.Soap.Tests
{
    [TestClass]
    public class SoapClientTests
    {
        [TestMethod]
        public void Test_SoapClient()
        {
            string url = "http://localhost:6371/settextappservice.svc";
            string soapAction = "http://tempuri.org/ISetTextAppService/Save";
            SoapClient client = new SoapClient(url, Encoding.UTF8);

            SetTextViewModel viewModel = CreateViewModel();
            SetTextViewModel viewModel2 = client.Invoke<SetTextViewModel>(soapAction, "Save", new SoapParameter("viewModel", viewModel));

            if (viewModel2.ValidationMessages != null)
            {
                AssertHelper.AreEqual(0, () => viewModel2.ValidationMessages.Count);
            }
            AssertHelper.IsTrue(() => viewModel2.TextWasSavedMessageVisible);
        }

        [TestMethod]
        public void Test_SoapClient_WithNamespaceMappings()
        {
            var namespaceMappings = new List<SoapNamespaceMapping>
            {
                new SoapNamespaceMapping(SoapNamespaceMapping.WCF_SOAP_NAMESPACE_HEADER + "JJ.Apps.SetText.ViewModels", "http://blahblahblah.com"),
            };

            string url = "http://localhost:6371/settextappservice.svc";
            string soapAction = "http://tempuri.org/ISetTextAppService/Save";
            SoapClient client = new SoapClient(url, Encoding.UTF8, namespaceMappings);

            SetTextViewModel viewModel = CreateViewModel();
            SetTextViewModel viewModel2 = client.Invoke<SetTextViewModel>(soapAction, "Save", new SoapParameter("viewModel", viewModel));

            // WCF will accept the message, just will not bind the data, 
            // so the sevice will return a validation message.
            AssertHelper.IsNotNull(() => viewModel2.ValidationMessages);
            AssertHelper.AreEqual(1, () => viewModel2.ValidationMessages.Count);
            AssertHelper.AreEqual("Text", () => viewModel2.ValidationMessages[0].PropertyKey);
        }

        [TestMethod]
        public void Test_SoapClient_WithNamespaceMapping_ThatReplacesDefaultNamespace()
        {
            var namespaceMappings = new List<SoapNamespaceMapping>
            {
                new SoapNamespaceMapping("http://tempuri.org/", "http://blahblahblah.org"),
            };

            string url = "http://localhost:6371/settextappservice.svc";
            string soapAction = "http://tempuri.org/ISetTextAppService/Save";
            SoapClient client = new SoapClient(url, Encoding.UTF8, namespaceMappings);

            SetTextViewModel viewModel = CreateViewModel();
            SetTextViewModel viewModel2 = client.Invoke<SetTextViewModel>(soapAction, "Save", new SoapParameter("viewModel", viewModel));

            // WCF will accept the message, just will not bind the data, 
            // so the sevice will return a validation message.
            AssertHelper.IsNotNull(() => viewModel2.ValidationMessages);
            AssertHelper.AreEqual(1, () => viewModel2.ValidationMessages.Count);
            AssertHelper.AreEqual("Text", () => viewModel2.ValidationMessages[0].PropertyKey);
        }
        private SetTextViewModel CreateViewModel()
        {
            return new SetTextViewModel
            {
                Text = "Hi!",
            };
        }
    }
}
