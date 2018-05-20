using System;
using System.Linq.Expressions;

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions.Aggregates
{
	/// <summary>
	/// throw new NotFoundException&lt;Customer&gt;(10);
	/// will have message: "Customer with key 10 not found."
	/// throw new NotFoundException&lt;User&gt;();
	/// will have message: "User not found."
	/// throw new NotUniqueException(typeof(Product), () => productNumber);
	/// will have message: "Product with productNumber 123 not unique."
	///
	/// throw new NotFoundException(() => item.Parent);
	/// will have message: "item.Parent not found."
	/// throw new NotUniqueException(new { customerNumber, customerType });
	/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not unique."
	/// throw new NotFoundException(10);
	/// will have message: "10 not found."
	/// throw new NotUniqueException(nameof(value));
	/// will have message: "value not unique."
	/// 
	/// throw new NotUniqueException(() => item.MyProperty, 10);
	/// will have message: "item.MyProperty with key 10 not unique."
	/// throw new NotUniqueException(nameof(customer), new { customerNumber, customerType });
	/// will have message: "customer with key { customerNumber = 1234, customerType = Subscriber } not unique."
	/// </summary>
	public abstract class ExceptionWithNameTypeAndKeyBase : Exception
	{
		protected abstract string MessageWithName { get; }
		protected abstract string MessageWithNameAndKey { get; }

		/// <summary>
		/// throw new NotFoundException&lt;Customer&gt;(10);
		/// will have message: "Customer with key 10 not found."
		/// throw new NotFoundException&lt;User&gt;();
		/// will have message: "User not found."
		/// throw new NotUniqueException(typeof(Product), () => productNumber);
		/// will have message: "Product with productNumber 123 not unique."
		///
		/// throw new NotFoundException(() => item.Parent);
		/// will have message: "item.Parent not found."
		/// throw new NotUniqueException(new { customerNumber, customerType });
		/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not unique."
		/// throw new NotFoundException(10);
		/// will have message: "10 not found."
		/// throw new NotUniqueException(nameof(value));
		/// will have message: "value not unique."
		/// 
		/// throw new NotUniqueException(() => item.MyProperty, 10);
		/// will have message: "item.MyProperty with key 10 not unique."
		/// throw new NotUniqueException(nameof(customer), new { customerNumber, customerType });
		/// will have message: "customer with key { customerNumber = 1234, customerType = Subscriber } not unique."
		/// </summary>
		public ExceptionWithNameTypeAndKeyBase(Expression<Func<object>> expression)
		{
			string text = ExceptionHelper.GetTextWithValue(expression);
			Message = string.Format(MessageWithName, text);
		}

		/// <summary>
		/// throw new NotFoundException&lt;Customer&gt;(10);
		/// will have message: "Customer with key 10 not found."
		/// throw new NotFoundException&lt;User&gt;();
		/// will have message: "User not found."
		/// throw new NotUniqueException(typeof(Product), () => productNumber);
		/// will have message: "Product with productNumber 123 not unique."
		///
		/// throw new NotFoundException(() => item.Parent);
		/// will have message: "item.Parent not found."
		/// throw new NotUniqueException(new { customerNumber, customerType });
		/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not unique."
		/// throw new NotFoundException(10);
		/// will have message: "10 not found."
		/// throw new NotUniqueException(nameof(value));
		/// will have message: "value not unique."
		/// 
		/// throw new NotUniqueException(() => item.MyProperty, 10);
		/// will have message: "item.MyProperty with key 10 not unique."
		/// throw new NotUniqueException(nameof(customer), new { customerNumber, customerType });
		/// will have message: "customer with key { customerNumber = 1234, customerType = Subscriber } not unique."
		/// </summary>
		public ExceptionWithNameTypeAndKeyBase(Expression<Func<object>> expression, object key)
		{
			string text = ExceptionHelper.GetTextWithValue(expression);
			Message = string.Format(MessageWithNameAndKey, text, key);
		}

		/// <summary>
		/// throw new NotFoundException&lt;Customer&gt;(10);
		/// will have message: "Customer with key 10 not found."
		/// throw new NotFoundException&lt;User&gt;();
		/// will have message: "User not found."
		/// throw new NotUniqueException(typeof(Product), () => productNumber);
		/// will have message: "Product with productNumber 123 not unique."
		///
		/// throw new NotFoundException(() => item.Parent);
		/// will have message: "item.Parent not found."
		/// throw new NotUniqueException(new { customerNumber, customerType });
		/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not unique."
		/// throw new NotFoundException(10);
		/// will have message: "10 not found."
		/// throw new NotUniqueException(nameof(value));
		/// will have message: "value not unique."
		/// 
		/// throw new NotUniqueException(() => item.MyProperty, 10);
		/// will have message: "item.MyProperty with key 10 not unique."
		/// throw new NotUniqueException(nameof(customer), new { customerNumber, customerType });
		/// will have message: "customer with key { customerNumber = 1234, customerType = Subscriber } not unique."
		/// </summary>
		public ExceptionWithNameTypeAndKeyBase(Type type)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			Message = string.Format(MessageWithName, typeName);
		}

		/// <summary>
		/// throw new NotFoundException&lt;Customer&gt;(10);
		/// will have message: "Customer with key 10 not found."
		/// throw new NotFoundException&lt;User&gt;();
		/// will have message: "User not found."
		/// throw new NotUniqueException(typeof(Product), () => productNumber);
		/// will have message: "Product with productNumber 123 not unique."
		///
		/// throw new NotFoundException(() => item.Parent);
		/// will have message: "item.Parent not found."
		/// throw new NotUniqueException(new { customerNumber, customerType });
		/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not unique."
		/// throw new NotFoundException(10);
		/// will have message: "10 not found."
		/// throw new NotUniqueException(nameof(value));
		/// will have message: "value not unique."
		/// 
		/// throw new NotUniqueException(() => item.MyProperty, 10);
		/// will have message: "item.MyProperty with key 10 not unique."
		/// throw new NotUniqueException(nameof(customer), new { customerNumber, customerType });
		/// will have message: "customer with key { customerNumber = 1234, customerType = Subscriber } not unique."
		/// </summary>
		public ExceptionWithNameTypeAndKeyBase(Type type, object key)
		{
			string typeName = ExceptionHelper.TryFormatShortTypeName(type);
			Message = string.Format(MessageWithNameAndKey, typeName, key);
		}

		/// <summary>
		/// throw new NotFoundException&lt;Customer&gt;(10);
		/// will have message: "Customer with key 10 not found."
		/// throw new NotFoundException&lt;User&gt;();
		/// will have message: "User not found."
		/// throw new NotUniqueException(typeof(Product), () => productNumber);
		/// will have message: "Product with productNumber 123 not unique."
		///
		/// throw new NotFoundException(() => item.Parent);
		/// will have message: "item.Parent not found."
		/// throw new NotUniqueException(new { customerNumber, customerType });
		/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not unique."
		/// throw new NotFoundException(10);
		/// will have message: "10 not found."
		/// throw new NotUniqueException(nameof(value));
		/// will have message: "value not unique."
		/// 
		/// throw new NotUniqueException(() => item.MyProperty, 10);
		/// will have message: "item.MyProperty with key 10 not unique."
		/// throw new NotUniqueException(nameof(customer), new { customerNumber, customerType });
		/// will have message: "customer with key { customerNumber = 1234, customerType = Subscriber } not unique."
		/// </summary>
		public ExceptionWithNameTypeAndKeyBase(object indicator) => Message = string.Format(MessageWithName, indicator);

		/// <summary>
		/// throw new NotFoundException&lt;Customer&gt;(10);
		/// will have message: "Customer with key 10 not found."
		/// throw new NotFoundException&lt;User&gt;();
		/// will have message: "User not found."
		/// throw new NotUniqueException(typeof(Product), () => productNumber);
		/// will have message: "Product with productNumber 123 not unique."
		///
		/// throw new NotFoundException(() => item.Parent);
		/// will have message: "item.Parent not found."
		/// throw new NotUniqueException(new { customerNumber, customerType });
		/// will have message: "{ customerNumber = 1234, customerType = Subscriber } not unique."
		/// throw new NotFoundException(10);
		/// will have message: "10 not found."
		/// throw new NotUniqueException(nameof(value));
		/// will have message: "value not unique."
		/// 
		/// throw new NotUniqueException(() => item.MyProperty, 10);
		/// will have message: "item.MyProperty with key 10 not unique."
		/// throw new NotUniqueException(nameof(customer), new { customerNumber, customerType });
		/// will have message: "customer with key { customerNumber = 1234, customerType = Subscriber } not unique."
		/// </summary>
		public ExceptionWithNameTypeAndKeyBase(string name, object key) => Message = string.Format(MessageWithNameAndKey, name, key);

		public override string Message { get; }
	}
}