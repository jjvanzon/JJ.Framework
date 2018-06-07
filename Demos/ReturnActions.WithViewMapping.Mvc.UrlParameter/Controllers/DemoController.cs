using System.Web.Mvc;
using JJ.Demos.ReturnActions.Mvc.Controllers;
using JJ.Demos.ReturnActions.WithViewMapping.Presenters;
using JJ.Demos.ReturnActions.WithViewMapping.ViewModels;
using JJ.Framework.Presentation;
using ActionDispatcher = JJ.Framework.Mvc.ActionDispatcher;
// ReSharper disable InvertIf
// ReSharper disable AccessToStaticMemberViaDerivedType

namespace JJ.Demos.ReturnActions.WithViewMapping.Mvc.UrlParameter.Controllers
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
				ActionInfo returnAction = ActionDispatcher.TryGetActionInfo(ret);
				viewModel = presenter.Show(id, returnAction);
			}

			return ActionDispatcher.Dispatch(this, viewModel);
		}

		[HttpPost]
		public ActionResult Edit(int id, EditViewModel viewModel, string ret = null)
		{
			var presenter = new EditPresenter(GetAuthenticatedUserName());
			viewModel.ReturnAction = ActionDispatcher.TryGetActionInfo(ret);
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
	}
}