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
using Puzzle.NCore.Framework.Collections;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;

namespace Puzzle.NPersist.Framework.Aop.Mixins
{
	public class IdentityHelperMixin : IIdentityHelper , IProxyAware
	{
		private IAopProxy target = null;

		#region IProxyAware Members

		public void SetProxy(Puzzle.NAspect.Framework.IAopProxy target) => this.target = target;

	    #endregion

		public void Reset()
		{
			identity = null;
			identityKeyParts = new ArrayList(1);
			hasKeyStruct = false;
			hasTransactionGuid = false;
			transactionGuid = Guid.Empty;
		}

		private string identity;
        public string GetIdentity() => identity;

	    public void SetIdentity(string identity) => this.identity = identity;

	    public bool HasIdentityKeyParts() => this.identityKeyParts.Count > 0;

	    private IList identityKeyParts = new ArrayList(1);

        public IList GetIdentityKeyParts() => identityKeyParts;

	    public bool HasKeyStruct() => this.hasKeyStruct;

	    private bool hasKeyStruct;
        private KeyStruct keyStruct;
		public KeyStruct GetKeyStruct() => this.keyStruct;

	    public void SetKeyStruct(KeyStruct value)
		{
			this.keyStruct = value;
            this.hasKeyStruct = true;
		}

		private bool hasTransactionGuid = false;
		private Guid transactionGuid = Guid.Empty;

		public Guid GetTransactionGuid() => transactionGuid;

	    public void SetTransactionGuid(Guid value)
		{
			IContextChild contextChild = this.target as IContextChild;
			if (contextChild != null)
			{
				IContext ctx = ((IContextChild) this.target).Context;
				if (ctx != null)
				{
					if (!ctx.IsDisposed)
					{
						if (ctx.WriteConsistency.Equals(ConsistencyMode.Pessimistic))
						{
							if (Guid.Empty.Equals(value))
							{
								throw new WriteConsistencyException(
									string.Format("A write consistency exception has occurred. The object of type {0} and with identity {1} was loaded or created outside of a transaction. This is not permitted in a context using Pessimistic WriteConsistency.",
									target.GetType(),
									ctx.ObjectManager.GetObjectIdentity(target)),									 
									target);								
							}
						}
						if (ctx.ReadConsistency.Equals(ConsistencyMode.Pessimistic))
						{
							if (Guid.Empty.Equals(value))
							{
								throw new ReadConsistencyException(
									string.Format("A read consistency exception has occurred. The object of type {0} and with identity {1} was loaded or created outside of a transaction. This is not permitted in a context using Pessimistic ReadConsistency.",
									target.GetType(),
									ctx.ObjectManager.GetObjectIdentity(target)),									 
									target);								
							}

							if (hasTransactionGuid)
							{
								if (!(transactionGuid.Equals(value)))
								{
									throw new ReadConsistencyException(
										string.Format("A read consistency exception has occurred. The object of type {0} and with identity {1} has already been loaded or created inside a transactions with Guid {2} and was now loaded again under another transaction with Guid {3}. This is not permitted in a context using Pessimistic ReadConsistency.",
										target.GetType(),
										ctx.ObjectManager.GetObjectIdentity(target),
										transactionGuid, 
										value),
										transactionGuid, 
										value, 
										target);
								}
							}
						}
					}
				}
			}
			this.transactionGuid = value;
			hasTransactionGuid = true;
		}
	}
}
