using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Validation.Resources;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public class ValidationMessages : IList<string>//, IEnumerable<string>
    {
        private readonly List<string> _list = new List<string>();

        // TIP: Add a breakpoint here to debug the where the validation rule is evaluated.
        public void Add(string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));
            _list.Add(message);
        }

        // TIP: Add a breakpoint here to debug the where the validation rule is evaluated.
        public void AddRange(IEnumerable<string> validationMessages) => _list.AddRange(validationMessages);

        public int Count => _list.Count;

        public string this[int i] => _list[i];

        private string DebuggerDisplay => DebugHelper.GetDebuggerDisplay(this);

        public void AddContainsMessage(string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.Contains(propertyDisplayName, valueOrName));
        }

        public void AddExistsMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.Exists(propertyDisplayName));
        }

        public void AddFileAlreadyExistsMessage(string filePath) => Add(ValidationResourceFormatter.FileAlreadyExists(filePath));

        public void AddFileNotFoundMessage(string filePath) => Add(ValidationResourceFormatter.FileNotFound(filePath));

        public void AddFolderAlreadyExistsMessage(string folderPath) => Add(ValidationResourceFormatter.FolderAlreadyExists(folderPath));

        public void AddFolderNotFoundMessage(string folderPath) => Add(ValidationResourceFormatter.FolderNotFound(folderPath));

        public void AddGreaterThanMessage(string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.GreaterThan(propertyDisplayName, limitOrName));
        }

        public void AddGreaterThanOrEqualMessage(string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.GreaterThanOrEqual(propertyDisplayName, limitOrName));
        }

        public void AddHasNullsMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.HasNulls(propertyDisplayName));
        }

        public void AddIsInvalidChoiceMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.InvalidChoice(propertyDisplayName));
        }

        public void AddIsInvalidMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.Invalid(propertyDisplayName));
        }

        public void AddInvalidIndexMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.InvalidIndex(propertyDisplayName));
        }

        public void AddIsBrokenNumberMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsBrokenNumber(propertyDisplayName));
        }

        public void AddIsEmptyMessageSingular(string propertyDisplayNameSingular)
        {
            if (string.IsNullOrEmpty(propertyDisplayNameSingular)) throw new NullOrEmptyException(() => propertyDisplayNameSingular);
            Add(ValidationResourceFormatter.IsEmpty(propertyDisplayNameSingular));
        }

        public void AddAreEmptyMessagePlural(string propertyDisplayNamePlural)
        {
            if (string.IsNullOrEmpty(propertyDisplayNamePlural)) throw new NullOrEmptyException(() => propertyDisplayNamePlural);
            Add(ValidationResourceFormatter.AreEmpty(propertyDisplayNamePlural));
        }

        public void AddIsEqualMessage(string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsEqual(propertyDisplayName, valueOrName));
        }

        public void AddIsFilledInMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsFilledIn(propertyDisplayName));
        }

        public void AddIsInfinityMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsInfinity(propertyDisplayName));
        }

        public void AddIsInListMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsInList(propertyDisplayName));
        }

        public void AddIsIntegerMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsInteger(propertyDisplayName));
        }

        public void AddIsNaNMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsNaN(propertyDisplayName));
        }

        public void AddIsOfTypeMessage(string propertyDisplayName, string typeName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsOfType(propertyDisplayName, typeName));
        }

        public void AddIsOfTypeMessage<T>(string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddIsOfTypeMessage(propertyDisplayName, typeName);
        }

        public void AddIsZeroMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.IsZero(propertyDisplayName));
        }

        public void AddLengthExceededMessage(string propertyDisplayName, int length)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.LengthExceeded(propertyDisplayName, length));
        }


        public void AddLessThanMessage(string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.LessThan(propertyDisplayName, limitOrName));
        }

        public void AddLessThanOrEqualMessage(string propertyDisplayName, object limitOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.LessThanOrEqual(propertyDisplayName, limitOrName));
        }


        public void AddNotBothValidationMessage(string propertyDisplayName1, string propertyDisplayName2)
        {
            if (string.IsNullOrEmpty(propertyDisplayName1)) throw new NullOrEmptyException(() => propertyDisplayName1);
            if (string.IsNullOrEmpty(propertyDisplayName2)) throw new NullOrEmptyException(() => propertyDisplayName2);

            Add(ValidationResourceFormatter.NotBoth(propertyDisplayName1, propertyDisplayName2));
        }

        public void AddNotBrokenNumberMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotBrokenNumber(propertyDisplayName));
        }

        public void AddNotContainsMessage(string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotContains(propertyDisplayName, valueOrName));
        }

        public void AddNotEmptyMessageSingular(string propertyDisplayNameSingular)
        {
            if (string.IsNullOrEmpty(propertyDisplayNameSingular)) throw new NullOrEmptyException(() => propertyDisplayNameSingular);
            Add(ValidationResourceFormatter.NotEmptySingular(propertyDisplayNameSingular));
        }

        public void AddNotEmptyMessagePlural(string propertyDisplayNamePlural)
        {
            if (string.IsNullOrEmpty(propertyDisplayNamePlural)) throw new NullOrEmptyException(() => propertyDisplayNamePlural);
            Add(ValidationResourceFormatter.NotEmptyPlural(propertyDisplayNamePlural));
        }

        public void AddNotEqualMessage(string propertyDisplayName, object valueOrName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotEqual(propertyDisplayName, valueOrName));
        }

        public void AddNotExistsMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotExists(propertyDisplayName));
        }

        public void AddNotExistsMessage(string propertyDisplayName, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotExists(propertyDisplayName, value));
        }

        public void AddNotFilledInMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotFilledIn(propertyDisplayName));
        }

        public void AddNotFilledInMessage() => Add(ValidationResourceFormatter.NotFilledIn());

        public void AddNotInListMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotInList(propertyDisplayName));
        }

        public void AddNotInListMessage(string propertyDisplayName, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotInList(propertyDisplayName, value));
        }

        public void AddNotInListMessage<TItem>(string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotInList(propertyDisplayName, possibleValues));
        }

        public void AddNotInListMessage<TItem>(string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotInList(propertyDisplayName, value, possibleValues));
        }

        public void AddNotIntegerMessage(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotInteger(propertyDisplayName));
        }

        public void AddNotOfTypeMessage(string propertyDisplayName, string typeName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotOfType(propertyDisplayName, typeName));
        }

        public void AddNotOfTypeMessage<T>(string propertyDisplayName)
        {
            string typeName = typeof(T).Name;
            AddNotOfTypeMessage(propertyDisplayName, typeName);
        }

        public void AddNotUniqueMessageSingular(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotUniqueSingular(propertyDisplayName));
        }

        public void AddNotUniqueMessagePlural(string propertyDisplayName)
        {
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);
            Add(ValidationResourceFormatter.NotUniquePlural(propertyDisplayName));
        }

        public void AddNotUniqueMessageSingular(string propertyDisplayNameSingular, object value)
        {
            if (string.IsNullOrEmpty(propertyDisplayNameSingular)) throw new NullOrEmptyException(() => propertyDisplayNameSingular);
            Add(ValidationResourceFormatter.NotUniqueSingular(propertyDisplayNameSingular, value));
        }

        // Explicit Interfaces

        void ICollection<string>.Clear() => _list.Clear();
        bool ICollection<string>.Contains(string item) => _list.Contains(item);
        void ICollection<string>.CopyTo(string[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);
        bool ICollection<string>.Remove(string item) => _list.Remove(item);
        bool ICollection<string>.IsReadOnly => false;
        int IList<string>.IndexOf(string item) => _list.IndexOf(item);
        void IList<string>.Insert(int index, string item) => _list.Insert(index, item);
        void IList<string>.RemoveAt(int index) => _list.RemoveAt(index);
        string IList<string>.this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
        public IEnumerator<string> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}
