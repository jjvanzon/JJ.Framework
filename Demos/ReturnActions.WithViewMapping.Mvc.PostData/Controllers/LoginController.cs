﻿using System.Web.Mvc;
using JJ.Demos.ReturnActions.Framework.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.WithViewMapping.Presenters;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData.Controllers
{
    public class LoginController : MasterController
    {
        public ActionResult Index()
        {
            if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
            {
                var presenter = new LoginPresenter();
                viewModel = presenter.Show();
            }

            return ActionDispatcher.Dispatch(this, viewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {
            var presenter = new LoginPresenter();
            object viewModel2 = presenter.Login(viewModel);

            // TODO: This is dirty.
            if (!(viewModel2 is LoginViewModel))
            {
                SetAuthenticatedUserName(viewModel.UserName);
            }

            return ActionDispatcher.Dispatch(this, viewModel2);
        }
    }
}