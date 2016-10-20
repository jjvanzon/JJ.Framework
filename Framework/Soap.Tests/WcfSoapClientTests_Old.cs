//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using JJ.Framework.Xml.Linq;
//using System.Text;
//using JJ.Presentation.SaveText.Interface.ViewModels;
//using JJ.Data.Canonical;
//using System.Collections.Generic;
//using JJ.Presentation.SaveText.AppService.Interface;

//namespace JJ.Framework.Soap.Tests
//{
//    [TestClass]
//    public class WcfSoapClientTests_Old
//    {
//        [TestMethod]
//        public void Test_WcfSoapClient()
//        {
//            string url = "http://localhost:6371/savetextappservice.svc";
//            var client = new WcfSoapClient<ISaveTextAppService>(url);
//            SaveTextViewModel viewModel = CreateViewModel();
//            SaveTextViewModel viewModel2 = client.Invoke(x => x.Save(viewModel, "nl-NL"));
//        }

//        [TestMethod]
//        public void Test_WcfSoapClient_WithCollections()
//        {
//            string url = "http://localhost:6371/savetextappservice.svc";
//            var client = new WcfSoapClient<ISaveTextAppService>(url);
//            SaveTextViewModel viewModel = CreateViewModel();

//            // Test collection items sent back and forth by abusing the ValidationMessages collection.
//            // Back (no text generates validation messages)
//            viewModel.Text = "";
//            // Forth
//            viewModel.ValidationMessages.Add(new ValidationMessage { PropertyKey = "Dummy", Text = "This is a dummy." });
//            viewModel.ValidationMessages.Add(new ValidationMessage { PropertyKey = "Dummy", Text = "This is a dummy." });

//            SaveTextViewModel viewModel2 = client.Invoke(x => x.Save(viewModel, "nl-NL"));
//        }

//        private SaveTextViewModel CreateViewModel()
//        {
//            return new SaveTextViewModel
//            {
//                Text = "Hi!",
//                ValidationMessages = new List<ValidationMessage>()
//            };
//        }
//    }
//}
