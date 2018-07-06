using System.Web.Mvc;
using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.WithViewMapping.Presenters;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;
using ActionDispatcher = JJ.Demos.ReturnActions.Framework.Mvc.ActionDispatcher;
// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.UrlParameter.Controllers
{
	public class LoginController : MasterController
	{
		public ActionResult Index(string ret = null)
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new LoginPresenter();
				ActionInfo returnAction = ActionDispatcher.TryGetActionInfo(ret);
				viewModel = presenter.Show(returnAction);
			}

			return ActionDispatcher.Dispatch(this, viewModel);
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

			return ActionDispatcher.Dispatch(this, viewModel2);
		}
	}
}