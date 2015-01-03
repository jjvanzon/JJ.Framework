//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using JJ.Framework.Reflection;

//namespace JJ.Framework.Configuration
//{
//    /// <summary>
//    /// Generic way of reading out a configuration section.
//    /// You can specify a custom section name using this class.
//    /// For the rest of the explanations see Configuration&lt;TInterface&gt;.
//    /// </summary>
//    public class ConfigurationSection<TInterface>
//    {
//        private XmlNode _rootXmlNode;

//        public ConfigurationSection()
//            : this(typeof(TInterface).Assembly)
//        { }

//        public ConfigurationSection(Assembly assembly)
//            : this(ReflectionHelper.GetAssemblyName(assembly).ToLower())
//        { }

//        public ConfigurationSection(string configurationSectionName)
//        {
//            _rootXmlNode = (XmlNode)ConfigurationSettings.GetConfig(configurationSectionName);
//        }

//        public TValue GetValue<TValue>(Expression<Func<TInterface, TValue>> expression)
//        {
//            var translator = new XmlExpressionTranslator(_rootXmlNode);
//            translator.Visit(expression);
//            string stringValue = translator.Result;
//            TValue value = ConfigurationHelper.ConvertValue<TValue>(stringValue);
//            return value;
//        }
//    }
//}
