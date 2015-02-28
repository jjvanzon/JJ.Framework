using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JJ.Framework.Presentation.Mvc
{
    /// <summary>
    /// Used for mapping view models to MVC actions,
    /// so we can dynamically redirect a view model to a controller action
    /// </summary>
    public static class ActionDispatcher
    {
        // No locking. For now you must not change the mappings after one-time initialization.
        private static IDictionary<Type, IList<ActionDispatcherMapping>> _mappings = new Dictionary<Type, IList<ActionDispatcherMapping>>();

        /// <summary>Not thread-safe.</summary>
        /// <param name="controllerName">nullable</param>
        /// <param name="actionName">nullable</param>
        /// <param name="viewName"></param>
        /// <param name="predicate">nullable</param>
        /// <param name="getValidationMesssagesDelegate">nullable</param>
        /// <param name="getActionParametersDelegate">nullable</param>
        public static void Map<TViewModel>(
            string controllerName, string actionName, string viewName,
            Func<TViewModel, object> getActionParametersDelegate = null,
            Func<TViewModel, ICollection<KeyValuePair<string, string>>> getValidationMesssagesDelegate = null)
        {
            Map(null, controllerName, actionName, viewName, getActionParametersDelegate, getValidationMesssagesDelegate);
        }

        /// <summary>Not thread-safe.</summary>
        /// <param name="controllerName">nullable</param>
        /// <param name="actionName">nullable</param>
        /// <param name="viewName"></param>
        /// <param name="predicate">nullable</param>
        /// <param name="getValidationMesssagesDelegate">nullable</param>
        /// <param name="getActionParametersDelegate">nullable</param>
        public static void Map<TViewModel>(
            Func<TViewModel, bool> predicate,
            string controllerName, string actionName, string viewName,
            Func<TViewModel, object> getActionParametersDelegate = null,
            Func<TViewModel, ICollection<KeyValuePair<string, string>>> getValidationMesssagesDelegate = null)
        {
            if (String.IsNullOrEmpty(viewName)) throw new Exception("viewName cannot be null or empty.");

            IList<ActionDispatcherMapping> mappings;
            if (!_mappings.TryGetValue(typeof(TViewModel), out mappings))
            {
                mappings = new List<ActionDispatcherMapping>();
                _mappings.Add(typeof(TViewModel), mappings);
            }

            // It was a choice between ugly delegates, covariance or double invokations.
            // Covariance did not work. I went with double invokations. 
            Func<object, bool> predicate2 = null;
            if (predicate != null)
            {
                predicate2 = x => predicate((TViewModel)x);
            }

            Func<object, ICollection<KeyValuePair<string, string>>> getValidationMesssagesDelegate2 = null;
            if (getValidationMesssagesDelegate != null)
            {
                getValidationMesssagesDelegate2 = x => getValidationMesssagesDelegate((TViewModel)x);
            }

            Func<object, object> getActionParametersDelegate2 = null;
            if (getActionParametersDelegate != null)
            {
                getActionParametersDelegate2 = x => getActionParametersDelegate((TViewModel)x);
            }

            var mapping = new ActionDispatcherMapping(
                controllerName,
                actionName,
                viewName,
                getActionParametersDelegate2,
                getValidationMesssagesDelegate2,
                predicate2);

            mappings.Add(mapping);
        }

        public static ActionResult DispatchAction(Controller sourceController, string sourceActionName, object viewModel)
        {
            if (sourceController == null) throw new NullException(() => sourceController);
            if (String.IsNullOrEmpty(sourceActionName)) throw new Exception("sourceActionName cannot be null or empty.");
            if (viewModel == null) throw new NullException(() => viewModel);

            var sourceControllerAccessor = new ControllerAccessor(sourceController);

            ActionDispatcherMapping destMapping = GetMapping(viewModel);

            string sourceControllerName = GetControllerName(sourceController);

            bool hasActionName = !String.IsNullOrEmpty(destMapping.ActionName);
            if (!hasActionName)
            {
                return sourceControllerAccessor.View(destMapping.ViewName, viewModel);
            }

            bool isSameControllerAndAction = String.Equals(destMapping.ControllerName, sourceControllerName) &&
                                             String.Equals(destMapping.ActionName, sourceActionName);

            bool mustReturnView = isSameControllerAndAction;

            if (mustReturnView)
            {
                if (destMapping.GetValidationMesssagesDelegate != null)
                {
                    sourceController.ModelState.ClearModelErrors();
                    foreach (var validationMessage in destMapping.GetValidationMesssagesDelegate(viewModel))
                    {
                        sourceController.ModelState.AddModelError(validationMessage.Key, validationMessage.Value);
                    }
                }

                return sourceControllerAccessor.View(destMapping.ViewName, viewModel);
            }
            else
            {
                sourceController.TempData[TempDataKeys.ViewModel] = viewModel;

                if (destMapping.GetActionParametersDelegate == null)
                {
                    return sourceControllerAccessor.RedirectToAction(destMapping.ActionName, destMapping.ControllerName);
                }
                else
                {
                    return sourceControllerAccessor.RedirectToAction(destMapping.ActionName, destMapping.ControllerName, destMapping.GetActionParametersDelegate(viewModel));
                }
            }
        }

        private static ActionDispatcherMapping GetMapping(object viewModel)
        {
            IList<ActionDispatcherMapping> mappings;
            if (!_mappings.TryGetValue(viewModel.GetType(), out mappings))
            {
                throw new Exception(String.Format("No mapping found for viewModel of type '{0}'. Call Map() upon program initialization to map view model types to their controllers, actions and views.", viewModel.GetType().FullName));
            }

            if (mappings.Count == 1)
            {
                return mappings[0];
            }
            else
            {
                IList<ActionDispatcherMapping> mappings2 = mappings.Where(x => x.Predicate(viewModel)).ToArray();
                switch (mappings2.Count)
                {
                    case 1:
                        return mappings2[0];

                    case 0:
                        throw new Exception(String.Format("viewModel of type '{0}' has multiple mappings and the predicate results in 0 mappings.", viewModel.GetType().FullName));

                    default:
                        throw new Exception(String.Format("viewModel of type '{0}' has multiple mappings and the predicate results in multiple mappings.", viewModel.GetType().FullName));
                }
            }
        }

        private static string GetControllerName(Controller sourceController)
        {
            string controllerName = (string)sourceController.ControllerContext.RequestContext.RouteData.Values["controller"];
            return controllerName;
        }
    }
}
