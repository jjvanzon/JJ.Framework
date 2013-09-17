using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JJ.Framework.Persistence.Tests
{
    public class ConfigurationSection
    {
        
        public string EntityFrameworkContextType { get; set; }

        [XmlElement("nhibernateContextType")]
        public string NHibernateContextType { get; set; }

        [XmlElement("npersistContextType")]
        public string NPersistContextType { get; set; }
    }
}
