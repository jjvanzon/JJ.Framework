﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Legacy
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public sealed class ActionParameterInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }

        private string DebuggerDisplay
        {
            get
            {
                return String.Format("{0}={1}", Name, Value);
            }
        }
    }
}
