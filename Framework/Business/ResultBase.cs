using JJ.Framework.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace JJ.Framework.Business
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public abstract class ResultBase : IResult
    {
        public bool Successful { get; set; }

        private IList<string> _messages = new List<string>();

        public ResultBase() { }
        public ResultBase(params string[] messages) => Messages = messages;

        /// <inheritdoc />
        public IList<string> Messages
        {
            get => _messages;
            set => _messages = value ?? throw new ArgumentNullException(nameof(value));
        }

        private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
    }
}
