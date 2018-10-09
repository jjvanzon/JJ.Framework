// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Interfaces
{
	public interface INullValueHelper
	{
		bool GetNullValueStatus(string propertyName);

		void SetNullValueStatus(string propertyName, bool value);

		void SetNullValueStatus(bool value);

		//We Really Should Add:
//		bool GetOriginalNullValueStatus(string propertyName);
//
//		void SetOriginalNullValueStatus(string propertyName, bool value);
//
//		void SetOriginalNullValueStatus(bool value);

	}
}