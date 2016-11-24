using System;
using System.Collections.Generic;

namespace Puzzle.NAspect.Debug.Serialization.Elements
{
    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class VizMethodBase
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

        #region Property Parameters

        private List<VizParameter> parameters = new List<VizParameter>();

        /// <summary>
        /// 
        /// </summary>
        public virtual List<VizParameter> Parameters
        {
            get { return parameters; }
        }

        #endregion

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

        #region Property OwnerType

        private VizType ownerType;

        /// <summary>
        /// 
        /// </summary>
        public virtual VizType OwnerType
        {
            get { return ownerType; }
            set { ownerType = value; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetProxyText()
        {
            return "hello";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetRealText()
        {
            return "hello";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetCallSample()
        {
            return "hello";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetParamTypes()
        {
            string paramString = "";
            foreach (VizParameter parameter in Parameters)
            {
                paramString += parameter.ParameterTypeName + ",";
            }
            if (paramString.Length > 0)
                paramString = paramString.Substring(0, paramString.Length - 1);

            return paramString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// DTO for the VS.NET 2005 debugger visualiser
    /// </summary>
    [Serializable]
    public class VizMethod : VizMethodBase
    {
        #region Property ReturnType

        private string returnType;

        /// <summary>
        /// 
        /// </summary>
        public virtual string ReturnType
        {
            get { return returnType; }
            set { returnType = value; }
        }

        #endregion

        //owner mixin

        #region Property Mixin

        private VizMixin mixin;

        /// <summary>
        /// 
        /// </summary>
        public virtual VizMixin Mixin
        {
            get { return mixin; }
            set { mixin = value; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetProxyText()
        {
            return string.Format("{0}.{1} ({2})", OwnerType.Name, Name, GetParamTypes());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetRealText()
        {
            if (Mixin == null)
                return string.Format("{0}.{1} ({2})", OwnerType.BaseName, Name, GetParamTypes());
            else
                return string.Format("{0}.{1} ({2})", Mixin.TypeName, Name, GetParamTypes());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{1} ({2}) : {0}", ReturnType, Name, GetParamTypes());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetCallSample()
        {
            return string.Format("My{0}Obj.{1} ({2})", OwnerType.BaseName, Name, GetParamTypes());
        }
    }
}