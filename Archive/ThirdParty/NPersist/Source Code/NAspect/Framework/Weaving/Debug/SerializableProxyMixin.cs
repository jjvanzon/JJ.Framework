// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

#if NET2 && DEBUG
using System;
using System.Collections;
using System.Reflection;
using Puzzle.NAspect.Debug.Serialization;
using Puzzle.NAspect.Debug.Serialization.Elements;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Interception;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Mixin used by the VS.NET 2005 debugger visualizer.
    /// this is only mixed in if the debugger visualizer is available.
    /// </summary>
    public class SerializableProxyMixin : ISerializableProxy, IProxyAware
    {
        private IAopProxy target;

        #region ISerializableProxy Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SerializedProxy GetSerializedProxy()
        {
            SerializedProxy proxy = new SerializedProxy();

            VizType vizType = new VizType();
            vizType.Name = target.GetType().Name;
            vizType.FullName = target.GetType().FullName;

            Type tmp = target.GetType();
            while (typeof (IAopProxy).IsAssignableFrom(tmp))
                tmp = tmp.BaseType;

            vizType.BaseName = tmp.Name;

            IList mixins = (IList) MethodCache.mixinsLookup[target.GetType()];
            foreach (Type mixinType in mixins)
            {
                VizMixin vizMixin = new VizMixin();
                vizMixin.TypeName = mixinType.Name;
                vizMixin.FullTypeName = mixinType.FullName;
                vizType.Mixins.Add(vizMixin);
            }
            IList aspects = (IList) MethodCache.aspectsLookup[target.GetType()];
            foreach (IAspect aspect in aspects)
            {
                IGenericAspect tmpAspect;
                if (aspect is IGenericAspect)
                    tmpAspect = (IGenericAspect) aspect;
                else
                    tmpAspect = TypedToGenericConverter.Convert((ITypedAspect) aspect);


                VizAspect vizAspect = new VizAspect();
                vizAspect.Name = tmpAspect.Name;
            }
            IList methods = (IList) MethodCache.methodsLookup[target.GetType()];
            foreach (string methodId in methods)
            {
                MethodBase methodBase = (MethodBase) MethodCache.methodLookup[methodId];
                if (methodBase is ConstructorInfo)
                {
                    ConstructorInfo constructor = (ConstructorInfo) methodBase;
                    VizConstructor vizConstructor = new VizConstructor();
                    vizConstructor.Name = constructor.Name;


                    ParameterInfo[] paramInfos = constructor.GetParameters();
                    SerializeParameters(vizConstructor, paramInfos);

                    IList interceptors = (IList) MethodCache.methodInterceptorsLookup[methodId];
                    SerializeInterceptors(vizConstructor, interceptors);
                    vizConstructor.OwnerType = vizType;
                    vizType.Methods.Add(vizConstructor);
                }
                else if (methodBase is MethodInfo)
                {
                    MethodInfo method = (MethodInfo) methodBase;
                    VizMethod vizMethod = new VizMethod();
                    vizMethod.Name = method.Name;
                    vizMethod.ReturnType = method.ReturnType.Name;


                    ParameterInfo[] paramInfos = method.GetParameters();
                    SerializeParameters(vizMethod, paramInfos);

                    IList interceptors = (IList) MethodCache.methodInterceptorsLookup[methodId];
                    SerializeInterceptors(vizMethod, interceptors);
                    vizMethod.OwnerType = vizType;
                    vizType.Methods.Add(vizMethod);
                }
            }


            proxy.ProxyType = vizType;
            return proxy;
        }

        private static void SerializeParameters(VizMethodBase vizMethodBase, ParameterInfo[] paramInfos)
        {
            foreach (ParameterInfo paramInfo in paramInfos)
            {
                VizParameter vizParameter = new VizParameter();
                vizParameter.Name = paramInfo.Name;
                vizParameter.ParameterTypeName = paramInfo.ParameterType.Name;
                vizMethodBase.Parameters.Add(vizParameter);
            }
        }

        private void SerializeInterceptors(VizMethodBase vizMethodBase, IList interceptors)
        {
            foreach (object interceptor in interceptors)
            {
                VizInterceptorType interceptorType = VizInterceptorType.Around;
                VizInterceptor vizInterceptor = new VizInterceptor();
                if (interceptor is IAfterInterceptor)
                {
                    interceptorType = VizInterceptorType.After;
                    vizInterceptor.Name = interceptor.GetType().Name;
                }
                else if (interceptor is IBeforeInterceptor)
                {
                    interceptorType = VizInterceptorType.Before;
                    vizInterceptor.Name = interceptor.GetType().Name;
                }
                else if (interceptor is IAroundInterceptor)
                {
                    interceptorType = VizInterceptorType.Around;
                    vizInterceptor.Name = interceptor.GetType().Name;
                }
                else if (interceptor is AroundDelegate)
                {
                    interceptorType = VizInterceptorType.Around;
                    Delegate ad = (Delegate) interceptor;
                    vizInterceptor.Name = ad.Method.DeclaringType.Name + "." + ad.Method.Name;
                }
                else if (interceptor is AfterDelegate)
                {
                    interceptorType = VizInterceptorType.After;
                    Delegate ad = (Delegate) interceptor;
                    vizInterceptor.Name = ad.Method.DeclaringType.Name + "." + ad.Method.Name;
                }
                else if (interceptor is BeforeDelegate)
                {
                    interceptorType = VizInterceptorType.Before;
                    Delegate ad = (Delegate) interceptor;
                    vizInterceptor.Name = ad.Method.DeclaringType.Name + "." + ad.Method.Name;
                }


                vizInterceptor.TypeName = interceptor.GetType().Name;

                vizInterceptor.InterceptorType = interceptorType;

                if (interceptor.GetType().GetCustomAttributes(typeof (MayBreakFlowAttribute), false).Length > 0)
                {
                    vizInterceptor.MayBreakFlow = true;
                }

                if (interceptor.GetType().GetCustomAttributes(typeof (IsRequiredAttribute), false).Length > 0)
                {
                    vizInterceptor.IsRequired = true;
                }

                object[] exceptionTypes = interceptor.GetType().GetCustomAttributes(typeof (ThrowsAttribute), false);
                foreach (ThrowsAttribute throws in exceptionTypes)
                {
                    vizInterceptor.ThrowsExceptionTypes.Add(throws.ExceptionType.Name);
                }

                vizMethodBase.Interceptors.Add(vizInterceptor);
            }
        }

        #endregion

        #region IProxyAware Members

        /// <summary>
        /// Assigns the proxy to the mixin.
        /// </summary>
        /// <param name="target">The proxy</param>
        public void SetProxy(IAopProxy target) => this.target = target;

        #endregion
    }
}

#endif