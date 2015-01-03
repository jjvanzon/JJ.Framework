//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using JJ.Framework.Xml.Linq;
//using System.Text;
//using JJ.Apps.SetText.Interface.ViewModels;
//using JJ.Models.Canonical;
//using System.Collections.Generic;
//using JJ.Apps.SetText.AppService.Interface;

//namespace JJ.Framework.Soap.Tests
//{
//    [TestClass]
//    public class WcfSoapClientOfTTests
//    {
//        [TestMethod]
//        public void Test_WcfSoapClientOfT()
//        {
//            string url = "http://localhost:6371/settextappservice.svc";
//            var client = new WcfSoapClient<ISetTextAppService>(url);
//            SetTextViewModel viewModel = CreateViewModel();
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
