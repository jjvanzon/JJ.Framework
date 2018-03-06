using JJ.Framework.Exceptions;
using System;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Validation
{
	public abstract class ValidatorBase : IValidator
	{
		public ValidationMessages Messages { get; } = new ValidationMessages();

		public bool IsValid => Messages.Count == 0;

		/// <summary> Throws an exception if IsValid is false. </summary>
		public void Assert()
		{
			// ReSharper disable once InvertIf
			if (Messages.Count > 0)
			{
				string formattedMessages = string.Join(Environment.NewLine, Messages);
				throw new Exception(formattedMessages);
			}
		}

		/// <summary> 
		/// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
		/// </summary>
		protected void ExecuteValidator(IValidator validator) => ExecuteValidator(validator, null);

		/// <summary>
		/// Executes a sub-validator and combines the results with the validation messages of the parent validator. 
		/// </summary>
		/// <param name="messagePrefix"> 
		/// A message prefix can identify the parent object so that validation messages indicate 
		/// what specific part of the object structure they are about. 
		/// </param>
		public void ExecuteValidator(IValidator validator, string messagePrefix)
		{
			if (validator == null) throw new NullException(() => validator);

			foreach (string validationMessage in validator.Messages)
			{
				Messages.Add(messagePrefix + validationMessage);
			}
		}
	}
}
