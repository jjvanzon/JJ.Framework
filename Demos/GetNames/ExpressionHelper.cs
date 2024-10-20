﻿using System;
using System.Linq.Expressions;

namespace JJ.Demos.GetNames
{
    public static class ExpressionHelper
    {
        public static string GetName<T>(Expression<Func<T, object>> expression) => GetName((LambdaExpression)expression);

        public static string GetName(LambdaExpression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var translator = new NameTranslator();
            translator.Visit(expression);
            return translator.Result;
        }
    }
}
