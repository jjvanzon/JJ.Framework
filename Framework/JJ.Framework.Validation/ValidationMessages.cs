using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using JJ.Framework.Validation.Resources;

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
            // TIP: Add a breakpoint here to debug the where the validation rule is evaluated.
            _list.Add(new ValidationMessage(propertyKey, message));
        }

        public void AddRange(IEnumerable<ValidationMessage> validationMessages)
        {
            // TIP: Add a breakpoint here to debug the where the validation rule is evaluated.
            _list.AddRange(validationMessages);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public void AddRequiredMessage(string propertyKey, string propertyDisplayName)
        {
            Add(propertyKey, ValidationMessageFormatter.NotFilledIn(propertyDisplayName));
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

        private string DebuggerDisplay
        {
            get { return DebugHelper.GetDebuggerDisplay(this); }
        }

        public string AddLessThanMessage(string propertyDisplayName, object propertyDisplayName2OrValue)
        {
            return ValidationMessageFormatter.LessThanOrEqual(propertyDisplayName, propertyDisplayName2OrValue);
        }
    }
}
