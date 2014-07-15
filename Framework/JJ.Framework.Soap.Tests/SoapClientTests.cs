using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using JJ.Apps.SetText.ViewModels;
using System.Collections.Generic;

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
            var client = new SoapClient(url, Encoding.UTF8);
            SetTextViewModel viewModel = CreateViewModel();
            SetTextViewModel viewModel2 = client.Invoke<SetTextViewModel>(soapAction, "Save", new SoapParameter("viewModel", viewModel));
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
