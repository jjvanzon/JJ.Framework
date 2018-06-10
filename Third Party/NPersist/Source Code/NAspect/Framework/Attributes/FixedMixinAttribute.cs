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
    /// Decorate a class with this attribute to ensure that the mixin or mixins you specify will always be applied to the class regardless of the configuration file.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple=true, Inherited=true)]
    public class FixedMixinAttribute : Attribute 
	{
        public FixedMixinAttribute(Type type) => this.types.Add(type);

	    public FixedMixinAttribute(IList types) => this.types = types;

	    public FixedMixinAttribute(params Type[] types)
        {
            foreach (Type type in types)
            this.types.Add(type);
        }

        private IList types = new ArrayList();
        public virtual IList Types => types;
	}
}
