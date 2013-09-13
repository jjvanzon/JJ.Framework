using System;
using System.Collections.Generic;

namespace Puzzle.NAspect.Debug.Serialization.Elements
{
    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class VizPointcut
    {
        #region Property Interceptors

        private List<VizInterceptor> interceptors = new List<VizInterceptor>();

        /// <summary>
        /// 
        /// </summary>
        public virtual List<VizInterceptor> Interceptors
        {
            get { return interceptors; }
        }

        #endregion
    }
}