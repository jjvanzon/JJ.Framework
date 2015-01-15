using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Presentation
{
    public static class ActionDescriptorHelper
    {
        public static ActionDescriptor CreateActionDescriptor<TPresenter>(Expression<Func<TPresenter, object>> methodCallExpression)
        {
            return CreateActionDescriptor(typeof(TPresenter), (LambdaExpression)methodCallExpression);
        }

        public static ActionDescriptor CreateActionDescriptor(Type presenterType, Expression<Func<object>> methodCallExpression)
        {
            return CreateActionDescriptor(presenterType, (LambdaExpression)methodCallExpression);
        }

        public static ActionDescriptor CreateActionDescriptor(Type presenterType, LambdaExpression methodCallExpression)
        {
            MethodCallInfo methodCallInfo = ExpressionHelper.GetMethodCallInfo(methodCallExpression);
            ActionDescriptor actionDescriptor = new ActionDescriptor
            {
                PresenterName = presenterType.Name,
                ActionName = methodCallInfo.Name,
                Parameters = methodCallInfo.Parameters.Select(x => new ParameterDescriptor
                {
                    Name = x.Name,
                    Value = Convert.ToString(x.Value)
                }).ToArray()
            };
            return actionDescriptor;
        }
    }
}
