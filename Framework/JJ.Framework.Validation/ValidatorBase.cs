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
            X = obj;

            Execute();
        }

        public T X { get; private set; }

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
                throw new Exception(ValidationMessages[0].Message);
            }
        }

        protected void Execute(IValidator validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }
            ValidationMessages validationMessages2 = validator.ValidationMessages;
            ValidationMessages.AddRange(validationMessages2);
        }
    }
}
