using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Legacy
{
    /// <inheritdoc cref="_methodcallinfo" />
    public class MethodCallInfo
    {
        /// <inheritdoc cref="_methodcallinfo" />
        internal MethodCallInfo(string name)
        {
            Name = name;
        }

        /// <inheritdoc cref="_methodcallinfo" />
        public string Name { get; private set; }

        /// <inheritdoc cref="_methodcallinfo" />
        private IList<MethodCallParameterInfo> _parameters = new List<MethodCallParameterInfo>();

        /// <summary>
        /// auto-instantiated
        /// </summary>
        /// <inheritdoc cref="_methodcallinfo" />
        public IList<MethodCallParameterInfo> Parameters
        {
            get { return _parameters; }
        }
    }
}
