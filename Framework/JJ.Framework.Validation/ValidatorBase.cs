using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JJ.Framework.Common;

namespace JJ.Framework.Validation.Legacy
{
    /// <inheritdoc cref="_validatorbase" />
    public abstract class ValidatorBase<TRootObject> : IValidator
    {
        /// <inheritdoc cref="_validatorbase" />
        public ValidatorBase(TRootObject obj, bool postponeExecute = false)
        {
            Object = obj;

            if (!postponeExecute)
            {
                Execute();
            }
        }

        /// <inheritdoc cref="_rootobject" />
        public TRootObject Object { get; private set; }

        /// <inheritdoc cref="_execute" />
        protected abstract void Execute();

        /// <inheritdoc cref="_validationmessages" />
        private readonly ValidationMessages _validationMessages = new ValidationMessages();

        /// <inheritdoc />
        public ValidationMessages ValidationMessages { get { return _validationMessages; } }

        /// <inheritdoc />
        public bool IsValid
        {
            get { return ValidationMessages.Count == 0; }
        }

        /// <inheritdoc />
        public void Verify()
        {
            if (ValidationMessages.Count > 0)
            {
                string formattedMessages = String.Join(Environment.NewLine, ValidationMessages.Select(x => x.Text).ToArray());
                throw new Exception(formattedMessages);
            }
        }

        /// <summary> 
        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
        /// </summary>
        /// <inheritdoc cref="_executeivalidator" />
        protected void Execute(IValidator validator)
        {
            Execute(validator, null);
        }

        /// <inheritdoc cref="_executetvalidator" />
        protected void Execute<[Dyn(PublicCtors)] TValidator>()
            where TValidator : ValidatorBase<TRootObject>
        {
            Execute(typeof(TValidator), null);
        }

        /// <inheritdoc cref="_executetvalidatorwithprefix" />
        protected void Execute<[Dyn(PublicCtors)] TValidator>(string messagePrefix)
            where TValidator : ValidatorBase<TRootObject>
        {
            Execute(typeof(TValidator), messagePrefix);
        }

        /// <inheritdoc cref="_executevalidatortype" />
        protected void Execute([Dyn(PublicCtors)] Type validatorType)
        {
            Execute(validatorType, null);
        }

        /// <inheritdoc cref="_executevalidatortypewithprefix" />
        protected void Execute([Dyn(PublicCtors)] Type validatorType, string messagePrefix)
        {
            IValidator validator = (IValidator)Activator.CreateInstance(validatorType, new object[] { Object });
            Execute(validator, messagePrefix);
        }

        /// <summary>
        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
        /// </summary>
        /// <param name="messagePrefix"> 
        /// A message prefix can identify the parent object so that validation messages indicate 
        /// what specific part of the object structure they are about. 
        /// </param>
        /// <inheritdoc cref="_executeivalidatorwithprefix" />
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
