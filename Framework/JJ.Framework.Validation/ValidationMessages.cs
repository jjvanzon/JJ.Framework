using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace JJ.Framework.Validation
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class ValidationMessages : IEnumerable<ValidationMessage>
    {
        private readonly List<ValidationMessage> _list = new List<ValidationMessage>();

        /// <param name="propertyKeyExpression">
        /// Used to extract the property key.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        public void Add(Expression<Func<object>> propertyKeyExpression, string message)
        {
            string propertyKey = PropertyKeyHelper.GetPropertyKeyFromExpression(propertyKeyExpression);
            Add(propertyKey, message);
        }

        public void Add(string propertyKey, string message)
        {
            _list.Add(new ValidationMessage(propertyKey, message));
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

        public void AddRange(IEnumerable<ValidationMessage> validationMessages)
        {
            _list.AddRange(validationMessages);
        }

        private string DebuggerDisplay
        {
            get
            {
                return String_PlatformSupport.Join(Environment.NewLine, _list.Select(x => String.Format("{0}: {1}", x.PropertyKey, x.Text)));
            }
        }
    }
}
