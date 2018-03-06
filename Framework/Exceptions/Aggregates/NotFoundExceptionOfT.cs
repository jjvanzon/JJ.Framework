namespace JJ.Framework.Exceptions.Aggregates
{
	public class NotFoundException<TObject> : NotFoundException
	{
		public NotFoundException() : base(typeof(TObject)) { }
		public NotFoundException(object key) : base(typeof(TObject), key) { }
	}
}