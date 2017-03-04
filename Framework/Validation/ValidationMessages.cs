using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using JetBrains.Annotations;
using JJ.Framework.Validation.Resources;
using JJ.Framework.Reflection;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public class ValidationMessages : IEnumerable<ValidationMessage>
    {
        [ItemNotNull] [NotNull] private readonly List<ValidationMessage> _list = new List<ValidationMessage>();

        /// <param name="propertyKeyExpression">
        /// Used to extract the property key.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        public void Add([NotNull] Expression<Func<object>> propertyKeyExpression, string message)
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

        public int Count => _list.Count;

        [NotNull]
        public ValidationMessage this[int i] => _list[i];

        public IEnumerator<ValidationMessage> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        private string DebuggerDisplay => DebugHelper.GetDebuggerDisplay(this);

        public void AddContainsMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.Contains(propertyDisplayName, valueOrName));
        }

        public void AddContainsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddContainsMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddContainsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, [NotNull] Expression<Func<object>> itemExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string itemExpressionText = ExpressionHelper.GetText(itemExpression);
            AddContainsMessage(propertyKey, propertyDisplayName, itemExpressionText);
        }

        public void AddExistsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddExistsMessage(propertyKey, propertyDisplayName);
        }

        public void AddExistsMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.Exists(propertyDisplayName));
        }

        public void AddFileAlreadyExistsMessage(string propertyKey, string filePath)
        {
            Add(propertyKey, ValidationResourceFormatter.FileAlreadyExists(filePath));
        }

        public void AddFileAlreadyExistsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string filePath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFileAlreadyExistsMessage(propertyKey, filePath);
        }

        public void AddFileNotFoundMessage(string propertyKey, string filePath)
        {
            Add(propertyKey, ValidationResourceFormatter.FileNotFound(filePath));
        }

        public void AddFileNotFoundMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string filePath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFileNotFoundMessage(propertyKey, filePath);
        }

        public void AddFolderAlreadyExistsMessage(string propertyKey, string folderPath)
        {
            Add(propertyKey, ValidationResourceFormatter.FolderAlreadyExists(folderPath));
        }

        public void AddFolderAlreadyExistsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string folderPath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFolderAlreadyExistsMessage(propertyKey, folderPath);
        }

        public void AddFolderNotFoundMessage(string propertyKey, string folderPath)
        {
            Add(propertyKey, ValidationResourceFormatter.FolderNotFound(folderPath));
        }

        public void AddFolderNotFoundMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string folderPath)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddFolderNotFoundMessage(propertyKey, folderPath);
        }

        public void AddGreaterThanMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.GreaterThan(propertyDisplayName, limitOrName));
        }

        public void AddGreaterThanMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddGreaterThanMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddGreaterThanMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddGreaterThanMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddGreaterThanOrEqualMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.GreaterThanOrEqual(propertyDisplayName, limitOrName));
        }

        public void AddGreaterThanOrEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddGreaterThanOrEqualMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddGreaterThanOrEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddGreaterThanOrEqualMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddHasNullsMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.HasNulls(propertyDisplayName));
        }

        public void AddHasNullsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddHasNullsMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsInvalidChoiceMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.InvalidChoice(propertyDisplayName));
        }

        public void AddIsInvalidChoiceMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInvalidChoiceMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsInvalidMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.Invalid(propertyDisplayName));
        }

        public void AddIsInvalidMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInvalidMessage(propertyKey, propertyDisplayName);
        }

        public void AddInvalidIndexMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.InvalidIndex(propertyDisplayName));
        }

        public void AddInvalidIndexMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddInvalidIndexMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsBrokenNumberMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsBrokenNumber(propertyDisplayName));
        }

        public void AddIsBrokenNumberMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsBrokenNumberMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsEmptyMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsEmpty(propertyDisplayName));
        }

        public void AddIsEmptyMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsEmptyMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsEqualMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsEqual(propertyDisplayName, valueOrName));
        }

        public void AddIsEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsEqualMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddIsEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddIsEqualMessage(propertyKey, propertyDisplayName, valueExpressionText);
        }

        public void AddIsFilledInMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsFilledIn(propertyDisplayName));
        }

        public void AddIsFilledInMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsFilledInMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsInfinityMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsInfinity(propertyDisplayName));
        }

        public void AddIsInfinityMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInfinityMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsInListMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsInList(propertyDisplayName));
        }

        public void AddIsInListMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsInListMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsIntegerMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsInteger(propertyDisplayName));
        }

        public void AddIsIntegerMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsIntegerMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsNaNMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsNaN(propertyDisplayName));
        }

        public void AddIsNaNMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsNaNMessage(propertyKey, propertyDisplayName);
        }

        public void AddIsOfTypeMessage(string propertyKey, string propertyDisplayName, string typeName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsOfType(propertyDisplayName, typeName));
        }

        public void AddIsOfTypeMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, string typeName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddIsOfTypeMessage<T>(string propertyKey, string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddIsOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddIsOfTypeMessage<T>([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string typeName = typeof(T).Name;
            AddIsOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddIsZeroMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.IsZero(propertyDisplayName));
        }

        public void AddIsZeroMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddIsZeroMessage(propertyKey, propertyDisplayName);
        }

        public void AddLengthExceededMessage(string propertyKey, string propertyDisplayName, int length)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.LengthExceeded(propertyDisplayName, length));
        }

        public void AddLengthExceededMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, int length)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddLengthExceededMessage(propertyKey, propertyDisplayName, length);
        }

        public void AddLessThanMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.LessThan(propertyDisplayName, limitOrName));
        }

        public void AddLessThanMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddLessThanMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddLessThanMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddLessThanMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddLessThanOrEqualMessage(string propertyKey, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.LessThanOrEqual(propertyDisplayName, limitOrName));
        }

        public void AddLessThanOrEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object limitOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddLessThanOrEqualMessage(propertyKey, propertyDisplayName, limitOrName);
        }

        public void AddLessThanOrEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddLessThanOrEqualMessage(propertyKey, propertyDisplayName, limitExpressionText);
        }

        public void AddNotBothValidationMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName1, string propertyDisplayName2)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotBothValidationMessage(propertyKey, propertyDisplayName1, propertyDisplayName2);
        }

        public void AddNotBothValidationMessage(string propertyKey, string propertyDisplayName1, string propertyDisplayName2)
        {
            if (string.IsNullOrEmpty(propertyDisplayName1)) throw new NullOrEmptyException(() => propertyDisplayName1);
            if (string.IsNullOrEmpty(propertyDisplayName2)) throw new NullOrEmptyException(() => propertyDisplayName2);

            Add(propertyKey, ValidationResourceFormatter.NotBoth(propertyDisplayName1, propertyDisplayName2));
        }

        public void AddNotBrokenNumberMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotBrokenNumber(propertyDisplayName));
        }

        public void AddNotBrokenNumberMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotBrokenNumberMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotContainsMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotContains(propertyDisplayName, valueOrName));
        }

        public void AddNotContainsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotContainsMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddNotContainsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddNotContainsMessage(propertyKey, propertyDisplayName, valueExpressionText);
        }

        public void AddNotEmptyMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotEmpty(propertyDisplayName));
        }

        public void AddNotEmptyMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotEmptyMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotEqualMessage(string propertyKey, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotEqual(propertyDisplayName, valueOrName));
        }

        public void AddNotEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object valueOrName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotEqualMessage(propertyKey, propertyDisplayName, valueOrName);
        }

        public void AddNotEqualMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddNotEqualMessage(propertyKey, propertyDisplayName, valueExpressionText);
        }

        public void AddNotExistsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotExistsMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotExistsMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotExists(propertyDisplayName));
        }

        public void AddNotExistsMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object value)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotExistsMessage(propertyKey, propertyDisplayName, value);
        }

        public void AddNotExistsMessage(string propertyKey, string propertyDisplayName, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotExists(propertyDisplayName, value));
        }

        public void AddRequiredMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotFilledIn(propertyDisplayName));
        }

        public void AddRequiredMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddRequiredMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotInListMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotInList(propertyDisplayName));
        }

        public void AddNotInListMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotInListMessage(string propertyKey, string propertyDisplayName, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotInList(propertyDisplayName, value));
        }

        public void AddNotInListMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, object value)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName, value);
        }

        public void AddNotInListMessage<TItem>(string propertyKey, string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotInList(propertyDisplayName, possibleValues));
        }

        public void AddNotInListMessage<TItem>([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName, possibleValues);
        }

        public void AddNotInListMessage<TItem>(string propertyKey, string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotInList(propertyDisplayName, value, possibleValues));
        }

        public void AddNotInListMessage<TItem>([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotInListMessage(propertyKey, propertyDisplayName, value, possibleValues);
        }

        public void AddNotIntegerMessage(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotInteger(propertyDisplayName));
        }

        public void AddNotIntegerMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotIntegerMessage(propertyKey, propertyDisplayName);
        }

        public void AddNotOfTypeMessage(string propertyKey, string propertyDisplayName, string typeName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotOfType(propertyDisplayName, typeName));
        }

        public void AddNotOfTypeMessage([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName, string typeName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddNotOfTypeMessage<T>(string propertyKey, string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddNotOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddNotOfTypeMessage<T>([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            string typeName = typeof(T).Name;
            AddNotOfTypeMessage(propertyKey, propertyDisplayName, typeName);
        }

        public void AddNotUniqueMessageSingular(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotUniqueSingular(propertyDisplayName));
        }

        public void AddNotUniqueMessageSingular([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotUniqueMessageSingular(propertyKey, propertyDisplayName);
        }

        public void AddNotUniqueMessagePlural(string propertyKey, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(propertyKey, ValidationResourceFormatter.NotUniquePlural(propertyDisplayName));
        }

        public void AddNotUniqueMessagePlural([NotNull] Expression<Func<object>> propertyKeyExpression, string propertyDisplayName)
        {
            string propertyKey = ExpressionHelper.GetText(propertyKeyExpression);
            AddNotUniqueMessagePlural(propertyKey, propertyDisplayName);
        }

        public void AddNotUniqueMessageSingular(string propertyKey, string propertyDisplayNameSingular, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayNameSingular)) throw new NullOrEmptyException(() => propertyDisplayNameSingular);
            Add(propertyKey, ValidationResourceFormatter.NotUniqueSingular(propertyDisplayNameSingular, value));
        }
    }
}
