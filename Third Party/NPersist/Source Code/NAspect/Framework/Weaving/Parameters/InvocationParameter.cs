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
    /// Representation of an intercepted call parameter.
    /// </summary>
    public class InterceptedParameter
    {
        private InvocationParameterInfo parameterInfo;
        private object[] rawParameters;
        private int rawParameterIndex;

        [DebuggerStepThrough()]
        public InterceptedParameter(InvocationParameterInfo parameterInfo, object[] rawParameters, int rawParameterIndex)
        {
            this.parameterInfo = parameterInfo;
            this.rawParameters = rawParameters;
            this.rawParameterIndex = rawParameterIndex;
        }

        public string Name => parameterInfo.Name;

        public int Index => parameterInfo.Index;

        public Type Type => parameterInfo.Type;

        public ParameterType ParameterType => parameterInfo.ParameterType;

        public object Value
        {
            get => rawParameters[rawParameterIndex];
            set => rawParameters[rawParameterIndex] = value;
        }
    }
}