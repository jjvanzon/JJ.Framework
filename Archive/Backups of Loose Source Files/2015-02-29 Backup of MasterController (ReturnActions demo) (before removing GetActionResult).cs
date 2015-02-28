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
            string sourceControllerName = GetControllerName();

            var editViewModel = viewModel as EditViewModel;
            if (editViewModel != null)
            {
                string destControllerName = ControllerNames.Demo;
                string destActionName = ActionNames.Edit;
                string destViewName = ViewNames.Edit;

                bool isSameControllerAndAction = String.Equals(sourceControllerName, destControllerName) &&
                                                 String.Equals(sourceActionName, destActionName);

                bool mustReturnView = isSameControllerAndAction;
                if (mustReturnView)
                {
                    return View(destViewName, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(destActionName, destControllerName, new { id = editViewModel.Entity.ID });
                }
            }

            var detailsViewModel = viewModel as DetailsViewModel;
            if (detailsViewModel != null)
            {
                string destControllerName = ControllerNames.Demo;
                string destActionName = ActionNames.Details;
                string destViewName = ViewNames.Details;

                bool isSameControllerAndAction = String.Equals(sourceControllerName, destControllerName) &&
                                                 String.Equals(sourceActionName, destActionName);

                bool mustReturnView = isSameControllerAndAction;

                if (mustReturnView)
                {
                    return View(destViewName, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(destActionName, destControllerName, new { id = detailsViewModel.Entity.ID });
                }
            }

            var listViewModel = viewModel as ListViewModel;
            if (listViewModel != null)
            {
                string destControllerName = ControllerNames.Demo;
                string destActionName = ActionNames.Index;
                string destViewName = ViewNames.Index;

                bool isSameControllerAndAction = String.Equals(sourceControllerName, destControllerName) &&
                                                 String.Equals(sourceActionName, destActionName);

                bool mustReturnView = isSameControllerAndAction;

                if (mustReturnView)
                {
                    return View(destViewName, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(destActionName, destControllerName);
                }
            }

            var loginViewModel = viewModel as LoginViewModel;
            if (loginViewModel != null)
            {
                string destControllerName = ControllerNames.Login;
                string destActionName = ActionNames.Index;
                string destViewName = ViewNames.Index;

                bool isSameControllerAndAction = String.Equals(sourceControllerName, destControllerName) &&
                                                 String.Equals(sourceActionName, destActionName);

                bool mustReturnView = isSameControllerAndAction;

                if (mustReturnView)
                {
                    return View(destViewName, viewModel);
                }
                else
                {
                    TempData[TempDataKeys.ViewModel] = viewModel;
                    return RedirectToAction(destActionName, destControllerName);
                }
            }

            var notAuthorizedViewModel = viewModel as NotAuthorizedViewModel;
            if (notAuthorizedViewModel != null)
            {
                string destControllerName = null;
                string destActionName = null;
                string destViewName = ViewNames.NotAuthorized;

                return View(destViewName, notAuthorizedViewModel);
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