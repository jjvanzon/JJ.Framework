namespace JJ.Framework.Exceptions
{
	public class IsEnumExceptionOfT<T> : IsEnumException
	{
		public IsEnumExceptionOfT()
			: base(typeof(T))
		{ }
	}
}
