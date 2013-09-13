using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JJ.Framework.Persistence
{
    public interface IPersistenceSettings
    {
        [XmlAttribute]
        string ContextType { get; }

        [XmlAttribute]
        string Location { get; }

        [XmlArrayItem("modelAssembly")]
        string[] ModelAssemblies { get; }
    }
}
