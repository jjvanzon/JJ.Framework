//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace JJ.Framework.Configuration
//{
//    /// <summary>
//    /// Generic, strongly-typed way of reading out configuration sections.
//    /// In the configuration XML declare the section as follows:
//    /// "&lt;configSections&gt; &lt;section name="my.assembly.name" type="JJ.Framework.Configuration.ConfigurationSectionHandler, JJ.Framework.Configuration" /&gt; &lt;/configSections&gt;"
//    /// The configuration section will look as follows:
//    /// "&lt;my.assembly.name&gt; &lt;mySetting&gt;10&lt;/mySetting&gt; &lt;/my.assembly.name&gt;"
//    /// In C# define an interface:
//    /// "interface IMySettings {  int MySetting { get; }  }".
//    /// Then call:
//    /// "Configuration&lt;IMySettings&gt;.GetValue(x => x.MySetting);"
//    /// To access child elements, define child interfaces:
//    /// "interface IMySettings { IMyChildSettings ChildSettings { get; } }."
//    /// For XML attributes use:
//    /// "interface IMySettings { [XmlAttribute] int MyAttribute { get; } }."
//    /// For XML arrays use:
//    /// "interface IMySettings { [XmlArrayItem("element")] int Elements[] { get; } }"
//    /// You can only read out one leaf node at a time.
//    /// You currently cannot access an intermediate element or array directly.
//    /// (Currently it is impossible to iterate through arrays.)
//    /// The following conventions are used:
//    /// XML elements should be camelCase while C# members are PascalCase.
//    /// You can deviate from this convention, by specifying a name using System.Xml.Serialization custom attributes on your properties.
//    /// The name of the section is the assembly name of TInterface in lower case letters.
//    /// For a custom section name, you have to create an instance of ConfigurationSection&lt;TInterface&gt;.
//    /// </summary>
//    public static class Configuration<TInterface>
//    {
//        private static ConfigurationSection<TInterface> _configurationSection;

//        static Configuration()
//        {
//            _configurationSection = new ConfigurationSection<TInterface>();
//        }

//        public static TValue GetValue<TValue>(Expression<Func<TInterface, TValue>> expression)
//        {
//            return _configurationSection.GetValue(expression);
//        }
//    }
//}
