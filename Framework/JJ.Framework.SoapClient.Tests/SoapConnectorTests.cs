using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq;
using System.Text;
using JJ.Apps.SetText.ViewModels;

namespace JJ.Framework.SoapClient.Tests
{
    [TestClass]
    public class SoapConnectorTests
    {
        [TestMethod]
        public void Test_SoapConnector()
        {
            // TODO: Make a WcfSoapConnector that is much like the SoapConnector,
            // but that does a few of these things for you.

            // TODO: Use a conflicting soap or operation namespace prefix (e.g. "v")
            // It will produce an error. Solve it. It is something not yet implemented.

            string url = "http://localhost:6371/settextappservice.svc";
            string soapAction = "http://tempuri.org/ISetTextAppService/Save";

            string soapXmlNamespacePrefix = "s";
            string operationXmlNamespacePrefix = "o";

            string[] dotNetNamespaces = new string[] { "JJ.Models.Canonical", "JJ.Apps.SetText.ViewModels" };
            string[] excludedXmlNamespacePrefixes = new string[] { soapXmlNamespacePrefix, operationXmlNamespacePrefix };

            var namespaceMappings = XmlNamespaceMappingFactory.CreateXmlNamespaceMappings(excludedXmlNamespacePrefixes, dotNetNamespaces);

            var connector = new SoapConnector(url, namespaceMappings, soapXmlNamespacePrefix, operationXmlNamespacePrefix, Encoding.UTF8);
            SetTextViewModel viewModel = CreateViewModel();
            SetTextViewModel viewModel2 = connector.Invoke<SetTextViewModel>(soapAction, "Save", new SoapParameter("viewModel", viewModel));
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
