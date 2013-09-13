using System;
using System.Collections.Generic;

namespace Puzzle.NAspect.Debug.Serialization.Elements
{
    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class VizType
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

        #region Property FullName

        private string fullName;

        /// <summary>
        /// 
        /// </summary>
        public virtual string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        #endregion

        #region Property BaseName

        private string baseName;

        /// <summary>
        /// 
        /// </summary>
        public virtual string BaseName
        {
            get { return baseName; }
            set { baseName = value; }
        }

        #endregion

        #region Property Methods

        private List<VizMethodBase> methods = new List<VizMethodBase>();

        /// <summary>
        /// 
        /// </summary>
        public virtual List<VizMethodBase> Methods
        {
            get { return methods; }
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

        #region Property Aspects

        private List<VizAspect> aspects = new List<VizAspect>();

        /// <summary>
        /// 
        /// </summary>
        public virtual List<VizAspect> Aspects
        {
            get { return aspects; }
        }

        #endregion
    }
}