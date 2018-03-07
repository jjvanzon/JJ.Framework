namespace JJ.Framework.Exceptions.Aggregates
{
	/// <inheritdoc />
	public class NotFoundException<TObject> : NotFoundException
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
		public NotFoundException() : base(typeof(TObject)) { }

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
		public NotFoundException(object key) : base(typeof(TObject), key) { }
	}
}