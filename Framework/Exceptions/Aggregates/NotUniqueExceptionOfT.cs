namespace JJ.Framework.Exceptions.Aggregates
{
	public class NotUniqueException<TObject> : NotUniqueException
	{
		/// <inheritdoc />
		public NotUniqueException() : base(typeof(TObject)) { }

		/// <inheritdoc />
		public NotUniqueException(object key) : base(typeof(TObject), key) { }
	}
}