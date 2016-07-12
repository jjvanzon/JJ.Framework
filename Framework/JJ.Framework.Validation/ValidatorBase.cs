using JJ.Framework.Reflection.Exceptions;
using System;
using System.Linq;

namespace JJ.Framework.Validation
{
    public abstract class ValidatorBase<TRootObject> : IValidator
    {
        /// <param name="postponeExecute">
        /// When set to true, you can do initializations in your constructor
        /// before Execute goes off. Then you have to call Execute from your own constructor.
        /// </param>
        public ValidatorBase(TRootObject obj, bool postponeExecute = false)
        {
            Object = obj;

            if (!postponeExecute)
            {
                Execute();
            }
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
        public void Assert()
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
        protected void Execute(IValidator validator)
        {
            Execute(validator, null);
        }

        /// <summary> 
        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
        /// This overload only works when the sub-validator takes the same object as the parent validator,
        /// and if the sub-validator has no additional constructor parameters.
        /// </summary>
        protected void Execute(Type validatorType)
        {
            Execute(validatorType, null);
        }

        /// <summary> 
        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
        /// This overload only works when the sub-validator takes the same object as the parent validator,
        /// and if the sub-validator has no additional constructor parameters.
        /// </summary>
        protected void Execute(Type validatorType, string messagePrefix)
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
