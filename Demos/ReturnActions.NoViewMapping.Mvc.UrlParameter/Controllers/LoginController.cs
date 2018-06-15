using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.Presenters;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Web;

// ReSharper disable UnusedParameter.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
    public class LoginController : MasterController
    {
        public ActionResult Index(string ret = null)
        {
            if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
            {
                var presenter = new LoginPresenter();
                viewModel = presenter.Show();
            }

            Response.StatusCode = HttpStatusCodes.NOT_AUTHENTICATED_401;

            return ActionDispatcher.Dispatch(this, viewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel userInput, string ret = null)
        {
            var presenter = new LoginPresenter();

            LoginViewModel viewModel = presenter.Login(userInput);

            if (viewModel.IsAuthenticated)
            {
                SetAuthenticatedUserName(viewModel.UserName);
            }

            return Redirect(ret);
        }
    }
}