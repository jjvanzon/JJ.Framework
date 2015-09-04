using System.Collections.Generic;

namespace JJ.Framework.Reflection
{
    public class MethodCallInfo
    {
        internal MethodCallInfo(string name)
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
