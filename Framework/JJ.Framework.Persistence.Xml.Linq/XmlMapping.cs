﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable UnusedTypeParameter

namespace JJ.Framework.Persistence.Legacy.Xml.Linq
{
    public abstract class XmlMapping<TEntity> : IXmlMapping
    {
        public XmlMapping()
        {
            ElementName = "x";
        }

        public IdentityType IdentityType { get; protected set; }
        public string IdentityPropertyName { get; protected set; }

        /// <summary>
        /// Not essential for storage. Default is "x". You can change it using this property.
        /// </summary>
        public string ElementName { get; protected set; }
    }
}
