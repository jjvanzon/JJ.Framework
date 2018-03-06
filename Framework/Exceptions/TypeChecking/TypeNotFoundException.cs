using System;

namespace JJ.Framework.Exceptions.TypeChecking
{
	public class TypeNotFoundException : Exception
	{
		public TypeNotFoundException(string typeName)
			: base($"Type '{typeName}' not found.")
		{ }
	}
}
