using Puzzle.NPersist.Framework.EventArguments;
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
	public interface IEventListener
	{
		void OnCreatingObject(object sender, ObjectCancelEventArgs e);

		void OnCreatedObject(object sender, ObjectEventArgs e);

		void OnInsertingObject(object sender, ObjectCancelEventArgs e);

		void OnInsertedObject(object sender, ObjectEventArgs e);

		void OnDeletingObject(object sender, ObjectCancelEventArgs e);

		void OnDeletedObject(object sender, ObjectEventArgs e);

		void OnRemovingObject(object sender, ObjectCancelEventArgs e);

		void OnRemovedObject(object sender, ObjectEventArgs e);

		void OnCommittingObject(object sender, ObjectCancelEventArgs e);

		void OnCommittedObject(object sender, ObjectEventArgs e);

		void OnUpdatingObject(object sender, ObjectCancelEventArgs e);

		void OnUpdatedObject(object sender, ObjectEventArgs e);

		void OnGettingObject(object sender, ObjectCancelEventArgs e);

		void OnGotObject(object sender, ObjectEventArgs e);

		void OnLoadingObject(object sender, ObjectCancelEventArgs e);

		void OnLoadedObject(object sender, ObjectEventArgs e);

		void OnReadingProperty(object sender, PropertyCancelEventArgs e);

		void OnReadProperty(object sender, PropertyEventArgs e);

		void OnWritingProperty(object sender, PropertyCancelEventArgs e);

		void OnWroteProperty(object sender, PropertyEventArgs e);

		void OnLoadingProperty(object sender, PropertyCancelEventArgs e);

		void OnLoadedProperty(object sender, PropertyEventArgs e);

		void OnInstantiatingObject(object sender, ObjectCancelEventArgs e);

		void OnInstantiatedObject(object sender, ObjectEventArgs e);

	}
}