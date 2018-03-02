namespace JJ.Framework.Exceptions
{
	public class NotEnumTypeException<T> : NotEnumTypeException
	{
		public NotEnumTypeException()
			: base(typeof(T))
		{ }
	}
}
