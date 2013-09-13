// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Interface used to make mixins aware of their owning proxy.
    /// </summary>
    public interface IProxyAware
    {
        /// <summary>
        /// Assigns the proxy to the mixin
        /// </summary>
        /// <param name="target">The proxy instance</param>
        void SetProxy(IAopProxy target);
    }
}