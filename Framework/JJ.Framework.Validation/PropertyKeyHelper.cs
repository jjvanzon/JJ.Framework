using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Framework.Validation
{
    internal static class PropertyKeyHelper
    {
        public static string GetPropertyKeyFromExpression(Expression<Func<object>> propertyKeyExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression, true);

            // Always cut off the root object, e.g. "MyObject.MyProperty" becomes "MyProperty".
            propertyKey = propertyKey.CutLeftUntil(".").CutLeft(".");

            return propertyKey;
        }
    }
}
