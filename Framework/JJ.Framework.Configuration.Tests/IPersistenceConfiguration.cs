using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JJ.Framework.Configuration.Tests
{
    public interface IPersistenceConfiguration
    {
        [XmlAttribute]
        string ContextType { get; }

        [XmlAttribute]
        string Location { get; }

        [XmlArrayItem("modelAssembly")]
        string[] ModelAssemblies { get; }

        ISubConfiguration SubConfiguration { get; }
    }
}
