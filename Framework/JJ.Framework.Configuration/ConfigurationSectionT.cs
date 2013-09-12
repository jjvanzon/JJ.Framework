using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Reflection;
using System.Xml;

namespace JJ.Framework.Configuration
{
    public class ConfigurationSection<TInterface>
    {
        private XmlNode _rootXmlNode;

        public ConfigurationSection()
            : this(typeof(TInterface).Assembly)
        { }

        public ConfigurationSection(Assembly assembly)
            : this(ReflectionHelper.GetAssemblyName(assembly).ToLower())
        { }

        public ConfigurationSection(string configurationSectionName)
        {
            _rootXmlNode = (XmlNode)ConfigurationSettings.GetConfig(configurationSectionName);
            //_rootXmlNode = (XmlNode)ConfigurationManager.GetSection(configurationSectionName);
        }

        //public static TElement GetSection<TElement>(string configurationSectionName)
        //{
        //    //return new System.Configuration.ConfigurationSection();

        //    ConfigurationSection configurationSection = (ConfigurationSection)System.Configuration.ConfigurationManager.GetSection(configurationSectionName);

        //    throw new NotImplementedException();
        //}

        //public static TElement GetSection<TElement>(Assembly assembly)
        //{
        //    string configurationSectionName = ReflectionHelper.GetAssemblyName(assembly);
        //    return GetSection<TElement>(configurationSectionName);
        //}

        public TValue GetValue<TValue>(Expression<Func<TInterface, TValue>> expression)
        {
            var translator = new XmlExpressionTranslator(_rootXmlNode);
            translator.Visit(expression);
            string stringValue = translator.Result;
            TValue value = ConfigurationHelper.ConvertValue<TValue>(stringValue);
            return value;
        }

        //public ConfigurationSection<IElementInterface> GetElement<IElementInterface>(Expression<Func<TInterface, IElementInterface>> expression)
        //{
        //    string name = ExpressionHelper.GetName(expression);

        //    //ConfigurationManager.GetSection
        //    //TElement value = (TElement)Convert.ChangeType(ConfigurationManager.AppSettings[name], typeof(TValue));
        //    //return value;
        //    throw new NotImplementedException();
        //}
    }
}
