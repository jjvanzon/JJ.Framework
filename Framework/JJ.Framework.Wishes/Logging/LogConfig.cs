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
        [XmlAttribute]
        public bool? Active { get; set; }

        [XmlArrayItem("log")]
        public LoggerElement[] Logs { get; set; }
    }
}
