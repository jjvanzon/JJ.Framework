namespace JJ.Framework.Exceptions.Aggregates
{
	public class NotUniqueException<TObject> : NotUniqueException
	{
		public NotUniqueException() : base(typeof(TObject)) { }
		public NotUniqueException(object key) : base(typeof(TObject), key) { }
	}
}