using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using JJ.Apps.SetText.ViewModels;

namespace JJ.Framework.Soap.Tests
{
    [TestClass]
    public class WcfSoapClientTests
    {
        [TestMethod]
        public void Test_WcfSoapClient()
        {
            string url = "http://localhost:6371/settextappservice.svc";
            string serviceInterfaceName = "ISetTextAppService";
            var client = new WcfSoapClient(url, serviceInterfaceName);
            SetTextViewModel viewModel = CreateViewModel();
            SetTextViewModel viewModel2 = client.Invoke<SetTextViewModel>("Save", new SoapParameter("viewModel", viewModel));
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
