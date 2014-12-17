using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Reflection;
using JJ.Framework.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Helpers
{
    public static class ExpressionHelper_UsingFunc
    {
        // GetValue 

        public static T GetValue<T>(Func<T> expression)
        {
            if (expression == null)
            {
                throw new NullException(() => expression);
            }

            return expression();
        }
    }
}