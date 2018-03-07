namespace JJ.Framework.Exceptions.TypeChecking
{
	public class NotEnumTypeException<T> : NotEnumTypeException
	{
		/// <summary>
		/// throw new NotEnumTypeException&lt;Customer&gt;();
		/// will have message: "Type Customer is not an enum."
		/// </summary>
		public NotEnumTypeException()
			: base(typeof(T))
		{ }
	}
}
