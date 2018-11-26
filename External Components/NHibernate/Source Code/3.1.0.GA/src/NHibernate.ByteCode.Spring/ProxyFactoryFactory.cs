using System;
using NHibernate.Bytecode;
using NHibernate.Proxy;

namespace NHibernate.ByteCode.Spring
{
	/// <summary>
	/// Creates a Spring for .NET backed <see cref="IProxyFactory"/> instance.
	/// </summary>
	/// <author>Erich Eichinger</author>
	public class ProxyFactoryFactory : IProxyFactoryFactory
	{
		#region IProxyFactoryFactory Members

		public IProxyFactory BuildProxyFactory()
		{
			return new ProxyFactory();
		}

		public IProxyValidator ProxyValidator
		{
			get { return new DynProxyTypeValidator(); }
		}

		public bool IsInstrumented(System.Type entityClass)
		{
			return false;
		}

		public bool IsProxy(object entity)
		{
			return entity is INHibernateProxy;
		}

		#endregion
	}
}