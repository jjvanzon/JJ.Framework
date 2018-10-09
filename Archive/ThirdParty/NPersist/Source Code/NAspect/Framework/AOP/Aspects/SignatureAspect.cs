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
using Puzzle.NAspect.Framework.Tools;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Aspect that matches target types based on wildcard signatures.
    /// ? for ignoring single characters
    /// * for ignoring one or more characters
    /// </summary>
    public class SignatureAspect : GenericAspectBase
    {
        /// <summary>
        /// Signature aspect ctor.
        /// </summary>
        /// <param name="name">Name of the aspect</param>
        /// <param name="targetName">Signature of the target type</param>
        /// <param name="mixins">Untyped list of <c>System.Type</c>s to mixin</param>
        /// <param name="pointcuts">Untyped list of IPointcut instances</param>
        public SignatureAspect(string name, string targetName, IList mixins, IList pointcuts)
        {
            Name = name;
            Mixins = mixins;
            Pointcuts = pointcuts;
            Targets.Add(new AspectTarget(targetName, AspectTargetType.Signature));
        }

        /// <summary>
        /// Signature aspect ctor.
        /// </summary>
        /// <param name="name">Name of the aspect</param>
        /// <param name="targetName">Signature of the target type</param>
        /// <param name="mixins">Array of <c>System.Type</c>s to mixin</param>
        /// <param name="pointcuts">Array of IPointcut instances</param>
        public SignatureAspect(string name, string targetName, Type[] mixins, IPointcut[] pointcuts)
        {
            Name = name;
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
            Targets.Add(new AspectTarget(targetName, AspectTargetType.Signature));
        }

        /// <summary>
        /// Signature aspect ctor.
        /// </summary>
        /// <param name="name">Name of the aspect.</param>
        /// <param name="targetName">Signature of the target type.</param>
        /// <param name="TargetMethodsignature">Signature of the target methods.</param>
        /// <param name="Interceptor">Single <c>IInterceptor</c> that should intercept the matched methods.</param>
        public SignatureAspect(string name, string targetName, string TargetMethodsignature, IInterceptor Interceptor)
        {
            Name = name;
            Pointcuts.Add(new SignaturePointcut(TargetMethodsignature, Interceptor));
            Targets.Add(new AspectTarget(targetName, AspectTargetType.Signature));
        }

        /// <summary>
        /// Signature aspect ctor.
        /// </summary>
        /// <param name="name">Name of the aspect</param>
        /// <param name="targetType">Specific Type to which the aspect should be applied.</param>
        /// <param name="mixins">Untyped list of <c>System.Type</c>s to mixin</param>
        /// <param name="pointcuts">Untyped list of IPointcut instances</param>
        public SignatureAspect(string name, Type targetType, IList mixins, IList pointcuts)
        {
            Name = name;
            Mixins = mixins;
            Pointcuts = pointcuts;
            Targets.Add(new AspectTarget(targetType.FullName, AspectTargetType.Signature));
        }

        /// <summary>
        /// Signature aspect ctor.
        /// </summary>
        /// <param name="name">Name of the aspect</param>
        /// <param name="targetType">Specific Type to which the aspect should be applied.</param>
        /// <param name="mixins">Array of <c>System.Type</c>s to mixin</param>
        /// <param name="pointcuts">Array of IPointcut instances</param>
        public SignatureAspect(string name, Type targetType, Type[] mixins, IPointcut[] pointcuts)
        {
            Name = name;
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
            Targets.Add(new AspectTarget(targetType.FullName, AspectTargetType.Signature));
        }

        /// <summary>
        /// Signature aspect ctor.
        /// </summary>
        /// <param name="name">Name of the aspect</param>
        /// <param name="targetType">Specific Type to which the aspect should be applied.</param>
        /// <param name="targetMethodsignature">Signature of the target methods.</param>
        /// <param name="interceptor">Single <c>IInterceptor</c> that should intercept the matched methods.</param>
        public SignatureAspect(string name, Type targetType, string targetMethodsignature, IInterceptor interceptor)
        {
            Name = name;
            Pointcuts.Add(new SignaturePointcut(targetMethodsignature, interceptor));
            Targets.Add(new AspectTarget(targetType.FullName, AspectTargetType.Signature));
        }
    }
}