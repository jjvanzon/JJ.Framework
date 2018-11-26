using System.Diagnostics;
using Puzzle.NPersist.Framework.BaseClasses;
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
	public class ValidationManager : ContextChild, IValidationManager
	{
		private IEventManager m_EventManager = null;
		private bool m_ValidateOnCommitting = true;
		private bool m_ValidateOnBeforeCreate = false;
		private bool m_ValidateOnBeforeDelete = false;
		private bool m_ValidateOnBeforePersist = false;
		private bool m_ValidateOnBeforeGet = false;
		private bool m_ValidateOnBeforeInsert = false;
		private bool m_ValidateOnBeforeRemove = false;
		private bool m_ValidateOnBeforeUpdate = false;
		private bool m_ValidateOnBeforeLoad = false;
		private bool m_ValidateOnReadingProperty = false;
		private bool m_ValidateOnWritingProperty = false;
		private bool m_ValidateOnBeforePropertyLoad = false;
		private bool m_ValidateOnCommitted = false;
		private bool m_ValidateOnAfterCreate = false;
		private bool m_ValidateOnAfterDelete = false;
		private bool m_ValidateOnAfterPersist = false;
		private bool m_ValidateOnAfterGet = false;
		private bool m_ValidateOnAfterInsert = false;
		private bool m_ValidateOnAfterRemove = false;
		private bool m_ValidateOnAfterUpdate = false;
		private bool m_ValidateOnAfterLoad = false;
		private bool m_ValidateOnReadProperty = false;
		private bool m_ValidateOnWroteProperty = false;
		private bool m_ValidateOnAfterPropertyLoad = false;

		public IEventManager EventManager
		{
			get { return this.m_EventManager; }
			set { this.m_EventManager = value; }
		}

		public bool ValidateOnBeforeGet
		{
			get { return m_ValidateOnBeforeGet; }
			set { m_ValidateOnBeforeGet = value; }
		}

		public bool ValidateOnBeforeCreate
		{
			get { return m_ValidateOnBeforeCreate; }
			set { m_ValidateOnBeforeCreate = value; }
		}

		public bool ValidateOnBeforeDelete
		{
			get { return m_ValidateOnBeforeDelete; }
			set { m_ValidateOnBeforeDelete = value; }
		}

		public bool ValidateOnBeforePersist
		{
			get { return m_ValidateOnBeforePersist; }
			set { m_ValidateOnBeforePersist = value; }
		}

		public bool ValidateOnBeforeLoad
		{
			get { return m_ValidateOnBeforeLoad; }
			set { m_ValidateOnBeforeLoad = value; }
		}

		public bool ValidateOnBeforeInsert
		{
			get { return m_ValidateOnBeforeInsert; }
			set { m_ValidateOnBeforeInsert = value; }
		}

		public bool ValidateOnBeforeRemove
		{
			get { return m_ValidateOnBeforeRemove; }
			set { m_ValidateOnBeforeRemove = value; }
		}

		public bool ValidateOnBeforeUpdate
		{
			get { return m_ValidateOnBeforeUpdate; }
			set { m_ValidateOnBeforeUpdate = value; }
		}

		public bool ValidateOnCommitting
		{
			get { return m_ValidateOnCommitting; }
			set { m_ValidateOnCommitting = value; }
		}

		public bool ValidateOnReadingProperty
		{
			get { return m_ValidateOnReadingProperty; }
			set { m_ValidateOnReadingProperty = value; }
		}

		public bool ValidateOnWritingProperty
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get { return m_ValidateOnWritingProperty; }
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set { m_ValidateOnWritingProperty = value; }
		}

		public bool ValidateOnAfterGet
		{
			get { return m_ValidateOnAfterGet; }
			set { m_ValidateOnAfterGet = value; }
		}

		public bool ValidateOnAfterCreate
		{
			get { return m_ValidateOnAfterCreate; }
			set { m_ValidateOnAfterCreate = value; }
		}

		public bool ValidateOnAfterDelete
		{
			get { return m_ValidateOnAfterDelete; }
			set { m_ValidateOnAfterDelete = value; }
		}

		public bool ValidateOnAfterPersist
		{
			get { return m_ValidateOnAfterPersist; }
			set { m_ValidateOnAfterPersist = value; }
		}

		public bool ValidateOnAfterLoad
		{
			get { return m_ValidateOnAfterLoad; }
			set { m_ValidateOnAfterLoad = value; }
		}

		public bool ValidateOnAfterInsert
		{
			get { return m_ValidateOnAfterInsert; }
			set { m_ValidateOnAfterInsert = value; }
		}

		public bool ValidateOnAfterRemove
		{
			get { return m_ValidateOnAfterRemove; }
			set { m_ValidateOnAfterRemove = value; }
		}

		public bool ValidateOnAfterUpdate
		{
			get { return m_ValidateOnAfterUpdate; }
			set { m_ValidateOnAfterUpdate = value; }
		}

		public bool ValidateOnCommitted
		{
			get { return m_ValidateOnCommitted; }
			set { m_ValidateOnCommitted = value; }
		}

		public bool ValidateOnReadProperty
		{
			get { return m_ValidateOnReadProperty; }
			set { m_ValidateOnReadProperty = value; }
		}

		public bool ValidateOnWroteProperty
		{
			get { return m_ValidateOnWroteProperty; }
			set { m_ValidateOnWroteProperty = value; }
		}

		public bool ValidateOnAfterPropertyLoad
		{
			get { return m_ValidateOnAfterPropertyLoad; }
			set { m_ValidateOnAfterPropertyLoad = value; }
		}

		public bool ValidateOnBeforePropertyLoad
		{
			get { return m_ValidateOnBeforePropertyLoad; }
			set { m_ValidateOnBeforePropertyLoad = value; }
		}

		public void SetAllValidationFlags(bool value)
		{
			m_ValidateOnCommitting = value;
			m_ValidateOnBeforeCreate = value;
			m_ValidateOnBeforeDelete = value;
			m_ValidateOnBeforePersist = value;
			m_ValidateOnBeforeGet = value;
			m_ValidateOnBeforeInsert = value;
			m_ValidateOnBeforeRemove = value;
			m_ValidateOnBeforeUpdate = value;
			m_ValidateOnBeforeLoad = value;
			m_ValidateOnReadingProperty = value;
			m_ValidateOnWritingProperty = value;
			m_ValidateOnBeforePropertyLoad = value;
			m_ValidateOnCommitted = value;
			m_ValidateOnAfterCreate = value;
			m_ValidateOnAfterDelete = value;
			m_ValidateOnAfterPersist = value;
			m_ValidateOnAfterGet = value;
			m_ValidateOnAfterInsert = value;
			m_ValidateOnAfterRemove = value;
			m_ValidateOnAfterUpdate = value;
			m_ValidateOnAfterLoad = value;
			m_ValidateOnReadProperty = value;
			m_ValidateOnWroteProperty = value;
			m_ValidateOnAfterPropertyLoad = value;
		}
	}
}