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
using Puzzle.NAspect.Framework.ConfigurationElements;
using Puzzle.NCore.Framework.Logging;
#if NET2
#endif

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Interface for Aop engines.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Util. method that inserts an object in the beginning of a parameter list
        /// </summary>
        /// <param name="state">State object to insert in parameter list. this object can be intercepted by ctor interceptors later on.</param>
        /// <param name="args">object array of boxed parameter values</param>
        /// <returns>A new array of parameters, including the state object</returns>
        object[] AddStateToCtorParams(object state, object[] args);

        /// <summary>
        /// The active engine configuration.
        /// </summary>
        EngineConfiguration Configuration { get; set; }

        /// <summary>
        /// Creates a subclass proxy.
        /// This is primary used by .NET 1.x users or where you need to create proxies of dynamic types in .NET 2.0.        
        /// </summary>
        /// <param name="type">Type to proxify</param>
        /// <param name="args">Object array of boxed parameter values</param>
        /// <returns>The proxy instance</returns>
        /// <example>
        /// <code lang="CS">
        /// Foo myFoo = (Foo)engine.CreateProxy(typeof(Foo));
        /// </code>
        /// </example>
        object CreateProxy(Type type, params object[] args);

        /// <summary>
        /// Creates a subclass proxy type
        /// </summary>
        /// <param name="type">Type to proxify</param>
        /// <returns>The proxy type</returns>
        Type CreateProxyType(Type type);

#if NET2
        /// <summary>
        /// Creates a subclass proxy of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">Type to proxify</typeparam>
        /// <param name="args">Object array of boxed parameter values</param>
        /// <returns>The proxy instance</returns>
        T CreateProxy<T>(params object[] args);

        /// <summary>
        /// Creates a subclass proxy of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">Type to proxify</typeparam>
        /// <param name="state">State object that should be used by ctor interceptors</param>
        /// <param name="args">Object array of boxed parameter values</param>
        /// <returns>The proxy instance</returns>
        T CreateProxyWithState<T>(object state, params object[] args);
#endif


        /// <summary>
        /// Creates a subclass proxy.
        /// This is primary used by .NET 1.x users or where you need to create proxies of dynamic types in .NET 2.0.        
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type">Type to proxify</param>
        /// <param name="args">Object array of boxed parameter values</param>
        /// <returns>The proxy instance</returns>
        /// <example>
        /// <code lang="CS">
        /// Foo myFoo = (Foo)engine.CreateProxyWithState(typeof(Foo),"I can be used in an ctor interceptor");
        /// </code>
        /// </example>
        object CreateProxyWithState(object state, Type type, params object[] args);

        /// <summary>
        /// Creates a interface wrapper proxy
        /// </summary>
        /// <param name="instance">The instance to wrap</param>
        /// <returns>Proxy object which redirect calls to the real instance</returns>
        object CreateWrapper(object instance);

        /// <summary>
        /// Creates an interface wrapper proxy type
        /// </summary>
        /// <param name="type">Type to proxify</param>
        /// <returns>The proxy type</returns>
        Type CreateWrapperType(Type type);

        /// <summary>
        /// Log manager.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// aopEngine.LogManager.Loggers.Add(new ConsoleLogger());
        /// </code>
        /// </example>
        ILogManager LogManager { get; set; }
    }
}