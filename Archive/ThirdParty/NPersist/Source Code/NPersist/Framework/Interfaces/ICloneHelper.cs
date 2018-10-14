using Puzzle.NPersist.Framework.Persistence;
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
	/// <summary>
	/// Summary description for IInterceptable.
	/// </summary>
	public interface ICloneHelper
	{
		//void SetInterceptor(IInterceptor value);

		IObjectClone GetObjectClone();

		void SetObjectClone(IObjectClone value);

	}
}