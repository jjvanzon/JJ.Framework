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
    public class DatabindingPropertySetInterceptor : IAroundInterceptor
    {
        public object HandleCall(MethodInvocation call)
        {
            IProxy proxy = (IProxy)call.Target;
            string propertyName = call.Method.Name.Substring(4);

            IPropertyChangedHelper propertyChangedObj = (IPropertyChangedHelper)proxy;
            propertyChangedObj.OnPropertyChanging(propertyName);

            object res = call.Proceed();

            propertyChangedObj.OnPropertyChanged(propertyName);
            return res;
        }
    }
}
