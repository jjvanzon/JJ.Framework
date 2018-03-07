using System;

namespace JJ.Framework.Exceptions.TypeChecking
{
	public class TypeNotFoundException : Exception
	{
		/// <summary>
		/// throw new TypeNotFoundException("MyNamespace.Customer")
		/// will have message: "Type 'MyNamespace.Customer' not found."
		/// </summary>
		public TypeNotFoundException(string typeName)
			: base($"Type '{typeName}' not found.")
		{ }
	}
}
