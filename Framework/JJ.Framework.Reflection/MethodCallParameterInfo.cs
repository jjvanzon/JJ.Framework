using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Legacy
{
    /// <inheritdoc cref="_methodcallinfo" />
    public class MethodCallParameterInfo
    {
        /// <inheritdoc cref="_methodcallinfo" />
        internal MethodCallParameterInfo(Type parameterType, string name, object value)
        {
            ParameterType = parameterType;
            Name = name;
            Value = value;
        }

        /// <inheritdoc cref="_methodcallinfo" />
        public Type ParameterType { get; private set; }
        /// <inheritdoc cref="_methodcallinfo" />
        public string Name { get; private set; }
        /// <inheritdoc cref="_methodcallinfo" />
        public object Value { get; private set; }
    }
}
