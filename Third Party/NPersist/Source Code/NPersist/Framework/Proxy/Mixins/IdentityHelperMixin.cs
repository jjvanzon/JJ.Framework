// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *


using System.Collections;
using Puzzle.NCore.Framework.Collections;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;

namespace Puzzle.NPersist.Framework.Proxy.Mixins
{
	public class IdentityHelperMixin : IIdentityHelper , IProxyAware
	{
		private IAopProxy target = null;

		#region IProxyAware Members

		public void SetProxy(Puzzle.NAspect.Framework.IAopProxy target)
		{
			this.target = target ;
		}

		#endregion

		private string identity;
        public string GetIdentity()
        {
            return identity;
        }

        public void SetIdentity(string identity)
        {
            this.identity = identity;
        }

        public bool HasIdentityKeyParts()
        {
            return this.identityKeyParts.Count > 0;
        }

        private IList identityKeyParts = new ArrayList(1);

        public IList GetIdentityKeyParts()
		{
            return identityKeyParts; 
		}

        public bool HasKeyStruct()
        {
            return this.hasKeyStruct;
        }

        private bool hasKeyStruct;
        private KeyStruct keyStruct;
		public KeyStruct GetKeyStruct()
		{
			return this.keyStruct;
		}

		public void SetKeyStruct(KeyStruct value)
		{
			this.keyStruct = value;
            this.hasKeyStruct = true;
		}
	}
}
