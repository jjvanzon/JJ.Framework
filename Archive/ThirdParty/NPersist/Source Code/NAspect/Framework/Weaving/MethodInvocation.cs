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
using Puzzle.NAspect.Framework.Interception;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Representation of a method call.
    /// </summary>
  //  [DebuggerStepThrough()]
    public class MethodInvocation
    {
        /// <summary>
        /// The object on which the method was invoked.
        /// </summary>
        public readonly IAopProxy Target;

        /// <summary>
        /// The object on which the method was invoked.
        /// </summary>
        public readonly object ExecutionTarget;

        /// <summary>
        /// The intercepted method. (in the dynamic proxy)
        /// </summary>
        public readonly MethodBase Method;

        /// <summary>
        /// Untyped list of <c>InterceptedParameters</c>.
        /// </summary>
        public readonly InterceptedParameter[] Parameters;

        /// <summary>
        /// Object array of the raw parameter values.
        /// </summary>
        public readonly object[] RawParameters;

        /// <summary>
        /// The return type of the method (if available, ctors do not have a return type).
        /// </summary>
        public readonly Type ReturnType;
        
#if NET2
        public FastInvokeHandler Handler;
#endif

        /// <summary>
        /// The intercepted methods base implementation. (in the base type)
        /// </summary>
        private readonly MethodBase EndMethod;

        /// <summary>
        /// Untyped list of <c>IInterceptor</c>'s or <c>BeforeDelegate</c>, <c>AroundDelegate</c> or <c>AfterDelegate</c>
        /// </summary>
        private IList Interceptors;

        /// <summary>
        /// current interception chain step. (current interceptor index)
        /// </summary>
        private int Step = 0;

        #region constructor

        /// <summary>
        /// Ctor for MethodInvocation
        /// </summary>
        /// <param name="target">The object on which the method was invoked.</param>
        /// <param name="method">The intercepted method. (in the dynamic proxy)</param>
        /// <param name="endMethod">The intercepted methods base implementation. (in the base type)</param>
        /// <param name="parameters">Untyped list of <c>InterceptedParameters</c>.</param>
        /// <param name="returnType">The return type of the method (if available, ctors do not have a return type).</param>
        /// <param name="interceptors">Untyped list of <c>IInterceptor</c>'s or <c>BeforeDelegate</c>, <c>AroundDelegate</c> or <c>AfterDelegate</c></param>
        [DebuggerStepThrough()]
        public MethodInvocation(IAopProxy target, object executionTarget, MethodBase method, MethodBase endMethod,
                                InterceptedParameter[] parameters, object[] rawParameters, Type returnType, IList interceptors)
        {
            Target = target;
            ExecutionTarget = executionTarget;
            Method = method;
            EndMethod = endMethod;
            Parameters = parameters;
            RawParameters = rawParameters;
            ReturnType = returnType;
            Interceptors = interceptors;
        }

        #endregion

        #region Proceed

        /// <summary>
        /// Executes the next step of the interception chain.
        /// </summary>
        /// <returns>The result of the next interceptor or base implementation</returns>
        [DebuggerStepThrough()]
        [DebuggerHidden()]
        public object Proceed()
        {
            if (Step < Interceptors.Count)
            {
                object currentInterceptor = Interceptors[Step];
                if (currentInterceptor is IAfterInterceptor)
                {
                    return InterceptAfter(currentInterceptor);
                }
                else if (currentInterceptor is IBeforeInterceptor)
                {
                    return InterceptBefore(currentInterceptor);
                }
                else if (currentInterceptor is IAroundInterceptor)
                {
                    return InterceptAround(currentInterceptor);
                }
                else if (currentInterceptor is AfterDelegate)
                {
                    return InterceptAfterDelegate(currentInterceptor);
                }
                else if (currentInterceptor is BeforeDelegate)
                {
                    return InterceptBeforeDelegate(currentInterceptor);
                }
                else if (currentInterceptor is AroundDelegate)
                {
                    return InterceptAroundDelegate(currentInterceptor);
                }
                else
                {
                    throw new Exception("Unknown interceptor type");
                }
            }
            else
            {
                return CallEndMethod();
            }
        }

        [DebuggerStepThrough()]
        [DebuggerHidden()]
        private object InterceptAroundDelegate(object currentInterceptor)
        {
            AroundDelegate interceptor = (AroundDelegate) currentInterceptor;
            Step++;
            return interceptor(this);
        }

        [DebuggerStepThrough()]
        [DebuggerHidden()]
        private object InterceptBeforeDelegate(object currentInterceptor)
        {
            BeforeDelegate interceptor = (BeforeDelegate) currentInterceptor;
            interceptor(new BeforeMethodInvocation(this));
            Step++;
            object res = Proceed();

            return res;
        }

        [DebuggerStepThrough()]
        [DebuggerHidden()]
        private object InterceptAfterDelegate(object currentInterceptor)
        {
            AfterDelegate interceptor = (AfterDelegate) currentInterceptor;
            Step++;
            object res = Proceed();
            interceptor(new AfterMethodInvocation(this));

            return res;
        }

        [DebuggerStepThrough()]
        [DebuggerHidden()]
        private object InterceptAround(object currentInterceptor)
        {
            //invoke the next interceptor
            IAroundInterceptor interceptor = (IAroundInterceptor) currentInterceptor;
            Step++;
            return interceptor.HandleCall(this);
        }

        [DebuggerStepThrough()]
        [DebuggerHidden()]
        private object InterceptBefore(object currentInterceptor)
        {
            IBeforeInterceptor beforeInterceptor = (IBeforeInterceptor) currentInterceptor;
            beforeInterceptor.BeforeCall(new BeforeMethodInvocation(this));
            Step++;
            object res = Proceed();

            return res;
        }

        [DebuggerStepThrough()]
        [DebuggerHidden()]
        private object InterceptAfter(object currentInterceptor)
        {
            IAfterInterceptor afterInterceptor = (IAfterInterceptor) currentInterceptor;
            Step++;
            object res = Proceed();
            afterInterceptor.AfterCall(new AfterMethodInvocation(this));

            return res;
        }

        #endregion

        #region CallEndMethod

        [DebuggerStepThrough()]
        [DebuggerHidden()]
        private object CallEndMethod()
        {
            object[] parr;
            if (Method is ConstructorInfo)
            {
                parr = new object[RawParameters.Length - 1];
                Array.Copy(RawParameters, 1, parr, 0, RawParameters.Length - 1);
            }
            else
            {
                parr = RawParameters;
            }

#if NET2
            FastInvokeHandler fastCall = Handler;
            object result = fastCall(ExecutionTarget, parr);
#else
            object result = EndMethod.Invoke(Target, parr);
#endif
            if (Method is ConstructorInfo)
            {
                for (int i = 0; i < parr.Length; i++)
                    RawParameters[i + 1] = parr[i];
            }

            return result;
        }

        #endregion

        #region Signature

        /// <summary>
        /// Returns the absolute signature of the call.
        /// </summary>
        public string Signature
        {
            get
            {
                string parameters = "";
                foreach (InterceptedParameter param in Parameters)
                    parameters += param.Type.FullName + ",";

                if (parameters != "")
                    parameters = parameters.Substring(0, parameters.Length - 1);

                if (Method is ConstructorInfo)
                {
                    return string.Format("{2} {0}({1})", Method.Name, parameters, Target.GetType().FullName);
                }
                else
                {
                    return
                        string.Format("{3} {0} {1}({2})", ReturnType == null ? "Void" : ReturnType.ToString(),
                                      Method.Name, parameters, Target.GetType().FullName);
                }
            }
        }

        #endregion

        #region ValueSignature

        /// <summary>
        /// Returns the value signature of the call.
        /// parameter values are represented with ".ToString()"
        /// </summary>
        public string ValueSignature
        {
            get
            {
                string parameters = "";
                foreach (InterceptedParameter param in Parameters)
                {
                    if (param.Value == null)
                    {
                        parameters += "null,";
                    }
                    else
                    {
                        parameters += param.Value.ToString() + ",";
                    }
                }

                if (parameters != "")
                    parameters = parameters.Substring(0, parameters.Length - 1);

                if (Method is ConstructorInfo)
                {
                    return string.Format("{2} {0}({1})", Method.Name, parameters, Target.GetType().FullName);
                }
                else
                {
                    return
                        string.Format("{3} {0} {1}({2})", ReturnType == null ? "Void" : ReturnType.ToString(),
                                      Method.Name, parameters, Target.GetType().FullName);
                }
            }
        }

        #endregion
    }
}