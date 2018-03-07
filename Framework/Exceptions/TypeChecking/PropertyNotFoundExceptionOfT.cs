namespace JJ.Framework.Exceptions.TypeChecking
{
	public class PropertyNotFoundException<T> : PropertyNotFoundException
	{
		/// <summary>
		/// These will both have message: "Property 'ProductNumber' not found on type 'MyNameSpace.Customer'."
		/// throw new PropertyNotFoundException&lt;Customer&gt;("ProductNumber");
		/// throw new PropertyNotFoundException(typeof(Customer), "ProductNumber");
		/// </summary>
		public PropertyNotFoundException(string propertyName)
			: base(typeof(T), propertyName)
		{ }
	}
}