using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Validation
{
    public class ValidationMessages : IEnumerable<ValidationMessage>
    {
        private readonly List<ValidationMessage> _list = new List<ValidationMessage>();

        public void Add(string propertyDisplayName, string message)
        {
            _list.Add(new ValidationMessage(propertyDisplayName, message));
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public ValidationMessage this[int i]
        {
            get { return _list[i]; }
        }

        public IEnumerator<ValidationMessage> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void AddRange(ValidationMessages validationMessages)
        {
            _list.AddRange(validationMessages);
        }
    }
}
