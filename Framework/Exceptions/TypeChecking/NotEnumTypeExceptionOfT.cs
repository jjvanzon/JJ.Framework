namespace JJ.Framework.Exceptions.TypeChecking
{
	public class NotEnumTypeException<T> : NotEnumTypeException
	{
		public NotEnumTypeException()
			: base(typeof(T))
		{ }
	}
}
