using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Mvc
{
    public abstract class ViewMapping<TViewModel> : IViewMapping
    {
        public string ViewName { get; private set; }
        public string PresenterName { get; protected set; }
        public string PresenterActionName { get; protected set; }
        public string ControllerName { get; protected set; }
        public string ControllerGetActionName { get; protected set; }

        public ViewMapping(string viewName)
        {
            if (!String.IsNullOrEmpty(viewName)) throw new Exception("viewName cannot be null or empty.");

            ViewName = viewName;
        }

        protected virtual object GetRouteValues(TViewModel viewModel)
        {
            return null;
        }

        protected virtual ICollection<KeyValuePair<string, string>> GetValidationMesssages(TViewModel viewModel)
        {
            return null;
        }

        protected virtual bool Predicate(TViewModel viewModel)
        {
            return true;
        }

        protected string GetReturnUrl(ActionInfo actionInfo)
        {
            // TODO: Map presenter names to controller names
            return UrlHelpers.GetReturnUrl(actionInfo);
        }

        // IActionMapping

        string IViewMapping.ViewName
        {
            get { return ViewName; }
        }

        string IViewMapping.PresenterName
        {
            get { return PresenterName; }
        }

        string IViewMapping.PresenterActionName
        {
            get { return PresenterActionName; }
        }

        string IViewMapping.ControllerName
        {
            get { return ControllerName; }
        }

        string IViewMapping.ControllerGetActionName
        {
            get { return ControllerGetActionName; }
        }

        object IViewMapping.GetRouteValues(object viewModel)
        {
            return GetRouteValues((TViewModel)viewModel);
        }

        ICollection<KeyValuePair<string, string>> IViewMapping.GetValidationMesssages(object viewModel)
        {
            return GetValidationMesssages((TViewModel)viewModel);
        }

        bool IViewMapping.Predicate(object viewModel)
        {
            return Predicate((TViewModel)viewModel);
        }
    }
}