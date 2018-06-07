using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;
using JJ.Demos.ReturnActions.NoViewMapping.Presenters;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using JJ.Framework.Presentation;
using ActionDispatcher = JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Helpers.ActionDispatcher;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
	public class LoginController : MasterController
	{
		public ActionResult Index(string ret = null)
		{
			if (!TempData.TryGetValue(nameof(TempDataKeys.ViewModel), out object viewModel))
			{
				var presenter = new LoginPresenter();
				viewModel = presenter.Show(ret);
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		[HttpPost]
		public ActionResult Index(LoginViewModel viewModel, string ret = null)
		{
			var presenter = new LoginPresenter();
			viewModel.ReturnAction = ret;
			AuthenticatedViewModel viewModel2 = presenter.Login(viewModel);

			SetAuthenticatedUserName(viewModel.UserName);

			return ActionDispatcher.Dispatch(this, viewModel2);
		}
	}
}