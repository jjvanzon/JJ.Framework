namespace JJ.Framework.Exceptions.TypeChecking
{
	public class PropertyNotFoundException<T> : PropertyNotFoundException
	{
		public PropertyNotFoundException(string propertyName)
			: base(typeof(T), propertyName)
		{ }
	}
}