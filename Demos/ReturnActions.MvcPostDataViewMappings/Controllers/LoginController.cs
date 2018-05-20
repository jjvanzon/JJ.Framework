using System.Web.Mvc;
using JJ.Demos.ReturnActions.MvcPostDataViewMappings.Names;
using JJ.Demos.ReturnActions.Presenters;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings.Controllers
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

			return ActionDispatcher.Dispatch(this, ActionNames.Index, viewModel);
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

			return ActionDispatcher.Dispatch(this, ActionNames.Index, viewModel2);
		}
	}
}