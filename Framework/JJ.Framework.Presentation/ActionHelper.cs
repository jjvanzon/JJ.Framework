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
    public static class ActionHelper
    {
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
            ActionInfo actionInfo = new ActionInfo
            {
                PresenterName = presenterType.Name,
                ActionName = methodCallInfo.Name,
                Parameters = methodCallInfo.Parameters.Select(x => new ActionParameterInfo
                {
                    Name = x.Name,
                    Value = Convert.ToString(x.Value)
                }).ToArray()
            };
            return actionInfo;
        }

        /// <summary>
        /// Gets a view model dynamically from the described presenter and action.
        /// Overloaded action methods are not supported.
        /// Also: only simple parameter types are supported.
        /// </summary>
        public static object DispatchAction(object presenter, ActionInfo actionInfo)
        {
            if (presenter == null) throw new NullException(() => presenter);
            if (actionInfo == null) throw new NullException(() => actionInfo);

            Type type = presenter.GetType();
            MethodInfo method = type.GetMethod(actionInfo.ActionName);
            if (method == null)
            {
                throw new Exception(String.Format("Method '{0}' of type '{1}' not found.", actionInfo.ActionName, type.Name));
            }

            // Convert parameter values.
            IList<ParameterInfo> parameterInfos = method.GetParameters();
            actionInfo.Parameters = actionInfo.Parameters ?? new ActionParameterInfo[0];
            if (parameterInfos.Count != actionInfo.Parameters.Count)
            {
                throw new Exception("MethodInfo and ActionInfo must have the same amount of parameters.");
            }
            object[] parameterValues = new object[parameterInfos.Count];
            for (int i = 0; i < parameterInfos.Count; i++)
            {
                ParameterInfo parameterInfo = parameterInfos[i];
                ActionParameterInfo actionParameterInfo = actionInfo.Parameters[i];
                actionParameterInfo = actionParameterInfo ?? new ActionParameterInfo();
                object parameterValue = ConvertValue(actionParameterInfo.Value, parameterInfo.ParameterType);
                parameterValues[i] = parameterValue;
            }

            // Call action.
            object viewModel = method.Invoke(presenter, parameterValues);
            return viewModel;
        }

        private static object ConvertValue(string value, Type type)
        {
            return Convert.ChangeType(value, type);
        }
    }
}
