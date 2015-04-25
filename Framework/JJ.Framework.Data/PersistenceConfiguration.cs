using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Data
{
    public class PersistenceConfiguration
    {
        [XmlAttribute]
        public string ContextType { get; set; }

        [XmlAttribute]
        public string Location { get; set; }

        [XmlAttribute]
        public string ModelAssembly { get; set; }

        [XmlAttribute]
        public string MappingAssembly { get; set; }

        [XmlArrayItem("repositoryAssembly")]
        public string[] RepositoryAssemblies { get; set; }

        [XmlAttribute]
        public string Dialect { get; set; }
    }
}
