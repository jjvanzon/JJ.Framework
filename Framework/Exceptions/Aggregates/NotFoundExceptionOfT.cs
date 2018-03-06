namespace JJ.Framework.Exceptions.Aggregates
{
	public class NotFoundException<TObject> : NotFoundException
	{
		/// <inheritdoc />
		public NotFoundException() : base(typeof(TObject)) { }

		/// <inheritdoc />
		public NotFoundException(object key) : base(typeof(TObject), key) { }
	}
}