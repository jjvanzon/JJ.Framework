using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using JJ.Framework.Validation.Resources;
using JJ.Framework.Reflection;
using JJ.Framework.Reflection.Exceptions;

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

        public void AddContainsMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.Contains(propertyDisplayName, valueOrName));
        }

        public void AddContainsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddContainsMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddContainsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> itemExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string itemExpressionText = ExpressionHelper.GetText(itemExpression);
            AddContainsMessage(propertyKey, propertyDisplayName, itemExpressionText);
        }

        public void AddExistsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddExistsMessage(propertyKey, propertyDisplayName);
        }

        public void AddExistsMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.Exists(propertyDisplayName));
        }

        public void AddFileAlreadyExistsMessage(string propertyKey, string filePath)
        {
            Add(propertyKey, ValidationMessageFormatter.FileAlreadyExists(filePath));
        }

        public void AddFileAlreadyExistsMessage(Expression<Func<object>> propertyKeyExpression, string filePath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFileAlreadyExistsMessage(propertyKey, filePath);
        }

        public void AddFileNotFoundMessage(string propertyKey, string filePath)
        {
            Add(propertyKey, ValidationMessageFormatter.FileNotFound(filePath));
        }

        public void AddFileNotFoundMessage(Expression<Func<object>> propertyKeyExpression, string filePath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFileNotFoundMessage(propertyKey, filePath);
        }

        public void AddFolderAlreadyExistsMessage(string propertyKey, string folderPath)
        {
            Add(propertyKey, ValidationMessageFormatter.FolderAlreadyExists(folderPath));
        }

        public void AddFolderAlreadyExistsMessage(Expression<Func<object>> propertyKeyExpression, string folderPath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFolderAlreadyExistsMessage(propertyKey, folderPath);
        }

        public void AddFolderNotFoundMessage(string propertyKey, string folderPath)
        {
            Add(propertyKey, ValidationMessageFormatter.FolderNotFound(folderPath));
        }

        public void AddFolderNotFoundMessage(Expression<Func<object>> propertyKeyExpression, string folderPath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFolderNotFoundMessage(propertyKey, folderPath);
        }

        public void AddGreaterThanMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.GreaterThan(propertyDisplayName, limitOrName));
        }

        public void AddGreaterThanMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddGreaterThanMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddGreaterThanMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddGreaterThanMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddGreaterThanOrEqualMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.GreaterThanOrEqual(propertyDisplayName, limitOrName));
        }

        public void AddGreaterThanOrEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddGreaterThanOrEqualMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddGreaterThanOrEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddGreaterThanOrEqualMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddHasNullsMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.HasNulls(propertyDisplayName));
        }

        public void AddHasNullsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddHasNullsMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsInvalidChoiceMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.InvalidChoice(propertyDisplayName));
        }

        public void AddIsInvalidChoiceMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInvalidChoiceMessage(propertyKey, propertyDisplayName);
        }


        public void AddIsInvalidMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.Invalid(propertyDisplayName));
        }

        public void AddIsInvalidMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInvalidMessage(propertyKey, propertyDisplayName);
        }

        public void AddInvalidIndexMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.InvalidIndex(propertyDisplayName));
        }

        public void AddInvalidIndexMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddInvalidIndexMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsBrokenNumberMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsBrokenNumber(propertyDisplayName));
        }

        public void AddIsBrokenNumberMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsBrokenNumberMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsEmptyMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsEmpty(propertyDisplayName));
        }

        public void AddIsEmptyMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsEmptyMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsEqualMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsEqual(propertyDisplayName, valueOrName));
        }

        public void AddIsEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsEqualMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddIsEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddIsEqualMessage(propertyKey, propertyDisplayName, valueExpressionText);
        }

        public void AddIsFilledInMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsFilledIn(propertyDisplayName));
        }

        public void AddIsFilledInMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsFilledInMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsInfinityMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsInfinity(propertyDisplayName));
        }

        public void AddIsInfinityMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInfinityMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsInListMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsInList(propertyDisplayName));
        }

        public void AddIsInListMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInListMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsIntegerMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsInteger(propertyDisplayName));
        }

        public void AddIsIntegerMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsIntegerMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsNaNMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsNaN(propertyDisplayName));
        }

        public void AddIsNaNMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsNaNMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsOfTypeMessage(string propertyKey, string propertyDisplayName, string typeName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsOfType(propertyDisplayName, typeName));
        }

        public void AddIsOfTypeMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, string typeName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddIsOfTypeMessage<T>(string propertyKey, string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddIsOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddIsOfTypeMessage<T>(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string typeName = typeof(T).Name;
            AddIsOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddIsZeroMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.IsZero(propertyDisplayName));
        }

        public void AddIsZeroMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsZeroMessage(propertyKey, propertyDisplayName);
        }

        public void AddLengthExceededMessage(string propertyKey, string propertyDisplayName, int length)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.LengthExceeded(propertyDisplayName, length));
        }

        public void AddLengthExceededMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, int length)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddLengthExceededMessage(propertyKey, propertyDisplayName, length);
        }

        public void AddLessThanMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.LessThan(propertyDisplayName, limitOrName));
        }

        public void AddLessThanMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddLessThanMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddLessThanMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddLessThanMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddLessThanOrEqualMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.LessThanOrEqual(propertyDisplayName, limitOrName));
        }

        public void AddLessThanOrEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddLessThanOrEqualMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddLessThanOrEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddLessThanOrEqualMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddNotBrokenNumberMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotBrokenNumber(propertyDisplayName));
        }

        public void AddNotBrokenNumberMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotBrokenNumberMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotContainsMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotContains(propertyDisplayName, valueOrName));
        }

        public void AddNotContainsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotContainsMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddNotContainsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddNotContainsMessage(propertyKey, propertyDisplayName, valueExpressionText);
        }

        public void AddNotEmptyMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotEmpty(propertyDisplayName));
        }

        public void AddNotEmptyMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotEmptyMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotEqualMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotEqual(propertyDisplayName, valueOrName));
        }

        public void AddNotEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotEqualMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddNotEqualMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddNotEqualMessage(propertyKey, propertyDisplayName, valueExpressionText);
        }

        public void AddNotExistsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotExistsMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotExistsMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotExists(propertyDisplayName));
        }

        public void AddNotExistsMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object value)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotExistsMessage(propertyKey, propertyDisplayName, value);
        }

        public void AddNotExistsMessage(string propertyKey, string propertyDisplayName, object value)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotExists(propertyDisplayName, value));
        }

        public void AddRequiredMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotFilledIn(propertyDisplayName));
        }

        public void AddRequiredMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddRequiredMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotInListMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotInList(propertyDisplayName));
        }

        public void AddNotInListMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotInListMessage(string propertyKey, string propertyDisplayName, object value)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotInList(propertyDisplayName, value));
        }

        public void AddNotInListMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object value)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName, value);
        }

        public void AddNotInListMessage<TItem>(string propertyKey, string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotInList(propertyDisplayName, possibleValues));
        }

        public void AddNotInListMessage<TItem>(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName, possibleValues);
        }

        public void AddNotInListMessage<TItem>(string propertyKey, string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotInList(propertyDisplayName, value, possibleValues));
        }

        public void AddNotInListMessage<TItem>(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName, value, possibleValues);
        }

        public void AddNotIntegerMessage(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotInteger(propertyDisplayName));
        }

        public void AddNotIntegerMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotIntegerMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotOfTypeMessage(string propertyKey, string propertyDisplayName, string typeName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotOfType(propertyDisplayName, typeName));
        }

        public void AddNotOfTypeMessage(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, string typeName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddNotOfTypeMessage<T>(string propertyKey, string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddNotOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddNotOfTypeMessage<T>(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string typeName = typeof(T).Name;
            AddNotOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddNotUniqueMessageSingular(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotUniqueSingular(propertyDisplayName));
        }

        public void AddNotUniqueMessageSingular(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotUniqueMessageSingular(propertyKey, propertyDisplayName);
        }

        public void AddNotUniqueMessagePlural(string propertyKey, string propertyDisplayName)
        {
            if (String.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationMessageFormatter.NotUniquePlural(propertyDisplayName));
        }

        public void AddNotUniqueMessagePlural(Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotUniqueMessagePlural(propertyKey, propertyDisplayName);
        }
    }
}
