namespace JJ.Framework.Common.Exceptions
{
    public class PropertyNotFoundException<T> : PropertyNotFoundException
    {
        public PropertyNotFoundException(string propertyName)
            : base(typeof(T), propertyName)
        { }
    }
}