using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Controllers
{
    public class MasterController : Controller
    {
        protected string GetAuthenticatedUserName()
        {
            return (string)Session[SessionKeys.AuthenticatedUserName];
        }

        protected void SetAuthenticatedUserName(string value)
        {
            Session[SessionKeys.AuthenticatedUserName] = value;
        }
    }
}