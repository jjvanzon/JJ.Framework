using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Exceptions.Comparative;

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Mvc
{
    /// <summary>
    /// Used for consistent, easier handling of redirection to either View() or RedirectToAction().
    /// In some cases the bureaucracy of that in MVC can be replaced
    /// by simple ActionDispatcher calls at the end of your controller action methods.
    /// 
    /// Make your own class ActionDispatcher, which derives from ActionDispatcherBase.
    /// 
    /// You can call ActionDispatcher.Dispatch() at the end of your Controller action, and pass it the viewModel.
    /// The ActionDispatcher will determine the ActionResult to return.
    ///
    /// For your ActionDispatcher to know which ActionResult to return, you would override
    /// the property DispatchTuples to return tuples of
    /// view model type, controller name, HTTP-get action name, view name.
    /// 
    /// You can also return the route values to use for each view model, by overriding the method
    /// TryGetRouteValues(object viewModel). There you could switch on the view model's type
    /// to determine the route values to return.
    ///
    /// Do note that you can not specify multiple MVC actions for the same ViewModel type.
    /// You would have to solve that differently,
    /// for instance by making due with the same MVC action for a single view model type,
    /// or fake it by making two view models, that look the same.
    /// </summary>
    [PublicAPI]
    public abstract class ActionDispatcherBase
    {
        public static string TempDataKey { get; } = "vm-b5b9-20e1e86a12d8";

        public ActionDispatcherBase()
            => _viewModelTypeToActionTupleDictionary = DispatchTuples
                   .ToDictionary(
                       x => x.viewModelType,
                       x => (x.controllerName, x.httpGetActionName, x.viewName));

        /// <summary> httpGetActionName is optional </summary>
        protected abstract IList<(Type viewModelType, string controllerName, string httpGetActionName, string viewName)> DispatchTuples { get; }

        private readonly Dictionary<Type, (string controllerName, string httpGetActionName, string viewName)>
            _viewModelTypeToActionTupleDictionary;

        public ActionResult Dispatch(Controller sourceController, object viewModel, [CallerMemberName] string sourceActionName = "")
        {
            if (sourceController == null) throw new NullException(() => sourceController);
            if (string.IsNullOrEmpty(sourceActionName)) throw new NullOrEmptyException(() => sourceActionName);
            if (viewModel == null) throw new NullException(() => viewModel);

            Type viewModelType = viewModel.GetType();

            if (!_viewModelTypeToActionTupleDictionary.TryGetValue(viewModelType, out (string, string, string) tuple))
            {
                throw new NotContainsException(nameof(_viewModelTypeToActionTupleDictionary), () => viewModelType);
            }

            (string destControllerName, string destHttpGetActionName, string destViewName) = tuple;

            var sourceControllerAccessor = new ControllerAccessor(sourceController);
            string sourceControllerName = sourceController.GetControllerName();

            bool hasActionName = !string.IsNullOrEmpty(destHttpGetActionName);

            if (!hasActionName)
            {
                return sourceControllerAccessor.View(destViewName, viewModel);
            }

            bool isSameControllerAndAction = string.Equals(destControllerName, sourceControllerName) &&
                                             string.Equals(destHttpGetActionName, sourceActionName);

            bool mustReturnView = isSameControllerAndAction;

            if (mustReturnView)
            {
                sourceController.ModelState.ClearModelErrors();

                foreach (string message in GetValidationMessages(viewModel))
                {
                    sourceController.ModelState.AddModelError(nameof(message), message);
                }

                return sourceControllerAccessor.View(destViewName, viewModel);
            }

            sourceController.TempData[TempDataKey] = viewModel;

            object parameters = TryGetRouteValues(viewModel);

            return sourceControllerAccessor.RedirectToAction(destHttpGetActionName, destControllerName, parameters);
        }

        protected abstract object TryGetRouteValues(object viewModel);
        protected abstract IList<string> GetValidationMessages(object viewModel);
    }
}