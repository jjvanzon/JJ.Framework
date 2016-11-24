using System;
using System.Collections.Generic;

namespace Puzzle.NAspect.Debug.Serialization.Elements
{
    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class VizAspect
    {
        #region Property Name

        private string name;

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        #region Property Mixins

        private List<VizMixin> mixins = new List<VizMixin>();

        /// <summary>
        /// 
        /// </summary>
        public virtual List<VizMixin> Mixins
        {
            get { return mixins; }
        }

        #endregion

        #region Property Pointcuts

        private List<VizPointcut> pointcuts = new List<VizPointcut>();

        /// <summary>
        /// 
        /// </summary>
        public virtual List<VizPointcut> Pointcuts
        {
            get { return pointcuts; }
        }

        #endregion
    }
}