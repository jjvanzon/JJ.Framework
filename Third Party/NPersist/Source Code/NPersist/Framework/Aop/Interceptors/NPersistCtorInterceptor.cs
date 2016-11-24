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
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Interception;
using Puzzle.NPersist.Framework.Interfaces;


namespace Puzzle.NPersist.Framework.Aop
{
	/// <summary>
	/// Summary description for NPersistCtorInterceptor.
	/// </summary>
	public class NPersistCtorInterceptor : IAroundInterceptor
	{
		public NPersistCtorInterceptor()
		{
		}

		public object HandleCall(MethodInvocation call)
		{
			IProxy proxy = (IProxy) call.Target;
			InterceptedParameter stateParam = (InterceptedParameter) call.Parameters [0];
			IContext ctx = (IContext)stateParam.Value;

			proxy.SetInterceptor(ctx.Interceptor) ;
			
			if (proxy.GetInterceptor() == null)
			{
				call.Proceed();
				return null;
			}
			else
			{
				bool cancel = false;
				proxy.GetInterceptor().NotifyInstantiatingObject(call.Target,ref cancel) ;

				if (!cancel)
					call.Proceed() ;

				proxy.GetInterceptor().NotifyInstantiatedObject(call.Target) ;

				return null;
			}
		}
	}
}
