using System.Web.Mvc;
using JJ.Demos.ReturnActions.MvcUrlParameter.Names;
using JJ.Demos.ReturnActions.Presenters;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
using ActionDispatcher = JJ.Framework.Mvc.ActionDispatcher;

namespace JJ.Demos.ReturnActions.MvcUrlParameter.Controllers
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

			return ActionDispatcher.Dispatch(this, ActionNames.Index, viewModel);
		}

		public ActionResult Details(int id)
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new DetailsPresenter();
				viewModel = presenter.Show(id);
			}

			return ActionDispatcher.Dispatch(this, ActionNames.Details, viewModel);
		}

		public ActionResult Edit(int id, string ret = null)
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new EditPresenter(GetAuthenticatedUserName());
				ActionInfo returnAction = ActionDispatcher.TryGetActionInfo(ret);
				viewModel = presenter.Show(id, returnAction);
			}

			return ActionDispatcher.Dispatch(this, ActionNames.Edit, viewModel);
		}

		[HttpPost]
		public ActionResult Edit(int id, EditViewModel viewModel, string ret = null)
		{
			var presenter = new EditPresenter(GetAuthenticatedUserName());
			viewModel.ReturnAction = ActionDispatcher.TryGetActionInfo(ret);
			object viewModel2 = presenter.Save(viewModel);

			return ActionDispatcher.Dispatch(this, ActionNames.Edit, viewModel2);
		}

		public ActionResult Logout()
		{
			if (!TempData.TryGetValue(ActionDispatcher.TempDataKey, out object viewModel))
			{
				var presenter = new LoginPresenter();
				viewModel = presenter.Logout();
			}

			SetAuthenticatedUserName(null);

			return ActionDispatcher.Dispatch(this, ActionNames.Logout, viewModel);
		}
	}
}