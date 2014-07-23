using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Xml.Tests.Mocks
{
    internal class Element_WithCollection_WithoutExplicitItemName
    {
        public int[] Collection { get; set; }
    }
}
