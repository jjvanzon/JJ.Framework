namespace JJ.Framework.Exceptions
{
	public class NotFoundException<TObject> : NotFoundException
	{
		public NotFoundException() : base(typeof(TObject)) { }
		public NotFoundException(object key) : base(typeof(TObject), key) { }
	}
}