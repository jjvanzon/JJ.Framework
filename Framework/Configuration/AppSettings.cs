using JJ.Framework.Reflection;
using System;
using System.Configuration;
using System.Linq.Expressions;

namespace JJ.Framework.Configuration
{
    public static class AppSettings<TInterface>
    {
        // TODO: Get is almost a TryGet. Make a distinction betwee Get and TryGet.
        // TryGet and Get should be handled differently for nullable types, 
        // reference types and non-nullable value types.

        public static TValue Get<TValue>(Expression<Func<TInterface, TValue>> expression)
        {
            string name = ExpressionHelper.GetName(expression);
            string stringValue = ConfigurationManager.AppSettings[name];
            TValue value = ConversionHelper.ConvertValue<TValue>(stringValue);
            return value;
        }
    }
}
