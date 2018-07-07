//using JJ.Framework.Presentation;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//// ReSharper disable UnusedVariable

//namespace JJ.Framework.Mvc.Tests
//{
//    [TestClass]
//    public class ReturnUrlHelperTests
//    {
//        [TestInitialize]
//        public void Test_Initialize() => ActionDispatcher.RegisterAssembly(GetType().Assembly);

//        [TestMethod]
//        public void Test_ReturnUrlHelper_ConvertActionInfoToReturnUrl()
//        {
//            ActionInfo actionInfo = Presentation.ActionDispatcher.CreateActionInfo("QuestionDetailsPresenter", "Show", "id", 1);

//            string url = ActionDispatcher.GetUrl(actionInfo);

//            Assert.AreEqual("Questions/Details?id=1", url);
//        }

//        [TestMethod]
//        public void Test_ReturnUrlHelper_ConvertActionInfosToReturnUrl()
//        {
//            ActionInfo actionInfo1 = Presentation.ActionDispatcher.CreateActionInfo("QuestionDetailsPresenter", "Show", "id", 1);
//            ActionInfo actionInfo2 = Presentation.ActionDispatcher.CreateActionInfo("QuestionEditPresenter", "Edit", "id", 1);
//            ActionInfo actionInfo3 = Presentation.ActionDispatcher.CreateActionInfo("LoginPresenter", "Show");

//            actionInfo1.ReturnAction = actionInfo2;
//            actionInfo2.ReturnAction = actionInfo3;

//            string url = ActionDispatcher.GetUrl(actionInfo1, "ret");
//        }
//    }
//}