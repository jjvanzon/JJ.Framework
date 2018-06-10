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
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;

namespace Puzzle.NPersist.Framework.BaseClasses
{
	public class InterceptableList : ArrayList , IInterceptableList
	{
		private IListInterceptor interceptor = new ListInterceptor();

		public InterceptableList() : base() => interceptor.List = this;

	    public InterceptableList(IInterceptable interceptable, string propertyName) : this()
		{
			Interceptable = interceptable;
			PropertyName = propertyName;
		}

		public IListInterceptor Interceptor => interceptor;

	    public virtual IInterceptable Interceptable
		{
			get => interceptor.Interceptable;
	        set => interceptor.Interceptable = value;
	    }

		public string PropertyName
		{
			get => interceptor.PropertyName;
		    set => interceptor.PropertyName = value;
		}

		public IContext Context => ((IContextChild) Interceptable).Context;

	    private IClassMap classMap = null;
		public IClassMap ClassMap 
		{
			get
			{
				if (classMap == null)
					classMap = Context.DomainMap.MustGetClassMap(Interceptable.GetType());
				return classMap;
			}
		}

		private IPropertyMap propertyMap = null;
		public IPropertyMap PropertyMap
		{
			get
			{
				if (propertyMap == null)
					propertyMap = ClassMap.MustGetPropertyMap(PropertyName);
				return propertyMap;
			}
		}


		public bool MuteNotify
		{
			get => interceptor.MuteNotify;
		    set => interceptor.MuteNotify = value;
		}

        public virtual void EnsureLoaded()
        {
            bool stackMute = Interceptor.MuteNotify;
            interceptor.MuteNotify = true;
            interceptor.BeforeRead();
            interceptor.MuteNotify = stackMute;
        }

		public override int Add(object value)
		{
			if (MuteNotify)
				EnsureReadConsistency(value);
			else
				EnsureWriteConsistency(value);

			interceptor.BeforeCall() ;
			int ret = base.Add(value);
			interceptor.AfterCall() ;
			
			return ret;
		}

		public override void AddRange(ICollection c)
		{
			if (!MuteNotify)
				EnsureWriteConsistency(null);

			interceptor.BeforeCall() ;
			base.AddRange(c);
			interceptor.AfterCall() ;
		}

		public override void Clear()
		{
			if (MuteNotify)
				EnsureReadConsistency(null);
			else
				EnsureWriteConsistency(null);

			interceptor.BeforeCall() ;
			base.Clear();
			interceptor.AfterCall() ;
		}

		public override void Insert(int index, object value)
		{
			if (!MuteNotify)
				EnsureWriteConsistency(null);

			interceptor.BeforeCall() ;
			base.Insert(index, value);
			interceptor.AfterCall() ;
		}

		public override void InsertRange(int index, ICollection c)
		{
			if (!MuteNotify)
				EnsureWriteConsistency(null);

			interceptor.BeforeCall() ;
			base.InsertRange(index, c);
			interceptor.AfterCall() ;
		}

		public override IEnumerator GetEnumerator()
		{
			interceptor.BeforeRead() ;
			return base.GetEnumerator ();
		}

		public override IEnumerator GetEnumerator(int index, int count)
		{
			interceptor.BeforeRead() ;
			return base.GetEnumerator (index, count);
		}

		public override bool Contains(object item)
		{
			interceptor.BeforeRead() ;
			return base.Contains (item);
		}

		public override void CopyTo(int index, Array array, int arrayIndex, int count)
		{
			interceptor.BeforeRead() ;
			base.CopyTo (index, array, arrayIndex, count);
		}

		public override void CopyTo(Array array)
		{
			interceptor.BeforeRead() ;
			base.CopyTo (array);
		}

		public override void CopyTo(Array array, int arrayIndex)
		{
			interceptor.BeforeRead() ;
			base.CopyTo (array, arrayIndex);
		}

		public override ArrayList GetRange(int index, int count)
		{
			interceptor.BeforeRead() ;
			return base.GetRange (index, count);
		}

		public override object[] ToArray()
		{
			interceptor.BeforeRead() ;
			return base.ToArray ();
		}

		public override Array ToArray(Type type)
		{
			interceptor.BeforeRead() ;
			return base.ToArray (type);
		}


		public override object this[int index]
		{
            get => IListThisGet(index);
		    set => IListThisSet(index, value);
		}

        protected virtual void IListThisSet(int index, object value)
        {
            if (!MuteNotify)
                EnsureWriteConsistency(value);
            base[index] = value;
        }

        protected virtual object IListThisGet(int index) => base[index];

	    public override void Remove(object obj)
		{
			interceptor.BeforeCall() ;
			base.Remove(obj);
			interceptor.AfterCall() ;
		}

		public override void RemoveAt(int index)
		{
			interceptor.BeforeCall() ;
			base.RemoveAt(index);
			interceptor.AfterCall() ;
		}

		public override void RemoveRange(int index, int count)
		{
			interceptor.BeforeCall() ;
			base.RemoveRange(index, count);
			interceptor.AfterCall() ;
		}

		public override void SetRange(int index, ICollection c)
		{
			interceptor.BeforeCall() ;
			base.SetRange(index, c);
			interceptor.AfterCall() ;
		}

		public override int Count
		{
			get
			{
				int count = 0;
				if (!interceptor.BeforeCount(ref count))
					count = base.Count;
				interceptor.AfterCount(ref count) ;
				return count;
			}
		}

		//We want to ensure that both the object that this list property 
		//belongs to and the object (value) being removed were loaded under 
		//the current (active) transaction...
		private void EnsureReadConsistency(object value)
		{
			IContext ctx = this.Context;
			if (ctx.ReadConsistency.Equals(ConsistencyMode.Pessimistic))
			{
				IIdentityHelper identityHelper = Interceptable as IIdentityHelper;
				if (identityHelper == null)
					throw new NPersistException(string.Format("Object of type {0} does not implement IIdentityHelper", Interceptable.GetType()));

				IClassMap classMap = ClassMap;
				ISourceMap sourceMap = classMap.GetSourceMap();
				if (sourceMap != null)
				{
					if (sourceMap.PersistenceType.Equals(PersistenceType.ObjectRelational) || sourceMap.PersistenceType.Equals(PersistenceType.Default))
					{
						ITransaction tx = ctx.GetTransaction(ctx.GetDataSource(sourceMap).GetConnection());
						if (tx == null)
						{
							throw new ReadConsistencyException(
								string.Format("A read consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was loaded or initialized with a value outside of a transaction. This is not permitted in a context using Pessimistic ReadConsistency.",
								PropertyName,
								Interceptable.GetType(),
								ctx.ObjectManager.GetObjectIdentity(Interceptable)),									 
								Interceptable);
						}

						Guid txGuid = identityHelper.GetTransactionGuid();
						if (!(tx.Guid.Equals(txGuid)))
						{
							throw new ReadConsistencyException(
								string.Format("A read consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} has already been loaded or initialized inside a transactions with Guid {3} and was now loaded or initialized again under another transaction with Guid {4}. This is not permitted in a context using Pessimistic ReadConsistency.",
								PropertyName,
								Interceptable.GetType(),
								ctx.ObjectManager.GetObjectIdentity(Interceptable),
								txGuid, 
								tx.Guid),
								txGuid, 
								tx.Guid, 
								Interceptable);
						}

						if (value != null)
						{
							IPropertyMap propertyMap = PropertyMap;
							if (propertyMap.ReferenceType != ReferenceType.None)
							{
								IIdentityHelper valueIdentityHelper = value as IIdentityHelper;
								if (valueIdentityHelper == null)
									throw new NPersistException(string.Format("Object of type {0} does not implement IIdentityHelper", value.GetType()));

								Guid valueTxGuid = valueIdentityHelper.GetTransactionGuid();
								if (!(tx.Guid.Equals(valueTxGuid)))
								{
									throw new ReadConsistencyException(
										string.Format("A read consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} has already been loaded or initialized inside a transactions with Guid {3} and was now loaded or initialized again with a reference to an object that was loaded under another transaction with Guid {4}. This is not permitted in a context using Pessimistic ReadConsistency.",
										PropertyName,
										Interceptable.GetType(),
										ctx.ObjectManager.GetObjectIdentity(Interceptable),
										tx.Guid, 
										valueTxGuid),
										tx.Guid, 
										valueTxGuid, 
										Interceptable);
								}
							}
						}
					}
				}
			}	
		}

		private void EnsureWriteConsistency(object value)
		{
			IContext ctx = this.Context;
			if (ctx.WriteConsistency.Equals(ConsistencyMode.Pessimistic))
			{
				IIdentityHelper identityHelper = Interceptable as IIdentityHelper;
				if (identityHelper == null)
					throw new NPersistException(string.Format("Object of type {0} does not implement IIdentityHelper", Interceptable.GetType()));

				IClassMap classMap = ClassMap;
				ISourceMap sourceMap = classMap.GetSourceMap();
				if (sourceMap != null)
				{
					if (sourceMap.PersistenceType.Equals(PersistenceType.ObjectRelational) || sourceMap.PersistenceType.Equals(PersistenceType.Default))
					{
						ITransaction tx = ctx.GetTransaction(ctx.GetDataSource(sourceMap).GetConnection());
						if (tx == null)
						{
							throw new WriteConsistencyException(
								string.Format("A write consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was updated with a value outside of a transaction. This is not permitted in a context using Pessimistic WriteConsistency.",
								PropertyName,
								Interceptable.GetType(),
								ctx.ObjectManager.GetObjectIdentity(Interceptable)),									 
								Interceptable);
						}

						Guid txGuid = identityHelper.GetTransactionGuid();
						if (!(tx.Guid.Equals(txGuid)))
						{
							throw new WriteConsistencyException(
								string.Format("A write consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was loaded or initialized inside a transactions with Guid {3} and was now updated with a value under another transaction with Guid {4}. This is not permitted in a context using Pessimistic WriteConsistency.",
								PropertyName,
								Interceptable.GetType(),
								ctx.ObjectManager.GetObjectIdentity(Interceptable),
								txGuid, 
								tx.Guid),
								txGuid, 
								tx.Guid, 
								Interceptable);
						}

						if (value != null)
						{
							IPropertyMap propertyMap = PropertyMap;
							if (propertyMap.ReferenceType != ReferenceType.None)
							{
								IIdentityHelper valueIdentityHelper = value as IIdentityHelper;
								if (valueIdentityHelper == null)
									throw new NPersistException(string.Format("Object of type {0} does not implement IIdentityHelper", value.GetType()));

								Guid valueTxGuid = valueIdentityHelper.GetTransactionGuid();
								if (!(tx.Guid.Equals(valueTxGuid)))
								{
									throw new WriteConsistencyException(
										string.Format("A write consistency exception has occurred. The property {0} for the object of type {1} and with identity {2} was loaded or initialized inside a transactions with Guid {3} and was now updated with a reference to an object that was loaded under another transaction with Guid {4}. This is not permitted in a context using Pessimistic WriteConsistency.",
										PropertyName,
										Interceptable.GetType(),
										ctx.ObjectManager.GetObjectIdentity(Interceptable),
										tx.Guid, 
										valueTxGuid),
										tx.Guid, 
										valueTxGuid, 
										Interceptable);
								}
							}
						}
					}
				}
			}
		}
	}
}
