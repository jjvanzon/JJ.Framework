using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.WithViewMapping.Presenters;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;
using JJ.Framework.Mvc;

// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.PostData.Controllers
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

		public ActionResult Edit(int id)
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new EditPresenter(GetAuthenticatedUserName());
				viewModel = presenter.Show(id);
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		[HttpPost]
		public ActionResult Edit(int id, EditViewModel viewModel)
		{
			var presenter = new EditPresenter(GetAuthenticatedUserName());
			object viewModel2 = presenter.Save(viewModel);

			return ActionDispatcher.Dispatch(this, viewModel2);
		}

		public ActionResult Logout()
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new LoginPresenter();
				viewModel = presenter.Logout();
			}

			SetAuthenticatedUserName(null);

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		// These methods are hacks necessary to make multi-level return actions
		// work when you put the return action information in the post data
		// as explained in README.TXT.

		public ActionResult EditFromIndex(int id)
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new ListPresenter();
				viewModel = presenter.Edit(id, GetAuthenticatedUserName());
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		[HttpPost]
		public ActionResult EditFromIndex(int id, EditViewModel viewModel)
		{
			var presenter = new EditPresenter(GetAuthenticatedUserName());
			object viewModel2 = presenter.Save(viewModel);
			return ActionDispatcher.Dispatch(this, viewModel2);
		}

		public ActionResult EditFromDetails(int id)
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new DetailsPresenter();
				viewModel = presenter.Edit(id, GetAuthenticatedUserName());
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		[HttpPost]
		public ActionResult EditFromDetails(int id, EditViewModel viewModel)
		{
			var presenter = new EditPresenter(GetAuthenticatedUserName());
			object viewModel2 = presenter.Save(viewModel);
			return ActionDispatcher.Dispatch(this, viewModel2);
		}
	}
}