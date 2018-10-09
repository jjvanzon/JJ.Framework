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
    /// Interface implemented by all pointcuts.
    /// </summary>
    public interface IPointcut
    {
        /// <summary>
        /// Untyped list of <c>IInterceptor</c>s and <c>BeforeDelegate</c>, <c>AroundDelegate</c> and <c>AfterDelegate</c>
        /// </summary>
        IList Interceptors { get; }

        /// <summary>
        /// Matches a method with the pointuct
        /// </summary>
        /// <param name="method">The method to match</param>
        /// <returns>True if the pointcut matched the method, otherwise false</returns>
        bool IsMatch(MethodBase method, Type type);

        IList Targets { get; set; }

        string Name { get; set; }
    }
}