using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Demos.ReturnActions.Presenters;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
using JJ.Framework.Presentation.Mvc;
using ActionDispatcher = JJ.Framework.Presentation.Mvc.ActionDispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Controllers
{
    public class LoginController : MasterController
    {
        public ActionResult Index(string ret = null)
        {
            object viewModel;
            if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out viewModel))
            {
                var presenter = new LoginPresenter();
                ActionInfo returnAction = ActionDispatcher.TryGetActionInfo(ret);
                viewModel = presenter.Show(returnAction);
            }

            return ActionDispatcher.Dispatch(this, ActionNames.Index, viewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel, string ret = null)
        {
            var presenter = new LoginPresenter();
            viewModel.ReturnAction = ActionDispatcher.TryGetActionInfo(ret);
            object viewModel2 = presenter.Login(viewModel);

            // TODO: This is dirty.
            if (!(viewModel2 is LoginViewModel))
            {
                SetAuthenticatedUserName(viewModel.UserName);
            }

            return ActionDispatcher.Dispatch(this, ActionNames.Index, viewModel2);
        }
    }
}