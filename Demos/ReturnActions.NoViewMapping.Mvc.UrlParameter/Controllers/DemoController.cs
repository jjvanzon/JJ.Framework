using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names;
using JJ.Demos.ReturnActions.NoViewMapping.Presenters;
using JJ.Demos.ReturnActions.NoViewMapping.ViewModels;
using ActionDispatcher = JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Helpers.ActionDispatcher;
// ReSharper disable InvertIf

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Controllers
{
	public class DemoController : MasterController
	{
		public ActionResult Index()
		{
			if (!TempData.TryGetValue(nameof(TempDataKeys.ViewModel), out object viewModel))
			{
				var presenter = new ListPresenter();
				viewModel = presenter.Show();
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		public ActionResult Details(int id)
		{
			if (!TempData.TryGetValue(nameof(TempDataKeys.ViewModel), out object viewModel))
			{
				var presenter = new DetailsPresenter();
				viewModel = presenter.Show(id);
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		public ActionResult Edit(int id, string ret = null)
		{
			if (!TempData.TryGetValue(nameof(TempDataKeys.ViewModel), out object viewModel))
			{
				var presenter = new EditPresenter(GetAuthenticatedUserName());
				viewModel = presenter.Show(id, ret);
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		[HttpPost]
		public ActionResult Edit(int id, EditViewModel viewModel, string ret = null)
		{
			var presenter = new EditPresenter(GetAuthenticatedUserName());
			viewModel.ReturnAction = ret;
			object viewModel2 = presenter.Save(viewModel);

			return ActionDispatcher.Dispatch(this, viewModel2);
		}

		public ActionResult Logout()
		{
			if (!TempData.TryGetValue(nameof(TempDataKeys.ViewModel), out object viewModel))
			{
                viewModel = new LoginPresenter().Logout();
			}

			SetAuthenticatedUserName(null);

			return ActionDispatcher.Dispatch(this, viewModel);
		}
	}
}