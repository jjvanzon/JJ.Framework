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
using System.Collections;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Interface for generic aspects.
    /// Current generic aspects are <c>SignatureAspect</c> and <c>AttributeAspect</c>
    /// </summary>
    public interface IGenericAspect : IAspect
    {
        /// <summary>
        /// Just a name of the aspect, has no real purpose today.
        /// Features to fetch named aspects might be added later.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Implement this method in a class to match specific types.
        /// </summary>
        /// <param name="type">Target that might get this aspect applied to it</param>
        /// <returns>return true if the given type should get this aspect applied, otherwise false</returns>
        bool IsMatch(Type type);

        /// <summary>
        /// List of mixin types.
        /// Since this is .NET 1.x compatible and we are lazy farts, you get this in an untyped manner.
        /// The element type of this list should be <c>System.Type</c>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// myAspect.Mixins.Add(typeof(MyMixin));
        /// myAspect.Mixins.Add(typeof(ISomeMarkerInterfaceWOImplementation));
        /// </code>
        /// </example>
        IList Mixins { get; }

        /// <summary>
        /// List of pointcuts.
        /// Since this is .NET 1.x compatible and we are lazy farts, you get this in an untyped manner.
        /// The element type of this list should be <c>IPointcut</c>.
        /// </summary>
        IList Pointcuts { get; }

        /// <summary>
        /// List of targets
        /// </summary>
        IList Targets { get; }
    }
}