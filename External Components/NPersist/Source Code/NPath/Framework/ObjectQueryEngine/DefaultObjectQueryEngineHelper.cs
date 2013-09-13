// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using System.Data;
using Puzzle.NPath.Framework.CodeDom;

namespace Puzzle.NPath.Framework
{
    public class DefaultObjectQueryEngineHelper : IObjectQueryEngineHelper
    {
        #region IObjectQueryEngineHelper Members

        public void ExpandWildcards(Puzzle.NPath.Framework.CodeDom.NPathSelectQuery query)
        {
            
        }

        public bool GetNullValueStatus(object target, string property)
        {
            return false;
        }

        public object EvalParameter(object item, Puzzle.NPath.Framework.CodeDom.NPathParameter parameter)
        {
            return null;
        }

        #endregion
    }
}
