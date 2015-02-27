using JJ.Demos.ReturnActions.MvcPostData.Names;
using JJ.Demos.ReturnActions.ViewModels;
using JJ.Framework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJ.Demos.ReturnActions.MvcPostData.Controllers
{
    public class MasterController : Controller
    {
        protected string GetAuthenticatedUserName()
        {
            return (string)Session[SessionKeys.AuthenticatedUserName];
        }

        protected void SetAuthenticatedUserName(string value)
        {
            Session[SessionKeys.AuthenticatedUserName] = value;
        }

        protected ActionResult GetActionResult(string sourceActionName, object viewModel)
        {
            var editViewModel = viewModel as EditViewModel;
            if (editViewModel != null)
            {
                bool isSameControllerAndAction = String.Equals(GetControllerName(), ControllerNames.Demo) &&
                                                 String.Equals(sourceActionName, ActionNames.Edit);

                bool mustReturnView = isSameControllerAndAction;
                if (mustReturnView)
                {
                    return View(ViewNames.Edit, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(ActionNames.Edit, ControllerNames.Demo, new { id = editViewModel.Entity.ID });
                }
            }

            var detailsViewModel = viewModel as DetailsViewModel;
            if (detailsViewModel != null)
            {
                bool isSameControllerAndAction = String.Equals(GetControllerName(), ControllerNames.Demo) &&
                                                 String.Equals(sourceActionName, ActionNames.Details);

                bool mustReturnView = isSameControllerAndAction;

                if (mustReturnView)
                {
                    return View(ViewNames.Details, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(ActionNames.Details, ControllerNames.Demo, new { id = detailsViewModel.Entity.ID });
                }
            }

            var listViewModel = viewModel as ListViewModel;
            if (listViewModel != null)
            {
                bool isSameControllerAndAction = String.Equals(GetControllerName(), ControllerNames.Demo) &&
                                                 String.Equals(sourceActionName, ActionNames.Index);

                bool mustReturnView = isSameControllerAndAction;

                if (mustReturnView)
                {
                    return View(ViewNames.Index, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(ActionNames.Index, ControllerNames.Demo);
                }
            }

            var loginViewModel = viewModel as LoginViewModel;
            if (loginViewModel != null)
            {
                bool isSameControllerAndAction = String.Equals(GetControllerName(), ControllerNames.Login) &&
                                                 String.Equals(sourceActionName, ActionNames.Index);

                bool mustReturnView = isSameControllerAndAction;

                if (mustReturnView)
                {
                    return View(ViewNames.Index, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(ActionNames.Index, ControllerNames.Login);
                }
            }

            var notAuthorizedViewModel = viewModel as NotAuthorizedViewModel;
            if (notAuthorizedViewModel != null)
            {
                return View(ViewNames.NotAuthorized, notAuthorizedViewModel);
            }

            throw new UnexpectedViewModelTypeException(viewModel);
        }

        private string GetControllerName()
        {
            string controllerName = (string)ControllerContext.RequestContext.RouteData.Values["controller"];
            return controllerName;
        }
    }
}