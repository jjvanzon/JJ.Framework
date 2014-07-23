using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using JJ.Apps.SetText.ViewModels;
using JJ.Models.Canonical;
using System.Collections.Generic;

namespace JJ.Framework.Soap.Tests
{
    [TestClass]
    public class WcfSoapClientTests
    {
        [TestMethod]
        public void Test_WcfSoapClient_WithCollections()
        {
            string url = "http://localhost:6371/settextappservice.svc";
            string serviceInterfaceName = "ISetTextAppService";
            var client = new WcfSoapClient(url, serviceInterfaceName);
            SetTextViewModel viewModel = CreateViewModel();

            // Test collection items sent back and forth by abusing the ValidationMessages collection.
            // Back (no text generates validation messages)
            viewModel.Text = "";
            // Forth
            viewModel.ValidationMessages.Add(new ValidationMessage { PropertyKey = "Dummy", Text = "This is a dummy." });
            viewModel.ValidationMessages.Add(new ValidationMessage { PropertyKey = "Dummy", Text = "This is a dummy." });

            SetTextViewModel viewModel2 = client.Invoke<SetTextViewModel>("Save", new SoapParameter("viewModel", viewModel));
        }

        private SetTextViewModel CreateViewModel()
        {
            return new SetTextViewModel
            {
                Text = "Hi!",
                ValidationMessages = new List<ValidationMessage>()
            };
        }
    }
}
