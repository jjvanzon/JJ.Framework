// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using Puzzle.NPath.Framework.CodeDom;

namespace Puzzle.NPath.Framework
{
	public interface IObjectQueryEngineHelper
	{
		void ExpandWildcards(NPathSelectQuery query);
		bool GetNullValueStatus(object target, string property);
		object EvalParameter(object item, NPathParameter parameter);
	}
}