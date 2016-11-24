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
using Puzzle.NAspect.Framework.Interception;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Pointcut that matches attributes on target methods.
    /// </summary>
    public class AttributePointcut : PointcutBase
    {
        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeType">Attribute type to match</param>
        /// <param name="interceptors">Untyped list of <c>IInterceptor</c>s to apply on matched methods</param>
        public AttributePointcut(Type attributeType, IList interceptors)
        {
            Interceptors = interceptors;
            Targets.Add(new PointcutTarget(attributeType, PointcutTargetType.Attribute));
        }

        #endregion

        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeType">Attribute type to match</param>
        /// <param name="interceptors">Array of <c>IInterceptor</c>s to apply on matched methods</param>
        public AttributePointcut(Type attributeType, IInterceptor[] interceptors)
        {
            Interceptors = new ArrayList(interceptors);
            Targets.Add(new PointcutTarget(attributeType, PointcutTargetType.Attribute));
        }

        #endregion

        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeType">Attribute type to match</param>
        /// <param name="interceptor"><c>IInterceptor</c> instance to appy on matched methods.</param>
        public AttributePointcut(Type attributeType, IInterceptor interceptor)
        {
            Interceptors = new ArrayList(new IInterceptor[] {interceptor});
            Targets.Add(new PointcutTarget(attributeType, PointcutTargetType.Attribute));
        }

        #endregion

        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeType">Attribute type to match</param>
        /// <param name="interceptor">Interceptor delegate to apply on matched methods, valid delegates are <c>BeforeDelegate</c>, <c>AroundDelegate</c> and <c>AfterDelegate</c></param>
        public AttributePointcut(Type attributeType, Delegate interceptor)
        {
            ArrayList arr = new ArrayList();
            arr.Add(interceptor);
            Interceptors = arr;
            Targets.Add(new PointcutTarget(attributeType, PointcutTargetType.Attribute));
        }

        #endregion

        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeTypeName">Name of the attribute type to match</param>
        /// <param name="interceptors">Untyped list of <c>IInterceptor</c>s to apply on matched methods</param>
        public AttributePointcut(string attributeTypeName, IList interceptors)
        {
            Interceptors = interceptors;
            Targets.Add(new PointcutTarget(attributeTypeName, PointcutTargetType.Attribute));
        }

        #endregion

        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeTypeName">Name of the attribute type to match</param>
        /// <param name="interceptors">Array of <c>IInterceptor</c>s to apply on matched methods</param>
        public AttributePointcut(string attributeTypeName, IInterceptor[] interceptors)
        {
            Interceptors = new ArrayList(interceptors);
            Targets.Add(new PointcutTarget(attributeTypeName, PointcutTargetType.Attribute));
        }

        #endregion

        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeTypeName">Name of the attribute type to match</param>
        /// <param name="interceptor"><c>IInterceptor</c> instance to appy on matched methods.</param>
        public AttributePointcut(string attributeTypeName, IInterceptor interceptor)
        {
            Interceptors = new ArrayList(new IInterceptor[] { interceptor });
            Targets.Add(new PointcutTarget(attributeTypeName, PointcutTargetType.Attribute));
        }

        #endregion

        #region Pointcut

        /// <summary>
        /// AttributePointcut ctor.
        /// </summary>
        /// <param name="attributeTypeName">Name of the attribute type to match</param>
        /// <param name="interceptor">Interceptor delegate to apply on matched methods, valid delegates are <c>BeforeDelegate</c>, <c>AroundDelegate</c> and <c>AfterDelegate</c></param>
        public AttributePointcut(string attributeTypeName, Delegate interceptor)
        {
            ArrayList arr = new ArrayList();
            arr.Add(interceptor);
            Interceptors = arr;
            Targets.Add(new PointcutTarget(attributeTypeName, PointcutTargetType.Attribute));
        }

        #endregion

    }
}