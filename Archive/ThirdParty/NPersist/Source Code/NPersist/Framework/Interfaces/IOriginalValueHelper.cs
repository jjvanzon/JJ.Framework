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
	public interface IOriginalValueHelper
	{
		object GetOriginalPropertyValue(string propertyName);

		void SetOriginalPropertyValue(string propertyName, object value);

		//void RemoveOriginalValues(string propertyName);

		void RemoveOriginalValues(string propertyName);

		bool HasOriginalValues();

		bool HasOriginalValues(string propertyName);

		//Note: We don't need any OriginalValueStatus, because:
		//for ref properties, NullValueStatus is never needed, since original value can be null 
		//for list props, null value status is never relevant
		//for primitive props, the original value can be DbNull.Value, it is only in the
		//propertyValue that the DbNull has been transformed to some primitive value...
	}
}