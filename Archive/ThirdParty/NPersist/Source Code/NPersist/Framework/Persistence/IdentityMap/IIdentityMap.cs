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
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface IIdentityMap : IContextChild
	{

		//ObjectStatus GetObjectStatus(object obj);

		void UnRegisterCreatedObject(object obj);

		void RegisterCreatedObject(object obj);

		void RegisterLoadedObject(object obj);

		void RegisterLazyLoadedObject(object obj);

		void UpdateIdentity(object obj, string previousIdentity);

		void UpdateIdentity(object obj, string previousIdentity, string newIdentity);

		bool HasObject(object obj);

		bool HasObject(string identity, Type type);

		void LoadObject(ref object obj, bool ignoreObjectNotFound);

        object GetObject(object identity, Type type, bool lazy);

        object GetObject(object identity, Type type, bool lazy, bool ignoreObjectNotFound);

		object GetObjectByKey(string keyPropertyName, object keyValue, Type type);

		object GetObjectByKey(string keyPropertyName, object keyValue, Type type, bool ignoreObjectNotFound);

		IList GetObjects() ;

		void RemoveObject(object obj);

        void Clear();
		
		object TryGetObject(string identity, Type type);
	}
}