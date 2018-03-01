namespace JJ.Framework.Exceptions
{
	public class NotUniqueException<TObject> : NotUniqueException
	{
		private const string MESSAGE_TEMPLATE = "{0} with key '{1}' not unique.";

		public NotUniqueException(object key)
			: base(string.Format(MESSAGE_TEMPLATE, typeof(TObject).Name, key))
		{ }
	}
}
