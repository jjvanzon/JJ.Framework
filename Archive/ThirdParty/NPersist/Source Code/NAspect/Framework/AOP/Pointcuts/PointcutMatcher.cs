// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using System.Reflection;
using System;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// For internal use only.
    /// This class loops through all pointcuts in all aspects and tries to match them for a given method.
    /// </summary>
    public class PointcutMatcher
    {
        /// <summary>
        /// PointcutMatcher ctor.
        /// </summary>
        public PointcutMatcher()
        {
        }


        /// <summary>
        /// Loops through all pointcuts in all aspects and tries to match them for a given method.
        /// </summary>
        /// <param name="method">The method to match</param>
        /// <param name="aspects">Untyped list of <c>IAspects</c></param>
        /// <returns></returns>
        public bool MethodShouldBeProxied(MethodBase method, IList aspects) => MethodShouldBeProxied(method, aspects, null);

        public bool MethodShouldBeProxied(MethodBase method, IList aspects, Type baseType)
        {
            foreach (IAspect aspect in aspects)
            {
                IGenericAspect tmpAspect;
                if (aspect is IGenericAspect)
                    tmpAspect = (IGenericAspect) aspect;
                else
                    tmpAspect = TypedToGenericConverter.Convert((ITypedAspect) aspect);

                foreach (IPointcut pointcut in tmpAspect.Pointcuts)
                {
                    if (pointcut.IsMatch(method, baseType))
                        return true;
                }
            }
            foreach (FixedInterceptorAttribute fixedInterceptorAttribute in method.GetCustomAttributes(typeof(FixedInterceptorAttribute), true))
                return true;

            if (baseType != null)
            {
                foreach (FixedInterceptorAttribute fixedInterceptorAttribute in baseType.GetCustomAttributes(typeof(FixedInterceptorAttribute), true))
                    return true;
            }

            return false;
        }
    }
}