using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Demos.ReturnActions.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Demos.ReturnActions.MvcPostData.ViewMapping
{
    public class LoginViewMapping : ViewMapping<LoginViewModel>
    {
        public LoginViewMapping()
        {
            MapController(ControllerNames.Login, ActionNames.Index, ViewNames.Index);
            MapPresenter(PresenterNames.LoginPresenter, PresenterActionNames.Show);
        }
    }
}