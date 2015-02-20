using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection
{
    public class MethodCallParameterInfo
    {
        internal MethodCallParameterInfo(Type parameterType, string name, object value)
        {
            ParameterType = parameterType;
            Name = name;
            Value = value;
        }

        public Type ParameterType { get; private set; }
        public string Name { get; private set; }
        public object Value { get; private set; }
    }
}
