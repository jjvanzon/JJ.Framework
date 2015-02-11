//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using JJ.Framework.Xml.Linq;
//using System.Text;
//using JJ.Presentation.SetText.Interface.ViewModels;
//using JJ.Business.CanonicalModel;
//using System.Collections.Generic;
//using JJ.Presentation.SetText.AppService.Interface;

//namespace JJ.Framework.Soap.Tests
//{
//    [TestClass]
//    public class WcfSoapClientTests_Old
//    {
//        [TestMethod]
//        public void Test_WcfSoapClient()
//        {
//            string url = "http://localhost:6371/settextappservice.svc";
//            var client = new WcfSoapClient<ISetTextAppService>(url);
//            SetTextViewModel viewModel = CreateViewModel();
//            SetTextViewModel viewModel2 = client.Invoke(x => x.Save(viewModel, "nl-NL"));
//        }

//        [TestMethod]
//        public void Test_WcfSoapClient_WithCollections()
//        {
//            string url = "http://localhost:6371/settextappservice.svc";
//            var client = new WcfSoapClient<ISetTextAppService>(url);
//            SetTextViewModel viewModel = CreateViewModel();

//            // Test collection items sent back and forth by abusing the ValidationMessages collection.
//            // Back (no text generates validation messages)
//            viewModel.Text = "";
//            // Forth
//            viewModel.ValidationMessages.Add(new ValidationMessage { PropertyKey = "Dummy", Text = "This is a dummy." });
//            viewModel.ValidationMessages.Add(new ValidationMessage { PropertyKey = "Dummy", Text = "This is a dummy." });

//            SetTextViewModel viewModel2 = client.Invoke(x => x.Save(viewModel, "nl-NL"));
//        }

//        private SetTextViewModel CreateViewModel()
//        {
//            return new SetTextViewModel
//            {
//                Text = "Hi!",
//                ValidationMessages = new List<ValidationMessage>()
//            };
//        }
//    }
//}
