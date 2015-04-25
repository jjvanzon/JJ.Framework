using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JJ.Framework.Data.Tests
{
    public class ConfigurationSection
    {
        [XmlAttribute]
        public string Location { get; set; }

        [XmlAttribute("nhibernateContextType")]
        public string NHibernateContextType { get; set; }

        [XmlAttribute("npersistContextType")]
        public string NPersistContextType { get; set; }

        [XmlAttribute("entityFramework5ContextType")]
        public string EntityFramework5ContextType { get; set; }

        [XmlAttribute]
        public string Dialect { get; set; }
    }
}
