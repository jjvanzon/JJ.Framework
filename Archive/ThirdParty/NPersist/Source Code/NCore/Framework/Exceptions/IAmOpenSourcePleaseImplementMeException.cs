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

namespace Puzzle.NCore.Framework.Exceptions
{
    public class IAmOpenSourcePleaseImplementMeException : NotImplementedException
    {
        public IAmOpenSourcePleaseImplementMeException()
            : base(
                "You have encountered a feature of this framework that has not yet been implemented. Since this is an open source effort, we would of course appreciate all help you could offer in implementing this functionality! Thank you! :-) /Sincerely, the Puzzle.NET team"
                )
        {
        }

        public IAmOpenSourcePleaseImplementMeException(string message) : base(message)
        {
        }

        public IAmOpenSourcePleaseImplementMeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public IAmOpenSourcePleaseImplementMeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}