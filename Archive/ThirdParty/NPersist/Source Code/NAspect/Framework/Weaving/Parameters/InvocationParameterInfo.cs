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
using System.Diagnostics;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Enum for parameter directions
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// ByValue parameter
        /// </summary>
        ByVal,
        /// <summary>
        /// ByReference parameter
        /// </summary>
        Ref,
        /// <summary>
        /// Output parameter
        /// </summary>
        Out
    }
    
	public class InvocationParameterInfo
	{
	    /// <summary>
        /// Name of the parameter.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Index of the parameter in the method signature.
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// Data type of the parameter.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// Direction of the parameter.
        /// </summary>
        public readonly ParameterType ParameterType;

        /// <summary>
        /// Ctor for an intercepted parameter
        /// </summary>
        /// <param name="name">Name of the parameter.</param>
        /// <param name="index">Index of the parameter in the method signature</param>
        /// <param name="type">Data type of the parameter.</param>
        /// <param name="parameterType">Direction of the parameter.</param>
        [DebuggerStepThrough()]
        public InvocationParameterInfo(string name, int index, Type type, ParameterType parameterType)
        {
            Name = name;
            Index = index;
            Type = type;
            ParameterType = parameterType;
        }
	}
}
