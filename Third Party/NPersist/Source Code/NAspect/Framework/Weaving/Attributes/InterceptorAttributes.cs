// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using System.Reflection;
using Puzzle.NAspect.Framework.Aop;
using System.Diagnostics;

namespace Puzzle.NAspect.Framework.Interception
{
    [AttributeUsage (AttributeTargets.Class)]
    public class MayBreakFlowAttribute : Attribute
    {
        #region Property Reason 
        private string reason;
        public string Reason
        {
            get
            {
                return this.reason;
            }
            set
            {
                this.reason = value;
            }
        }                        
        #endregion

        public MayBreakFlowAttribute()
        {
        }

        public MayBreakFlowAttribute(string reason)
        {
            this.Reason = reason;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class IsRequiredAttribute : Attribute
    {
        #region Property required 
        private bool required;
        public bool Required
        {
            get
            {
                return this.required;
            }
            set
            {
                this.required = value;
            }
        }                        
        #endregion

        public IsRequiredAttribute()
        {
        }

        public IsRequiredAttribute(bool required)
        {
            this.Required = required;
        }
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class ThrowsAttribute : Attribute
    {
        #region Property ExceptionType 
        private Type exceptionType;
        public Type ExceptionType
        {
            get
            {
                return this.exceptionType;
            }
            set
            {
                this.exceptionType = value;
            }
        }                        
        #endregion

        public ThrowsAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CatchesAttribute : Attribute
    {
        #region Property ExceptionType
        private Type exceptionType;
        public Type ExceptionType
        {
            get
            {
                return this.exceptionType;
            }
            set
            {
                this.exceptionType = value;
            }
        }
        #endregion

        public CatchesAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ReplaceException : Attribute
    {
        #region Property CatchType 
        private Type catchType;
        public Type CatchType
        {
            get
            {
                return this.catchType;
            }
            set
            {
                this.catchType = value;
            }
        }                        
        #endregion

        #region Property ThrowType 
        private Type throwType;
        public Type ThrowType
        {
            get
            {
                return this.throwType;
            }
            set
            {
                this.throwType = value;
            }
        }                        
        #endregion

        public ReplaceException(Type catchType, Type throwType)
        {
            this.CatchType = catchType;
            this.ThrowType = throwType;
        }
    }


}
