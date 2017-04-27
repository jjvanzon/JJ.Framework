using System;
using System.Collections;
using System.Collections.Generic;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Business
{
    public class Messages : IEnumerable<Message>
    {
        private readonly IList<Message> _list = new List<Message>();

        public Messages()
        { }

        public Messages(params Message[] messages) => AddRange(messages);

        public void Add(string key, string text) => Add(new Message(key, text));

        public void Add(Message message)
        {
            if (message == null) throw new NullException(() => message);

            _list.Add(message);
        }

        public void AddRange(IEnumerable<Message> messages)
        {
            if (messages == null) throw new NullException(() => messages);

            foreach (Message message in messages)
            {
                Add(message);
            }
        }

        // IEnumerable

        public IEnumerator<Message> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}
