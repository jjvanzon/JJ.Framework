using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JJ.Framework.Common;

namespace JJ.Framework.Validation
{
    public abstract class ValidatorBase<TRootObject> : IValidator
    {
        public ValidatorBase(TRootObject obj)
        {
            Object = obj;

            Execute();
        }

        public TRootObject Object { get; private set; }

        protected abstract void Execute();

        private readonly ValidationMessages _validationMessages = new ValidationMessages();
        public ValidationMessages ValidationMessages { get { return _validationMessages; } }

        public bool IsValid
        {
            get { return ValidationMessages.Count == 0; }
        }

        /// <summary>
        /// Throws an exception if IsValid is false.
        /// </summary>
        public void Verify()
        {
            if (ValidationMessages.Count > 0)
            {
                throw new Exception(ValidationMessages[0].Text);
            }
        }

        /// <summary> 
        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
        /// </summary>
        protected void Execute(IValidator validator)
        {
            Execute(validator, null);
        }

        /// <summary>
        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
        /// </summary>
        /// <param name="messagePrefix"> 
        /// A message prefix can identify the parent object so that validation messages indicate 
        /// what specific part of the object structure they are about. 
        /// </param>
        public void Execute(IValidator validator, string messagePrefix)
        {
            if (validator == null) throw new NullException(() => validator);

            foreach (ValidationMessage validationMessage in validator.ValidationMessages)
            {
                ValidationMessages.Add(validationMessage.PropertyKey, messagePrefix + validationMessage.Text);
            }
        }
    }
}
