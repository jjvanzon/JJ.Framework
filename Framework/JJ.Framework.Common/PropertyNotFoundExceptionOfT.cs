using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common
{
    public class PropertyNotFoundException<T> : PropertyNotFoundException
    {
        public PropertyNotFoundException(string propertyName)
            : base(typeof(T), propertyName)
        { }
    }
}