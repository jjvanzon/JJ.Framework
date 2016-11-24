using System;
using Puzzle.NAspect.Debug.Serialization.Elements;

namespace Puzzle.NAspect.Debug.Serialization
{
    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class SerializedProxy
    {
        #region Property ProxyType

        private VizType proxyType;

        /// <summary>
        /// 
        /// </summary>
        public virtual VizType ProxyType
        {
            get { return proxyType; }
            set { proxyType = value; }
        }

        #endregion
    }
}