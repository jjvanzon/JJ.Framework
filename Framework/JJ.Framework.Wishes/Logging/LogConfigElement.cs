using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Wishes.Logging
{
    public class LogConfigElement
    {
        // Preliminary. Might use later.
        /// <inheritdoc cref="docs.loggerelementtypeproperty" />
        //[XmlAttribute]
        //public string Type { get; set; }
        
        [XmlAttribute]
        public bool? Active { get; set; }
    }
}