using System;

namespace JJ.Framework.Business
{
    public abstract class ResultBase : IResult
    {
        public bool Successful { get; set; }

        private Messages _messages = new Messages();

        /// <summary> not nullable, auto-instantiated </summary>
        public Messages Messages
        {
            get => _messages;
            set => _messages = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
