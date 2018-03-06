namespace JJ.Framework.Exceptions.TypeChecking
{
	public class IsEnumTypeException<T> : IsEnumTypeException
	{
		public IsEnumTypeException()
			: base(typeof(T))
		{ }
	}
}
