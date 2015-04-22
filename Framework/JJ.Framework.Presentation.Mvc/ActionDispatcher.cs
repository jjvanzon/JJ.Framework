using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using JJ.Framework.Web;

namespace JJ.Framework.Presentation.Mvc
{
    /// <summary>
    /// Used for mapping view models to MVC actions,
    /// so we can dynamically redirect a view model to a controller action.
    /// </summary>
    public static class ActionDispatcher
    {
        /// <summary>
        /// Just for checking if the assembly was already registerd, so we can generate a meaningful exception message.
        /// No locking. For now you must not change the mappings after one-time initialization. 
        /// </summary>
        private static HashSet<Assembly> _registeredAssemblies = new HashSet<Assembly>();

        /// <summary>
        /// The key is the view model type.
        /// No locking. For now you must not change the mappings after one-time initialization. 
        /// </summary>
        private static Dictionary<Type, IList<IViewMapping>> _mappings = new Dictionary<Type, IList<IViewMapping>>();

        /// <summary>
        /// Call this method to add all ViewMapping implementations of an assembly to the dispatcher.
        /// Only call this method upon initialization, because it is not thread-safe.
        /// </summary>
        public static void RegisterAssembly(Assembly assembly)
        {
            if (assembly == null) throw new NullException(() => assembly);

            if (_registeredAssemblies.Contains(assembly))
            {
                throw new Exception(String.Format("Assembly '{0}' was already registered.", assembly.FullName));
            }

            IList<Type> types = ReflectionHelper.GetImplementations<IViewMapping>(assembly);
            foreach (Type type in types)
            {
                RegisterViewMapping(type);
            }
        }

        private static void RegisterViewMapping(Type viewMappingType)
        {
            IViewMapping mapping = (IViewMapping)Activator.CreateInstance(viewMappingType);
            Type viewModelType = mapping.ViewModelType;

            IList<IViewMapping> mappings;
            if (!_mappings.TryGetValue(viewModelType, out mappings))
            {
                mappings = new List<IViewMapping>();
                _mappings.Add(viewModelType, mappings);
            }
            
            mappings.Add(mapping);
        }

        private static string _tempDataKey ="vm-b5b9-20e1e86a12d8";

        public static string TempDataKey { get { return _tempDataKey; } }

        public static ActionResult Dispatch(Controller sourceController, string sourceActionName, object viewModel)
        {
            if (sourceController == null) throw new NullException(() => sourceController);
            if (String.IsNullOrEmpty(sourceActionName)) throw new NullOrEmptyException(() => sourceActionName);
            if (viewModel == null) throw new NullException(() => viewModel);

            IViewMapping destMapping = GetViewMapping(viewModel);
            ControllerAccessor sourceControllerAccessor = new ControllerAccessor(sourceController);
            string sourceControllerName = GetControllerName(sourceController);

            bool hasActionName = !String.IsNullOrEmpty(destMapping.ControllerGetActionName);
            if (!hasActionName)
            {
                return sourceControllerAccessor.View(destMapping.ViewName, viewModel);
            }

            bool isSameControllerAndAction = String.Equals(destMapping.ControllerName, sourceControllerName) &&
                                             String.Equals(destMapping.ControllerGetActionName, sourceActionName);

            bool mustReturnView = isSameControllerAndAction;
            if (mustReturnView)
            {
                sourceController.ModelState.ClearModelErrors();
                foreach (var validationMessage in destMapping.GetValidationMesssages(viewModel))
                {
                    sourceController.ModelState.AddModelError(validationMessage.Key, validationMessage.Value);
                }

                return sourceControllerAccessor.View(destMapping.ViewName, viewModel);
            }
            else
            {
                sourceController.TempData[TempDataKey] = viewModel;

                object parameters = destMapping.GetRouteValues(viewModel);
                return sourceControllerAccessor.RedirectToAction(destMapping.ControllerGetActionName, destMapping.ControllerName, parameters);
            }
        }

        private static IViewMapping GetViewMapping(object viewModel)
        {
            IList<IViewMapping> mappings;
            if (!_mappings.TryGetValue(viewModel.GetType(), out mappings))
            {
                throw new Exception(String.Format(
                    "No mapping found for viewModel of type '{0}'. " + 
                    "Program an implementation of ViewMapping<TViewModel> to map view model types to their controllers, " + 
                    "actions, views and presenters. " + 
                    "Then call ActionDispatcher.RegisterAssembly passing along the assembly that contains your ViewMapping implementations. " +
                    "Only call RegisterAssembly upon program initialization, because it is not thread-safe.", viewModel.GetType().FullName));
            }

            if (mappings.Count == 1)
            {
                return mappings[0];
            }
            else
            {
                IList<IViewMapping> mappings2 = mappings.Where(x => x.Predicate(viewModel)).ToArray();
                switch (mappings2.Count)
                {
                    case 1:
                        return mappings2[0];

                    case 0:
                        throw new Exception(String.Format(
                            "viewModel of type '{0}' has multiple mappings and applying the predicate results in 0 mappings.", viewModel.GetType().FullName));

                    default:
                        throw new Exception(String.Format(
                            "viewModel of type '{0}' has multiple mappings and applying the predicate results in multiple mappings.", viewModel.GetType().FullName));
                }
            }
        }

        private static string GetControllerName(Controller sourceController)
        {
            string controllerName = (string)sourceController.ControllerContext.RequestContext.RouteData.Values["controller"];
            return controllerName;
        }

        public static ActionInfo GetReturnAction(string ret)
        {
            ActionInfo actionInfo = UrlHelpers.GetReturnAction(ret);

            throw new NotImplementedException();
        }
    }
}
