using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection
{
    public class MethodCallInfo
    {
        public MethodCallInfo(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        private IList<MethodCallParameterInfo> _parameters = new List<MethodCallParameterInfo>();
        /// <summary>
        /// auto-instantiated
        /// </summary>
        public IList<MethodCallParameterInfo> Parameters
        {
            get { return _parameters; }
        }
    }
}
