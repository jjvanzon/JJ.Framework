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
    /// Class that converts typed aspects into generic aspects.
    /// </summary>
    public class TypedToGenericConverter
    {
        /// <summary>
        /// Convert a typed aspect into a generic one.
        /// </summary>
        /// <param name="aspect"></param>
        /// <returns></returns>
        public static IGenericAspect Convert(ITypedAspect aspect)
        {
            IGenericAspect newAspect = null;

            IList mixins = new ArrayList();
            IList pointcuts = new ArrayList();

            AddMixins(aspect, mixins);

            AddInterceptors(aspect, pointcuts);


            newAspect = CreateAspect(aspect, newAspect, mixins, pointcuts);

            return newAspect;
        }

        private static void AddInterceptors(ITypedAspect aspect, IList pointcuts)
        {
            ArrayList methodsList = new ArrayList();
            MethodInfo[] methods =
                aspect.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                            BindingFlags.DeclaredOnly);
            foreach (MethodInfo method in methods)
            {
                object[] interceptorAttributes = method.GetCustomAttributes(typeof (InterceptorAttribute), false);
                if (interceptorAttributes != null && interceptorAttributes.Length > 0)
                {
                    methodsList.Add(method);
                }
            }

            methodsList.Sort(new InterceptorMethodSorter());

            foreach (MethodInfo method in methodsList)
            {
                object[] interceptorAttributes = method.GetCustomAttributes(typeof (InterceptorAttribute), false);
                if (interceptorAttributes != null)
                {
                    InterceptorAttribute interceptor = (InterceptorAttribute) interceptorAttributes[0];
                    IPointcut pointcut = null;
                    Delegate interceptorDelegate = CreateDelegate(aspect, method);
                    if (interceptor.TargetAttribute != null)
                    {
                        pointcut = new AttributePointcut(interceptor.TargetAttribute, interceptorDelegate);
                    }
                    else if (interceptor.TargetSignature != null)
                    {
                        pointcut = new SignaturePointcut(interceptor.TargetSignature, interceptorDelegate);
                    }
                    else
                    {
                        throw new Exception("Interceptor attribute does not contain any target info");
                    }
                    pointcuts.Add(pointcut);
                }
            }
        }

        private static Delegate CreateDelegate(ITypedAspect aspect, MethodInfo method)
        {
            Delegate interceptorDelegate = null;
            Type paramType = method.GetParameters()[0].ParameterType;
            if (paramType == typeof (MethodInvocation))
            {
                interceptorDelegate = Delegate.CreateDelegate(typeof (AroundDelegate), aspect, method.Name);
            }
            else if (paramType == typeof (AfterMethodInvocation))
            {
                interceptorDelegate = Delegate.CreateDelegate(typeof (AfterDelegate), aspect, method.Name);
            }
            else if (paramType == typeof (BeforeMethodInvocation))
            {
                interceptorDelegate = Delegate.CreateDelegate(typeof (BeforeDelegate), aspect, method.Name);
            }
            else
            {
                throw new Exception("Unknown interceptor delegate");
            }
            return interceptorDelegate;
        }

        private static IGenericAspect CreateAspect(ITypedAspect aspect, IGenericAspect newAspect, IList mixins,
                                                   IList pointcuts)
        {
            object[] aspectTargetAttributes =
                aspect.GetType().GetCustomAttributes(typeof (AspectTargetAttribute), false);
            if (aspectTargetAttributes != null)
            {
                AspectTargetAttribute aspectTargetAttribute = (AspectTargetAttribute) aspectTargetAttributes[0];
                if (aspectTargetAttribute.TargetAttribute != null)
                    newAspect =
                        new AttributeAspect(aspect.GetType().Name, aspectTargetAttribute.TargetAttribute, mixins,
                                            pointcuts);
                else if (aspectTargetAttribute.TargetInterface != null)
                    newAspect =
                        new InterfaceAspect(aspect.GetType().Name, aspectTargetAttribute.TargetInterface, mixins,
                                            pointcuts);
                else if (aspectTargetAttribute.TargetSignature != null)
                    newAspect =
                        new SignatureAspect(aspect.GetType().Name, aspectTargetAttribute.TargetSignature, mixins,
                                            pointcuts);
                else if (aspectTargetAttribute.TargetType != null)
                    newAspect =
                        new SignatureAspect(aspect.GetType().Name, aspectTargetAttribute.TargetType, mixins, pointcuts);
                else
                    throw new Exception("No target specified");
            }
            return newAspect;
        }

        private static void AddMixins(ITypedAspect aspect, IList mixins)
        {
            object[] mixinAttributes = aspect.GetType().GetCustomAttributes(typeof (MixinAttribute), false);
            if (mixinAttributes != null)
            {
                foreach (MixinAttribute mixinAttribute in mixinAttributes)
                {
                    mixins.Add(mixinAttribute.MixinType);
                }
            }
        }
    }

    /// <summary>
    /// Class that sorts interceptor methods based on index parameters
    /// </summary>
    public class InterceptorMethodSorter : IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            MethodInfo m1 = (MethodInfo) x;
            MethodInfo m2 = (MethodInfo) y;

            InterceptorAttribute i1 =
                (InterceptorAttribute) m1.GetCustomAttributes(typeof (InterceptorAttribute), false)[0];
            InterceptorAttribute i2 =
                (InterceptorAttribute) m2.GetCustomAttributes(typeof (InterceptorAttribute), false)[0];

            return i1.Index - i2.Index;
        }
    }
}