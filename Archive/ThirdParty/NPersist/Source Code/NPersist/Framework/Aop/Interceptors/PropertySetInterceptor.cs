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
    public class PropertySetInterceptor : IAroundInterceptor
	{
        public object HandleCall(MethodInvocation call)
        {
            IProxy proxy = (IProxy)call.Target;
            bool cancel = false;
            object value = ((InterceptedParameter)call.Parameters[0]).Value;
            string propertyName = call.Method.Name.Substring(4);
            object refValue = value;

            Puzzle.NPersist.Framework.Interfaces.IInterceptor interceptor = proxy.GetInterceptor();
            if (interceptor != null) { interceptor.NotifyPropertySet(call.Target, propertyName, ref refValue, ref cancel); }
            if (cancel) { return null; }

            IContext context = null;
            if (interceptor != null) { context = interceptor.Context; }
            object oldValue = null;
            if (context != null)
                oldValue = context.ObjectManager.GetPropertyValue(call.ExecutionTarget, propertyName);
            else
                oldValue = call.ExecutionTarget.GetType().GetProperty(propertyName).GetValue(call.ExecutionTarget, null);
            ((InterceptedParameter)call.Parameters[0]).Value = refValue;
            call.Proceed();

            if (interceptor != null) { interceptor.NotifyWroteProperty(call.Target, propertyName, refValue, oldValue); }
            return null;
        }
	}
}
