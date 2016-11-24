// *
// * Copyright (C) 2006 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Text;
using System.Collections;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Decorate a method with this attribute to ensure that the interceptors you specify will always be applied regardless of the configuration file. If you decorate a class with this attribute, all methods in the class will be intercepted by the specified interceptors regardless of the configuration file.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
	public class FixedInterceptorAttribute : Attribute 
	{
        public FixedInterceptorAttribute(Type type) 
        {
            this.types.Add(type);
        }

        public FixedInterceptorAttribute(IList types)
        {
            this.types = types;
        }

        public FixedInterceptorAttribute(params Type[] types)
        {
            foreach (Type type in types)
            this.types.Add(type);
        }

        private IList types = new ArrayList();
        public virtual IList Types
        {
            get { return types; }
        }

	}
}
