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
    /// Decorate your interceptors with this attribute in order to indicate the types of mixins that are required for your interceptors to function properly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class RequiresMixinAttribute : Attribute
    {
        public RequiresMixinAttribute(Type type) => this.types.Add(type);

        public RequiresMixinAttribute(IList types) => this.types = types;

        public RequiresMixinAttribute(params Type[] types)
        {
            foreach (Type type in types)
                this.types.Add(type);
        }

        private IList types = new ArrayList();
        public virtual IList Types => types;
    }
}
