//using JJ.Framework.Exceptions;
//using System;
//using System.Linq;
//using JetBrains.Annotations;

//namespace JJ.Framework.Validation
//{
//    public abstract class ValidatorBase_WithoutConstructorArgumentNullCheck : IValidator
//    {
//        [NotNull]
//        public ValidationMessages ValidationMessages { get; } = new ValidationMessages();

//        public bool IsValid => ValidationMessages.Count == 0;

//        /// <summary>
//        /// Throws an exception if IsValid is false.
//        /// </summary>
//        public void Assert()
//        {
//            // ReSharper disable once InvertIf
//            if (ValidationMessages.Count > 0)
//            {
//                string formattedMessages = string.Join(Environment.NewLine, ValidationMessages.Select(x => x.Text).ToArray());
//                throw new Exception(formattedMessages);
//            }
//        }

//        /// <summary> 
//        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
//        /// </summary>
//        protected void ExecuteValidator(IValidator validator) => ExecuteValidator(validator, null);

//        /// <summary>
//        /// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
//        /// </summary>
//        /// <param name="messagePrefix"> 
//        /// A message prefix can identify the parent object so that validation messages indicate 
//        /// what specific part of the object structure they are about. 
//        /// </param>
//        public void ExecuteValidator([NotNull] IValidator validator, string messagePrefix)
//        {
//            if (validator == null) throw new NullException(() => validator);

//            foreach (ValidationMessage validationMessage in validator.ValidationMessages)
//            {
//                ValidationMessages.Add(validationMessage.Key, messagePrefix + validationMessage.Text);
//            }
//        }
//    }
//}
