using System;
using System.Collections;
using Puzzle.NPersist.Framework.Interfaces;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Aop.Mixins
{
	public class ObservableMixin : IObservable
	{
		public ObservableMixin(object target)
		{
		}

		public ObservableMixin()
		{
		}

		private ArrayList m_EventListeners = new ArrayList();

		public void AddEventListener(IEventListener eventListener)
		{
			if (!(m_EventListeners.Contains(eventListener)))
			{
				m_EventListeners.Add(eventListener);
			}
		}

		public ArrayList GetEventListeners()
		{
			return m_EventListeners;
		}
	}
}
