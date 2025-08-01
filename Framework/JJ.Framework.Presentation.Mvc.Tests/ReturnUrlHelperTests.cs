﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Presentation.Mvc.Tests
{
    [TestClass]
    public class ReturnUrlHelperTests
    {
        [TestMethod]
        public void Test_ReturnUrlHelper_ConvertActionInfoToReturnUrl()
        {
            ActionInfo actionInfo = JJ.Framework.Presentation.Legacy.ActionDispatcher.CreateActionInfo("Questions", "Details", "id", 1);

            string url = UrlHelpers.GetReturnUrl(actionInfo);
            
            Assert.AreEqual("Questions/Details?id=1", url);
        }

        [TestMethod]
        public void Test_ReturnUrlHelper_ConvertActionInfosToReturnUrl()
        {
            ActionInfo actionInfo1 = JJ.Framework.Presentation.Legacy.ActionDispatcher.CreateActionInfo("Questions", "Details", "id", 1);
            ActionInfo actionInfo2 = JJ.Framework.Presentation.Legacy.ActionDispatcher.CreateActionInfo("Questions", "Edit", "id", 1);
            ActionInfo actionInfo3 = JJ.Framework.Presentation.Legacy.ActionDispatcher.CreateActionInfo("Login", "Index");

            actionInfo1.ReturnAction = actionInfo2;
            actionInfo2.ReturnAction = actionInfo3;

            string url = UrlHelpers.GetReturnUrl(actionInfo1, "ret");
        }
    }
}
