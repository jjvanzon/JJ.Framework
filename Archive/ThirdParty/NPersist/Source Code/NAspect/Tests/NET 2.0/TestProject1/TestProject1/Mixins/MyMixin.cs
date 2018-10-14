namespace KumoUnitTests
{
	public class SayHelloMixin : ISayHello
	{
		public SayHelloMixin()
		{
		}

		#region ISayHello Members

		public string SayHello()
		{
			return "Hello";
		}

		#endregion
	}

	public interface ISayHello
	{
		string SayHello();
	}
}