using System;
using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Business.Helpers;

namespace JJ.Framework.Business
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public abstract class ResultBase : IResult
    {
        public bool Successful { get; set; }

        private IList<string> _messages = new List<string>();

        /// <summary> not nullable, auto-instantiated </summary>
        public IList<string> Messages
        {
            get => _messages;
            set => _messages = value ?? throw new ArgumentNullException(nameof(value));
        }

        private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
    }
}
