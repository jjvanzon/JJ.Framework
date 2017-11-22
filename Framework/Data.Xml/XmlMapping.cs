namespace JJ.Framework.Data.Xml
{
	public abstract class XmlMapping<TEntity> : IXmlMapping
	{
		public XmlMapping()
		{
			ElementName = "x";
		}

		public IdentityType IdentityType { get; protected set; }
		public string IdentityPropertyName { get; protected set; }
		public string ElementName { get; protected set; }
	}
}
