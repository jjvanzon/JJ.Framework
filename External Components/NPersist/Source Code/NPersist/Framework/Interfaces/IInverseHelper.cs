// *
// * Copyright (C) 2008 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
namespace Puzzle.NPersist.Framework.Interfaces
{
	public interface IInverseHelper
	{
        bool HasCount(string propertyName);
        bool HasCount(string propertyName, ITransaction transaction);
        int GetCount(string propertyName);
        int GetCount(string propertyName, ITransaction transaction);
        void SetCount(string propertyName, int count);
        void SetCount(string propertyName, int count, ITransaction transaction);
        IList GetPartiallyLoadedList(string propertyName);
        IList GetPartiallyLoadedList(string propertyName, ITransaction transaction);
        void Clear();
        void Clear(ITransaction transaction);
		void CheckPartiallyLoadedList(string propertyName);
		void CheckPartiallyLoadedList(string propertyName, ITransaction transaction);
    }
}
