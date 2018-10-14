// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NAspect.Framework.Interception
{
    /// <summary>
    /// Represents an "after" interceptor that is triggered after the base implementation of a method call is invoked.
    /// </summary>
    public interface IAfterInterceptor : IInterceptor
    {
        /// <summary>
        /// Method that is triggered after the base implementation of a method call is invoked.
        /// </summary>
        /// <param name="call">The method call</param>
        void AfterCall(AfterMethodInvocation call);
    }
}