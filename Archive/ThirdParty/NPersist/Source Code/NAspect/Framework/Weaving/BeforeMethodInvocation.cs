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
using System.Diagnostics;
using System.Reflection;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Representation of a "before" method call.
    /// Meaning this will fire before the base implementation is invoked.
    /// </summary>
    public class BeforeMethodInvocation
    {
        private MethodInvocation invocation;


        /// <summary>
        /// BeforeMethodInvocation ctor.
        /// </summary>
        /// <param name="invocation">MethodInvocation that should be wrapped</param>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public BeforeMethodInvocation(MethodInvocation invocation) => this.invocation = invocation;

        /// <summary>
        /// Untyped list of InterceptedParameter instances.
        /// </summary>
        public IList Parameters => invocation.Parameters;

        /// <summary>
        /// The intercepted method. (in the dynamic proxy)
        /// </summary>
        public MethodBase Method => invocation.Method;

        /// <summary>
        /// The object on which the method was invoked.
        /// </summary>
        public IAopProxy Target => invocation.Target;

        /// <summary>
        /// The return type of the method (if available, ctors do not have a return type).
        /// </summary>
        public Type ReturnType => invocation.ReturnType;

        /// <summary>
        /// Returns the absolute signature of the call.
        /// </summary>
        public string Signature => invocation.Signature;

        /// <summary>
        /// Returns the value signature of the call.
        /// parameter values are represented with ".ToString()"
        /// </summary>
        public string ValueSignature => invocation.ValueSignature;
    }
}