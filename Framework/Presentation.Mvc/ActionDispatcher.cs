﻿using JJ.Framework.Exceptions;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using JJ.Framework.Web;
using System.Web;
using JJ.Framework.Common;

namespace JJ.Framework.Presentation.Mvc
{
    /// <summary>
    /// Used for mapping view models to MVC actions, so we can dynamically redirect a view model to a controller action.
    /// </summary>
    public static class ActionDispatcher
    {
        // Dictionaries

        /// <summary>
        /// Just for checking if the assembly was already registerd, so we can generate a meaningful exception message.
        /// No locking. You must not change the mappings after one-time initialization. 
        /// </summary>
        private static HashSet<Assembly> _registeredAssemblies = new HashSet<Assembly>();

        /// <summary>
        /// No locking. You must not change the mappings after one-time initialization. 
        /// </summary>
        private static Dictionary<Type, IList<IViewMapping>> _mappingsByViewModelType = new Dictionary<Type, IList<IViewMapping>>();

        /// <summary>
        /// No locking. You must not change the mappings after one-time initialization. 
        /// </summary>
        private static Dictionary<string, IList<IViewMapping>> _mappingsByControllerActionKey = new Dictionary<string, IList<IViewMapping>>();

        /// <summary>
        /// No locking. You must not change the mappings after one-time initialization. 
        /// </summary>
        private static Dictionary<string, IList<IViewMapping>> _mappingsByPresenterActionKey = new Dictionary<string, IList<IViewMapping>>();

        // Registration

        /// <summary>
        /// Call this method to add all IViewMapping implementations of an assembly to the dispatcher.
        /// Only call this method upon initialization, because it is not thread-safe.
        /// </summary>
        public static void RegisterAssembly(Assembly assembly)
        {
            if (assembly == null) throw new NullException(() => assembly);

            if (_registeredAssemblies.Contains(assembly))
            {
                throw new Exception(String.Format("Assembly '{0}' was already registered in the ActionDispatcher.", assembly.FullName));
            }

            IList<Type> types = ReflectionHelper.GetImplementations<IViewMapping>(assembly);
            IList<IViewMapping> viewMappings = types.Select(x => (IViewMapping)Activator.CreateInstance(x)).ToArray();
            _mappingsByViewModelType = viewMappings.ToNonUniqueDictionary(x => x.ViewModelType);
            _mappingsByControllerActionKey = viewMappings.ToNonUniqueDictionary(x => GetActionKey(x.ControllerName, x.ControllerGetActionName));
            _mappingsByPresenterActionKey = viewMappings.ToNonUniqueDictionary(x => GetActionKey(x.PresenterName, x.PresenterActionName));
        }

        // Dispatch

        private static string _tempDataKey = "vm-b5b9-20e1e86a12d8";
        public static string TempDataKey { get { return _tempDataKey; } }

        public static ActionResult Dispatch(Controller sourceController, string sourceActionName, object viewModel)
        {
            if (sourceController == null) throw new NullException(() => sourceController);
            if (String.IsNullOrEmpty(sourceActionName)) throw new NullOrEmptyException(() => sourceActionName);
            if (viewModel == null) throw new NullException(() => viewModel);

            IViewMapping destMapping = GetViewMappingByViewModel(viewModel);

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

        private static IViewMapping GetViewMappingByViewModel(object viewModel)
        {
            IList<IViewMapping> mappings;
            if (!_mappingsByViewModelType.TryGetValue(viewModel.GetType(), out mappings))
            {
                throw new ViewMappingNotFoundException(viewModel.GetType().FullName);
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

        // GetActionInfo

        /// <summary>
        /// Converts the URL to an ActionInfo object,
        /// translating names out of the MVC layer to 
        /// names out of the Presenter layer using the ViewMappings.
        /// If the URL has a return URL (encoded in a URL parameter),
        /// the return URL is translated too and this is done recursively,
        /// because it can yet again have a return URL.
        /// </summary>
        public static ActionInfo TryGetActionInfo(string mvcUrl, string returnUrlParameterName = "ret")
        {
            if (String.IsNullOrEmpty(returnUrlParameterName)) throw new NullOrEmptyException(() => returnUrlParameterName);

            if (String.IsNullOrEmpty(mvcUrl))
            {
                // There must be null-tollerance here, for brevity in calls to the ActionDispatcher.
                return null;
            }

            // The code line below will convert the URL to action info,
            // but it will still have the MVC-based names.
            ActionInfo controllerActionInfo = ActionInfoToUrlConverter.ConvertUrlToActionInfo(mvcUrl, returnUrlParameterName);

            ActionInfo presenterActionInfo = TranslateActionInfo_FromControllerToPresenter_Recursive(controllerActionInfo, mvcUrl);

            return presenterActionInfo;
        }

        /// <summary>
        /// Translate the MVC-level names in the action info to presenter-level names using ViewMappings. 
        /// If the actionInfo has a return action, the return action is translated too and this is done recursively.
        /// </summary>
        /// <param name="mvcUrl">for in exception messages only</param>
        private static ActionInfo TranslateActionInfo_FromControllerToPresenter_Recursive(ActionInfo controllerActionInfo, string mvcUrl)
        {
            ActionInfo presenterActionInfo = TranslateActionInfo_FromControllerToPresenter(controllerActionInfo, mvcUrl);

            if (controllerActionInfo.ReturnAction != null)
            {
                presenterActionInfo.ReturnAction = TranslateActionInfo_FromControllerToPresenter_Recursive(controllerActionInfo.ReturnAction, mvcUrl);
            }

            return presenterActionInfo;
        }

        /// <summary>
        /// Translate the MVC-level names in the action info to presenter-level names using ViewMappings. 
        /// </summary>
        /// <param name="mvcUrl">for in exception messages only</param>
        private static ActionInfo TranslateActionInfo_FromControllerToPresenter(ActionInfo controllerActionInfo, string mvcUrl)
        {
            IViewMapping viewMapping = GetViewMappingByControllerActionInfo(controllerActionInfo);

            var presenterActionInfo = new ActionInfo
            {
                PresenterName = viewMapping.PresenterName,
                ActionName = viewMapping.PresenterActionName,
                Parameters = new List<ActionParameterInfo>(controllerActionInfo.Parameters.Count)
            };

            // Map unnamed parameters to presenter action parameters
            // (e.g. in "Question/Details/1234" the third URL path element
            // is the first parameter.
            ActionParameterInfo[] unnamedControllerActionParameters = controllerActionInfo.Parameters.Where(x => String.IsNullOrEmpty(x.Name)).ToArray();
            for (int i = 0; i < unnamedControllerActionParameters.Length; i++)
            {
                ActionParameterInfo controllerParameterInfo = unnamedControllerActionParameters[i];
                ActionParameterMapping parameterMapping = viewMapping.ParameterMappings.ElementAtOrDefault(i);
                if (parameterMapping == null)
                {
                    throw new Exception(String.Format(
                        "Unnamed controller parameter [{0}] in URL '{1}' cannot be mapped to a presenter parameter. " +
                        "When a controller parameter can be used as a URL path element it must be mapped in the ViewMapping " +
                        "using the MapParameter method. The unnamed parameter will be mapped to a presenter parameter in the order " +
                        "in which you call MapParameter.", i, mvcUrl));
                }

                var presenterParameterInfo = new ActionParameterInfo
                {
                    Name = parameterMapping.PresenterParameterName,
                    Value = controllerParameterInfo.Value
                };
                presenterActionInfo.Parameters.Add(presenterParameterInfo);
            }

            ActionParameterInfo[] namedControllerActionParameter = controllerActionInfo.Parameters.Except(unnamedControllerActionParameters).ToArray();
            foreach (ActionParameterInfo controllerParameterInfo in namedControllerActionParameter)
            {
                ActionParameterMapping parameterMapping = viewMapping.ParameterMappings
                                                                     .Where(x => String.Equals(x.ControllerParameterName, controllerParameterInfo.Name))
                                                                     .SingleOrDefault();
                string presenterParameterName;
                if (parameterMapping == null)
                {
                    presenterParameterName = controllerParameterInfo.Name;
                }
                else
                {
                    presenterParameterName = parameterMapping.PresenterParameterName;
                }

                var presenterParameterInfo = new ActionParameterInfo
                {
                    Name = presenterParameterName,
                    Value = controllerParameterInfo.Value
                };
                presenterActionInfo.Parameters.Add(presenterParameterInfo);
            }

            return presenterActionInfo;
        }

        private static IViewMapping GetViewMappingByControllerActionInfo(ActionInfo controllerActionInfo)
        {
            // Keep working with a non-unique dictionary, even though you can only have one mapping per key,
            // otherwise a programmer gets to see an incomprehendable error message.
            string key = GetActionKey(controllerActionInfo.PresenterName, controllerActionInfo.ActionName);
            IList<IViewMapping> mappings;
            if (!_mappingsByControllerActionKey.TryGetValue(key, out mappings))
            {
                throw new ViewMappingNotFoundException(key);
            }

            switch (mappings.Count)
            {
                case 1:
                    return mappings[0];

                case 0:
                    throw new ViewMappingNotFoundException(key);

                default:
                    throw new Exception(String.Format("Controller action '{0}' has multiple mappings.", key));
            }
        }

        // GetUrl

        /// <summary>
        /// Takes presenter action info and converts it to an MVC url.
        /// If the ActionInfo has a return action that possibly also has a return action,
        /// return URL parameters are stacked up as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// </summary>
        public static string GetUrl(ActionInfo presenterActionInfo, string returnUrlParameterName = "ret")
        {
            if (presenterActionInfo == null) throw new NullException(() => presenterActionInfo);
            if (String.IsNullOrEmpty(returnUrlParameterName)) throw new NullOrEmptyException(() => returnUrlParameterName);

            ActionInfo controllerActionInfo = TranslateActionInfo_FromPresenterToController_Recursive(presenterActionInfo);

            string url = ActionInfoToUrlConverter.ConvertActionInfoToUrl(controllerActionInfo, returnUrlParameterName);
            return url;
        }

        /// <summary>
        /// Translate the MVC-level names in the action info to presenter-level names using ViewMappings. 
        /// If the actionInfo has a return action, the return action is translated too and this is done recursively.
        /// </summary>
        private static ActionInfo TranslateActionInfo_FromPresenterToController_Recursive(ActionInfo presenterActionInfo)
        {
            ActionInfo controllerActionInfo = TranslateActionInfo_FromPresenterToController(presenterActionInfo);

            if (presenterActionInfo.ReturnAction != null)
            {
                controllerActionInfo.ReturnAction = TranslateActionInfo_FromPresenterToController_Recursive(presenterActionInfo.ReturnAction);
            }

            return controllerActionInfo;
        }

        /// <summary>
        /// Translate the MVC-level names in the action info to presenter-level names using ViewMappings. 
        /// </summary>
        private static ActionInfo TranslateActionInfo_FromPresenterToController(ActionInfo presenterActionInfo)
        {
            IViewMapping viewMapping = GetViewMappingByPresenterActionInfo(presenterActionInfo);

            var controllerActionInfo = new ActionInfo
            {
                PresenterName = viewMapping.ControllerName,
                ActionName = viewMapping.ControllerGetActionName,
                Parameters = new List<ActionParameterInfo>()
            };

            foreach (ActionParameterInfo presenterParameterInfo in presenterActionInfo.Parameters)
            {
                ActionParameterMapping parameterMapping = viewMapping.ParameterMappings
                                                                     .Where(x => String.Equals(x.PresenterParameterName, presenterParameterInfo.Name))
                                                                     .SingleOrDefault();
                string controllerParameterName;
                if (parameterMapping == null)
                {
                    controllerParameterName = presenterParameterInfo.Name;
                }
                else
                {
                    controllerParameterName = parameterMapping.ControllerParameterName;
                }

                var controllerParameterInfo = new ActionParameterInfo
                {
                    Name = controllerParameterName,
                    Value = presenterParameterInfo.Value
                };

                controllerActionInfo.Parameters.Add(controllerParameterInfo);
            }

            return controllerActionInfo;
        }

        private static IViewMapping GetViewMappingByPresenterActionInfo(ActionInfo presenterActionInfo)
        {
            // Keep working with a non-unique dictionary, even though you can only have one mapping per key,
            // otherwise a programmer gets to see an incomprehendable error message.
            string key = GetActionKey(presenterActionInfo.PresenterName, presenterActionInfo.ActionName);
            IList<IViewMapping> mappings;
            if (!_mappingsByPresenterActionKey.TryGetValue(key, out mappings))
            {
                throw new ViewMappingNotFoundException(key);
            }

            switch (mappings.Count)
            {
                case 1:
                    return mappings[0];

                case 0:
                    throw new ViewMappingNotFoundException(key);

                default:
                    throw new Exception(String.Format("Presenter action '{0}' has multiple mappings.", key));
            }
        }

        // Helpers

        private static string GetControllerName(Controller sourceController)
        {
            string controllerName = (string)sourceController.ControllerContext.RequestContext.RouteData.Values["controller"];
            return controllerName;
        }

        private static string GetActionKey(string controllerName, string actionName)
        {
            string key = String.Format("{0}/{1}", controllerName, actionName);
            return key;
        }
    }
}
