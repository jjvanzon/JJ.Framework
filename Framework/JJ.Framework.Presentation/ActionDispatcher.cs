using JJ.Framework.Common;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using JJ.Framework.Reflection;

namespace JJ.Framework.Presentation
{
    /// <summary>
    /// This is the platform-independent action dispatcher.
    /// (For MVC you may need the one in Framework.Presentation.Mvc instead.)
    /// </summary>
    public static class ActionDispatcher
    {
        private static ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

        /// <summary>
        /// Gets a view model dynamically from the described presenter and action.
        /// Overloaded action methods are not supported.
        /// Also: only simple action method parameter types are supported + 1 return action parameter of type ActionInfo.
        /// The presenter name is a type name that should only be present once in the app domain.
        /// If it does not you should use the overload that takes a presenter instance
        /// and you should program something to instantiate the presenter yourself.
        /// The presenter should have only one constructor into which are filled in 
        /// the constructor arguments passed as an object (typically an anonymous type) 
        /// whose property names should match those constructor arguments.
        /// You are allowed to pass constructor arguments that are not present in the presenter's constructor.
        /// You are allowed to omit constructor arguments that are nullable in the presenter's constructor.
        /// </summary>
        /// <param name="presenterConstructorArguments">nullable</param>
        public static object Dispatch(ActionInfo actionInfo, object presenterConstructorArguments)
        {
            if (actionInfo == null) throw new NullException(() => actionInfo);

            Type presenterType = GetPresenterType(actionInfo.PresenterName);
            object presenter = CreateInstance(presenterType, presenterConstructorArguments);
            object viewModel = Dispatch(presenter, actionInfo);
            return viewModel;
        }

        private static Type GetPresenterType(string shortTypeName)
        {
            IList<Type> types = _reflectionCache.GetTypesByShortName(shortTypeName);
            switch (types.Count)
            {
                case 1:
                    return types[0];

                case 0:
                    throw new Exception(String.Format("Type with short name '{0}' not found in the AppDomain's assemblies.", shortTypeName));

                default:
                    throw new Exception(String.Format(
                        "Type with short name '{0}' found multiple times in the AppDomain's assemblies. " +
                        "Presenters must have unique class names within the AppDomain. " +
                        "If that is not possible you must program the instantiation of the presenter yourself and use the other overload of DispatchAction. " +
                        "Found types:{1}{2}",
                        shortTypeName, Environment.NewLine, String_PlatformSupport.Join(Environment.NewLine, types.Select(x => x.FullName))));
            }
        }

        /// <param name="constructorArguments">nullable</param>
        private static object CreateInstance(Type type, object constructorArguments)
        {
            ConstructorInfo constructor = _reflectionCache.GetConstructor(type);

            if (constructorArguments == null)
            {
                return constructor.Invoke(null);
            }

            IDictionary<string, PropertyInfo> propertyDictionary = _reflectionCache.GetPropertyDictionary(constructorArguments.GetType());

            IList<ParameterInfo> parameters = constructor.GetParameters();
            object[] parameterValues = new object[parameters.Count];
            for (int i = 0; i < parameters.Count; i++)
            {
                ParameterInfo parameter = parameters[i];

                PropertyInfo property;
                propertyDictionary.TryGetValue(parameter.Name, out property);

                if (property != null)
                {
                    object propertyValue = property.GetValue_PlatformSafe(constructorArguments);
                    parameterValues[i] = propertyValue;
                }
            }

            object obj = constructor.Invoke(parameterValues);
            return obj;
        }

        /// <summary>
        /// Gets a view model dynamically from the described presenter and action.
        /// Overloaded action methods are not supported.
        /// Also: only simple parameter types are supported + 1 return action parameter of type ActionInfo.
        /// </summary>
        public static object Dispatch(object presenter, ActionInfo actionInfo)
        {
            if (presenter == null) throw new NullException(() => presenter);
            if (actionInfo == null) throw new NullException(() => actionInfo);

            actionInfo.Parameters = actionInfo.Parameters ?? new ActionParameterInfo[0];

            // Get MethodInfo.
            Type type = presenter.GetType();
            MethodInfo method = type.GetMethod(actionInfo.ActionName);
            if (method == null)
            {
                throw new Exception(String.Format("Method '{0}' of type '{1}' not found.", actionInfo.ActionName, type.Name));
            }

            // Convert parameter values.
            IList<ParameterInfo> parameters = method.GetParameters();
            object[] parameterValues = new object[parameters.Count];

            for (int i = 0; i < parameters.Count; i++)
            {
                ParameterInfo parameter = parameters[i];

                // Handle the return action parameter.
                if (parameter.ParameterType == typeof(ActionInfo))
                {
                    parameterValues[i] = actionInfo.ReturnAction;
                    continue;
                }

                // Handle normal parameter.
                object value;
                IList<ActionParameterInfo> matchingActionParameterInfos = actionInfo.Parameters
                                                                                    .Where(x => String.Equals(x.Name, parameter.Name))
                                                                                    .ToArray();
                switch (matchingActionParameterInfos.Count)
                {
                    case 1:
                        ActionParameterInfo actionParameterInfo = matchingActionParameterInfos[0];
                        value = actionParameterInfo.Value;
                        break;

                    case 0:
                        // Permit that there is no specification of the parameter in the action info,
                        // to accomodate the possibility that the method parameter is optional.
                        object defaultValue = parameter.DefaultValue;
                        value = defaultValue;
                        break;

                        //throw new Exception(String.Format(
                        //    "Parameter '{0}' for method '{1}' of type '{2}' not found in ActionInfo. Permitted parameters: {3}. ActionInfo parameters: {4}.",
                        //    parameter.Name, method.Name, type.Name,
                        //    String_PlatformSupport.Join(", ", parameters.Select(x => x.Name)),
                        //    String_PlatformSupport.Join(", ", actionInfo.Parameters.Select(x => x.Name))));

                    default:
                        throw new Exception(String.Format("Parameter '{0}' for method '{1}' of type '{2}' found multiple times in ActionInfo.", parameter.Name, method.Name, type.Name));
                }

                object parameterValue = ConvertValue(value, parameter.ParameterType);
                parameterValues[i] = parameterValue;
            }

            // Call action.
            object viewModel = method.Invoke(presenter, parameterValues);
            return viewModel;
        }

        public static ActionInfo CreateActionInfo<TPresenter>(Expression<Func<TPresenter, object>> methodCallExpression)
        {
            return CreateActionInfo(typeof(TPresenter), (LambdaExpression)methodCallExpression);
        }

        public static ActionInfo CreateActionInfo(Type presenterType, Expression<Func<object>> methodCallExpression)
        {
            return CreateActionInfo(presenterType, (LambdaExpression)methodCallExpression);
        }

        public static ActionInfo CreateActionInfo(Type presenterType, LambdaExpression methodCallExpression)
        {
            if (presenterType == null) throw new NullException(() => presenterType);

            MethodCallInfo methodCallInfo = ExpressionHelper.GetMethodCallInfo(methodCallExpression);

            MethodCallParameterInfo returnActionParameterInfo =
                methodCallInfo.Parameters
                              .Where(x => x.ParameterType == typeof(ActionInfo))
                              .SingleOrDefault();

            MethodCallParameterInfo[] valueLikeMethodCallParameterInfos = methodCallInfo.Parameters.Except(returnActionParameterInfo).ToArray();

            var actionInfo = new ActionInfo
            {
                PresenterName = presenterType.Name,
                ActionName = methodCallInfo.Name,
                Parameters = valueLikeMethodCallParameterInfos.Select(x => new ActionParameterInfo
                {
                    Name = x.Name,
                    Value = Convert.ToString(x.Value)
                })
                .ToArray()
            };

            if (returnActionParameterInfo != null)
            {
                actionInfo.ReturnAction = (ActionInfo)returnActionParameterInfo.Value;
            }

            return actionInfo;
        }

        // Code-smell: repeated code. Similar to the other overload. 
        // TODO: Let one overload delegate to the other.

        /// <summary>
        /// TODO: This oveload does not handle return ActionInfo parameters.
        /// </summary>
        public static ActionInfo CreateActionInfo(string presenterName, string actionName, params object[] parameterNamesAndValues)
        {
            var keyValuePairs = KeyValuePairHelper.ConvertNamesAndValuesListToKeyValuePairs(parameterNamesAndValues);

            var actionInfo = new ActionInfo
            {
                PresenterName = presenterName,
                ActionName = actionName,
                Parameters = keyValuePairs.Select(x => new ActionParameterInfo
                {
                    Name = x.Key,
                    Value = Convert.ToString(x.Value)
                }).ToArray()
            };

            return actionInfo;
        }

        private static object ConvertValue(object value, Type type)
        {
            // TODO: Convert more types of values.
            if (String.IsNullOrEmpty(Convert.ToString(value)))
            {
                return null;
            }

            return Convert.ChangeType(value, type);
        }
    }
}