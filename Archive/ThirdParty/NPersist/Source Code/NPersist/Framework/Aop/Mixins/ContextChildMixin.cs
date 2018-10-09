// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;

namespace Puzzle.NPersist.Framework.Aop.Mixins
{
	public class ContextChildMixin : IContextChild, IProxyAware
	{
        private IAopProxy target = null;



        #region IProxyAware Members

        public void SetProxy(Puzzle.NAspect.Framework.IAopProxy target) => this.target = target;

	    #endregion

        #region IContextChild Members

        public IContext Context
        {
            get
            {
                IInterceptor interceptor = GetInterceptor();
                if (interceptor != null)
                    return interceptor.Context;
                return null;
            }
            set
            {
                IInterceptor interceptor = GetInterceptor();
                if (interceptor != null)
                    interceptor.Context = value;
                else
                    throw new NPersistException("Could not set context because interceptor was not found on object.");
            }
        }

        #endregion

        private IInterceptor GetInterceptor()
        {
            if (target != null)
            {
                IProxy proxy = target as IProxy;
                if (proxy != null)
                {
                    return proxy.GetInterceptor();
                }
            }
            return null;
        }
    }
}
