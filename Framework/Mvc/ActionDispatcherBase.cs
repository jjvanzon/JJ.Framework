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
    [PublicAPI]
    public abstract class ActionDispatcherBase
    {
        public static string TempDataKey { get; } = "vm-b5b9-20e1e86a12d8";

        public ActionDispatcherBase()
            => _viewModelTypeToActionTupleDictionary = DispatchTuples
                   .ToDictionary(
                       x => x.viewModelType,
                       x => (x.controllerName, x.httpGetActionName, x.viewName));

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

                foreach (string message in GetValidationMesssages(viewModel))
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
        protected abstract IList<string> GetValidationMesssages(object viewModel);
    }
}