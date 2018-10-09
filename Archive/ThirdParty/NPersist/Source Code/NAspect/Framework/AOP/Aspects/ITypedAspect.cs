// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Marker interface for typed aspects.    
    /// </summary>
    /// <example >
    /// <code lang="CS">
    /// [AspectTarget(TargetSignature = "*")]
    /// [Mixin(typeof(MyMixin))]
    /// [Mixin(typeof(MyOtherMixin))]
    /// public class CacheAspect : ITypedAspect //marked iface only
    /// {
    ///     [Interceptor(index = 1,TargetSignature="get_*")]
    ///     public object CacheInterceptor (MethodInvocation call)
    ///     {
    ///       ...
    ///     }
    /// 
    ///     [Interceptor(index = 2,TargetSignature="get_*")]
    ///     public void AfterInterceptor (AfterMethodInvocation call)
    ///     {
    ///        ...
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="InterceptorAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    /// <seealso cref="AspectTargetAttribute"/>
    /// <seealso cref="MixinAttribute"/>
    public interface ITypedAspect : IAspect
    {
    }
}