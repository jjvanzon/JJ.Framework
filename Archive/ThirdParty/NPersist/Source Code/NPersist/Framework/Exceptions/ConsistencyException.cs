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
	public class ConsistencyException : NPersistException
	{
		public ConsistencyException() : base()
		{
		}

		public ConsistencyException(string message) : base(message)
		{
		}

		public ConsistencyException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public ConsistencyException(string message, object obj, string propertyName) : base(message, obj, propertyName)
		{
		}

		public ConsistencyException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException, obj, propertyName)
		{
		}

		public ConsistencyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}