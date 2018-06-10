// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Text;
using System.Collections;
using Puzzle.NAspect.Framework.Interception;

namespace Puzzle.NAspect.Framework.Aop
{
	public class Pointcut : PointcutBase
	{
        public Pointcut()
        {
            ;
        }

        /// <summary>
        /// SignaturePointcut ctor. 
        /// </summary>
        /// <param name="interceptors">Untyped list of <c>IInterceptor</c>s to be applied to by this pointcut</param>
        public Pointcut(IList interceptors) => Interceptors = interceptors;

	    /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="interceptors">Array of <c>IInterceptors</c> to be applied by this pointcut</param>
        public Pointcut(IInterceptor[] interceptors) => Interceptors = new ArrayList(interceptors);

	    /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="interceptor">a single <c>IInterceptor</c> that should be applied by this pointcut</param>
        public Pointcut(IInterceptor interceptor) => Interceptors = new ArrayList(new IInterceptor[] { interceptor });

	    /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="interceptor">Interceptor delegate to apply on matched methods, valid delegates are <c>BeforeDelegate</c>, <c>AroundDelegate</c> and <c>AfterDelegate</c></param>
        public Pointcut(Delegate interceptor)
        {
            ArrayList arr = new ArrayList();
            arr.Add(interceptor);
            Interceptors = arr;
        }

        /// <summary>
        /// SignaturePointcut ctor. 
        /// </summary>
        /// <param name="targets">Untyped list of <c>PointcutTarget</c>s to be used by this pointcut</param>
        /// <param name="interceptors">Untyped list of <c>IInterceptor</c>s to be applied to by this pointcut</param>
        public Pointcut(IList targets, IList interceptors)
        {
            Targets = targets;
            Interceptors = interceptors;
        }

        /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="targets">Untyped list of <c>PointcutTarget</c>s to be used by this pointcut</param>
        /// <param name="interceptors">Array of <c>IInterceptors</c> to be applied by this pointcut</param>
        public Pointcut(IList targets, IInterceptor[] interceptors)
        {
            Targets = targets;
            Interceptors = new ArrayList(interceptors);
        }

        /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="targets">Untyped list of <c>PointcutTarget</c>s to be used by this pointcut</param>
        /// <param name="interceptor">a single <c>IInterceptor</c> that should be applied by this pointcut</param>
        public Pointcut(IList targets, IInterceptor interceptor)
        {
            Targets = targets;
            Interceptors = new ArrayList(new IInterceptor[] { interceptor });
        }

        /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="targets">Untyped list of <c>PointcutTarget</c>s to be used by this pointcut</param>
        /// <param name="interceptor">Interceptor delegate to apply on matched methods, valid delegates are <c>BeforeDelegate</c>, <c>AroundDelegate</c> and <c>AfterDelegate</c></param>
        public Pointcut(IList targets, Delegate interceptor)
        {
            Targets = targets;
            ArrayList arr = new ArrayList();
            arr.Add(interceptor);
            Interceptors = arr;
        }

	}
}
