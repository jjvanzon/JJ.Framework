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

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Attribute that can be applied to interceptor methods in a typed aspect.
    /// Interceptor methods must match delegate signatures of either <c>AroundDelegate</c>, <c>BeforeDelegate</c> or <c>AfterDelegate</c> 
    /// </summary>
    /// <seealso cref="InterceptorAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    /// <seealso cref="AspectTargetAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    [AttributeUsage(AttributeTargets.Method)]
    public class InterceptorAttribute : Attribute
    {
        #region Property Index

        private int index;

        /// <summary>
        /// Call chain index of the interceptor, mark your first interceptor with index=1 , then next with index=2 etc.
        /// </summary>
        public virtual int Index
        {
            get { return index; }
            set { index = value; }
        }

        #endregion

        #region Property TargetAttribute

        private Type targetAttribute;

        /// <summary>
        /// When a type is matched, every method decorated with an attribute of this type with get the current interceptor applied.        
        /// </summary>
        /// <example>
        /// <para>Sample of method that should get the interceptor applied:</para>
        /// <code lang="CS">
        /// [AttributeThatIWantToPointcutOn]
        /// public virtual void Foo()
        /// {
        /// }
        /// </code>
        /// 
        /// <para>Sample interceptor in your typed aspect:</para>
        /// <code lang="CS">
        /// [Interceptor(Index=1,TargetAttribute=typeof(AttributeThatIWantToPointcutOn))]
        /// private object MyAroundInterceptor(MethodInvocation call)
        /// {
        ///     return call.Proceed();
        /// }
        /// </code>
        /// </example>
        public virtual Type TargetAttribute
        {
            get { return targetAttribute; }
            set { targetAttribute = value; }
        }

        #endregion

        #region Property TargetSignature

        private string targetSignature;

        /// <summary>
        /// When a type is matched, every method with this signature will be matched.
        /// Valid wildcards are:
        /// ? for ignoring single characters
        /// * for ignoring one or more characters
        /// </summary>
        /// <example>
        /// <para>Sample of method that should get the interceptor applied:</para>
        /// <code lang="CS">      
        /// public virtual void Foo()
        /// {
        /// }
        /// </code>
        /// 
        /// <para>Sample interceptor in your typed aspect:</para>
        /// <code lang="CS">
        /// [Interceptor(Index=1,TargetSignature="*void Foo()"))]
        /// private object MyAroundInterceptor(MethodInvocation call)
        /// {
        ///     return call.Proceed();
        /// }
        /// </code>
        /// </example>
        public virtual string TargetSignature
        {
            get { return targetSignature; }
            set { targetSignature = value; }
        }

        #endregion

        /// <summary>
        /// InterceptorAttribute ctor.
        /// </summary>
        public InterceptorAttribute()
        {
        }
    }


    /// <summary>
    /// Attribute that can be applied to typed aspects.
    /// </summary>
    /// <example>
    /// <para>Example of typed aspect:</para>
    /// <code lang="CS">
    /// [AspectTarget(TargetType=typeof(SomeClassThatGetsThisAspectApplied)]
    /// [Mixin(typeof(MyMixin))]
    /// [Mixin(typeof(MyOther))]
    /// public class MyAspect : ITypedAspect //marker interface only
    /// {
    ///     ...
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="InterceptorAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    /// <seealso cref="AspectTargetAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    public class MixinAttribute : Attribute
    {
        #region Property MixinType

        private Type mixinType;

        /// <summary>
        /// Type of the mixin to be applied to this aspect.
        /// </summary>
        /// <example>
        /// <para>Example of typed aspect:</para>
        /// <code lang="CS">
        /// [AspectTarget(TargetType=typeof(SomeClassThatGetsThisAspectApplied)]
        /// [Mixin(typeof(MyMixin))] //mixes in MyMixin on all targets
        /// public class MyAspect : ITypedAspect ...
        /// </code>
        /// </example>
        public virtual Type MixinType
        {
            get { return mixinType; }
            set { mixinType = value; }
        }

        #endregion

        /// <summary>
        /// Mixin attribute Ctor.
        /// </summary>
        /// <param name="mixinType">A type that should be mixed into every target of this aspect</param>
        /// <example>
        /// <para>Example of typed aspect:</para>
        /// <code lang="CS">
        /// [AspectTarget(TargetType=typeof(SomeClassThatGetsThisAspectApplied)]
        /// [Mixin(typeof(MyMixin))] //mixes in MyMixin on all targets
        /// public class MyAspect : ITypedAspect ...
        /// </code>
        /// </example>
        public MixinAttribute(Type mixinType)
        {
            MixinType = mixinType;
        }
    }

    /// <summary>
    /// Attribute that can be applied to typed aspects.
    /// Determines what types should get this aspect applied.
    /// </summary>
    /// <example>
    /// <code lang="CS">
    /// [AspectTarget(TargetType=typeof(SomeClass)] //SomeClass will get the MyAspect applied to it
    /// [Mixin(typeof(MyMixin))] 
    /// public class MyAspect : ITypedAspect ...
    /// </code>
    /// </example>
    /// <seealso cref="InterceptorAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    /// <seealso cref="AspectTargetAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    public class AspectTargetAttribute : Attribute
    {
        #region Property TargetAttribute

        private Type targetAttribute;

        /// <summary>
        /// Every type decorated with an attribute of this type will get the current aspect applied.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// [AspectTarget(TargetAttribute=typeof(SomeAttribute)] //every type decorated with SomeAttribute will get this aspect applied to it
        /// public class MyAspect : ITypedAspect ...
        /// </code>
        /// </example>
        public virtual Type TargetAttribute
        {
            get { return targetAttribute; }
            set { targetAttribute = value; }
        }

        #endregion

        #region Property TargetInterface

        private Type targetInterface;

        /// <summary>
        /// Every type implementing the interface of this type will get the current aspect applied.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// [AspectTarget(TargetInterface=typeof(SomeInterface)] //every type implementing the SomeInterface interface will get this aspect applied to it
        /// public class MyAspect : ITypedAspect ...
        /// </code>
        /// </example>
        public virtual Type TargetInterface
        {
            get { return targetInterface; }
            set { targetInterface = value; }
        }

        #endregion


        #region Property TargetSignature

        private string targetSignature;

        /// <summary>
        /// Every type with a signature that matches this pattern will get the current aspect applied.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// [AspectTarget(TargetSignature="*SomeClass*")] //every type whose name matches *SomeClass* will get the current aspect applied
        /// public class MyAspect : ITypedAspect ...
        /// </code>
        /// </example>
        public virtual string TargetSignature
        {
            get { return targetSignature; }
            set { targetSignature = value; }
        }

        #endregion

        #region Property TargetType

        private Type targetType;

        /// <summary>
        /// Assigns a single type that should get this aspect applied to it.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// [AspectTarget(TargetType=typeof(SomeClass)] //SomeClass will get the MyAspect applied to it
        /// [Mixin(typeof(MyMixin))] 
        /// public class MyAspect : ITypedAspect ...
        /// </code>
        /// </example> 
        public virtual Type TargetType
        {
            get { return targetType; }
            set { targetType = value; }
        }

        #endregion
    }
}