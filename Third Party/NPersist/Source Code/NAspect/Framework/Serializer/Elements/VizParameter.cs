using System;

namespace Puzzle.NAspect.Debug.Serialization.Elements
{
    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public enum VizParameterDirection
    {
        /// <summary>
        /// ByVal type of parameter
        /// </summary>
        Val,
        /// <summary>
        /// ByRef type of parameter
        /// </summary>
        Ref,
        /// <summary>
        /// Output parameter
        /// </summary>
        Out,
    }

    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class VizParameter
    {
        #region Property Name

        private string name;

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name
        {
            get => name;
            set => name = value;
        }

        #endregion

        #region Property ParameterTypeName

        private string parameterTypeName;

        /// <summary>
        /// 
        /// </summary>
        public virtual string ParameterTypeName
        {
            get => parameterTypeName;
            set => parameterTypeName = value;
        }

        #endregion

        #region Property Direction

        private VizParameterDirection direction;

        /// <summary>
        /// 
        /// </summary>
        public virtual VizParameterDirection Direction
        {
            get => direction;
            set => direction = value;
        }

        #endregion
    }
}