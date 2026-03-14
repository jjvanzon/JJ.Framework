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
        /// <inheritdoc cref="_postponeexecute" />
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

        /// <inheritdoc cref="_validationmessages" />
        public ValidationMessages ValidationMessages { get { return _validationMessages; } }

        /// <inheritdoc cref="_isvalid" />
        public bool IsValid
        {
            get { return ValidationMessages.Count == 0; }
        }

        /// <inheritdoc cref="_verify" />
        public void Verify()
        {
            if (ValidationMessages.Count > 0)
            {
                string formattedMessages = String.Join(Environment.NewLine, ValidationMessages.Select(x => x.Text).ToArray());
                throw new Exception(formattedMessages);
            }
        }

        /// <inheritdoc cref="_executesub" />
        protected void Execute(IValidator validator)
        {
            Execute(validator, null);
        }

        /// <inheritdoc cref="_executesub" />
        protected void Execute<[Dyn(PublicCtors)] TValidator>()
            where TValidator : ValidatorBase<TRootObject>
        {
            Execute(typeof(TValidator), null);
        }

        /// <inheritdoc cref="_executesub" />
        protected void Execute<[Dyn(PublicCtors)] TValidator>(string messagePrefix)
            where TValidator : ValidatorBase<TRootObject>
        {
            Execute(typeof(TValidator), messagePrefix);
        }
        /// <inheritdoc cref="_executesub" />
        protected void Execute([Dyn(PublicCtors)] Type validatorType)
        {
            Execute(validatorType, null);
        }

        /// <inheritdoc cref="_executesub" />
        protected void Execute([Dyn(PublicCtors)] Type validatorType, string messagePrefix)
        {
            IValidator validator = (IValidator)Activator.CreateInstance(validatorType, new object[] { Object });
            Execute(validator, messagePrefix);
        }

        /// <inheritdoc cref="_executesub" />
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
