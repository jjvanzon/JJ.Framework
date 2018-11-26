using System;
using System.Collections.Generic;

namespace Puzzle.NAspect.Debug.Serialization.Elements
{
    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    public enum VizInterceptorType
    {
        /// <summary>
        /// 
        /// </summary>
        Before,
        /// <summary>
        /// 
        /// </summary>
        After,
        /// <summary>
        /// 
        /// </summary>
        Around,
    }

    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class VizInterceptor
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

        #region Property TypeName

        private string typeName;

        /// <summary>
        /// 
        /// </summary>
        public virtual string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        #endregion

        #region Property InterceptorType

        private VizInterceptorType interceptorType;

        /// <summary>
        /// 
        /// </summary>
        public virtual VizInterceptorType InterceptorType
        {
            get { return interceptorType; }
            set { interceptorType = value; }
        }

        #endregion

        #region Property MayBreakFlow 

        private bool mayBreakFlow;

        /// <summary>
        /// 
        /// </summary>
        public bool MayBreakFlow
        {
            get { return mayBreakFlow; }
            set { mayBreakFlow = value; }
        }

        #endregion

        #region Property IsOptional 

        private bool isRequired;

        /// <summary>
        /// 
        /// </summary>
        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        #endregion

        #region Property ThrowsExceptionTypes 

        private List<string> throwsExceptionTypes = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public List<string> ThrowsExceptionTypes
        {
            get { return throwsExceptionTypes; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} : {1}", TypeName, InterceptorType);
        }
    }
}