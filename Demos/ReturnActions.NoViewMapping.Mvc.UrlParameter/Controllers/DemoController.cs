using System.Web.Mvc;
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
			if (!TempData.TryGetValue(TempDataKeys.ViewModel, out object viewModel))
			{
				var presenter = new ListPresenter();
				viewModel = presenter.Show();
			}

			return ActionDispatcher.Dispatch(this, nameof(ActionNames.Index), viewModel);
		}

		public ActionResult Details(int id)
		{
			if (!TempData.TryGetValue(TempDataKeys.ViewModel, out object viewModel))
			{
				var presenter = new DetailsPresenter();
				viewModel = presenter.Show(id);
			}

			return ActionDispatcher.Dispatch(this, nameof(ActionNames.Details), viewModel);
		}

		public ActionResult Edit(int id, string ret = null)
		{
			if (!TempData.TryGetValue(TempDataKeys.ViewModel, out object viewModel))
			{
				var presenter = new EditPresenter(GetAuthenticatedUserName());
				viewModel = presenter.Show(id, ret);
			}

			return ActionDispatcher.Dispatch(this, nameof(ActionNames.Edit), viewModel);
		}

		[HttpPost]
		public ActionResult Edit(int id, EditViewModel viewModel, string ret = null)
		{
			var presenter = new EditPresenter(GetAuthenticatedUserName());
			viewModel.ReturnAction = ret;
			object viewModel2 = presenter.Save(viewModel);

			return ActionDispatcher.Dispatch(this, nameof(ActionNames.Edit), viewModel2);
		}

		public ActionResult Logout()
		{
			if (!TempData.TryGetValue(TempDataKeys.ViewModel, out object viewModel))
			{
				var presenter = new LoginPresenter();
				viewModel = presenter.Logout();
			}

			SetAuthenticatedUserName(null);

			return ActionDispatcher.Dispatch(this, nameof(ActionNames.Logout), viewModel);
		}
	}
}