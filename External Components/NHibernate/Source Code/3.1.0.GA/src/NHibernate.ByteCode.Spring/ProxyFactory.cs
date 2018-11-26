using System;
using Common.Logging;
using NHibernate.Engine;
using NHibernate.Proxy;

namespace NHibernate.ByteCode.Spring
{
	/// <summary>
	/// A Spring for .NET backed <see cref="IProxyFactory"/> implementation for creating
	/// NHibernate proxies.
	/// </summary>
	/// <seealso cref="ProxyFactoryFactory"/>
	/// <author>Erich Eichinger (Spring.NET Team)</author>
	public class ProxyFactory : AbstractProxyFactory
	{
		private static readonly ILog log = LogManager.GetLogger(typeof (ProxyFactory));

		[Serializable]
		private class SerializableProxyFactory : global::Spring.Aop.Framework.ProxyFactory
		{
			// ensure proxy types are generated as Serializable
			public override bool IsSerializable
			{
				get { return true; }
			}
		}

		#region IProxyFactory Members

		public override INHibernateProxy GetProxy(object id, ISessionImplementor session)
		{
			try
			{
				var initializer = new LazyInitializer(EntityName, PersistentClass.IsInterface ? typeof (object) : PersistentClass,
				                                      id, GetIdentifierMethod, SetIdentifierMethod, ComponentIdType, session);

				var proxyFactory = new SerializableProxyFactory
				                   	{Interfaces = Interfaces, TargetSource = initializer, ProxyTargetType = IsClassProxy};
				proxyFactory.AddAdvice(initializer);

				object proxyInstance = proxyFactory.GetProxy();
				return (INHibernateProxy) proxyInstance;
			}
			catch (Exception ex)
			{
				log.Error("Creating a proxy instance failed", ex);
				throw new HibernateException("Creating a proxy instance failed", ex);
			}
		}

		#endregion
	}
}