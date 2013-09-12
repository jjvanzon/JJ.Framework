using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Configuration
{
    public static class Configuration<TInterface>
    {
        private static ConfigurationSection<TInterface> _configurationSection;

        static Configuration()
        {
            _configurationSection = new ConfigurationSection<TInterface>();
        }

        public static TValue GetValue<TValue>(Expression<Func<TInterface, TValue>> expression)
        {
            return _configurationSection.GetValue(expression);
        }
    }
}
