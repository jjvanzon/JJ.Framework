namespace JJ.Framework.Exceptions
{
	public class IsEnumTypeException<T> : IsEnumTypeException
	{
		public IsEnumTypeException()
			: base(typeof(T))
		{ }
	}
}
