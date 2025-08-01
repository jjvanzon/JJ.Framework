﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable UnusedTypeParameter

namespace JJ.Framework.Persistence.Legacy.Xml
{
    public abstract class XmlMapping<TEntity> : IXmlMapping
    {
        public XmlMapping()
        {
            ElementName = "x";
        }

        public IdentityType IdentityType { get; protected set; }
        public string IdentityPropertyName { get; protected set; }
        public string ElementName { get; protected set; }
    }
}
