using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Xml.Linq.Tests.Mocks
{
    internal class Element_WithCollection<T>
    {
        [XmlArrayItem("item")]
        public T Collection { get; set; }
    }
}
