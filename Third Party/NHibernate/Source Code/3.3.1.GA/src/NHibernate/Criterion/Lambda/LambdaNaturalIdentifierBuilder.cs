namespace NHibernate.Criterion.Lambda
{

	public class LambdaNaturalIdentifierBuilder
	{
		private readonly NaturalIdentifier naturalIdentifier;
		private readonly string propertyName;

		public LambdaNaturalIdentifierBuilder(NaturalIdentifier naturalIdentifier, string propertyName)
		{
			this.naturalIdentifier = naturalIdentifier;
			this.propertyName = propertyName;
		}

		public NaturalIdentifier Is(object value)
		{
			return naturalIdentifier.Set(propertyName, value);
		}

	}

}
