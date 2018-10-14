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

namespace Puzzle.NAspect.Framework.Interception
{
    /// <summary>
    /// This attribute can be applied to IInterceptors.
    /// It tells the debug visualizer that the interceptor may break the call flow.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MayBreakFlowAttribute : Attribute
    {
        #region Property Reason 

        private string reason;

        /// <summary>
        /// Reason why the interceptor may break the flow.
        /// </summary>
        public string Reason
        {
            get => reason;
            set => reason = value;
        }

        #endregion

        /// <summary>
        /// MayBreakFlowAttribute ctor.
        /// </summary>
        public MayBreakFlowAttribute()
        {
        }

        /// <summary>
        /// MayBreakFlowAttribute ctor.
        /// </summary>
        /// <param name="reason">Reason why the interceptor may break the flow.</param>
        public MayBreakFlowAttribute(string reason) => Reason = reason;
    }

    /// <summary>
    /// This attribute can be applied to IInterceptors.
    /// It tells the engine that the interceptor may not be used after an interceptor that may break flow.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IsRequiredAttribute : Attribute
    {
        #region Property required 

        private bool required;

        /// <summary>
        /// Gets or sets the required property.
        /// </summary>
        public bool Required
        {
            get => required;
            set => required = value;
        }

        #endregion

        /// <summary>
        /// IsRequiredAttribute ctor.
        /// </summary>
        public IsRequiredAttribute()
        {
        }

        /// <summary>
        /// IsRequiredAttribute ctor.
        /// </summary>
        /// <param name="required">Set to true if the interceptor is required</param>
        public IsRequiredAttribute(bool required) => Required = required;
    }

    /// <summary>
    /// This attribute can be applied to IInterceptors.
    /// It tells the debug visualizer that the interceptor may throw an exception.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ThrowsAttribute : Attribute
    {
        #region Property ExceptionType 

        private Type exceptionType;

        /// <summary>
        /// Type of exception the interceptor may throw.
        /// </summary>
        public Type ExceptionType
        {
            get => exceptionType;
            set => exceptionType = value;
        }

        #endregion

        /// <summary>
        /// ThrowsAttribute ctor.
        /// </summary>
        /// <param name="exceptionType">Type of the exception the interceptor may throw</param>
        public ThrowsAttribute(Type exceptionType) => ExceptionType = exceptionType;
    }

    /// <summary>
    /// This attribute can be applied to IInterceptors.
    /// It tells the debug visualizer that the interceptor may catch and consume an exception.
    /// Thus preventing the exception to bouble up in the call chain.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CatchesAttribute : Attribute
    {
        #region Property ExceptionType

        private Type exceptionType;

        /// <summary>
        /// The type of the exception that may be chaught
        /// </summary>
        public Type ExceptionType
        {
            get => exceptionType;
            set => exceptionType = value;
        }

        #endregion

        /// <summary>
        /// CatchesAttribute ctor.
        /// </summary>
        /// <param name="exceptionType">The type of the exception that may be chaught</param>
        public CatchesAttribute(Type exceptionType) => ExceptionType = exceptionType;
    }


    /// <summary>
    /// This attribute can be applied to IInterceptors.
    /// It tells the debug visualizer that the interceptor may catch and replace an excepton of one type with another
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ReplaceException : Attribute
    {
        #region Property CatchType 

        private Type catchType;

        /// <summary>
        /// Exception type to catch
        /// </summary>
        public Type CatchType
        {
            get => catchType;
            set => catchType = value;
        }

        #endregion

        #region Property ThrowType 

        private Type throwType;

        /// <summary>
        /// Exception type to replace with
        /// </summary>
        public Type ThrowType
        {
            get => throwType;
            set => throwType = value;
        }

        #endregion

        /// <summary>
        /// ReplaceException ctor.
        /// </summary>
        /// <param name="catchType">Exception type to catch</param>
        /// <param name="throwType">Exception type to replace with</param>
        public ReplaceException(Type catchType, Type throwType)
        {
            CatchType = catchType;
            ThrowType = throwType;
        }
    }
}