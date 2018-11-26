namespace NHibernate.ByteCode.Castle.Tests.ProxyInterface
{
	/// <summary>
	/// Summary description for CastleProxy.
	/// </summary>
	public interface CastleProxy
	{
		int Id { get; set; }

		string Name { get; set; }

		void ThrowDeepException();
	}
}