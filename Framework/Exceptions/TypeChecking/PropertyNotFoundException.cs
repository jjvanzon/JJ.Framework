using System;

namespace JJ.Framework.Exceptions.TypeChecking
{
	public class PropertyNotFoundException : Exception
	{
		/// <summary>
		/// These will both have message: "Property 'ProductNumber' not found on type 'MyNameSpace.Customer'."
		/// throw new PropertyNotFoundException&lt;Customer&gt;("ProductNumber");
		/// throw new PropertyNotFoundException(typeof(Customer), "ProductNumber");
		/// </summary>
		public PropertyNotFoundException(Type type, string propertyName)
		{
			string typeName = ExceptionHelper.TryFormatFullTypeName(type);

			Message = $"Property '{propertyName}' not found on type '{typeName}'.";
		}

		public override string Message { get; }
	}
}