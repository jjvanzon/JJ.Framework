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
            if (String.IsNullOrEmpty(viewName)) throw new NullOrEmptyException(() => viewName);

            ViewName = viewName;
        }

        /// <summary> nullable </summary>
        protected virtual object GetRouteValues(TViewModel viewModel)
        {
            return null;
        }

        /// <summary> not nullable </summary>
        protected virtual ICollection<KeyValuePair<string, string>> GetValidationMesssages(TViewModel viewModel)
        {
            return new KeyValuePair<string, string>[0];
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

        // IViewMapping

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

        Type IViewMapping.ViewModelType
        {
            get { return typeof(TViewModel); }
        }
    }
}