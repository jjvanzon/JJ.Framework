// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Reflection;
using System;

namespace Puzzle.NAspect.Framework.Utils
{
    /// <summary>
    /// Util class.
    /// </summary>
    public class AopTools
    {
        #region GetMethodSignature

        /// <summary>
        /// Returns the signature for a method,property or ctor.
        /// </summary>
        /// <param name="method">a method,property or ctor</param>
        /// <returns>string based representation of the method signature</returns>
        public static string GetMethodSignature(MethodBase method) => method.ToString();

        #endregion

        #region HasFixedAttributes


        public static bool HasFixedAttributes(Type baseType)
        {
            foreach (FixedMixinAttribute fixedMixinAttribute in baseType.GetCustomAttributes(typeof(FixedMixinAttribute), true))
                return true;

            foreach (FixedInterceptorAttribute fixedInterceptorAttribute in baseType.GetCustomAttributes(typeof(FixedInterceptorAttribute), true))
                return true;

            foreach (MethodBase method in baseType.GetMethods())
                foreach (FixedInterceptorAttribute fixedInterceptorAttribute in method.GetCustomAttributes(typeof(FixedInterceptorAttribute), true))
                    return true;

            foreach (MethodBase method in baseType.GetConstructors())
                foreach (FixedInterceptorAttribute fixedInterceptorAttribute in method.GetCustomAttributes(typeof(FixedInterceptorAttribute), true))
                    return true;

            return false;
        }

        #endregion

    }
}