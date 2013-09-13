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
    public class PropertyGetInterceptor : IAroundInterceptor
	{
        public object HandleCall(MethodInvocation call)
        {
            IProxy proxy = (IProxy)call.Target;
            string propertyName = call.Method.Name.Substring(4);

            object value = null;
            bool cancel = false;

            Puzzle.NPersist.Framework.Interfaces.IInterceptor interceptor = proxy.GetInterceptor();
            if (interceptor != null) { interceptor.NotifyPropertyGet(call.Target, propertyName, ref value, ref cancel); }
            if (cancel) { return value; }

            value = call.Proceed();

            if (interceptor != null) { interceptor.NotifyReadProperty(proxy, propertyName, ref value); }
            return value;
        }
	}
}
