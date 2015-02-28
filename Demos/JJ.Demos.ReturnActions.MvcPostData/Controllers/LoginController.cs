using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Demos.ReturnActions.Presenters;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostData.Controllers
{
    public class LoginController : MasterController
    {
        public ActionResult Index()
        {
            object viewModel;
            if (!TempData.TryGetValue(TempDataKeys.ViewModel, out viewModel))
            {
                var presenter = new LoginPresenter();
                viewModel = presenter.Show();
            }

            return ActionDispatcher.DispatchAction(this, ActionNames.Index, viewModel);
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

            return ActionDispatcher.DispatchAction(this, ActionNames.Index, viewModel2);
        }
    }
}