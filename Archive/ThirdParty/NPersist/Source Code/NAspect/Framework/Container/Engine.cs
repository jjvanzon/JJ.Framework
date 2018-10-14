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
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.ConfigurationElements;
using Puzzle.NCore.Framework.Logging;
using Puzzle.NAspect.Framework.Interception;
#if NET2
#endif

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Default NAspect implementation of the aop engine.
    /// </summary>
    /// <example>
    /// <para>To create and use an NAspect engine:</para>
    /// <para>.NET 1.x :</para>
    /// <code lang="CS">
    /// Engine engine = Engine.Default;
    /// Car myCar = (Car)engine.CreateProxy(typeof(Car));
    /// </code>
    /// <para>.NET 2.0 :</para>
    /// <code lang="CS">
    /// Engine engine = Engine.Default;
    /// Car myCar = engine.CreateProxy&lt;Car&gt;();
    /// </code>
    /// </example>
    public class Engine : IEngine
    {
        /// <summary>
        /// Singleton engine instance configured from app.config.
        /// </summary>
        public static readonly IEngine Default = ApplicationContext.Configure();

        private IDictionary proxyLookup;
        private IDictionary wrapperLookup;

        private readonly Hashtable FixedInterceptorLookup = new Hashtable();

        /// <summary>
        /// The aspect matcher to use when matching aspects.
        /// </summary>
        public readonly AspectMatcher AspectMatcher = new AspectMatcher();

        /// <summary>
        /// The pointcut matcher to use when matching pointcuts.
        /// </summary>
        public readonly PointcutMatcher PointCutMatcher = new PointcutMatcher();

        #region Engine

        /// <summary>
        /// AOP Engine constructor
        /// </summary>
        /// <param name="configurationName">Name of configuration/type cache to use</param>
        /// <example >
        /// <para>You can create Engine instances when you want to be sure 
        /// they run with a totally unique configuration.
        /// This is very useful in unit testing scenarios.
        /// </para>
        /// <code lang="CS">
        /// 
        /// Engine engine = new Engine("MyUniqueConfig");
        /// engine.Configuration.Aspects.Add(someAspect);
        /// 
        /// </code>
        /// </example>
        public Engine(string configurationName)
        {
            configuration = new EngineConfiguration();
            proxyLookup = ConfigurationCache.GetProxyLookup(configurationName);
            wrapperLookup = ConfigurationCache.GetWrapperLookup(configurationName);
            logManager = new LogManager();
        }

        #endregion

        #region Public Property Configuration

        private EngineConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        public EngineConfiguration Configuration
        {
            get => configuration;
            set => configuration = value;
        }

        #endregion

        #region Public Property LogManager

        private ILogManager logManager;

        /// <summary>
        /// Log manager.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// aopEngine.LogManager.Loggers.Add(new ConsoleLogger());
        /// </code>
        /// </example>
        public ILogManager LogManager
        {
            get => logManager;
            set => logManager = value;
        }

        #endregion

        #region CreateProxy

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
        public object CreateProxy(Type type, params object[] args)
        {
            if (args == null)
                args = new object[] { null };

            LogMessage message = new LogMessage("Creating proxy for type {0}", type.FullName);
            LogManager.Info(this, message);

            return CreateProxyWithState(null, type, args);
        }

        /// <summary>
        /// Creates a interface wrapper proxy.
        /// This is useful when you want to create an AOP'ed Facade for an existing object.
        /// The wrapper will implement all of the interfaces implmented by the real instance and
        /// simply redirect every call from the wrapper to the real instance through its interceptors.
        /// </summary>
        /// <param name="instance">The instance to wrap</param>
        /// <returns>Proxy object which redirect calls to the real instance</returns>
        /// <example>
        /// <code lang="CS">
        /// IFoo myFoo = (IFoo)engine.CreateWrapper(someFooInstance);
        /// </code>
        /// </example>
        public object CreateWrapper(object instance)
        {
            LogMessage message = new LogMessage("Creating wrapper for type {0}", instance.GetType().FullName);
            LogManager.Info(this, message);

            Type wrapperType = CreateWrapperType(instance.GetType());

            object wrapperObject = Activator.CreateInstance(wrapperType, new object[] {instance});
            return wrapperObject;
        }

        /// <summary>
        /// Util. method that inserts an object in the beginning of a parameter list
        /// </summary>
        /// <param name="state">State object to insert in parameter list. this object can be intercepted by ctor interceptors later on.</param>
        /// <param name="args">object array of boxed parameter values</param>
        /// <returns>A new array of parameters, including the state object</returns>
        public object[] AddStateToCtorParams(object state, object[] args)
        {
            if (args == null)
                args = new object[] {null};

            object[] proxyArgs = new object[args.Length + 1];
            Array.Copy(args, 0, proxyArgs, 1, args.Length);
            proxyArgs[0] = state;

            return proxyArgs;
        }

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
        public object CreateProxyWithState(object state, Type type, params object[] args)
        {
            if (args == null)
                args = new object[] { null };

            LogMessage message = new LogMessage("Creating context bound wrapper for type {0}", type.FullName);
            LogManager.Info(this, message);
            ProxyTypeInfo typeInfo = CreateProxyTypeInfo(type);
            Type proxyType = typeInfo.Type;

            object[] proxyArgs;
			
            if (typeInfo.IsProxied)
            {
                proxyArgs = AddStateToCtorParams(state, args);
            }
            else //base or non proxied type
            {
                proxyArgs = args;
            }            		

            object proxyObject = Activator.CreateInstance(proxyType, proxyArgs);
            return proxyObject;
        }

        /// <summary>
        /// Creates a subclass proxy type
        /// </summary>
        /// <param name="type">Type to proxify</param>
        /// <returns>The proxy type</returns>
        public Type CreateProxyType(Type type) => CreateProxyTypeInfo(type).Type;

        private ProxyTypeInfo CreateProxyTypeInfo(Type type)
        {
            bool wasProxied = false;
            bool wasExtended = false;
            ProxyTypeInfo typeInfo = null;
            lock (proxyLookup.SyncRoot)
            {
                Type proxyType = null;
                //incase a proxy for this type does not exist , generate it
                if (proxyLookup[type] == null)
                {
                    Type extendedType = type;
                    //foreach (ITypeExtender typeExtender in configuration.TypeExtenders)
                    //{
                    //    extendedType = typeExtender.Extend(extendedType);
                    //    wasExtended = true;
                    //}
                    
                    IList typeAspects = AspectMatcher.MatchAspectsForType(type, Configuration.Aspects);

                    IList typeMixins = GetMixinsForType(type, typeAspects);

                    typeMixins.Add(typeof (AopProxyMixin));

#if NET2
                    if (SerializerIsAvailable())
                    {
                        AddSerializerMixin(typeMixins);
                    }
#endif

                    foreach (object aspect in typeAspects)
                    {
                        if (aspect is GenericAspectBase)
                        {
                            GenericAspectBase genericAspect = (GenericAspectBase)aspect;
                            foreach (TypeExtender typeExtender in genericAspect.TypeExtenders)
                            {
                                wasExtended = true;
                                extendedType = typeExtender.Extend(extendedType);                                
                            }
                        }
                    }


                    proxyType = SubclassProxyFactory.CreateProxyType(extendedType, typeAspects, typeMixins, this);


                    if (proxyType == null)
                        throw new NullReferenceException(
                            string.Format("Could not generate proxy for type '{0}'", type.FullName));

                    if (proxyType != extendedType)
                        wasProxied = true;

                    typeInfo = new ProxyTypeInfo();
                    typeInfo.Type = proxyType;
                    typeInfo.IsExtended = wasExtended;
                    typeInfo.IsProxied = wasProxied;


                    proxyLookup[type] = typeInfo;
                    LogMessage message = new LogMessage("Emitting new proxy type for type {0}", type.FullName);
                    LogManager.Info(this, message);
                }
                else
                {
                    typeInfo = proxyLookup[type] as ProxyTypeInfo;
                    //fetch the proxy type from the lookup
                    proxyType = typeInfo.Type;
                    LogMessage message = new LogMessage("Fetching proxy type from cache for type {0}", type.FullName);
                    LogManager.Info(this, message);
                }
                return typeInfo;
            }
        }

        /// <summary>
        /// Creates an interface wrapper proxy type
        /// </summary>
        /// <param name="type">Type to proxify</param>
        /// <returns>The proxy type</returns>
        public Type CreateWrapperType(Type type)
        {
            lock (wrapperLookup.SyncRoot)
            {
                Type wrapperType = null;
                //incase a proxy for this type does not exist , generate it
                if (wrapperLookup[type] == null)
                {
                    IList typeAspects = AspectMatcher.MatchAspectsForType(type, Configuration.Aspects);

                    IList typeMixins = GetMixinsForType(type, typeAspects);

                    typeMixins.Add(typeof (AopProxyMixin));

                    wrapperType = InterfaceProxyFactory.CreateProxyType(type, typeAspects, typeMixins, this);
                    if (wrapperType == null)
                        throw new NullReferenceException(
                            string.Format("Could not generate wrapper for type '{0}'", type.FullName));

                    wrapperLookup[type] = wrapperType;
                    LogMessage message = new LogMessage("Emitting new wrapper type for type {0}", type.FullName);
                    LogManager.Info(this, message);
                }
                else
                {
                    //fetch the proxy type from the lookup
                    wrapperType = wrapperLookup[type] as Type;
                    LogMessage message = new LogMessage("Fetching proxy wrapper from cache for type {0}", type.FullName);
                    LogManager.Info(this, message);
                }
                return wrapperType;
            }
        }

        private IList GetMixinsForType(Type type, IList typeAspects)
        {
            //	IList typeAspects = AspectMatcher.MatchAspectsForType(type, Configuration.Aspects);
            Hashtable mixins = new Hashtable();
            foreach (IAspect aspect in typeAspects)
            {
                IGenericAspect tmpAspect;
                if (aspect is IGenericAspect)
                    tmpAspect = (IGenericAspect) aspect;
                else
                    tmpAspect = TypedToGenericConverter.Convert((ITypedAspect) aspect);

                foreach (Type mixinType in tmpAspect.Mixins)
                {
                    //distinct add mixin..
                    mixins[mixinType] = mixinType;
                }
            }

            foreach (FixedMixinAttribute fixedMixinAttribute in type.GetCustomAttributes(typeof(FixedMixinAttribute), true))
                foreach (Type mixinType in fixedMixinAttribute.Types)
                    mixins[mixinType] = mixinType;

            IList distinctMixins = new ArrayList(mixins.Values);

            LogMessage message = new LogMessage("Getting mixins for type {0}", type.FullName);
            string verbose = "";
            foreach (Type mixinType in distinctMixins)
            {
                verbose += mixinType.Name;
                if (mixinType != distinctMixins[distinctMixins.Count - 1])
                    verbose += ", ";
            }



            LogManager.Info(this, message);

            return distinctMixins;
        }

		#region GetFixedInterceptor
        
		internal IInterceptor GetFixedInterceptor(Type interceptorType)
		{
			IInterceptor interceptor = (IInterceptor)FixedInterceptorLookup[interceptorType];
			if (interceptor == null)
			{
				interceptor = (IInterceptor) Activator.CreateInstance(interceptorType);
				FixedInterceptorLookup[interceptorType] = interceptor;
			}
			return interceptor;
		}

		#endregion


#if NET2
        /// <summary>
        /// Creates a subclass proxy of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">Type to proxify</typeparam>
        /// <param name="args">Object array of boxed parameter values</param>
        /// <returns>The proxy instance</returns>
        /// <example>
        /// <para>.NET 2.0 :</para>
        /// <code lang="CS">
        /// IEngine engine = Engine.Default;
        /// Car myCar = engine.CreateProxy&lt;Car&gt;();
        /// </code>
        /// </example>
        public T CreateProxy<T>(params object[] args)
        {
            Type type = typeof (T);
            object o = CreateProxy(type, args);
            return (T) o;
        }

        /// <summary>
        /// Creates a subclass proxy of type <c>T</c>.
        /// </summary>
        /// <typeparam name="T">Type to proxify</typeparam>
        /// <param name="state">State object that should be used by ctor interceptors</param>
        /// <param name="args">Object array of boxed parameter values</param>
        /// <returns>The proxy instance</returns>
        public T CreateProxyWithState<T>(object state, params object[] args)
        {
            Type type = typeof (T);
            object o = CreateProxyWithState(state, type, args);
            return (T) o;
        }


        //private static bool serializerIsAvailable=true;
        //private static bool serializerDoOnce=false;

        


        internal static bool SerializerIsAvailable()
        {
#if NET2 && DEBUG
            return true;
#else
            return false;
#endif
        }

        private void AddSerializerMixin(IList typeMixins)
        {
            Type t = Type.GetType("Puzzle.NAspect.Framework.SerializableProxyMixin", false);
            typeMixins.Add(t);
        }
#endif

        #endregion
    }
}