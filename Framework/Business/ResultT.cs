namespace JJ.Framework.Business
{
	public class Result<T> : ResultBase
	{
		public Result() { }
		public Result(params string[] messages) : base(messages) { }

		public T Data { get; set; }
	}
}
