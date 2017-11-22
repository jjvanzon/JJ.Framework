namespace JJ.Framework.Soap
{
	public class SoapParameter
	{
		public SoapParameter(string name, object value)
		{
			Name = name;
			Value = value;
		}

		public string Name { get; }
		public object Value { get; }
	}
}
