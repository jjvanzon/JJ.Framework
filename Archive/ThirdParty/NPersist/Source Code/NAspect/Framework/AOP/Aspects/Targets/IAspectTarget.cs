﻿// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Text;
using System.Reflection.Emit;
using Puzzle.NAspect.Framework.Tools;

namespace Puzzle.NAspect.Framework.Aop
{
    public interface IAspectTarget
    {
        bool Exclude { get; set; }

        bool IsMatch(Type type);
    }
}
