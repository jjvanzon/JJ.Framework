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
using Puzzle.NAspect.Framework.Tools;
using Puzzle.NAspect.Framework.Utils;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Pointcut that matches method signatures.
    /// </summary>
    public class SignaturePointcut : PointcutBase
    {
        /// <summary>
        /// SignaturePointcut ctor. 
        /// </summary>
        /// <param name="targetMethodSignature">Wildcard pattern of the method signatures to match</param>
        /// <param name="interceptors">Untyped list of <c>IInterceptor</c>s to be applied to by this pointcut</param>
        public SignaturePointcut(string targetMethodSignature, IList interceptors)
        {
            Interceptors = interceptors;
            Targets.Add(new PointcutTarget(targetMethodSignature, PointcutTargetType.Signature));
        }

        /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="targetMethodSignature">Wildcard pattern of the method signatures to match</param>
        /// <param name="interceptors">Array of <c>IInterceptors</c> to be applied by this pointcut</param>
        public SignaturePointcut(string targetMethodSignature, IInterceptor[] interceptors)
        {
            Interceptors = new ArrayList(interceptors);
            Targets.Add(new PointcutTarget(targetMethodSignature, PointcutTargetType.Signature));
        }

        /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="targetMethodSignature">Wildcard pattern of the method signatures to match</param>
        /// <param name="interceptor">a single <c>IInterceptor</c> that should be applied by this pointcut</param>
        public SignaturePointcut(string targetMethodSignature, IInterceptor interceptor)
        {
            Interceptors = new ArrayList(new IInterceptor[] {interceptor});
            Targets.Add(new PointcutTarget(targetMethodSignature, PointcutTargetType.Signature));
        }

        /// <summary>
        /// SignaturePointcut ctor.
        /// </summary>
        /// <param name="targetMethodSignature">Wildcard pattern of the method signatures to match</param>
        /// <param name="interceptor">Interceptor delegate to apply on matched methods, valid delegates are <c>BeforeDelegate</c>, <c>AroundDelegate</c> and <c>AfterDelegate</c></param>
        public SignaturePointcut(string targetMethodSignature, Delegate interceptor)
        {
            ArrayList arr = new ArrayList();
            arr.Add(interceptor);
            Interceptors = arr;
            Targets.Add(new PointcutTarget(targetMethodSignature, PointcutTargetType.Signature));
        }

    }
}