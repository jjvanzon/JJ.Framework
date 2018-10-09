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
using System.Reflection.Emit;
using Puzzle.NAspect.Framework.Interception;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Aspect that matches target types based on attributes applied to the target.
    /// </summary>
    public class AttributeAspect : GenericAspectBase
    {
        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="attributeType">Type of the attribute to match.</param>
        /// <param name="mixins">IList of mixin types.</param>
        /// <param name="pointcuts">IList of IPointcut instances.</param>
        public AttributeAspect(string Name, Type attributeType, IList mixins, IList pointcuts)
        {
            this.Name = Name;
            Mixins = mixins;
            Pointcuts = pointcuts;
            Targets.Add(new AspectTarget(attributeType, AspectTargetType.Attribute));
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="attributeType">Type of the attribute to match.</param>
        /// <param name="mixins">Type[] array of mixin types</param>
        /// <param name="pointcuts">IPointcut[] array of pointcut instances</param>
        public AttributeAspect(string Name, Type attributeType, Type[] mixins, IPointcut[] pointcuts)
        {
            this.Name = Name;
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
            Targets.Add(new AspectTarget(attributeType, AspectTargetType.Attribute));
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="attributeType">Type of the attribute to match</param>
        /// <param name="TargetMethodsignature">string Signature of methods to match.</param>
        /// <param name="Interceptor">Instance of an IInterceptor</param>
        public AttributeAspect(string Name, Type attributeType, string TargetMethodsignature, IInterceptor Interceptor)
        {
            this.Name = Name;
            Pointcuts.Add(new SignaturePointcut(TargetMethodsignature, Interceptor));
            Targets.Add(new AspectTarget(attributeType, AspectTargetType.Attribute));
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="attributeTypeName">Full name of the type of the attribute to match.</param>
        /// <param name="mixins">IList of mixin types.</param>
        /// <param name="pointcuts">IList of IPointcut instances.</param>
        public AttributeAspect(string Name, string attributeTypeName, IList mixins, IList pointcuts)
        {
            this.Name = Name;
            Mixins = mixins;
            Pointcuts = pointcuts;
            Targets.Add(new AspectTarget(attributeTypeName, AspectTargetType.Attribute));
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="attributeTypeName">Full name of the type of the attribute to match.</param>
        /// <param name="mixins">Type[] array of mixin types</param>
        /// <param name="pointcuts">IPointcut[] array of pointcut instances</param>
        public AttributeAspect(string Name, string attributeTypeName, Type[] mixins, IPointcut[] pointcuts)
        {
            this.Name = Name;
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
            Targets.Add(new AspectTarget(attributeTypeName, AspectTargetType.Attribute));
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="Name">Name of the aspect.</param>
        /// <param name="attributeTypeName">Full name of the type of the attribute to match</param>
        /// <param name="TargetMethodsignature">string Signature of methods to match.</param>
        /// <param name="Interceptor">Instance of an IInterceptor</param>
        public AttributeAspect(string Name, string attributeTypeName, string TargetMethodsignature, IInterceptor Interceptor)
        {
            this.Name = Name;
            Pointcuts.Add(new SignaturePointcut(TargetMethodsignature, Interceptor));
            Targets.Add(new AspectTarget(attributeTypeName, AspectTargetType.Attribute));
        }

    }
}