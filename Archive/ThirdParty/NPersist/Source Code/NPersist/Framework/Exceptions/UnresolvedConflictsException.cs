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
using System.Runtime.Serialization;

namespace Puzzle.NPersist.Framework.Exceptions 
{
	/// <summary>
	/// Summary description for UnresolvedConflictsException.
	/// </summary>
	public class UnresolvedConflictsException : ConcurrencyException
	{
		public UnresolvedConflictsException() : base()
		{
		}

		public UnresolvedConflictsException(string message, IList conflicts) : base(message) => this.conflicts = conflicts;

	    public UnresolvedConflictsException(string message, Exception innerException, IList conflicts) : base(message, innerException) => this.conflicts = conflicts;

	    public UnresolvedConflictsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		private IList conflicts;
		public IList Conflicts => this.conflicts;
	}
}
