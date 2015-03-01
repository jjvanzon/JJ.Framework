using JJ.Framework.Common;
using JJ.Framework.Reflection;
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
        /// whose property names should exactly match those constructor arguments.
        /// </summary>
        public static object DispatchAction(ActionInfo actionInfo, object constructorArguments)
        {
            throw new NotImplementedException();
        }

        private static Type GetTypeByShortName(string typeName)
        {
            // TODO: Go through app domain assemblies.
            // Find all types that have this type name.
            // It there are duplicates, throw an exception.
            // Cache the found type.
            throw new NotImplementedException();
        }

        private static object CreateInstance(object constructorArguments)
        {
            // TODO: Get constructorArguments properties from property cache.
            // Get the constructor, insist on only one constructor.
            // Create an object[] for the constructor arguments
            // and try to fill in values from the constructorArguments array.
            // Then instantiate and return.
            throw new NotImplementedException();
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
