﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Security.Legacy
{
    public class AuthenticationConfiguration
    {
        [XmlAttribute]
        public AuthenticationTypeEnum AuthenticationType { get; set; }
    }
}
