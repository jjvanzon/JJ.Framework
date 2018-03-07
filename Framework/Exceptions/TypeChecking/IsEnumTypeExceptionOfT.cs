namespace JJ.Framework.Exceptions.TypeChecking
{
	public class IsEnumTypeException<T> : IsEnumTypeException
	{
		/// <summary>
		/// throw new IsEnumTypeException&lt;Customer&gt;();
		/// will have message: "Type Customer cannot be an enum."
		/// </summary>
		public IsEnumTypeException()
			: base(typeof(T))
		{ }
	}
}
