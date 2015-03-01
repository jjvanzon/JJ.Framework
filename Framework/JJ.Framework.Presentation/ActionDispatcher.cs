using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Presentation
{
    /// <summary>
    /// This is the platform-independent action dispatcher.
    /// (For MVC you may need the one in Framework.Presentation.Mvc instead.)
    /// </summary>
    public static class ActionDispatcher
    {
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
        /// You can ommit constructor arguments that are nullable in the presenter's constructor.
        /// </summary>
        /// <param name="constructorArguments">nullable</param>
        public static object DispatchAction(ActionInfo actionInfo, object constructorArguments)
        {
            if (actionInfo == null) throw new NullException(() => actionInfo);

            Type presenterType = GetTypeByShortName(actionInfo.PresenterName);
            object presenter = CreateInstance(presenterType, constructorArguments);
            object viewModel = DispatchAction(presenter, actionInfo);
            return viewModel;
        }

        private static IDictionary<string, Type> _typeByShortNameDictionary = new Dictionary<string, Type>();
        private static object _typeByShortNameDictionaryLock = new object();

        private static Type GetTypeByShortName(string shortTypeName)
        {
            lock (_typeByShortNameDictionaryLock)
            {
                Type type;
                if (_typeByShortNameDictionary.TryGetValue(shortTypeName, out type))
                {
                    return type;
                }

                List<Type> types = new List<Type>();
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        types.AddRange(assembly.GetTypes().Where(x => String.Equals(x.Name, shortTypeName)));
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        // Ignore.
                        // TODO: Learn why types of some assemblies cannot be retrieved,
                        // and why it says the assembly cannot be loaded (file not found),
                        // while it clearly is part of the app domain.
                    }
                }

                switch (types.Count)
                {
                    case 1:
                        _typeByShortNameDictionary.Add(shortTypeName, types[0]);
                        return types[0];

                    case 0:
                        throw new Exception(String.Format("Type with short name '{0}' not found in the AppDomain's assemblies.", shortTypeName));

                    default:
                        throw new Exception(String.Format("Type with short name '{0}' found multiple times in the AppDomain's assemblies. " +
                                                          "Presenters must have unique class names within the AppDomain. " +
                                                          "If that is not possible you must program the instantiation of the presenter yourself and use the other overload of DispatchAction. " +
                                                          "Found types:{1}{2}",
                                                          shortTypeName, Environment.NewLine, String_PlatformSupport.Join(Environment.NewLine, types.Select(x => x.FullName))));
                }
            }
        }

        /// <param name="constructorArguments">nullable</param>
        private static object CreateInstance(Type type, object constructorArguments)
        {
            ConstructorInfo constructor = GetConstructor(type);

            if (constructorArguments == null)
            {
                return constructor.Invoke(null);
            }

            IDictionary<string, PropertyInfo> constructorArgumentPropertyDictionary = GetPropertyDictionary(constructorArguments.GetType());

            IList<ParameterInfo> parameters = constructor.GetParameters();
            object[] parameterValues = new object[parameters.Count];
            for (int i = 0; i < parameters.Count; i++)
            {
                ParameterInfo parameter = parameters[i];

                PropertyInfo constructorArgumentProperty;
                constructorArgumentPropertyDictionary.TryGetValue(parameter.Name, out constructorArgumentProperty);

                if (constructorArgumentProperty != null)
                {
                    object parameterValue = constructorArgumentProperty.GetValue_PlatformSafe(constructorArguments);
                    parameterValues[i] = parameterValue;
                }
            }

            object obj = constructor.Invoke(parameterValues);
            return obj;
        }

        private static IDictionary<Type, IDictionary<string, PropertyInfo>> _propertyDictionaryDictionary = new Dictionary<Type, IDictionary<string, PropertyInfo>>();
        private static object _propertyDictionaryDictionaryLock = new object();

        private static IDictionary<string, PropertyInfo> GetPropertyDictionary(Type type)
        {
            lock (_propertyDictionaryDictionaryLock)
            {
                IDictionary<string, PropertyInfo> propertyDictionary;
                if (!_propertyDictionaryDictionary.TryGetValue(type, out propertyDictionary))
                {
                    propertyDictionary = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(x => x.Name);
                    _propertyDictionaryDictionary.Add(type, propertyDictionary);
                }
                return propertyDictionary;
            }
        }

        private static IDictionary<Type, ConstructorInfo> _constructorDictionary = new Dictionary<Type, ConstructorInfo>();
        private static object _constructorDictionaryLock = new object();

        private static ConstructorInfo GetConstructor(Type type)
        {
            lock (_constructorDictionary)
            {
                ConstructorInfo constructor;
                if (_constructorDictionary.TryGetValue(type, out constructor))
                {
                    return constructor;
                }

                // TODO: Consider if you need to pass BindingFlags.
                IList<ConstructorInfo> constructors = type.GetConstructors();
                switch (constructors.Count)
                {
                    case 1:
                        _constructorDictionary.Add(type, constructors[0]);
                        return constructors[0];

                    case 0:
                        throw new Exception(String.Format("No constructor found for type '{0}'.", type.FullName));

                    default:
                        throw new Exception(String.Format("Multiple constructors found on type '{0}'.", type.FullName));
                }
            }
        }

        /// <summary>
        /// Gets a view model dynamically from the described presenter and action.
        /// Overloaded action methods are not supported.
        /// Also: only simple parameter types are supported + 1 return action parameter of type ActionInfo.
        /// </summary>
        public static object DispatchAction(object presenter, ActionInfo actionInfo)
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
            IList<ParameterInfo> parameterInfos = method.GetParameters();

            object[] parameterValues = new object[parameterInfos.Count];
            for (int i = 0; i < parameterInfos.Count; i++)
            {
                ParameterInfo parameterInfo = parameterInfos[i];

                // Handle the return action parameter.
                if (parameterInfo.ParameterType == typeof(ActionInfo))
                {
                    parameterValues[i] = actionInfo.ReturnAction;
                    continue;
                }

                // Handle normal parameter.
                ActionParameterInfo actionParameterInfo = actionInfo.Parameters
                                                                    .Where(x => String.Equals(x.Name, parameterInfo.Name))
                                                                    .Single();

                object parameterValue = ConvertValue(actionParameterInfo.Value, parameterInfo.ParameterType);
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

        private static object ConvertValue(string value, Type type)
        {
            return Convert.ChangeType(value, type);
        }
    }
}