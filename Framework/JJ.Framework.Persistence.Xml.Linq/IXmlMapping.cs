﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Persistence.Legacy.Xml.Linq
{
    public interface IXmlMapping
    {
        IdentityType IdentityType { get; }
        string IdentityPropertyName { get; }
        string ElementName { get; }
    }
}
