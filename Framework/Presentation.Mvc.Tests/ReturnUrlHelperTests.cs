using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Presentation.Mvc.Tests
{
    [TestClass]
    public class ReturnUrlHelperTests
    {
        [TestInitialize]
        public void Test_Initialize()
        {
            ActionDispatcher.RegisterAssembly(GetType().Assembly);
        }

        [TestMethod]
        public void Test_ReturnUrlHelper_ConvertActionInfoToReturnUrl()
        {
            ActionInfo actionInfo = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("QuestionDetailsPresenter", "Show", "id", 1);

            string url = ActionDispatcher.GetUrl(actionInfo);
            
            Assert.AreEqual("Questions/Details?id=1", url);
        }

        [TestMethod]
        public void Test_ReturnUrlHelper_ConvertActionInfosToReturnUrl()
        {
            ActionInfo actionInfo1 = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("QuestionDetailsPresenter", "Show", "id", 1);
            ActionInfo actionInfo2 = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("QuestionEditPresenter", "Edit", "id", 1);
            ActionInfo actionInfo3 = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("LoginPresenter", "Show");

            actionInfo1.ReturnAction = actionInfo2;
            actionInfo2.ReturnAction = actionInfo3;

            string url = ActionDispatcher.GetUrl(actionInfo1, "ret");
        }
    }
}
