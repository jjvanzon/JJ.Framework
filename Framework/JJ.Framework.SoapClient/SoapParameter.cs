using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.SoapClient
{
    public class SoapParameter
    {
        public SoapParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public object Value { get; private set; }
    }
}
