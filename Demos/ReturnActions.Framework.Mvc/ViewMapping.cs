using System;
using System.Collections.Generic;
using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Framework.Exceptions.Basic;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global

namespace JJ.Demos.ReturnActions.Framework.Mvc
{
    public abstract class ViewMapping<TViewModel> : IViewMapping
    {
        public string PresenterName { get; protected set; }
        public string PresenterActionName { get; protected set; }
        public string ControllerName { get; protected set; }
        public string ControllerGetActionName { get; protected set; }
        public string ViewName { get; protected set; }

        public IList<ActionParameterMapping> ParameterMappings { get; } = new List<ActionParameterMapping>();

        /// <summary> nullable, base method does nothing </summary>
        protected virtual object TryGetRouteValues(TViewModel viewModel) => null;

        /// <summary> not nullable </summary>
        protected virtual ICollection<string> GetValidationMessages(TViewModel viewModel) => new string[0];

        protected virtual bool Predicate(TViewModel viewModel) => true;

        /// <summary>
        ///     Takes presenter action info and converts it to an MVC url.
        /// </summary>
        protected string TryGetReturnUrl(ActionInfo actionInfo)
        {
            if (actionInfo == null)
            {
                return null;
            }

            return ActionDispatcher.GetUrl(actionInfo);
        }

        /// <summary>
        ///     Syntactic sugar for assigning PresenterName and PresenterActionName.
        /// </summary>
        protected void MapPresenter(string presenterName, string presenterActionName)
        {
            if (string.IsNullOrEmpty(presenterName)) throw new NullOrEmptyException(() => presenterName);
            if (string.IsNullOrEmpty(presenterActionName)) throw new NullOrEmptyException(() => presenterActionName);

            PresenterName = presenterName;
            PresenterActionName = presenterActionName;
        }

        /// <summary>
        ///     Syntactic sugar for assigning ControllerName, ControllerGetActionName and ViewName.
        /// </summary>
        protected void MapController(string controllerName, string controllerGetActionName, string viewName)
        {
            if (string.IsNullOrEmpty(controllerName)) throw new NullOrEmptyException(() => controllerName);
            if (string.IsNullOrEmpty(controllerGetActionName))
                throw new NullOrEmptyException(() => controllerGetActionName);
            if (string.IsNullOrEmpty(viewName)) throw new NullOrEmptyException(() => viewName);

            ControllerName = controllerName;
            ControllerGetActionName = controllerGetActionName;
            ViewName = viewName;
        }

        /// <summary>
        ///     Syntactic sugar for assigning ControllerName and ViewName.
        /// </summary>
        protected void MapController(string controllerName, string viewName)
        {
            if (string.IsNullOrEmpty(viewName)) throw new NullOrEmptyException(() => viewName);

            ControllerName = controllerName;
            ViewName = viewName;
        }

        protected void MapParameter(string presenterActionParameter, string controllerActionParameter) => ParameterMappings.Add(new ActionParameterMapping(presenterActionParameter, controllerActionParameter));

        // IViewMapping

        string IViewMapping.ViewName => ViewName;
        string IViewMapping.PresenterName => PresenterName;
        string IViewMapping.PresenterActionName => PresenterActionName;
        string IViewMapping.ControllerName => ControllerName;
        string IViewMapping.ControllerGetActionName => ControllerGetActionName;
        object IViewMapping.TryGetRouteValues(object viewModel) => TryGetRouteValues((TViewModel)viewModel);
        bool IViewMapping.Predicate(object viewModel) => Predicate((TViewModel)viewModel);
        Type IViewMapping.ViewModelType => typeof(TViewModel);

        ICollection<string> IViewMapping.GetValidationMessages(object viewModel)
            => GetValidationMessages((TViewModel)viewModel);
    }
}