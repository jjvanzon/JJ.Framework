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
            if (!TempData.TryGetValue(ActionDispatcher.VIEW_MODEL_TEMP_DATA_KEY, out viewModel))
            {
                var presenter = new LoginPresenter();
                ActionInfo returnAction = UrlHelpers.GetReturnAction(ret);
                viewModel = presenter.Show(returnAction);
            }

            return ActionDispatcher.DispatchAction(this, ActionNames.Index, viewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel, string ret = null)
        {
            viewModel.ReturnAction = UrlHelpers.GetReturnAction(ret);

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