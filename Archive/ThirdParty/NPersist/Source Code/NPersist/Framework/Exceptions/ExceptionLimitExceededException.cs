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
using System.Text;

namespace Puzzle.NPersist.Framework.Exceptions
{
	public class ExceptionLimitExceededException : CompositeException
	{
		public ExceptionLimitExceededException() : base()
		{
		}

		public ExceptionLimitExceededException(string message) : base(message)
		{
		}

		public ExceptionLimitExceededException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public ExceptionLimitExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public ExceptionLimitExceededException(IList innerExceptions) : base("Maximum number of allowed exceptions during an atomic operation was exceeded." + GetVerbose (innerExceptions), innerExceptions)
		{
        
		}

        private static string GetVerbose(IList innerExceptions)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\r\n");
            foreach (Exception x in innerExceptions)
            {
                sb.AppendFormat("{0}\r\n", x);                
            }
            string res = sb.ToString();
            return res;
        }

        //public ExceptionLimitExceededException(string message, IList innerExceptions) : base(message, innerExceptions)
        //{
        //}

	}
}
