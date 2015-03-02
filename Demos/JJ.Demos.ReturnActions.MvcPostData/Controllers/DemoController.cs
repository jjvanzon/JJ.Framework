using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Demos.ReturnActions.Presenters;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostData.Controllers
{
    public class DemoController : MasterController
    {
        public ActionResult Index()
        {
            object viewModel;
            if (!TempData.TryGetValue(ActionDispatcher.VIEW_MODEL_TEMP_DATA_KEY, out viewModel))
            {
                var presenter = new ListPresenter();
                viewModel = presenter.Show();
            }

            return ActionDispatcher.DispatchAction(this, ActionNames.Index, viewModel);
        }

        public ActionResult Details(int id)
        {
            object viewModel;
            if (!TempData.TryGetValue(ActionDispatcher.VIEW_MODEL_TEMP_DATA_KEY, out viewModel))
            {
                var presenter = new DetailsPresenter();
                viewModel = presenter.Show(id);
            }

            return ActionDispatcher.DispatchAction(this, ActionNames.Details, viewModel);
        }

        public ActionResult Edit(int id)
        {
            object viewModel;
            if (!TempData.TryGetValue(ActionDispatcher.VIEW_MODEL_TEMP_DATA_KEY, out viewModel))
            {
                var presenter = new EditPresenter(GetAuthenticatedUserName());
                viewModel = presenter.Show(id);
            }

            return ActionDispatcher.DispatchAction(this, ActionNames.Edit, viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, EditViewModel viewModel)
        {
            var presenter = new EditPresenter(GetAuthenticatedUserName());
            object viewModel2 = presenter.Save(viewModel);

            return ActionDispatcher.DispatchAction(this, ActionNames.Edit, viewModel2);
        }

        public ActionResult Logout()
        {
            object viewModel;
            if (!TempData.TryGetValue(ActionDispatcher.VIEW_MODEL_TEMP_DATA_KEY, out viewModel))
            {
                var presenter = new LoginPresenter();
                viewModel = presenter.Logout();
            }

            SetAuthenticatedUserName(null);

            return ActionDispatcher.DispatchAction(this, ActionNames.Logout, viewModel);
        }

        // These methods are hacks necessary to make multi-level return actions
        // work when you put the return action information in the post data
        // as explained in README.TXT.

        public ActionResult EditFromIndex(int id)
        {
            object viewModel;
            if (!TempData.TryGetValue(ActionDispatcher.VIEW_MODEL_TEMP_DATA_KEY, out viewModel))
            {
                var presenter = new ListPresenter();
                viewModel = presenter.Edit(id, GetAuthenticatedUserName());
            }

            return ActionDispatcher.DispatchAction(this, ActionNames.Edit, viewModel);
        }

        [HttpPost]
        public ActionResult EditFromIndex(int id, EditViewModel viewModel)
        {
            var presenter = new EditPresenter(GetAuthenticatedUserName());
            object viewModel2 = presenter.Save(viewModel);
            return ActionDispatcher.DispatchAction(this, ActionNames.Edit, viewModel2);
        }

        public ActionResult EditFromDetails(int id)
        {
            object viewModel;
            if (!TempData.TryGetValue(ActionDispatcher.VIEW_MODEL_TEMP_DATA_KEY, out viewModel))
            {
                var presenter = new DetailsPresenter();
                viewModel = presenter.Edit(id, GetAuthenticatedUserName());
            }

            return ActionDispatcher.DispatchAction(this, ActionNames.Edit, viewModel);
        }

        [HttpPost]
        public ActionResult EditFromDetails(int id, EditViewModel viewModel)
        {
            var presenter = new EditPresenter(GetAuthenticatedUserName());
            object viewModel2 = presenter.Save(viewModel);
            return ActionDispatcher.DispatchAction(this, ActionNames.Edit, viewModel2);
        }
    }
}