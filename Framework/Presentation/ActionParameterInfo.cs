﻿using System.Diagnostics;

namespace JJ.Framework.Presentation
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public sealed class ActionParameterInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }

        private string DebuggerDisplay => $"{Name}={Value}";
    }
}
