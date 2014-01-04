using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Validation
{
    public abstract class ValidatorBase<T> : IValidator
    {
        public ValidatorBase(T obj)
        {
            Object = obj;

            Execute();
        }

        public T Object { get; private set; }

        protected abstract void Execute();

        private readonly ValidationMessages _validationMessages = new ValidationMessages();
        public ValidationMessages ValidationMessages { get { return _validationMessages; } }

        public bool IsValid
        {
            get { return ValidationMessages.Count == 0; }
        }

        public void Verify()
        {
            if (ValidationMessages.Count > 0)
            {
                throw new Exception(ValidationMessages[0].Text);
            }
        }

        protected void Execute(IValidator validator, string messageHeading = null)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }

            foreach (ValidationMessage validationMessage in validator.ValidationMessages)
            {
                ValidationMessages.Add(validationMessage.PropertyKey, messageHeading + validationMessage.Text);
            }
        }
    }
}
