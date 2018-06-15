using System;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Helpers;
using JJ.Demos.ReturnActions.NoViewMapping.Presenters;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Web;

// ReSharper disable UnusedParameter.Global
// ReSharper disable InvertIf

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
    public class DemoController : MasterController
    {
        public ActionResult Index()
        {
            if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
            {
                var presenter = new ListPresenter();
                viewModel = presenter.Show();
            }

            return ActionDispatcher.Dispatch(this, viewModel);
        }

        public ActionResult Details(int id)
        {
            if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
            {
                var presenter = new DetailsPresenter();
                viewModel = presenter.Show(id);
            }

            return ActionDispatcher.Dispatch(this, viewModel);
        }

        public ActionResult Edit(int id, string ret = null)
        {
            if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
            {
                var presenter = new EditPresenter(GetAuthenticatedUserName());
                viewModel = presenter.Show(id);
            }

            return ActionDispatcher.Dispatch(this, viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditViewModel userInput, string ret = null)
        {
            var presenter = new EditPresenter(GetAuthenticatedUserName());

            EditViewModel viewModel = presenter.Save(userInput);

            if (viewModel.Successful)
            {
                return Redirect(ret);
            }

            return ActionDispatcher.Dispatch(this, viewModel);
        }

        public ActionResult Logout()
        {
            if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
            {
                viewModel = new LoginPresenter().Logout();
            }

            SetAuthenticatedUserName(null);

            return ActionDispatcher.Dispatch(this, viewModel);
        }

        public ActionResult GenerateAthenticationError() => throw new AuthenticationException();
        public ActionResult GenerateAuthorizationError() => throw new UnauthorizedAccessException();
        public ActionResult GenerateArbitraryError() => throw new Exception("An error occurred.");
        public ActionResult GenerateNotFoundError() => throw new HttpException(HttpStatusCodes.NOT_FOUND_404, "Not found.");
    }
}