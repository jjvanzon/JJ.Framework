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
    /// Represents an "around" interceptor that may proceed or break a call.
    /// </summary>
    public interface IAroundInterceptor : IInterceptor
    {
        /// <summary>
        /// Intercepts a call.
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        object HandleCall(MethodInvocation call);
    }
}