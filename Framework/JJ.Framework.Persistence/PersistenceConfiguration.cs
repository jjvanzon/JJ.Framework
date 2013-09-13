using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JJ.Framework.Persistence
{
    public class PersistenceConfiguration
    {
        [XmlAttribute]
        public string ContextType { get; set; }

        [XmlAttribute]
        public string Location { get; set; }

        [XmlArrayItem("modelAssembly")]
        public string[] ModelAssemblies { get; set; }
    }
}
