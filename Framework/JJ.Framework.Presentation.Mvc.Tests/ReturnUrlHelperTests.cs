using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Presentation.Mvc.Tests
{
    [TestClass]
    public class ReturnUrlHelperTests
    {
        [TestMethod]
        public void Test_ReturnUrlHelper_ConvertActionInfoToReturnUrl()
        {
            ActionInfo actionInfo = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("Questions", "Details", "id", 1);

            string url = ReturnUrlHelper.ConvertActionInfoToReturnUrl(actionInfo);
            
            Assert.AreEqual("Questions\\Details?id=1", url);
        }

        [TestMethod]
        public void Test_ReturnUrlHelper_ConvertActionInfosToReturnUrl()
        {
            ActionInfo actionInfo1 = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("Questions", "Details", "id", 1);
            ActionInfo actionInfo2 = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("Questions", "Edit", "id", 1);
            ActionInfo actionInfo3 = JJ.Framework.Presentation.ActionDispatcher.CreateActionInfo("Login", "Index");

            string url = ReturnUrlHelper.ConvertActionInfosToReturnUrl("ret", actionInfo1, actionInfo2, actionInfo3);
        }
    }
}
