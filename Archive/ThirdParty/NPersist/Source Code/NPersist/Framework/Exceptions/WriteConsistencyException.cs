// *
// * Copyright (C) 2008 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Runtime.Serialization;

namespace Puzzle.NPersist.Framework.Exceptions
{
	public class WriteConsistencyException : ConsistencyException
	{
		public WriteConsistencyException() : base()
		{
		}

		public WriteConsistencyException(string message, object obj) : base(message, obj, "")
		{
		}

		public WriteConsistencyException(string message, object obj, string propertyName) : base(message, obj, propertyName)
		{
		}

		public WriteConsistencyException(string message, Exception innerException, object obj) : base(message, innerException, obj, "")
		{
		}

		public WriteConsistencyException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException, obj, propertyName)
		{
		}

		public WriteConsistencyException(string message, Guid oldTransactionGuid, Guid newTransactionGuid, object obj) : base(message, obj, "")
		{
			this.oldTransactionGuid = oldTransactionGuid;
			this.newTransactionGuid = newTransactionGuid;
		}

		public WriteConsistencyException(string message, Guid oldTransactionGuid, Guid newTransactionGuid, object obj, string propertyName) : base(message, obj, propertyName)
		{
			this.oldTransactionGuid = oldTransactionGuid;
			this.newTransactionGuid = newTransactionGuid;
		}

		public WriteConsistencyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	

		#region Property  OldTransactionGuid
		
		private Guid oldTransactionGuid;
		
		public Guid OldTransactionGuid
		{
			get => this.oldTransactionGuid;
		    set => this.oldTransactionGuid = value;
		}
		
		#endregion

		#region Property  NewTransactionGuid
		
		private Guid newTransactionGuid;
		
		public Guid NewTransactionGuid
		{
			get => this.newTransactionGuid;
		    set => this.newTransactionGuid = value;
		}
		
		#endregion


	}
}
