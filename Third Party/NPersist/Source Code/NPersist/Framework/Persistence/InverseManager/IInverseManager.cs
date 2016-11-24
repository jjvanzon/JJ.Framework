using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface IInverseManager : IContextChild
	{
		void NotifyPropertyGet(object obj, string propertyName);

		void NotifyPropertySet(object obj, string propertyName, object value);

		void NotifyPropertySet(object obj, string propertyName, object value, object oldValue);

		void NotifyCreate(object obj);

		void NotifyPersist(object obj);

		void NotifyDelete(object obj);

		void NotifyCommitted(object obj);

		void NotifyPropertyLoad(object obj, IPropertyMap propertyMap, object value);

		void RemoveAllReferencesToObject(object obj);

		void RemoveNonInverseReferences(object obj);

		void RemoveInverseReferences(object obj);

		//bool HasFullyLoadedProperty(Type type, string propertyName);

		//bool HasFullyLoadedProperty(Type type, string propertyName, ITransaction transaction);

		//bool SetFullyLoadedProperty(Type type, string propertyName);

		//bool SetFullyLoadedProperty(Type type, string propertyName, ITransaction transaction);

        void Clear();

		//void Clear(ITransaction transaction);
	}
}