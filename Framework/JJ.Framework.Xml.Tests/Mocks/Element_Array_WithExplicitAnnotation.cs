﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Xml.Tests.Mocks
{
    internal class Element_Array_WithExplicitAnnotation
    {
        [XmlArray]
        [XmlArrayItem("item")]
        public int[] Array_WithExplicitAnnotation { get; set; }
    }
}
