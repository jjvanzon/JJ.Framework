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
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Aop

{
	/// <summary>
	/// Summary description for NPersistProxyMixin.
	/// </summary>
	public class NPersistProxyMixin : IProxy
	{
		private IInterceptor interceptor;
		public NPersistProxyMixin(object target)
		{
		}

		public NPersistProxyMixin()
		{
		}

		public IInterceptor GetInterceptor() => interceptor;

	    public void SetInterceptor(IInterceptor value) => interceptor = value;
	}
}
