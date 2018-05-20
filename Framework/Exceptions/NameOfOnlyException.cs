using System;
using JetBrains.Annotations;

namespace JJ.Framework.Exceptions
{
	/// <summary>
	/// For when you want a member only to be used with the nameof operator,
	/// you can throw this exception in its implementation.
	/// </summary>
	[PublicAPI]
	public class NameOfOnlyException : Exception
	{
		public NameOfOnlyException() : base("Usage: nameof(MyClass.MyMember)") { }
	}
}