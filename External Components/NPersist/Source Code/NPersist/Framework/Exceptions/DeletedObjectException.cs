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
using System.Runtime.Serialization;

namespace Puzzle.NPersist.Framework.Exceptions
{
	public class DeletedObjectException : NPersistException
	{
		public DeletedObjectException() : base()
		{
		}

		public DeletedObjectException(string message, object obj) : base(message, obj)
		{
		}

		public DeletedObjectException(string message, object obj, string propertyName) : base(message, obj, propertyName)
		{
		}

		public DeletedObjectException(string message, Exception innerException, object obj) : base(message, innerException, obj)
		{
		}

		public DeletedObjectException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException, obj, propertyName)
		{
		}

		public DeletedObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}