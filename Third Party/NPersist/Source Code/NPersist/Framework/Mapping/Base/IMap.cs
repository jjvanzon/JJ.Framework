// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public interface IMap : IComparable, IFixable
	{
		void Accept(IMapVisitor visitor) ;

		string Name { get; set; }

		string GetKey();

		bool IsInParents(IMap possibleParent) ;

		IMap GetParent() ;

		IMap Clone();

		IMap DeepClone();

		void Copy(IMap mapObject);

		void DeepCopy(IMap mapObject);

		void DeepMerge(IMap mapObject);

		bool Compare(IMap compareTo);

		bool DeepCompare(IMap compareTo);

		ArrayList MetaData { get; set; }

		object GetMetaData(string key);

		void SetMetaData(string key, object value);

		bool HasMetaData(string key);

		void RemoveMetaData(string key);
	}
}