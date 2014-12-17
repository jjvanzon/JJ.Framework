using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace JJ.Demos.GetNames
{
    public static class ExpressionHelper
    {

        public static string GetName<T>(Expression<Func<T, object>> expression)
        {
            return ExpressionHelper.GetName((LambdaExpression)expression);
        }

        public static string GetName(LambdaExpression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");

            var translator = new NameTranslator();
            translator.Visit(expression);
            return translator.Result;
        }
    }
}
