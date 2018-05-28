using System.Web.Mvc;
using JJ.Demos.ReturnActions.MvcUrlParameter.Helpers;
using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Demos.ReturnActions.NoViewMapping.Presenters;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using ActionDispatcher = JJ.Demos.ReturnActions.MvcUrlParameter.Helpers.ActionDispatcher;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Controllers
{
	public class LoginController : MasterController
	{
		public ActionResult Index(string ret = null)
		{
			if (!TempData.TryGetValue(TempDataKeys.ViewModel, out object viewModel))
			{
				var presenter = new LoginPresenter();
				viewModel = presenter.Show(ret);
			}

			return ActionDispatcher.Dispatch(this, ActionNames.Index, viewModel);
		}

		[HttpPost]
		public ActionResult Index(LoginViewModel viewModel, string ret = null)
		{
			var presenter = new LoginPresenter();
			viewModel.ReturnAction = ret;
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