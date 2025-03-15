using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Logging.Core.Mappers
{
    public class RootLoggerXml : LoggerXml
    {
        [XmlArrayItem("log")]
        public IList<LoggerXml> Logs { get; set; }
    }
}
