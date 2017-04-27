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

        /// <param name="keyExpression">
        /// Used to extract the property key.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        public void Add([NotNull] Expression<Func<object>> keyExpression, string message)
        {
            string key = MessageKeyHelper.GetMessageKeyFromExpression(keyExpression);
            Add(key, message);
        }

        public void Add(string key, string message)
        {
            // TIP: Add a breakpoint here to debug the where the validation rule is evaluated.
            _list.Add(new ValidationMessage(key, message));
        }

        public void AddRange(IEnumerable<ValidationMessage> validationMessages)
        {
            // TIP: Add a breakpoint here to debug the where the validation rule is evaluated.
            _list.AddRange(validationMessages);
        }

        public int Count => _list.Count;

        [NotNull]
        public ValidationMessage this[int i] => _list[i];

        public IEnumerator<ValidationMessage> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        private string DebuggerDisplay => DebugHelper.GetDebuggerDisplay(this);

        public void AddContainsMessage(string key, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.Contains(propertyDisplayName, valueOrName));
        }

        public void AddContainsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object valueOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddContainsMessage(key, propertyDisplayName, valueOrName);
        }

        public void AddContainsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, [NotNull] Expression<Func<object>> itemExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string itemExpressionText = ExpressionHelper.GetText(itemExpression);
            AddContainsMessage(key, propertyDisplayName, itemExpressionText);
        }

        public void AddExistsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddExistsMessage(key, propertyDisplayName);
        }

        public void AddExistsMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.Exists(propertyDisplayName));
        }

        public void AddFileAlreadyExistsMessage(string key, string filePath) => Add(key, ValidationResourceFormatter.FileAlreadyExists(filePath));

        public void AddFileAlreadyExistsMessage([NotNull] Expression<Func<object>> keyExpression, string filePath)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddFileAlreadyExistsMessage(key, filePath);
        }

        public void AddFileNotFoundMessage(string key, string filePath) => Add(key, ValidationResourceFormatter.FileNotFound(filePath));

        public void AddFileNotFoundMessage([NotNull] Expression<Func<object>> keyExpression, string filePath)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddFileNotFoundMessage(key, filePath);
        }

        public void AddFolderAlreadyExistsMessage(string key, string folderPath) => Add(key, ValidationResourceFormatter.FolderAlreadyExists(folderPath));

        public void AddFolderAlreadyExistsMessage([NotNull] Expression<Func<object>> keyExpression, string folderPath)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddFolderAlreadyExistsMessage(key, folderPath);
        }

        public void AddFolderNotFoundMessage(string key, string folderPath) => Add(key, ValidationResourceFormatter.FolderNotFound(folderPath));

        public void AddFolderNotFoundMessage([NotNull] Expression<Func<object>> keyExpression, string folderPath)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddFolderNotFoundMessage(key, folderPath);
        }

        public void AddGreaterThanMessage(string key, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.GreaterThan(propertyDisplayName, limitOrName));
        }

        public void AddGreaterThanMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object limitOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddGreaterThanMessage(key, propertyDisplayName, limitOrName);
        }

        public void AddGreaterThanMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddGreaterThanMessage(key, propertyDisplayName, limitExpressionText);
        }

        public void AddGreaterThanOrEqualMessage(string key, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.GreaterThanOrEqual(propertyDisplayName, limitOrName));
        }

        public void AddGreaterThanOrEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object limitOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddGreaterThanOrEqualMessage(key, propertyDisplayName, limitOrName);
        }

        public void AddGreaterThanOrEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddGreaterThanOrEqualMessage(key, propertyDisplayName, limitExpressionText);
        }

        public void AddHasNullsMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.HasNulls(propertyDisplayName));
        }

        public void AddHasNullsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddHasNullsMessage(key, propertyDisplayName);
        }

        public void AddIsInvalidChoiceMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.InvalidChoice(propertyDisplayName));
        }

        public void AddIsInvalidChoiceMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsInvalidChoiceMessage(key, propertyDisplayName);
        }

        public void AddIsInvalidMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.Invalid(propertyDisplayName));
        }

        public void AddIsInvalidMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsInvalidMessage(key, propertyDisplayName);
        }

        public void AddInvalidIndexMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.InvalidIndex(propertyDisplayName));
        }

        public void AddInvalidIndexMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddInvalidIndexMessage(key, propertyDisplayName);
        }

        public void AddIsBrokenNumberMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsBrokenNumber(propertyDisplayName));
        }

        public void AddIsBrokenNumberMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsBrokenNumberMessage(key, propertyDisplayName);
        }

        public void AddIsEmptyMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsEmpty(propertyDisplayName));
        }

        public void AddIsEmptyMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsEmptyMessage(key, propertyDisplayName);
        }

        public void AddIsEqualMessage(string key, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsEqual(propertyDisplayName, valueOrName));
        }

        public void AddIsEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object valueOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsEqualMessage(key, propertyDisplayName, valueOrName);
        }

        public void AddIsEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddIsEqualMessage(key, propertyDisplayName, valueExpressionText);
        }

        public void AddIsFilledInMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsFilledIn(propertyDisplayName));
        }

        public void AddIsFilledInMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsFilledInMessage(key, propertyDisplayName);
        }

        public void AddIsInfinityMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsInfinity(propertyDisplayName));
        }

        public void AddIsInfinityMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsInfinityMessage(key, propertyDisplayName);
        }

        public void AddIsInListMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsInList(propertyDisplayName));
        }

        public void AddIsInListMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsInListMessage(key, propertyDisplayName);
        }

        public void AddIsIntegerMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsInteger(propertyDisplayName));
        }

        public void AddIsIntegerMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsIntegerMessage(key, propertyDisplayName);
        }

        public void AddIsNaNMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsNaN(propertyDisplayName));
        }

        public void AddIsNaNMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsNaNMessage(key, propertyDisplayName);
        }

        public void AddIsOfTypeMessage(string key, string propertyDisplayName, string typeName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsOfType(propertyDisplayName, typeName));
        }

        public void AddIsOfTypeMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, string typeName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsOfTypeMessage(key, propertyDisplayName, typeName);
        }

        public void AddIsOfTypeMessage<T>(string key, string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddIsOfTypeMessage(key, propertyDisplayName, typeName);
        }

        public void AddIsOfTypeMessage<T>([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string typeName = typeof(T).Name;
            AddIsOfTypeMessage(key, propertyDisplayName, typeName);
        }

        public void AddIsZeroMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.IsZero(propertyDisplayName));
        }

        public void AddIsZeroMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddIsZeroMessage(key, propertyDisplayName);
        }

        public void AddLengthExceededMessage(string key, string propertyDisplayName, int length)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.LengthExceeded(propertyDisplayName, length));
        }

        public void AddLengthExceededMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, int length)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddLengthExceededMessage(key, propertyDisplayName, length);
        }

        public void AddLessThanMessage(string key, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.LessThan(propertyDisplayName, limitOrName));
        }

        public void AddLessThanMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object limitOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddLessThanMessage(key, propertyDisplayName, limitOrName);
        }

        public void AddLessThanMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddLessThanMessage(key, propertyDisplayName, limitExpressionText);
        }

        public void AddLessThanOrEqualMessage(string key, string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.LessThanOrEqual(propertyDisplayName, limitOrName));
        }

        public void AddLessThanOrEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object limitOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddLessThanOrEqualMessage(key, propertyDisplayName, limitOrName);
        }

        public void AddLessThanOrEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, Expression<Func<object>> limitExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string limitExpressionText = ExpressionHelper.GetText(limitExpression);
            AddLessThanOrEqualMessage(key, propertyDisplayName, limitExpressionText);
        }

        public void AddNotBothValidationMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName1, string propertyDisplayName2)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotBothValidationMessage(key, propertyDisplayName1, propertyDisplayName2);
        }

        public void AddNotBothValidationMessage(string key, string propertyDisplayName1, string propertyDisplayName2)
        {
            if (string.IsNullOrEmpty(propertyDisplayName1)) throw new NullOrEmptyException(() => propertyDisplayName1);
            if (string.IsNullOrEmpty(propertyDisplayName2)) throw new NullOrEmptyException(() => propertyDisplayName2);

            Add(key, ValidationResourceFormatter.NotBoth(propertyDisplayName1, propertyDisplayName2));
        }

        public void AddNotBrokenNumberMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotBrokenNumber(propertyDisplayName));
        }

        public void AddNotBrokenNumberMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotBrokenNumberMessage(key, propertyDisplayName);
        }

        public void AddNotContainsMessage(string key, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotContains(propertyDisplayName, valueOrName));
        }

        public void AddNotContainsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object valueOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotContainsMessage(key, propertyDisplayName, valueOrName);
        }

        public void AddNotContainsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddNotContainsMessage(key, propertyDisplayName, valueExpressionText);
        }

        public void AddNotEmptyMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotEmpty(propertyDisplayName));
        }

        public void AddNotEmptyMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotEmptyMessage(key, propertyDisplayName);
        }

        public void AddNotEqualMessage(string key, string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotEqual(propertyDisplayName, valueOrName));
        }

        public void AddNotEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object valueOrName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotEqualMessage(key, propertyDisplayName, valueOrName);
        }

        public void AddNotEqualMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, Expression<Func<object>> valueExpression)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string valueExpressionText = ExpressionHelper.GetText(valueExpression);
            AddNotEqualMessage(key, propertyDisplayName, valueExpressionText);
        }

        public void AddNotExistsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotExistsMessage(key, propertyDisplayName);
        }

        public void AddNotExistsMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotExists(propertyDisplayName));
        }

        public void AddNotExistsMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object value)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotExistsMessage(key, propertyDisplayName, value);
        }

        public void AddNotExistsMessage(string key, string propertyDisplayName, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotExists(propertyDisplayName, value));
        }

        public void AddNotFilledInMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotFilledIn(propertyDisplayName));
        }

        public void AddNotFilledInMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotFilledInMessage(key, propertyDisplayName);
        }

        public void AddNotInListMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotInList(propertyDisplayName));
        }

        public void AddNotInListMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotInListMessage(key, propertyDisplayName);
        }

        public void AddNotInListMessage(string key, string propertyDisplayName, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotInList(propertyDisplayName, value));
        }

        public void AddNotInListMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, object value)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotInListMessage(key, propertyDisplayName, value);
        }

        public void AddNotInListMessage<TItem>(string key, string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotInList(propertyDisplayName, possibleValues));
        }

        public void AddNotInListMessage<TItem>([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotInListMessage(key, propertyDisplayName, possibleValues);
        }

        public void AddNotInListMessage<TItem>(string key, string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotInList(propertyDisplayName, value, possibleValues));
        }

        public void AddNotInListMessage<TItem>([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotInListMessage(key, propertyDisplayName, value, possibleValues);
        }

        public void AddNotIntegerMessage(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotInteger(propertyDisplayName));
        }

        public void AddNotIntegerMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotIntegerMessage(key, propertyDisplayName);
        }

        public void AddNotOfTypeMessage(string key, string propertyDisplayName, string typeName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotOfType(propertyDisplayName, typeName));
        }

        public void AddNotOfTypeMessage([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName, string typeName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotOfTypeMessage(key, propertyDisplayName, typeName);
        }

        public void AddNotOfTypeMessage<T>(string key, string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddNotOfTypeMessage(key, propertyDisplayName, typeName);
        }

        public void AddNotOfTypeMessage<T>([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            string typeName = typeof(T).Name;
            AddNotOfTypeMessage(key, propertyDisplayName, typeName);
        }

        public void AddNotUniqueMessageSingular(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotUniqueSingular(propertyDisplayName));
        }

        public void AddNotUniqueMessageSingular([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotUniqueMessageSingular(key, propertyDisplayName);
        }

        public void AddNotUniqueMessagePlural(string key, string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(key, ValidationResourceFormatter.NotUniquePlural(propertyDisplayName));
        }

        public void AddNotUniqueMessagePlural([NotNull] Expression<Func<object>> keyExpression, string propertyDisplayName)
        {
            string key = ExpressionHelper.GetText(keyExpression);
            AddNotUniqueMessagePlural(key, propertyDisplayName);
        }

        public void AddNotUniqueMessageSingular(string key, string propertyDisplayNameSingular, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayNameSingular)) throw new NullOrEmptyException(() => propertyDisplayNameSingular);
            Add(key, ValidationResourceFormatter.NotUniqueSingular(propertyDisplayNameSingular, value));
        }
    }
}
