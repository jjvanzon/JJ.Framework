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
	public interface IValidationManager
	{
		void SetAllValidationFlags(bool value);

		IEventManager EventManager { get; set; }

		bool ValidateOnCommitting { get; set; }

		bool ValidateOnBeforeCreate { get; set; }

		bool ValidateOnBeforeDelete { get; set; }

		bool ValidateOnBeforePersist { get; set; }

		bool ValidateOnBeforeGet { get; set; }

		bool ValidateOnBeforeInsert { get; set; }

		bool ValidateOnBeforeRemove { get; set; }

		bool ValidateOnBeforeUpdate { get; set; }

		bool ValidateOnBeforeLoad { get; set; }

		bool ValidateOnReadingProperty { get; set; }

		bool ValidateOnWritingProperty { get; set; }

		bool ValidateOnBeforePropertyLoad { get; set; }

		bool ValidateOnCommitted { get; set; }

		bool ValidateOnAfterCreate { get; set; }

		bool ValidateOnAfterDelete { get; set; }

		bool ValidateOnAfterPersist { get; set; }

		bool ValidateOnAfterGet { get; set; }

		bool ValidateOnAfterInsert { get; set; }

		bool ValidateOnAfterRemove { get; set; }

		bool ValidateOnAfterUpdate { get; set; }

		bool ValidateOnAfterLoad { get; set; }

		bool ValidateOnReadProperty { get; set; }

		bool ValidateOnWroteProperty { get; set; }

		bool ValidateOnAfterPropertyLoad { get; set; }
	}
}