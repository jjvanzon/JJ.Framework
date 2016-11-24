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
using System.Collections;
using System.Reflection.Emit;
using Puzzle.NAspect.Framework.Interception;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Aspect that matches target types based on interfaces implemented by the target.
    /// </summary>
    public class InterfaceAspect : GenericAspectBase
    {
        /// <summary>
        /// Interface aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="interfaceType">Type of the interface to match.</param>
        /// <param name="mixins">IList of mixin types.</param>
        /// <param name="pointcuts">IList of IPointcut instances.</param>
        public InterfaceAspect(string Name, Type interfaceType, IList mixins, IList pointcuts)
        {
            this.Name = Name;
            Mixins = mixins;
            Pointcuts = pointcuts;
            Targets.Add(new AspectTarget(interfaceType, AspectTargetType.Interface));
        }

        /// <summary>
        /// Interface aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="interfaceType">Type of the interface to match.</param>
        /// <param name="mixins">Type[] array of mixin types</param>
        /// <param name="pointcuts">IPointcut[] array of pointcut instances</param>
        public InterfaceAspect(string Name, Type interfaceType, Type[] mixins, IPointcut[] pointcuts)
        {
            this.Name = Name;
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
            Targets.Add(new AspectTarget(interfaceType, AspectTargetType.Interface));
        }

        /// <summary>
        /// Interface aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="interfaceType">Type of the interface to match</param>
        /// <param name="TargetMethodsignature">string Signature of methods to match.</param>
        /// <param name="Interceptor">Instance of an IInterceptor</param>
        public InterfaceAspect(string Name, Type interfaceType, string TargetMethodsignature, IInterceptor Interceptor)
        {
            this.Name = Name;
            Pointcuts.Add(new SignaturePointcut(TargetMethodsignature, Interceptor));
            Targets.Add(new AspectTarget(interfaceType, AspectTargetType.Interface));
        }

        /// <summary>
        /// Interface aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="interfaceTypeName">Full name of the type of the interface to match.</param>
        /// <param name="mixins">IList of mixin types.</param>
        /// <param name="pointcuts">IList of IPointcut instances.</param>
        public InterfaceAspect(string Name, string interfaceTypeName, IList mixins, IList pointcuts)
        {
            this.Name = Name;
            Mixins = mixins;
            Pointcuts = pointcuts;
            Targets.Add(new AspectTarget(interfaceTypeName, AspectTargetType.Interface));
        }

        /// <summary>
        /// Interface aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="interfaceTypeName">Full name of the type of the interface to match.</param>
        /// <param name="mixins">Type[] array of mixin types</param>
        /// <param name="pointcuts">IPointcut[] array of pointcut instances</param>
        public InterfaceAspect(string Name, string interfaceTypeName, Type[] mixins, IPointcut[] pointcuts)
        {
            this.Name = Name;
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
            Targets.Add(new AspectTarget(interfaceTypeName, AspectTargetType.Interface));
        }

        /// <summary>
        /// Interface aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="interfaceTypeName">Full name of the type of the interface to match</param>
        /// <param name="TargetMethodsignature">string Signature of methods to match.</param>
        /// <param name="Interceptor">Instance of an IInterceptor</param>
        public InterfaceAspect(string Name, string interfaceTypeName, string TargetMethodsignature, IInterceptor Interceptor)
        {
            this.Name = Name;
            Pointcuts.Add(new SignaturePointcut(TargetMethodsignature, Interceptor));
            Targets.Add(new AspectTarget(interfaceTypeName, AspectTargetType.Interface));
        }

    }
}