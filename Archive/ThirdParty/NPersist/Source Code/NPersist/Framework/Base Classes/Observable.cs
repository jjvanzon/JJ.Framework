// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using Puzzle.NPersist.Framework.Interfaces;

//HACK: Roger was here again..
//ändrade till abstract..
namespace Puzzle.NPersist.Framework.BaseClasses
{
	public abstract class Observable : IObservable
	{
		private ArrayList m_EventListeners = new ArrayList();

		public void AddEventListener(IEventListener eventListener)
		{
			if (!(m_EventListeners.Contains(eventListener)))
			{
				m_EventListeners.Add(eventListener);
			}
		}

		public ArrayList GetEventListeners() => m_EventListeners;
	}
}