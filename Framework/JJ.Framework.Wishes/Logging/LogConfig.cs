using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging
{
    public class LogConfig
    {
        // TODO: Make nullable
        [XmlAttribute]
        public bool? Active { get; set; }

        [XmlArrayItem("log")]
        public IList<LoggerElement> Logs { get; set; }
    }
}
