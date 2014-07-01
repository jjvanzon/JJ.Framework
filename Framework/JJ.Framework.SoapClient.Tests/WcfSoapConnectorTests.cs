using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using JJ.Apps.SetText.ViewModels;

namespace JJ.Framework.SoapClient.Tests
{
    [TestClass]
    public class WcfSoapConnectorTests
    {
        [TestMethod]
        public void Test_WcfSoapConnector()
        {
            string url = "http://localhost:6371/settextappservice.svc";
            string serviceInterfaceName = "ISetTextAppService";
            string[] dotNetNamespaces = new string[] { "JJ.Models.Canonical", "JJ.Apps.SetText.ViewModels" };

            var connector = new WcfSoapConnector(url, serviceInterfaceName, dotNetNamespaces);
            SetTextViewModel viewModel = CreateViewModel();
            SetTextViewModel viewModel2 = connector.Invoke<SetTextViewModel>("Save", new SoapParameter("viewModel", viewModel));
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
