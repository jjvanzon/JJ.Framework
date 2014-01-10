using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary> Executes a sub-validator and combines the results with the validation messages of the parent validator. </summary>
        /// <param name="propertyKeyPrefix">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// </param>
        /// <param name="propertyKeyPrefixExpression">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// This overload takes a strongly-typed expression as opposed to a string e.g. () => MyObject.MyProperty
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        /// <param name="messagePrefix"> A message prefix can identify the parent object so that validation messages indicate what specific part of the object structure they are about. </param>
        protected void Execute(IValidator validator)
        {
            Execute(validator, (string)null, null);
        }

        /// <summary> Executes a sub-validator and combines the results with the validation messages of the parent validator. </summary>
        /// <param name="propertyKeyPrefix">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// </param>
        /// <param name="propertyKeyPrefixExpression">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// This overload takes a strongly-typed expression as opposed to a string e.g. () => MyObject.MyProperty
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        /// <param name="messagePrefix"> A message prefix can identify the parent object so that validation messages indicate what specific part of the object structure they are about. </param>
        protected void Execute(IValidator validator, string messagePrefix)
        {
            Execute(validator, (string)null, messagePrefix);
        }

        /// <summary> Executes a sub-validator and combines the results with the validation messages of the parent validator. </summary>
        /// <param name="propertyKeyPrefix">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// </param>
        /// <param name="propertyKeyPrefixExpression">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// This overload takes a strongly-typed expression as opposed to a string e.g. () => MyObject.MyProperty
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        /// <param name="messagePrefix"> A message prefix can identify the parent object so that validation messages indicate what specific part of the object structure they are about. </param>
        protected void Execute(IValidator validator, Expression<Func<object>> propertyKeyPrefixExpression)
        {
            Execute(validator, propertyKeyPrefixExpression, null);
        }

        /// <summary> Executes a sub-validator and combines the results with the validation messages of the parent validator. </summary>
        /// <param name="propertyKeyPrefix">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// </param>
        /// <param name="propertyKeyPrefixExpression">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// This overload takes a strongly-typed expression as opposed to a string e.g. () => MyObject.MyProperty
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        /// <param name="messagePrefix"> A message prefix can identify the parent object so that validation messages indicate what specific part of the object structure they are about. </param>
        protected void Execute(IValidator validator, Expression<Func<object>> propertyKeyPrefixExpression, string messagePrefix)
        {
            string propertyKeyPrefix = propertyKeyPrefixExpression != null ? ExpressionHelper.GetString(propertyKeyPrefixExpression, true) : null;

            // Always cut off the root object, e.g. "MyObject.MyProperty" becomes "MyProperty".
            propertyKeyPrefix = propertyKeyPrefix.CutLeftUntil(".").CutLeft(".") ;

            // Add a period to the prefix e.g. "MyProperty."
            propertyKeyPrefix += ".";

            Execute(validator, propertyKeyPrefix, messagePrefix);
        }

        /// <summary> Executes a sub-validator and combines the results with the validation messages of the parent validator. </summary>
        /// <param name="propertyKeyPrefix">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// </param>
        /// <param name="propertyKeyPrefixExpression">
        /// A key prefix can be supplied to indicate the parent object, so that a property can be mapped to a specific part of the object structure.
        /// This can be used to e.g. to make MVC display validation messages next to a specific html input element.
        /// This overload takes a strongly-typed expression as opposed to a string e.g. () => MyObject.MyProperty
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        /// <param name="messagePrefix"> A message prefix can identify the parent object so that validation messages indicate what specific part of the object structure they are about. </param>
        public void Execute(IValidator validator, string propertyKeyPrefix, string messagePrefix)
        {
            if (validator == null) { throw new ArgumentNullException("validator"); }

            foreach (ValidationMessage validationMessage in validator.ValidationMessages)
            {
                ValidationMessages.Add(propertyKeyPrefix + validationMessage.PropertyKey, messagePrefix + validationMessage.Text);
            }
        }
    }
}
