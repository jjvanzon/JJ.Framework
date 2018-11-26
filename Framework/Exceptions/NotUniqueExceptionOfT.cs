﻿namespace JJ.Framework.Exceptions
{
	public class NotUniqueException<TObject> : NotUniqueException
	{
		private const string MESSAGE = "{0} with key '{1}' not unique.";

		public NotUniqueException(object key)
			: base(string.Format(MESSAGE, typeof(TObject).Name, key))
		{ }
	}
}
