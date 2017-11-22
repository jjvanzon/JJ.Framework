namespace JJ.Framework.Business
{
	public class VoidResult : ResultBase
	{
		public VoidResult() { }
		public VoidResult(params string[] messages) : base(messages) { }
	}
}