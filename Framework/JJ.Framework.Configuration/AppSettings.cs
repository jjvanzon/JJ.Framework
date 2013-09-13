using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Configuration
{
    public static class AppSettings<TInterface>
    {
        public static TValue Get<TValue>(Expression<Func<TInterface, TValue>> expression)
        {
            string name = ExpressionHelper.GetName(expression);
            string stringValue = ConfigurationManager.AppSettings[name];
            TValue value = ConfigurationHelper.ConvertValue<TValue>(stringValue);
            return value;
        }
    }
}
